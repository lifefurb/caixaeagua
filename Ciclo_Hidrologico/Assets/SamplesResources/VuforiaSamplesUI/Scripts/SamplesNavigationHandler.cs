/*===============================================================================
Copyright (c) 2015-2016 PTC Inc. All Rights Reserved.
 
Copyright (c) 2015 Qualcomm Connected Experiences, Inc. All Rights Reserved.
 
Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================*/
using UnityEngine;
using System.Collections;

public class SamplesNavigationHandler : MonoBehaviour
{
	#region PUBLIC_METHODS

    public void OnStartAR()
    {
        // called by OK button on About screen
        SamplesMainMenu.LoadScene(SamplesMainMenu.LoadingScene);
    }

    public void LoadMenuScene()
    {
        // called by "<" button on About screen
        // called by "Vuforia Samples" button in AR scene UI menu
        SamplesMainMenu.LoadScene(SamplesMainMenu.MenuScene);
    }

	#endregion // PUBLIC_METHODS

	#region MONOBEHAVIOUR_METHODS

    void Update()
    {
        #if (UNITY_EDITOR || UNITY_ANDROID)

        if (Input.GetKeyUp(KeyCode.Escape))
        {

            #if (UNITY_5_2 || UNITY_5_1 || UNITY_5_0)
            string currentSceneName = Application.loadedLevelName;
            #else // UNITY_5_3 or above
			string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            #endif

            Debug.Log("Esc/Back button pressed from " + currentSceneName);

            if (currentSceneName == "Vuforia-1-Menu" && !SamplesMainMenu.isAboutScreenVisible)
            {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #elif UNITY_ANDROID
				// On Android, the Back button is mapped to the Esc key
				Application.Quit();
                #endif
            }
            else
            {
                #if (UNITY_5_2 || UNITY_5_1 || UNITY_5_0)
                Application.LoadLevel(SamplesMainMenu.MenuScene);
                #else // UNITY_5_3 or above
                UnityEngine.SceneManagement.SceneManager.LoadScene(SamplesMainMenu.MenuScene);
                #endif
            }
        }

        if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.JoystickButton0))
        {

            #if (UNITY_5_2 || UNITY_5_1 || UNITY_5_0)
            string currentSceneName = Application.loadedLevelName;
            #else // UNITY_5_3 or above
			string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            #endif

            if (currentSceneName == /*"Vuforia-2-About"*/ "Vuforia-1-Menu" && SamplesMainMenu.isAboutScreenVisible)
            {
                // Treat 'Return' key as pressing the Close button and dismiss the About Screen
                // On ODG R7, JoystickButton0 is the Trackpad select button
                OnStartAR();
            }
        }

        #endif // UNITY_EDITOR || UNITY_ANDROID
    }

	#endregion // MONOBEHAVIOUR_METHODS

}