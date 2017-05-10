using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionBehavior : MonoBehaviour {
    
    public Text m_QuestionText;
    public Text[] m_AlternativesText = new Text[4];
    public QuestionScreenBehavior m_QuestionScreenBehavior;
    public GameObject m_QuestionPrefab;
    public GameObject m_ImageTarget;

    private List<QuestionTeste> m_Questions;
    private PlayerBehavior m_Player = new PlayerBehavior();
    private int m_QuestionAmount;

    void Awake() {
        m_Questions = QuestionSingleTonTeste.m_Questions;
        m_QuestionAmount = m_Questions.Count - 1;

        GameObject temp = Instantiate(m_QuestionPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        temp.transform.parent = m_ImageTarget.transform;
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

        if (answer == m_Questions[m_QuestionAmount].m_RightAlternative)
            RightAnswer();
        else
            WrongAnswer();

        m_QuestionScreenBehavior.EnableQuestionPanel(false);
    }

    public void ShowQuestion() {

        //randomiza as perguntas da lista m_Questions
        for (int i = 0; i < m_Questions.Count; i++) {
            QuestionTeste temp = m_Questions[i];
            int randomIndex = Random.Range(i, m_Questions.Count);
            m_Questions[i] = m_Questions[randomIndex];
            m_Questions[randomIndex] = temp;
        }

        //Randomiza as alternativas da pergunta que está na ultima posição de m_Questions
        for (int i = 0; i < m_Questions[m_QuestionAmount].m_Alternatives.Length; i++) {
            string temp = m_Questions[m_QuestionAmount].m_Alternatives[i];
            int randomIndex = Random.Range(i, m_Questions[m_QuestionAmount].m_Alternatives.Length);
            m_Questions[m_QuestionAmount].m_Alternatives[i] = m_Questions[m_QuestionAmount].m_Alternatives[randomIndex];
            m_Questions[m_QuestionAmount].m_Alternatives[randomIndex] = temp;
        }

        //Exibe o texto da pergunta que está na ultima posição de m_Questions
        for (int i = 0; i < m_Questions.Count; i++) {
            m_QuestionText.text = m_Questions[m_QuestionAmount].m_QuestionText;
        }

        //Exibe as alternativas da pergunta que está na ultima posição de m_Questions
        for (int i = 0; i < m_AlternativesText.Length; i++) {
            m_AlternativesText[i].text = m_Questions[m_QuestionAmount].m_Alternatives[i];
        }

    }

    int x = 5;
    private void RightAnswer() {
        m_Player.IncrementScore();
        m_Questions.Remove(m_Questions[m_QuestionAmount]);
        m_QuestionAmount--;

        Destroy(GameObject.Find("Question(Clone)"));

        if (m_Questions.Count > 0) {
            GameObject temp = Instantiate(m_QuestionPrefab, new Vector3(x, 0, 0), Quaternion.identity);
            temp.transform.parent = m_ImageTarget.transform;
        }
        x += 5;
        //chamar o método da classe que gerencia os efeitos de som que reproduz o audio de acerto
    }

    private void WrongAnswer() {
        m_Player.DecrementScore();
        //chamar o método da classe que gerencia os efeitos de som que reproduz o audio de erro
    }
}
