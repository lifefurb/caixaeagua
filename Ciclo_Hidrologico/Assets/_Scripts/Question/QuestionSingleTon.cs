using System.Collections.Generic;
using UnityEngine;

public enum Difficulty {
    EASY, NORMAL, HARD
}

public class QuestionSingleTon : MonoBehaviour {
    
    public List<Question> m_Questions;
    public ResponseToQuestionnaire m_Questionnaire;
    public int m_QuestionsAmount;
    public Difficulty m_Difficulty = Difficulty.NORMAL;
    public QuestionFromJson m_JsonQuestions;

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
        QuestionFromJson.LoadPlayerPrefs();
        PopulateQuestionsFromQuestionnaireJson();

        DontDestroyOnLoad(gameObject);
    }

    //Preenche a lista m_Questions com as perguntas do vetor questions do objeto m_Questionnaire
    public void PopulateQuestionsFromQuestionnaireJson() {
        m_Questions = new List<Question>();
        m_JsonQuestions = QuestionFromJson.CreateQuestionnaireFromJson();
        
        foreach (Question p in m_JsonQuestions.m_Questionnaire.result.questions) {
            p.m_RightAlternative = p.m_AnswerA;
            m_Questions.Add(p);
        }
        m_QuestionsAmount = m_Questions.Count;
    }
}