using UnityEngine;

public class BookGameManager : MonoBehaviour {

    public void LoadScene(string scene) {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

}
