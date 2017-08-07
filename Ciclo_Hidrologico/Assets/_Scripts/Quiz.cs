using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour {

    public QuestionScreenBehavior m_QuestionScreenBehavior;
    public GameObject m_QuestionPrefab;
    public GameObject m_ImageTarget;
    public AudioManager m_AudioManager;
    public static List<string> m_TipSplit = new List<string>();
    public static bool m_FlagArrow = false;
    public static bool m_GameOver = false;
    public GameObject m_Canvas;
    public int m_Score;
    //public TurnPage m_TurnPageLeft;
    //public TurnPage m_TurnPageRight;

    private List<Question> mQuestions;
    private int mQuestionAmount;
    private int mRightQuestionsCount = 0;
    private int mWrongQuestionsCount = 0;

    void Awake() {
        QuestionSingleTon.Instance.PopulateQuestionsFromQuestionnaireJson();
        mQuestions = QuestionSingleTon.Instance.m_Questions;
        mQuestionAmount = mQuestions.Count - 1;
    }

    void Start() {
        InstantiateQuestion();
        ShowQuestion();
    }

    public void CheckAlternative(string alternative) {
        switch (alternative) {
            case "A": CheckAnswer(m_QuestionScreenBehavior.m_AlternativeAText.text);
                break;
            case "B": CheckAnswer(m_QuestionScreenBehavior.m_AlternativeBText.text);
                break;
            case "C": CheckAnswer(m_QuestionScreenBehavior.m_AlternativeCText.text);
                break;
            case "D": CheckAnswer(m_QuestionScreenBehavior.m_AlternativeDText.text);
                break;
        }
    }

    private void CheckAnswer(string answer) {

        if (answer == mQuestions[mQuestionAmount].m_RightAlternative)
            RightAnswer();
        else
            WrongAnswer();

        if(mQuestionAmount >= 0)
            ShowQuestion();

        m_QuestionScreenBehavior.ShowQuestionsScore(mRightQuestionsCount, mWrongQuestionsCount);
    }

    public void ShowQuestion() {
        //randomiza as perguntas da lista m_Questions
        for (int i = 0; i < mQuestions.Count; i++) {
            Question temp = mQuestions[i];
            int randomIndex = Random.Range(i, mQuestions.Count);
            mQuestions[i] = mQuestions[randomIndex];
            mQuestions[randomIndex] = temp;
        }

        //Randomiza as alternativas da pergunta que está na ultima posição de m_Questions
        string[] alternatives = new string[4];
        alternatives[0] = mQuestions[mQuestionAmount].m_AnswerA;
        alternatives[1] = mQuestions[mQuestionAmount].m_AnswerB;
        alternatives[2] = mQuestions[mQuestionAmount].m_AnswerC;
        alternatives[3] = mQuestions[mQuestionAmount].m_AnswerD;

        for (int i = 0; i < alternatives.Length; i++) {
            string temp = alternatives[i];
            int randomIndex = Random.Range(i, alternatives.Length);
            alternatives[i] = alternatives[randomIndex];
            alternatives[randomIndex] = temp;
        }

        mQuestions[mQuestionAmount].m_AnswerA = alternatives[0];
        mQuestions[mQuestionAmount].m_AnswerB = alternatives[1];
        mQuestions[mQuestionAmount].m_AnswerC = alternatives[2];
        mQuestions[mQuestionAmount].m_AnswerD = alternatives[3];

        //Exibe a pergunta que está na última posição de mQuestions
        m_QuestionScreenBehavior.m_QuestionText.text = mQuestions[mQuestionAmount].m_Question;

        //Exibe as alternativas da pergunta que está na última posição de mQuestions
        m_QuestionScreenBehavior.m_AlternativeAText.text = mQuestions[mQuestionAmount].m_AnswerA;
        m_QuestionScreenBehavior.m_AlternativeBText.text = mQuestions[mQuestionAmount].m_AnswerB;
        m_QuestionScreenBehavior.m_AlternativeCText.text = mQuestions[mQuestionAmount].m_AnswerC;
        m_QuestionScreenBehavior.m_AlternativeDText.text = mQuestions[mQuestionAmount].m_AnswerD;

        //Seta a página da apostila para a página onde está a dica da pergunta
        //m_TurnPageLeft.m_Count = mQuestions[mQuestionAmount].m_Tip;
        //m_TurnPageRight.m_Count = mQuestions[mQuestionAmount].m_Tip + 1;
    }
    
    private void RightAnswer() {
        m_QuestionScreenBehavior.EnableQuestionPanel(false);

        mQuestions.Remove(mQuestions[mQuestionAmount]);
        mQuestionAmount--;
        mRightQuestionsCount++;

        IncrementScore();
        m_AudioManager.PlayRightAnswerAudio();

        m_QuestionScreenBehavior.ShowRightAnswerMessege(mQuestionAmount + 1);
        m_QuestionScreenBehavior.ShowScore(m_Score);

        Destroy(GameObject.Find("Question(Clone)"));
        m_FlagArrow = true;

        if (mQuestions.Count > 0) {
            InstantiateQuestion();
        } else {
            m_GameOver = true;
            m_AudioManager.PlayWinAudio();
            m_QuestionScreenBehavior.EnableMainPanel(false);
            m_QuestionScreenBehavior.EnableFinalPanel(true);
        }
    }

    private void WrongAnswer() {
        mWrongQuestionsCount++;

        if (m_Score > 0)
            DecrementScore();

        m_AudioManager.PlayWrongAnswerAudio();
        m_QuestionScreenBehavior.ShowWrongAnswerMessege();
        m_QuestionScreenBehavior.ShowScore(m_Score);
    }

    private void IncrementScore() {
        int score = 0;
        switch (QuestionSingleTon.Instance.m_Difficulty) {
            case Difficulty.EASY: score = 10;
                break;
            case Difficulty.NORMAL: score = 30;
                break;
            case Difficulty.HARD: score = 50;
                break;
        }
        m_Score += score;
        m_QuestionScreenBehavior.ShowAddScoreAnimation(score);
    }

    private void DecrementScore() {
        int score = 0;
        switch (QuestionSingleTon.Instance.m_Difficulty) {
            case Difficulty.EASY: score = 2;
                break;
            case Difficulty.NORMAL: score = 5;
                break;
            case Difficulty.HARD: score = 10;
                break;
        }
        m_Score -= score;
        m_QuestionScreenBehavior.ShowSubScoreAnimation(score);
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
        temp.transform.localScale = new Vector3(0.8f, 0.01f, 0.8f);
    }

    public InputField m_PlayerName;
    public void SendScoreButtom() {
        Player player = new Player();
        if (m_PlayerName.text != "") {
            player.points = m_Score;
            player.name = m_PlayerName.text;
            player.questCode = QuestionSingleTon.Instance.m_JsonQuestions.m_Questionnaire.result.code;
            string json = JsonUtility.ToJson(player);
            Debug.Log(m_PlayerName.text);
            Debug.Log(json);
            StartCoroutine(ServerConnection.SaveScore(json, CallBackSaveScore));
        } else {
            m_QuestionScreenBehavior.EnableMessegePanel("Nome inválido. Tente novamente!");
            m_AudioManager.PlayWrongAnswerAudio();
        }
    }

    /// <summary>
    /// Envia a pontuação e o nome do jogador para o servidor.
    /// </summary>
    /// <param name="err">Erro retornado da consulta ao servidor</param>
    /// <param name="resultStr">Resultado retornado da consulta ao servidor</param>
    /// <returns>Retorna 0</returns>
    public int CallBackSaveScore(string err, string resultStr) {
        if (err == null) {
            m_QuestionScreenBehavior.EnableMessegePanel("Pontuação enviada com sucesso!");
            m_QuestionScreenBehavior.EnableRankingButton();
            m_AudioManager.PlayRightAnswerAudio();
        } else {
            m_QuestionScreenBehavior.EnableMessegePanel("Erro ao enviar a pontuação. Tente novamente.");
            m_AudioManager.PlayWrongAnswerAudio();
        }
        return 0;
    }
}