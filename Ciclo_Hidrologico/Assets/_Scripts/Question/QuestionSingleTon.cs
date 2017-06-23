using System.Collections.Generic;
using UnityEngine;

public class QuestionSingleTon: MonoBehaviour {

    public List<Question> m_AllQuestions = new List<Question>();
    public List<Question> m_Questions = new List<Question>();
    public List<QuestionPreview> m_ListOfQuestions = new List<QuestionPreview>();
    public static QuestionSingleTon Instance;

    private QuestionFromJson mJsonQuestions;

    void Awake() {

        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }
        
        Instance = this;

        //Preenche a lista m_Questions com as perguntas do json QuestionsJson
        mJsonQuestions = QuestionFromJson.CreateQuestionsFromJson();
        foreach (Question p in mJsonQuestions.m_ArrayQuestions) {
            p.m_RightAlternative = p.m_Alternatives[0];
            m_Questions.Add(p);
        }

        //Preenche a lista m_ListOfQuestions com as perguntas do json ListOfQuestionsJson
        mJsonQuestions = QuestionFromJson.CreateListOfQuestionsFromJson();
        foreach (QuestionPreview p in mJsonQuestions.m_ArrayQuestionPreview) {
            m_ListOfQuestions.Add(p);
        }

        //Temporário apenas para tentar simular todas as perguntas do servidor
        //Preenche a lista m_AllQuestions com todas as perguntas do json QuestionsJson
        mJsonQuestions = QuestionFromJson.CreateAllQuestionsFromJson();
        foreach (Question p in mJsonQuestions.m_ArrayAllQuestions) {
            m_AllQuestions.Add(p);
        }

        DontDestroyOnLoad(gameObject);
    }
}
