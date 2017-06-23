using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour {

    public Text m_QuestionText;
    public Text[] m_AlternativesText = new Text[4];
    public QuestionScreenBehavior m_QuestionScreenBehavior;
    public GameObject m_QuestionPrefab;
    public GameObject m_ImageTarget;
    public PlayerBehavior m_PlayerBehavior = new PlayerBehavior();
    public AudioManager m_AudioManager;
    public TurnPage m_TurnPageLeft;
    public TurnPage m_TurnPageRight;

    public static List<string> m_TipSplit = new List<string>();
    public static bool m_FlagArrow = false;
    public static bool m_GameOver = false;

    private TipBook mTipBook;
    private List<Question> mQuestions;
    private int mQuestionAmount;
    private int mRightQuestionsCount = 0;
    private int mWrongQuestionsCount = 0;

    void Awake() {
        mQuestions = QuestionSingleTon.Instance.m_Questions;
        mQuestionAmount = mQuestions.Count - 1;

        foreach (Question p in mQuestions) {
            Debug.Log("Id: " + p.m_Id + " | Pergunta: " + p.m_QuestionText);
        }
        Debug.Log("Tamanho lista: " + mQuestionAmount);

    }

    void Start() {
        InstantiateQuestion();
    }

    public void CheckAlternative(string alternative) {
        switch (alternative) {
            case "A": CheckAnswer(m_AlternativesText[0].text);
                break;
            case "B": CheckAnswer(m_AlternativesText[1].text);
                break;
            case "C": CheckAnswer(m_AlternativesText[2].text);
                break;
            case "D": CheckAnswer(m_AlternativesText[3].text);
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
        for (int i = 0; i < mQuestions[mQuestionAmount].m_Alternatives.Length; i++) {
            string temp = mQuestions[mQuestionAmount].m_Alternatives[i];
            int randomIndex = Random.Range(i, mQuestions[mQuestionAmount].m_Alternatives.Length);
            mQuestions[mQuestionAmount].m_Alternatives[i] = mQuestions[mQuestionAmount].m_Alternatives[randomIndex];
            mQuestions[mQuestionAmount].m_Alternatives[randomIndex] = temp;
        }

        //Exibe a pergunta que está na última posição de mQuestions
        m_QuestionText.text = mQuestions[mQuestionAmount].m_QuestionText;

        //Exibe as alternativas da pergunta que está na última posição de mQuestions
        for (int i = 0; i < m_AlternativesText.Length; i++) {
            m_AlternativesText[i].text = mQuestions[mQuestionAmount].m_Alternatives[i];
        }

        foreach (Question p in mQuestions) {
            if (p.m_QuestionText == m_QuestionText.text) {
                m_TurnPageLeft.m_Count = p.m_Tip;
                m_TurnPageRight.m_Count = p.m_Tip + 1;
            }
        }
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

        GameObject temp = Instantiate(m_QuestionPrefab, new Vector3(randomPositionX, 0, randomPositionZ), Quaternion.identity);
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

    public int CallBackRequestQuestion(string err, string resultStr) {

        List<Question> result = new List<Question>();
        JsonUtility.FromJsonOverwrite(resultStr, result);

        if (err == null) {
            mQuestions = result;
        }
        return 0;
    }
}