/*===============================================================================
Copyright (c) 2016 PTC Inc. All Rights Reserved.

Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SamplesMainMenu : MonoBehaviour
{

	#region PUBLIC_MEMBERS

    public enum MenuItem
    {
        ImageTargets = 0,
        VuMark = 1,
        CylinderTargets = 2,
        MultiTargets = 3,
        UserDefinedTargets = 4,
        ObjectReco = 5,
        CloudReco = 6,
        TextReco = 7,
        FrameMarkers = 8,
        VirtualButtons = 9,
        SmartTerrain = 10
    }

    public Canvas AboutCanvas;
    public Text AboutTitle;
    public Text AboutDescription;

    public static bool isAboutScreenVisible = false;

    // initialize static enum with one of the items
    public static MenuItem menuItem = MenuItem.ImageTargets;

    public const string MenuScene = "Vuforia-1-Menu";
    public const string LoadingScene = "Vuforia-2-Loading";

    SamplesAboutScreenInfo aboutScreenInfo;

	#endregion // PUBLIC_MEMBERS

    void Start()
    {
        // about screen is hidden when scene reloaded
        // set about screen state to false for nav handler
        isAboutScreenVisible = false;

        if (aboutScreenInfo == null)
        {
            // initialize if null
            aboutScreenInfo = new SamplesAboutScreenInfo();
        }
    }

	#region PUBLIC_METHODS

    public static string GetSceneToLoad()
    {
        return "Vuforia-3-" + SamplesMainMenu.menuItem.ToString();
    }

    public static void LoadScene(string scene)
    {
        #if (UNITY_5_2 || UNITY_5_1 || UNITY_5_0)
        Application.LoadLevel(scene);
        #else // UNITY_5_3 or above
		UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        #endif
    }

    public void LoadAboutScene(string itemSelected)
    {
        // This method called from list of Sample App menu buttons
        switch (itemSelected)
        {

        case("ImageTargets"):
            SamplesMainMenu.menuItem = SamplesMainMenu.MenuItem.ImageTargets;
            break;
        case("VuMark"):
            SamplesMainMenu.menuItem = SamplesMainMenu.MenuItem.VuMark;
            break;
        case("CylinderTargets"):
            SamplesMainMenu.menuItem = SamplesMainMenu.MenuItem.CylinderTargets;
            break;
        case("MultiTargets"):
            SamplesMainMenu.menuItem = SamplesMainMenu.MenuItem.MultiTargets;
            break;
        case("UserDefinedTargets"):
            SamplesMainMenu.menuItem = SamplesMainMenu.MenuItem.UserDefinedTargets;
            break;
        case("ObjectReco"):
            SamplesMainMenu.menuItem = SamplesMainMenu.MenuItem.ObjectReco;
            break;
        case("CloudReco"):
            SamplesMainMenu.menuItem = SamplesMainMenu.MenuItem.CloudReco;
            break;
        case("TextReco"):
            SamplesMainMenu.menuItem = SamplesMainMenu.MenuItem.TextReco;
            break;
        case("FrameMarkers"):
            SamplesMainMenu.menuItem = SamplesMainMenu.MenuItem.FrameMarkers;
            break;
        case("VirtualButtons"):
            SamplesMainMenu.menuItem = SamplesMainMenu.MenuItem.VirtualButtons;
            break;
        case("SmartTerrain"):
            SamplesMainMenu.menuItem = SamplesMainMenu.MenuItem.SmartTerrain;
            break;
        }

        AboutTitle.text = aboutScreenInfo.GetTitle(SamplesMainMenu.menuItem.ToString());
        AboutDescription.text = aboutScreenInfo.GetDescription(SamplesMainMenu.menuItem.ToString());

        AboutCanvas.transform.parent.transform.position = Vector3.zero; // move canvas into position
        AboutCanvas.sortingOrder = 1; // bring canvas in front of main menu
        isAboutScreenVisible = true;

    }

	#endregion // PUBLIC_METHODS

}
