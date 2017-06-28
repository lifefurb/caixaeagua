using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonQuestionPreview : MonoBehaviour {

    public long m_Id = 0;

    public void ButtonQuestionOnClick() {
        List<Question> tempList = new List<Question>();

        foreach (Question p in QuestionSingleTon.Instance.m_AllQuestions) {
            if (p.m_Id == m_Id) {
                p.m_RightAlternative = p.m_Alternatives[0];
                tempList.Add(p);
            }
        }
        QuestionSingleTon.Instance.m_Questions = tempList;
        Debug.Log("Perguntas substituídas com sucesso.");
    }
}
