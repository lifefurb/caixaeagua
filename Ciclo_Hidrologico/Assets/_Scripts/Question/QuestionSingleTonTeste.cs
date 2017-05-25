using System.Collections.Generic;
using UnityEngine;

public class QuestionSingleTonTeste: MonoBehaviour {

    private QuestionFromJson m_JsonQuestions;
    public static List<Question> m_Questions = new List<Question>();

    void Awake() {
        m_JsonQuestions = QuestionFromJson.CreateFromJson();

        foreach (Question p in m_JsonQuestions.m_ArrayQuestions) {
            p.m_RightAlternative = p.m_Alternatives[0];
            m_Questions.Add(p);
        }
    }
}
