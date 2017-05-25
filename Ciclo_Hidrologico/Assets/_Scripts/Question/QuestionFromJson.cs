using System;
using UnityEngine;

[Serializable]
public class QuestionFromJson {

    public Question[] m_ArrayQuestions;

    public QuestionFromJson() { }

    public static QuestionFromJson CreateFromJson() {
        TextAsset assets = Resources.Load("QuestionsJson") as TextAsset;
        return JsonUtility.FromJson<QuestionFromJson>(assets.text);
    }

}
