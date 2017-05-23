using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScreenBehavior : MonoBehaviour {

    public GameObject m_MainPanel;
    public GameObject m_QuestionsPanel;
    public GameObject m_FinalPanel;
    public Text m_TextFinalAnswer;
    public Text m_TextRightHits;

    public void EnableMainPanel(bool active) {
        m_MainPanel.SetActive(active);
    }

    public void EnableQuestionPanel(bool active) {
        m_QuestionsPanel.SetActive(active);
    }

    public void EnableFinalPanel(bool active) {
        m_FinalPanel.SetActive(active);
    }

    public void ShowRightAnswerMessege(int value) {
        m_TextFinalAnswer.color = new Color(18f / 255f, 218f / 255f, 0);
        m_TextFinalAnswer.text = "Você acertou!\n Faltam " + value + " perguntas.";
    }

    public void ShowWrongAnswerMessege() {
        m_TextFinalAnswer.color = new Color(227f / 255f, 8f / 255f, 8f / 255f);
        m_TextFinalAnswer.text = "Você errou!\n Tente novamente.";
    }

    public void EraseAnswerMessege() {
        m_TextFinalAnswer.text = "";
    }

    public void ShowScore(int value) {
        m_TextRightHits.text = "Pontos: " + value.ToString();
    }

}
