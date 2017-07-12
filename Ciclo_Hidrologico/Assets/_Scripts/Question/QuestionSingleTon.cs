﻿using System.Collections.Generic;
using UnityEngine;

public class QuestionSingleTon : MonoBehaviour {
    
    public List<Question> m_Questions;
    public ResponseToQuestionnaire m_Questionnaire;
    public static QuestionSingleTon Instance;
    
    private QuestionFromJson mJsonQuestions;
    private long mId = 0;

    void Awake() {

        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        QuestionFromJson.LoadPlayerPrefs();
        PopulateQuestionsFromQuestionnaireJson();

        DontDestroyOnLoad(gameObject);
    }

    //Preenche a lista m_Questions com as perguntas do vetor questions do objeto m_Questionnaire
    public void PopulateQuestionsFromQuestionnaireJson() {
        m_Questions = new List<Question>();
        mJsonQuestions = QuestionFromJson.CreateQuestionnaireFromJson();
        foreach (Question p in mJsonQuestions.m_Questionnaire.result.questions) {
            p.m_RightAlternative = p.m_AnswerA;
            m_Questions.Add(p);
        }
    }
}