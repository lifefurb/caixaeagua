using System.Collections.Generic;
using UnityEngine;

public class QuestionSingleTonTeste: MonoBehaviour {

    private QuestionFromJson m_JsonQuestions;
    public static List<QuestionTeste> m_Questions = new List<QuestionTeste>();

    void Awake() {
        m_JsonQuestions = QuestionFromJson.CreateFromJson();

        foreach (QuestionTeste p in m_JsonQuestions.m_ArrayQuestions) {
            p.m_RightAlternative = p.m_Alternatives[0];
            m_Questions.Add(p);
        }
        /*
        foreach (Question p in m_Questions) {
            Debug.Log(p.m_QuestionText);
        }*/
    }
}
