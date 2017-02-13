/*===============================================================================
Copyright (c) 2016 PTC Inc. All Rights Reserved.

Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================*/
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Object = UnityEngine.Object;
using Vuforia;

public class VuforiaLicense : EditorWindow
{
    private string licenseKey = "Paste Vuforia License Key here...";
    private const string directions = 
        "Paste the Vuforia License Key into the box below and press " +
        "<b>Apply License Key</b> to assign the key to all scenes that " +
        "have an ARCamera. This will also save those scenes along with " +
        "any unsaved modifications to them.";
    private static string initialOpenScene = "";
    private bool isPlayMode;

    // Add menu item
    [MenuItem("Vuforia/Set Sample App License Key")]
    static void OpenLicenseKeyDialog()
    {
        EditorWindow window = EditorWindow.CreateInstance<VuforiaLicense>();
        window.minSize = new Vector2(320.0f, 260.0f);
        window.Show();
    }

    void OnGUI()
    {
        {
            GUI.skin.label.wordWrap = true;
            GUI.skin.label.richText = true;
            GUILayout.Label(directions, GUI.skin.label);
            
            if (EditorApplication.isPlaying || EditorApplication.isPaused)
            {
                GUILayout.Label("\n<b>STOP:</b> Please exit PlayMode before applying license key.", GUI.skin.label);
                isPlayMode = true;
            }
            else
            {
                isPlayMode = false;
            }

            if (EditorApplication.currentScene.Length == 0)
            {
                GUILayout.Label("\n<b>WARNING:</b> Current scene has not yet been saved.", GUI.skin.label);
            }

            if (EditorApplication.isSceneDirty)
            {
                GUILayout.Label("\n<b>WARNING:</b> Current scene has unsaved modifications.", GUI.skin.label);
            }

            if (GUILayout.Button("Apply License Key") && !isPlayMode)
            {
                SetLicenseKeyFromFromEditorDialog(licenseKey);
            }

            // layout options for text area
            GUILayoutOption[] options = { GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true) };

            EditorStyles.textArea.wordWrap = true;

            licenseKey = EditorGUILayout.TextArea(licenseKey, EditorStyles.textArea, options);
            
            GUILayout.Label("Length: " + licenseKey.Length);
        }
    }

    public static void SetLicenseKeyFromFromEditorDialog(string key)
    {
        SetLicenseKeyInAllScenes(key);
    }
    
    private static void SetLicenseKeyInAllScenes(string licenseKey)
    {
        initialOpenScene = EditorApplication.currentScene;

        List<string> scenes = GetScenesInDirectory("Assets");
        foreach (var scene in scenes)
        {
            if (SetLicenseKeyInScene(scene, licenseKey))
                Debug.Log("Successfully set license key in scene " + scene);
        }

        if (initialOpenScene.Length > 0)
        {
            EditorApplication.OpenScene(initialOpenScene);
        }
    }
    
    private static bool SetLicenseKeyInScene(string sceneName, string licenseKey)
    {
        bool didSetKey = false;
        EditorApplication.OpenScene(sceneName);
        VuforiaAbstractBehaviour[] vuforiaAbstractBehaviours = (VuforiaAbstractBehaviour[])Object.FindObjectsOfType(typeof(VuforiaAbstractBehaviour));
        foreach (var vuforiaAbstractBehaviour in vuforiaAbstractBehaviours)
        {
            // record potential changes for this object
            Undo.RecordObject(vuforiaAbstractBehaviour.gameObject, "Setting License Key");
            
            vuforiaAbstractBehaviour.SetAppLicenseKey(licenseKey);
            EditorUtility.SetDirty(vuforiaAbstractBehaviour);
            didSetKey = true;
        }
        
        if (didSetKey)
            EditorApplication.SaveScene(sceneName);
        
        return didSetKey;
    }
    
    /// <summary>
    /// Returns a list of scene paths in the current Unity project
    /// </summary>
    private static List<string> GetScenesInDirectory(string root)
    {
        List<string> sceneFiles = new List<string>();
        
        string[] files = null;
        string[] subDirs = null;
        
        try
        {
            files = Directory.GetFiles(root);
        }
        catch (UnauthorizedAccessException e)
        {
            Debug.LogWarning(e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.LogWarning(e.Message);
        }
        
        if (files != null)
        {
            foreach (string file in files)
            {
                if (string.Compare(StripExtensionFromPath(file), "unity", true) == 0)
                {
                    sceneFiles.Add(file);
                }
            }
            
            subDirs = Directory.GetDirectories(root);
            
            foreach (string directory in subDirs)
            {
                sceneFiles.AddRange(GetScenesInDirectory(directory));
            }
        }
        
        sceneFiles.Sort();
        
        return sceneFiles;
    }
    
    /// <summary>
    /// returns the extension of a file, given a full path to that file.
    /// </summary>
    private static string StripExtensionFromPath(string fullPath)
    {
        string[] pathParts = fullPath.Split(new char[] { '.' });
        
        // Return empty string if there is no extension.
        if (pathParts.Length <= 1)
        {
            return "";
        }
        
        string extension = pathParts[pathParts.Length - 1];
        
        return extension;
    }
}