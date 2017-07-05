using System;
using UnityEngine;

[Serializable]
public class QuestionFromJson {

    public Question[] m_ArrayQuestions;
    public QuestionPreview[] m_ArrayQuestionPreview;    //Temporário

    public QuestionFromJson() { }

    public static QuestionFromJson CreateQuestionsFromJson() {
        TextAsset assets = Resources.Load("QuestionsJson") as TextAsset;
        Debug.Log(JsonUtility.FromJson<QuestionFromJson>(assets.text));
        return JsonUtility.FromJson<QuestionFromJson>(assets.text);
    }

    //Temporário apenas para tentar simular todos os questionários do servidor
    public static QuestionFromJson CreateListOfQuestionsFromJson() {
        TextAsset assets = Resources.Load("ListOfQuestionsJson") as TextAsset;
        return JsonUtility.FromJson<QuestionFromJson>(assets.text);
    }

    //Temporário apenas para tentar simular todas as perguntas do servidor
    public Question[] m_ArrayAllQuestions;
    public static QuestionFromJson CreateAllQuestionsFromJson() {
        TextAsset assets = Resources.Load("AllQuestions") as TextAsset;
        return JsonUtility.FromJson<QuestionFromJson>(assets.text);
    }
}
