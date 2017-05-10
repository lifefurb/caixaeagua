using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSingleTon : MonoBehaviour {

    // Public field, set in the inspector we can access
    // the audio clip through the singleton instance
    public NewQuestion[] questions;

    // Static singleton property
    public static QuestionSingleTon Instance { get; private set; }

    void Awake()
    {
        // First we check if there are any other instances conflicting
        if (Instance != null && Instance != this)
        {
            // If that is the case, we destroy other instances
            Destroy(gameObject);
        }

        // Here we save our singleton instance
        Instance = this;

        // Furthermore we make sure that we don't destroy between scenes (this is optional)
        DontDestroyOnLoad(gameObject);
    }

    // Instance method, this method can be accesed through the singleton instance
    public void CreateQuestions()
    {
        
    }
}
