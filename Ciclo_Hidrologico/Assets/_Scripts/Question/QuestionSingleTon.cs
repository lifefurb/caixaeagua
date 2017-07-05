using System.Collections.Generic;
using UnityEngine;

public class QuestionSingleTon : MonoBehaviour
{

    public List<Question> m_AllQuestions = new List<Question>();
    public List<Question> m_Questions;
    public List<QuestionPreview> m_ListOfQuestions;
    public static QuestionSingleTon Instance;
    
    private QuestionFromJson mJsonQuestions;
    private long mId = 0;

    void Awake() {

        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        PopulateQuestions();

        //----------------------------TEMPORÁRIO-----------------------------//
        //Temporário apenas para tentar simular todas as perguntas do servidor
        //Preenche a lista m_AllQuestions com todas as perguntas do json QuestionsJson
        mJsonQuestions = QuestionFromJson.CreateAllQuestionsFromJson();
        foreach (Question p in mJsonQuestions.m_ArrayAllQuestions) {
            m_AllQuestions.Add(p);
        }

        PopulateListOfQuestions();
        //------------------------FIM-TEMPORÁRIO-----------------------------//

        DontDestroyOnLoad(gameObject);
    }
    //Preenche a lista m_Questions com as perguntas do vetor m_ArrayQuestions
    public void PopulateQuestions() {
        m_Questions = new List<Question>();
        mJsonQuestions = QuestionFromJson.CreateQuestionsFromJson();
        foreach (Question p in mJsonQuestions.m_ArrayQuestions) {
            p.m_RightAlternative = p.m_Alternatives[0];
            m_Questions.Add(p);
        }
    }

    //Temporário apenas para simular todos os questionários do servidor
    //Preenche a lista m_ListOfQuestions com as perguntas do json ListOfQuestionsJson
    public void PopulateListOfQuestions() {
        m_ListOfQuestions = new List<QuestionPreview>();
        mId = 0;
        mJsonQuestions = QuestionFromJson.CreateListOfQuestionsFromJson();
        foreach (QuestionPreview p in mJsonQuestions.m_ArrayQuestionPreview) {
            p.m_IdPreview = mId;
            m_ListOfQuestions.Add(p);
            mId++;
        }
    }
}