/*using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{

    //armazena os elementos Text do Canvas  
    public Text m_pergunta;
    public Text m_respostaA;
    public Text m_respostaB;
    public Text m_respostaC;
    public Text m_respostaD;

    public string[] m_perguntas;        //armazena todas as perguntas
    public string[] m_alternativaA;     //armazena todas as alternativas A
    public string[] m_alternativaB;     //armazena todas as alternativas B
    public string[] m_alternativaC;     //armazena todas as alternativas C
    public string[] m_alternativaD;     //armazena todas as alternativas D
    public string[] m_corretas;         //armazena todas as alternativas corretas

    public Question m_question;

    //private int m_idPergunta;

    private float m_acertos;
    private float m_questoes;
    private float m_media;
    private int m_notaFinal;

    // Use this for initialization
    void Start()
    {
        m_question.questaoAtual = 0;
        //m_idPergunta = 0;

        m_pergunta.text = m_perguntas[m_question.questaoAtual];
        m_respostaA.text = m_alternativaA[m_question.questaoAtual];
        m_respostaB.text = m_alternativaB[m_question.questaoAtual];
        m_respostaC.text = m_alternativaC[m_question.questaoAtual];
        m_respostaD.text = m_alternativaD[m_question.questaoAtual];
    }

    public void Resposta(string alternativa)
    {
        switch (alternativa)
        {
            case "A":
                if (m_alternativaA[m_question.questaoAtual] == m_corretas[m_question.questaoAtual])
                    m_acertos++;
                break;
            case "B":
                if (m_alternativaB[m_question.questaoAtual] == m_corretas[m_question.questaoAtual])
                    m_acertos++;
                break;
            case "C":
                if (m_alternativaC[m_question.questaoAtual] == m_corretas[m_question.questaoAtual])
                    m_acertos++;
                break;
            case "D":
                if (m_alternativaD[m_question.questaoAtual] == m_corretas[m_question.questaoAtual])
                    m_acertos++;
                break;
        }
    }
}*/