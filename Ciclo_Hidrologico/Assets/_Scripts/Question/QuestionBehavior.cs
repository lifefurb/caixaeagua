using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionBehavior : MonoBehaviour {
    
    public Text m_QuestionText;
    public Text[] m_AlternativesText = new Text[4];
    public QuestionScreenBehavior m_QuestionScreenBehavior;
    public GameObject m_QuestionPrefab;
    public GameObject m_ImageTarget;
    public PlayerBehavior m_PlayerBehavior = new PlayerBehavior();
    public AudioManager m_AudioManager;

    private List<QuestionTeste> mQuestions;
    private int mQuestionAmount;

    void Awake() {
        mQuestions = QuestionSingleTonTeste.m_Questions;
        mQuestionAmount = mQuestions.Count - 1;

        InstantiateQuestion();
    }

    public void CheckAlternative(string alternative) {
        switch (alternative)
        {
            case "A":
                CheckAnswer(m_AlternativesText[0].text);
                break;
            case "B":
                CheckAnswer(m_AlternativesText[1].text);
                break;
            case "C":
                CheckAnswer(m_AlternativesText[2].text);
                break;
            case "D":
                CheckAnswer(m_AlternativesText[3].text);
                break;
        }
    }

    private void CheckAnswer(string answer) {

        if (answer == mQuestions[mQuestionAmount].m_RightAlternative)
            RightAnswer();
        else
            WrongAnswer();

        m_QuestionScreenBehavior.EnableQuestionPanel(false);
    }

    public void ShowQuestion() {

        //randomiza as perguntas da lista m_Questions
        for (int i = 0; i < mQuestions.Count; i++) {
            QuestionTeste temp = mQuestions[i];
            int randomIndex = Random.Range(i, mQuestions.Count);
            mQuestions[i] = mQuestions[randomIndex];
            mQuestions[randomIndex] = temp;
        }

        //Randomiza as alternativas da pergunta que está na ultima posição de m_Questions
        for (int i = 0; i < mQuestions[mQuestionAmount].m_Alternatives.Length; i++) {
            string temp = mQuestions[mQuestionAmount].m_Alternatives[i];
            int randomIndex = Random.Range(i, mQuestions[mQuestionAmount].m_Alternatives.Length);
            mQuestions[mQuestionAmount].m_Alternatives[i] = mQuestions[mQuestionAmount].m_Alternatives[randomIndex];
            mQuestions[mQuestionAmount].m_Alternatives[randomIndex] = temp;
        }

        //Exibe o texto da pergunta que está na ultima posição de m_Questions
        for (int i = 0; i < mQuestions.Count; i++) {
            m_QuestionText.text = mQuestions[mQuestionAmount].m_QuestionText;
        }

        //Exibe as alternativas da pergunta que está na ultima posição de m_Questions
        for (int i = 0; i < m_AlternativesText.Length; i++) {
            m_AlternativesText[i].text = mQuestions[mQuestionAmount].m_Alternatives[i];
        }

    }
    
    private void RightAnswer() {
        m_PlayerBehavior.IncrementScore();
        mQuestions.Remove(mQuestions[mQuestionAmount]);
        mQuestionAmount--;

        m_AudioManager.PlayRightAnswerAudio();
        m_QuestionScreenBehavior.ShowRightAnswerMessege(mQuestions.Count);
        m_QuestionScreenBehavior.ShowScore(m_PlayerBehavior.m_Player.m_Score);

        Destroy(GameObject.Find("Question(Clone)"));

        if (mQuestions.Count > 0) {
            InstantiateQuestion();
        } else {
            m_AudioManager.PlayWinAudio();
            m_QuestionScreenBehavior.EnableMainPanel(false);
            m_QuestionScreenBehavior.EnableFinalPanel(true);
        }            
    }

    private void WrongAnswer() {
        m_PlayerBehavior.DecrementScore();
        m_AudioManager.PlayWrongAnswerAudio();
        m_QuestionScreenBehavior.ShowWrongAnswerMessege();
        m_QuestionScreenBehavior.ShowScore(m_PlayerBehavior.m_Player.m_Score);
    }

    private void InstantiateQuestion() {
        float wall1 = GameObject.Find("Wall1").transform.position.x;
        float wall2 = GameObject.Find("Wall2").transform.position.x;
        float wall3 = GameObject.Find("Wall3").transform.position.z;
        float wall4 = GameObject.Find("Wall4").transform.position.z;

        float randomPositionX = Random.Range(wall1 - 0.5f, wall2 - 0.5f);
        float randomPositionZ = Random.Range(wall3 - 0.5f, wall4 - 0.5f);

        GameObject temp = Instantiate(m_QuestionPrefab, new Vector3(randomPositionX, 0, randomPositionZ), Quaternion.identity);
        temp.transform.parent = m_ImageTarget.transform;
        temp.transform.localScale = new Vector3(0.5f, 0.01f, 0.5f);
    }
}
