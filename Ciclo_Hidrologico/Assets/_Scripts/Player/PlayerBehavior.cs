using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior: MonoBehaviour{

    public PlayerTeste m_Player;

    public void IncrementScore() {
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name) {
            case "Easy": m_Player.m_Score += 10;
                break;
            case "Normal":  m_Player.m_Score += 30;
                break;
            case "Hard":  m_Player.m_Score += 50;
                break;
        }
    }

    public void DecrementScore() {
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name)
        {
            case "Easy": m_Player.m_Score -= 2;
                break;
            case "Normal": m_Player.m_Score -= 5;
                break;
            case "Hard": m_Player.m_Score -= 10;
                break;
        }
    }
}
