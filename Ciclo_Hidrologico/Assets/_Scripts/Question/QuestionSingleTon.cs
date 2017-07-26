﻿using System.Collections.Generic;
using UnityEngine;

public enum Difficulty {
    EASY, NORMAL, HARD
}

public class QuestionSingleTon : MonoBehaviour {
    
    public List<Question> m_Questions;
    public ResponseToQuestionnaire m_Questionnaire;
    public int m_QuestionsAmount;
    public Difficulty m_Difficulty = Difficulty.NORMAL;

    private QuestionFromJson mJsonQuestions;
    private static QuestionSingleTon mInstance;

    public static QuestionSingleTon Instance {
        get {
            if (mInstance == null) {
                mInstance = FindObjectOfType<QuestionSingleTon>();
            }
            return mInstance;
        }
    }

    void Awake() {
        /*
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        */

        QuestionFromJson.LoadPlayerPrefs();
        PopulateQuestionsFromQuestionnaireJson();

        DontDestroyOnLoad(gameObject);
    }

    //Preenche a lista m_Questions com as perguntas do vetor questions do objeto m_Questionnaire
    public void PopulateQuestionsFromQuestionnaireJson() {
        m_Questions = new List<Question>();
        mJsonQuestions = QuestionFromJson.CreateQuestionnaireFromJson();
        Debug.Log("QuestionSingleton.mJsonQuestions");
        
        foreach (Question p in mJsonQuestions.m_Questionnaire.result.questions) {
            p.m_RightAlternative = p.m_AnswerA;
            m_Questions.Add(p);
        }
        m_QuestionsAmount = m_Questions.Count;
    }
}