using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour {

    public Text m_QuestionText;
    public Text m_AnswerAText;
    public Text m_AnswerBText;
    public Text m_AnswerCText;
    public Text m_AnswerDText;
    public QuestionScreenBehavior m_QuestionScreenBehavior;
    public GameObject m_QuestionPrefab;
    public GameObject m_ImageTarget;
    public PlayerBehavior m_PlayerBehavior = new PlayerBehavior();
    public AudioManager m_AudioManager;
    public static List<string> m_TipSplit = new List<string>();
    public static bool m_FlagArrow = false;
    public static bool m_GameOver = false;
    public GameObject m_Arrow;
    public GameObject m_Timer;
    public GameObject m_Canvas;
    public GameObject m_ThirdPersonCharacter;
    //public TurnPage m_TurnPageLeft;
    //public TurnPage m_TurnPageRight;

    private List<Question> mQuestions;
    private int mQuestionAmount;
    private int mRightQuestionsCount = 0;
    private int mWrongQuestionsCount = 0;

    void Awake() {
        mQuestions = QuestionSingleTon.Instance.m_Questions;
        mQuestionAmount = mQuestions.Count - 1;
    }

    void Start() {
        InstantiateQuestion();

        switch (QuestionSingleTon.Instance.m_Difficulty) {
            case Difficulty.EASY:
                Instantiate(m_Arrow, new Vector3(0, 0, 0), Quaternion.Euler(90, 0, 0), m_ThirdPersonCharacter.transform);
                break;
            case Difficulty.HARD:
                Instantiate(m_Timer, new Vector3(993, 80, 0), Quaternion.identity, m_Canvas.transform);
                break;
        }
    }

    public void CheckAlternative(string alternative) {
        switch (alternative) {
            case "A": CheckAnswer(m_AnswerAText.text);
                break;
            case "B": CheckAnswer(m_AnswerBText.text);
                break;
            case "C": CheckAnswer(m_AnswerCText.text);
                break;
            case "D": CheckAnswer(m_AnswerDText.text);
                break;
        }
    }

    private void CheckAnswer(string answer) {

        if (answer == mQuestions[mQuestionAmount].m_RightAlternative)
            RightAnswer();
        else
            WrongAnswer();

        m_QuestionScreenBehavior.EnableQuestionPanel(false);
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
        m_QuestionText.text = mQuestions[mQuestionAmount].m_Question;
        
        //Exibe as alternativas da pergunta que está na última posição de mQuestions
        m_AnswerAText.text = mQuestions[mQuestionAmount].m_AnswerA;
        m_AnswerBText.text = mQuestions[mQuestionAmount].m_AnswerB;
        m_AnswerCText.text = mQuestions[mQuestionAmount].m_AnswerC;
        m_AnswerDText.text = mQuestions[mQuestionAmount].m_AnswerD;

        //Seta a página da apostila para a página onde está a dica da pergunta
        //m_TurnPageLeft.m_Count = mQuestions[mQuestionAmount].m_Tip;
        //m_TurnPageRight.m_Count = mQuestions[mQuestionAmount].m_Tip + 1;
    }
    
    private void RightAnswer() {
        mQuestions.Remove(mQuestions[mQuestionAmount]);
        mQuestionAmount--;
        mRightQuestionsCount++;

        m_PlayerBehavior.IncrementScore();
        m_AudioManager.PlayRightAnswerAudio();

        m_QuestionScreenBehavior.ShowRightAnswerMessege(mQuestionAmount + 1);
        m_QuestionScreenBehavior.ShowScore(m_PlayerBehavior.m_Player.points);
        m_QuestionScreenBehavior.EnablePressButtonPanel(false);
        m_QuestionScreenBehavior.EnableButtonQ(false);

        Destroy(GameObject.Find("Question(Clone)"));
        m_FlagArrow = true;

        if (mQuestions.Count > 0) {
            InstantiateQuestion();
        } else {
            m_GameOver = true;
            m_AudioManager.PlayWinAudio();
            m_QuestionScreenBehavior.EnableMainPanel(false);
            m_QuestionScreenBehavior.EnableFinalPanel(true);
            m_QuestionScreenBehavior.ShowTextScoreValue(m_PlayerBehavior.m_Player.points);
        }            
    }

    private void WrongAnswer() {
        mWrongQuestionsCount++;

        if (m_PlayerBehavior.m_Player.points > 0)
            m_PlayerBehavior.DecrementScore();

        m_AudioManager.PlayWrongAnswerAudio();
        m_QuestionScreenBehavior.ShowWrongAnswerMessege();
        m_QuestionScreenBehavior.ShowScore(m_PlayerBehavior.m_Player.points);
    }

    private void InstantiateQuestion() {
        float wall1 = GameObject.Find("Wall1").transform.position.x;
        float wall2 = GameObject.Find("Wall2").transform.position.x;
        float wall3 = GameObject.Find("Wall3").transform.position.z;
        float wall4 = GameObject.Find("Wall4").transform.position.z;

        float randomPositionX = Random.Range(wall1 - 0.5f, wall2 - 0.5f);
        float randomPositionZ = Random.Range(wall3 - 0.5f, wall4 - 0.5f);

        GameObject temp = Instantiate(m_QuestionPrefab, new Vector3(randomPositionX, 60, randomPositionZ), Quaternion.identity);
        temp.transform.parent = m_ImageTarget.transform;
        temp.transform.localScale = new Vector3(0.5f, 0.01f, 0.5f);
    }

    public void ButtonQ() {
        m_QuestionScreenBehavior.EraseAnswerMessege();
        m_QuestionScreenBehavior.EnableQuestionPanel(true);
        m_QuestionScreenBehavior.EnablePressButtonPanel(false);
        ShowQuestion();
    }

    public InputField m_PlayerName;
    private List<string> mNames = new List<string>();
    private List<string> mNotSent = new List<string>();

    public void SendButtom() {
        
        if ((m_PlayerName.text != "") && !(mNames.Contains(m_PlayerName.text))) {
            
            m_PlayerBehavior.m_Player.name = m_PlayerName.text;
            string json = JsonUtility.ToJson(m_PlayerBehavior.m_Player);
            Debug.Log(json);

            StartCoroutine(SendScore.saveScore(json, CallBackSaveScore));
            
            mNames.Add(m_PlayerName.text);
            
        }
        else {
            m_QuestionScreenBehavior.EnableMessegePanel("Nome inválido. Tente novamente!");
        }
    }

    //Envia a pontuação para o servidor
    public int CallBackSaveScore(string err, string resultStr) {

        ResultServer result = new ResultServer();
        JsonUtility.FromJsonOverwrite(resultStr, result);

        if (err != null) {
            mNotSent.Add(resultStr);
            m_QuestionScreenBehavior.EnableMessegePanel(result.msg);
            Debug.Log(result.msg);
            Debug.Log(result.err);
        }else {
            m_QuestionScreenBehavior.EnableMessegePanel(result.msg);
            Debug.Log(result.msg);
            m_PlayerBehavior.m_Player.id = result.idUser;
        }
        return 0;
    }
}