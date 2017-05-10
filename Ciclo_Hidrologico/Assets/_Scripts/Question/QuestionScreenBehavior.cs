using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScreenBehavior : MonoBehaviour {

    public GameObject m_MainPanel;
    public GameObject m_QuestionsPanel;

    public void EnableMainPanel(bool active) {
        m_MainPanel.SetActive(active);
    }

    public void EnableQuestionPanel(bool active) {
        m_QuestionsPanel.SetActive(active);
    }

}
