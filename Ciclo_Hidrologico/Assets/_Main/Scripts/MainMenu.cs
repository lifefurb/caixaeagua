//Responsável por gerenciar o menu principal da scene MainMenu

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject m_canvasMainMenu;        
    public GameObject m_canvasInstructions;     
	public GameObject m_canvasDiffuculty;		

    // Use this for initialization
    void Start () {
        //apenas garante que a primeira tela apresentada seja a do menu principal
        m_canvasMainMenu.SetActive(true);
        m_canvasInstructions.SetActive(false);
		m_canvasDiffuculty.SetActive(false);
    }

    //chamado no metodo OnClick do buttonPlay.
    public void Play() {
		m_canvasInstructions.SetActive(false);
		m_canvasMainMenu.SetActive(false);
		m_canvasDiffuculty.SetActive(true);
    }

    //chamado no metodo Onclick do buttonInstruction.
    public void Instructions() {
        m_canvasMainMenu.SetActive(false);
        m_canvasInstructions.SetActive(true);
    }
    

    //chamado no metodo OnClick do buttonQuit. Fecha a aplicação.
    public void Quit() {
        Application.Quit();
    }

    //chamado no metodo OnClick do buttonBack do canvasInstructions.
    public void Back() {
        SceneManager.LoadScene("MainMenu");
    }

	//chamado no metodo OnClick do buttonEasy.
	public void Easy() {
		SceneManager.LoadScene("MainScene_Easy");
	}

	//chamado no metodo OnClick do buttonMedium.
	public void Medium() {
		SceneManager.LoadScene("MainScene_Medium");
	}

	//chamado no metodo OnClick do buttonHard.
	public void Hard() {
		SceneManager.LoadScene("MainScene_Hard");
	}
}
