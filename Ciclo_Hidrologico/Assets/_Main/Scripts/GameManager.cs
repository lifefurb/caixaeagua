//Responsável por gerenciar o botão ButtonMainMenu do CanvasFinal e o botão ButtonBackMenu do CanvasMain. 
//Utilizado no gameObject _gameManager das três scenes MainScene_ 

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
    public void Back() {
        SceneManager.LoadScene("MainMenu");
    }
}
