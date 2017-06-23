using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject m_MainMenuPanel;
    public GameObject m_InstructionsPanel;
	public GameObject m_DiffucultyPanel;
    public GameObject m_QuestionsListPanel;

    void Start () {
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

    public void BackFromInstructions() {
        m_InstructionsPanel.SetActive(false);
        m_MainMenuPanel.SetActive(true);
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
}
