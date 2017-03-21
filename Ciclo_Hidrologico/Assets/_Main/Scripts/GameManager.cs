//Responsável por gerenciar o botão ButtonMainMenu do CanvasFinal e o botão ButtonBackMenu do CanvasMain. 
//Utilizado no gameObject _gameManager das três scenes MainScene_ 

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //public AudioSource m_AnswerAudio;
    //public AudioClip m_WinAudio;

    private static GameObject m_CanvasMain;
    private static GameObject m_MobileSingleStickControlRig;
    private static GameObject m_CanvasQuestions;
    private static GameObject m_CanvasFinal;
    
    void Awake() {
        m_CanvasMain = GameObject.Find("CanvasMain");
        m_MobileSingleStickControlRig = GameObject.Find("MobileSingleStickControlRig");
        m_CanvasFinal = GameObject.Find("CanvasFinal");
        m_CanvasQuestions = GameObject.Find("CanvasQuestions");
        m_CanvasFinal = GameObject.Find("CanvasFinal");
    }

    public static void StartPanel() {
        m_CanvasFinal.SetActive(false);
        m_CanvasQuestions.SetActive(false);
        m_CanvasMain.SetActive(true);
        m_MobileSingleStickControlRig.SetActive(true);
    }
    /*
    public static void WinPanel() {
        m_CanvasMain.SetActive(false);
        m_MobileSingleStickControlRig.SetActive(false);
        m_CanvasQuestions.SetActive(false);
        m_CanvasFinal.SetActive(true);
        m_AnswerAudio.clip = m_WinAudio;
    }
    */
    /*
    public void ButtonQ()
    {
        m_TextFinalAnswer.text = "";
        m_PanelPressButton.gameObject.SetActive(false);     //desativa o aviso para apertar o botao
        m_CanvasQuestions.SetActive(true);                  //ativa o canvas das perguntas
        m_ButtonShowQuestions.interactable = false;         //torna o buttonPergunta nao interativo (para nao poder recarregar a pergunta enquanto esta no collider)
        m_clicked = false;
    }
    */
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
