﻿using System;
using UnityEngine;

[Serializable]
public class QuestionFromJson {
    
    public ResponseToQuestionnaire m_Questionnaire;

    public QuestionFromJson() { }

    public static QuestionFromJson CreateQuestionnaireFromJson() {
        string assets = PlayerPrefs.GetString("Questionnaire");
        return JsonUtility.FromJson<QuestionFromJson>(assets);
    }
    
    public static void LoadPlayerPrefs() {
        string test = PlayerPrefs.GetString("Questionnaire", "");
        if (test == "") {
            string json = Resources.Load("QuestionnaireJson").ToString();
            PlayerPrefs.SetString("Questionnaire", json);
        }
    }
}
