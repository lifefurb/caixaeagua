using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject m_MainMenuPanel;        
    public GameObject m_InstructionsPanel;     
	public GameObject m_DiffucultyPanel;		

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

    public void Apostila() {
        SceneManager.LoadScene("Apostila");
    }

    public void Quit() {
        Application.Quit();
    }

    public void Back() {
        SceneManager.LoadScene("MainMenu");
    }

	public void Easy() {
		SceneManager.LoadScene("Scene_Easy");
	}

	public void Medium() {
		SceneManager.LoadScene("Scene_Normal");
	}

	public void Hard() {
		SceneManager.LoadScene("Scene_Hard");
	}
}
