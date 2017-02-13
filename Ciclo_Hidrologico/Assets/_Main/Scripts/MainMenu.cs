//Classe responsavel por gerenciar o menu principal da scene MainMenu e o buttonBackMenu da scene MainScene

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //chamado no metodo OnClick do buttonPlay. Inicializa a cena principal da caixa de areia
    public void Play() {
        SceneManager.LoadScene("MainScene");
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
