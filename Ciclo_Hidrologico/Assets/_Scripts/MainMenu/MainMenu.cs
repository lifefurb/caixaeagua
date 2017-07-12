using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject m_MainMenuPanel;
    public GameObject m_InstructionsPanel;
    public GameObject m_DiffucultyPanel;
    public GameObject m_QuestionsListPanel;
    public GameObject m_QuestionnairePanel;
    public GameObject m_MessegePanel;
    public InputField m_QuestionnaireCode;
    public Text m_Messege;

    void Start() {
        m_MainMenuPanel.SetActive(true);
        m_InstructionsPanel.SetActive(false);
        m_DiffucultyPanel.SetActive(false);
    }

    public void Play() {
        m_InstructionsPanel.SetActive(false);
        m_MainMenuPanel.SetActive(false);
        m_DiffucultyPanel.SetActive(true);
    }

    public void Instructions() {
        m_MainMenuPanel.SetActive(false);
        m_InstructionsPanel.SetActive(true);
    }

    public void Questionnaire() {
        m_MainMenuPanel.SetActive(false);
        m_QuestionnairePanel.SetActive(true);
    }

    public void QuestionsList() {
        m_MainMenuPanel.SetActive(false);
        m_QuestionsListPanel.SetActive(true);
    }

    public void BackFromQuestionsList() {
        m_QuestionsListPanel.SetActive(false);
        m_MainMenuPanel.SetActive(true);
    }

    public void LoadScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void Quit() {
        Application.Quit();
    }

    public void EnableMessegePanel(string messege) {
        m_QuestionnairePanel.SetActive(false);
        m_Messege.text = messege;
        m_MessegePanel.SetActive(true);
    }

    public void BackToSendQuestionnaireCode() {
        m_MessegePanel.SetActive(false);
        m_QuestionnairePanel.SetActive(true);
    }

    public void BackToMainMenu(){
        m_InstructionsPanel.SetActive(false);
        m_DiffucultyPanel.SetActive(false);
        m_QuestionsListPanel.SetActive(false);
        m_QuestionnairePanel.SetActive(false);
        m_MessegePanel.SetActive(false);
        m_MainMenuPanel.SetActive(true);
    }

    public void SendCodeQuestionnaire() {

        if (m_QuestionnaireCode.text != "")
            StartCoroutine(SendScore.requestQuestion(m_QuestionnaireCode.text, CallBackRequestQuestion));
        else
            EnableMessegePanel("Código inválido. Tente novamente!");
    }

    //Recebe as perguntas do servidor. Incompleto
    public int CallBackRequestQuestion(string err, string resultStr) {
        if (err == null) {
            Debug.Log("Json antigo");
            Debug.Log(PlayerPrefs.GetString("Questionnaire"));
            PlayerPrefs.SetString("Questionnaire", resultStr);
            QuestionSingleTon.Instance.PopulateQuestionsFromQuestionnaireJson();
            Debug.Log("Json novo");
            Debug.Log(PlayerPrefs.GetString("Questionnaire"));
        }else {
            EnableMessegePanel("Código inválido. Tente novamente!");
        }
        return 0;
    }
}
