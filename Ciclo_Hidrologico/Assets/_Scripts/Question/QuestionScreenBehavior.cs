using UnityEngine;
using UnityEngine.UI;

public class QuestionScreenBehavior : MonoBehaviour {

    public GameObject m_MainPanel;
    public GameObject m_QuestionsPanel;
    public GameObject m_FinalPanel;
    public GameObject m_SendScorePanel;
    public GameObject m_MessegePanelError;
    public GameObject m_MessegePanelResult;
    public GameObject m_PanelScoreText;
    public GameObject m_PressButtonPanel;
    public GameObject m_MobileSingleStickControlRig;

    public Text m_QuestionText;
    public Text m_AlternativeAText;
    public Text m_AlternativeBText;
    public Text m_AlternativeCText;
    public Text m_AlternativeDText;
    public Text m_TextFinalAnswer;
    public Text m_TextRightHits;
    public Text m_Messege;
    public Text m_TextRightScore;
    public Text m_TextWrongScore;
    public Text m_TextScoreValue;

    public Button m_ButtonQ;

    public void EnableMainPanel(bool active) {
        m_MainPanel.SetActive(active);
    }

    public void EnableQuestionPanel(bool active) {
        m_QuestionsPanel.SetActive(active);
    }

    public void EnableFinalPanel(bool active) {
        m_MobileSingleStickControlRig.SetActive(false);
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

    public void ShowQuestionsScore(int rightQuestionsCount, int wrongQuestionsCount) {
        m_TextRightScore.text = rightQuestionsCount.ToString();
        m_TextWrongScore.text = wrongQuestionsCount.ToString();
    }

    public void EnableButtonQ(bool value) {
        m_ButtonQ.interactable = value;
    }

    public void EnablePressButtonPanel(bool value) {
        m_PressButtonPanel.SetActive(value);
    }

    public void ShowTextScoreValue(int value) {
        m_TextScoreValue.text = value.ToString();
    }

    public void EnableMessegePanelError(string messege) {
        m_SendScorePanel.SetActive(false);
        m_Messege.text = messege;
        m_MessegePanelError.SetActive(true);
    }

    public void EnableMessegePanelResult(string messege) {
        m_SendScorePanel.SetActive(false);
        m_Messege.text = messege;
        m_MessegePanelResult.SetActive(true);
    }

    public void ShowAddScoreAnimation(int value) {
        ScoreTextManager.Instance.CreateText(m_PanelScoreText.transform.position, "+" + value.ToString() + " ", new Color(18f / 255f, 218f / 255f, 0));
    }

    public void ShowSubScoreAnimation(int value) {
        ScoreTextManager.Instance.CreateText(m_PanelScoreText.transform.position, "-" + value.ToString() + " ", new Color(227f / 255f, 8f / 255f, 8f / 255f));
    }

    public void BackFinalPanel() {
        m_SendScorePanel.SetActive(false);
        m_FinalPanel.SetActive(true);
    }

    public void BackSendPanel() {
        m_MessegePanelError.SetActive(false);
        m_SendScorePanel.SetActive(true);
    }

    public void SendScorePanel() {
        m_FinalPanel.SetActive(false);
        m_SendScorePanel.SetActive(true);
    }
}
