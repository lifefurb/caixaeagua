using UnityEngine;

public class PlayerBehavior: MonoBehaviour{

    public Player m_Player;
    public QuestionScreenBehavior m_QuestionScreenBehavior;

    void Awake() {
        m_Player = new Player();
    }

    public void IncrementScore() {
        switch (QuestionSingleTon.Instance.m_Difficulty) {
            case Difficulty.EASY:
                m_Player.points += 10;
                m_QuestionScreenBehavior.ShowAddScoreAnimation(10);
                break;
            case Difficulty.NORMAL:
                m_Player.points += 30;
                m_QuestionScreenBehavior.ShowAddScoreAnimation(30);
                break;
            case Difficulty.HARD:
                m_Player.points += 50;
                m_QuestionScreenBehavior.ShowAddScoreAnimation(50);
                break;
        }
    }

    public void DecrementScore() {
        switch (QuestionSingleTon.Instance.m_Difficulty) {
            case Difficulty.EASY:
                m_Player.points -= 2;
                m_QuestionScreenBehavior.ShowSubScoreAnimation(2);
                break;
            case Difficulty.NORMAL:
                m_Player.points -= 5;
                m_QuestionScreenBehavior.ShowSubScoreAnimation(5);
                break;
            case Difficulty.HARD:
                m_Player.points -= 10;
                m_QuestionScreenBehavior.ShowSubScoreAnimation(10);
                break;
        }
    }
}
