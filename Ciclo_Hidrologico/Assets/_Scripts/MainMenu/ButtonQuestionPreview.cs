using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonQuestionPreview : MonoBehaviour {
    
    public void ButtonQuestionOnClick() {
        long id = 0;
        List<Question> tempList = new List<Question>();

        foreach (QuestionPreview p in ListOfQuestions.m_QuestionsList) {
            if (p.m_NamePreview == this.GetComponentInChildren<Text>().text) {
                id = p.m_IdPreview;
                break;
            }
        }
        foreach (Question p in QuestionSingleTon.Instance.m_AllQuestions) {
            if (p.m_Id == id) {
                p.m_RightAlternative = p.m_Alternatives[0];
                tempList.Add(p);
            }
                
        }
        QuestionSingleTon.Instance.m_Questions = tempList;
        Debug.Log("Perguntas substituídas com sucesso.");
    }
}
