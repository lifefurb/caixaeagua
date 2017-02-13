//Classe responsavel por gerenciar o menu principal da scene MainMenu e o buttonBackMenu da scene MainScene

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject m_canvasMainMenu;         //armazena o canvas do menu principal
    public GameObject m_canvasInstructions;     //armazena o canvas das instrucoes

    // Use this for initialization
    void Start () {
        //apenas garante que a primeira tela apresentada é a do menu principal
        m_canvasMainMenu.gameObject.SetActive(true);
        m_canvasInstructions.gameObject.SetActive(false);
        //m_canvasConfiguration.gameObject.SetActive(false);
    }

    //chamado no metodo OnClick do buttonPlay. Inicializa a cena principal da caixa de areia
    public void Play() {
        SceneManager.LoadScene("MainScene");
    }

    //chamado no metodo Onclick do buttonInstruction. Desabilita o canvas do menu principal e habilita o canvas das instrucoes
    public void Instructions() {
        m_canvasMainMenu.gameObject.SetActive(false);
        m_canvasInstructions.gameObject.SetActive(true);
    }
    

    //chamado no metodo OnClick do buttonQuit. Fecha a aplicação
    public void Quit() {
        Application.Quit();
    }

    //chamado no metodo OnClick do buttonBack do canvasInstructions, canvasConfigurations e no buttonBackMenu do canvasMain na scene MainScene
    public void Back() {
        SceneManager.LoadScene("MainMenu");
    }
}
