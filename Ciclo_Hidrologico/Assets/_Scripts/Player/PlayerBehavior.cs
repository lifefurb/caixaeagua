using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior: MonoBehaviour{

    public Player m_Player;
    public QuestionScreenBehavior m_QuestionScreenBehavior;

    void Awake() {
        m_Player = new Player();
    }

    public void IncrementScore() {
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name) {
            case "Scene_Easy":
                m_Player.points += 10;
                m_QuestionScreenBehavior.ShowAddScoreAnimation(10);
                break;
            case "Scene_Normal":
                m_Player.points += 30;
                m_QuestionScreenBehavior.ShowAddScoreAnimation(30);
                break;
            case "Scene_Hard":
                m_Player.points += 50;
                m_QuestionScreenBehavior.ShowAddScoreAnimation(50);
                break;
        }
    }

    public void DecrementScore() {
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name)
        {
            case "Scene_Easy":
                m_Player.points -= 2;
                m_QuestionScreenBehavior.ShowSubScoreAnimation(2);
                break;
            case "Scene_Normal":
                m_Player.points -= 5;
                m_QuestionScreenBehavior.ShowSubScoreAnimation(5);
                break;
            case "Scene_Hard":
                m_Player.points -= 10;
                m_QuestionScreenBehavior.ShowSubScoreAnimation(10);
                break;
        }
    }
}
