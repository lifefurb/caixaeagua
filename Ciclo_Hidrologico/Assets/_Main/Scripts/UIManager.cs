//Classe responsável pelo gerenciamento dos elementos UI da Main Scene
//E do gerenciamento das perguntas apresentadas
//Está inserido no gameObject ThirdPersonCharacter

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour {

    public Text m_question;     //guarda a pergunta, dependendo de qual objeto entrar em contato com o personagem
    public Text m_title;        //referente a mensagem inicial de quando o jogo começa
    public Button m_true;       //botão da resposta verdadeira
    public Button m_false;      //botão da resposta falsa
    public float m_time = 5f;   //usada para calcular quanto tempo a mensagem inicial fica visível (utilizada no Updade())
    public Text m_answer;       //recebe o gameObject Answer no Unity e apenas o seta como vazio no onTriggerExit

    public int questaoAtual;    //recebe o número da questão, que será referenciado no vetor respostas[]

    // Use this for initialization
    void Start () {
        m_question.text = " ";  //faz com que a variavel que exibe as perguntas inicie vazia
    }

    // Update is called once per frame
    void Update()
    {
        //faz com que a mensagem inicial desapareça após 5 segundos
        if (m_time > 0)
        {
            m_time -= Time.deltaTime;
            m_title.gameObject.SetActive(true);
        }
        else {
            m_title.gameObject.SetActive(false);
        }
    }
    
    void OnTriggerEnter(Collider collider)
    {
        //Chama o método das perguntas quando o personagem entra em contato com algum collider
        Question(collider);
    }

    //Desativa todos os textos e botões quando o personagem sai do collider
    void OnTriggerExit(Collider collider) {
        m_question.text = " ";
        m_true.gameObject.SetActive(false);
        m_false.gameObject.SetActive(false);
        m_answer.text = " ";
    }

    //Método que gerencia as perguntas
    private void Question(Collider collider)
    {
        //Se o nome do objeto com o qual o personagem colidiu for igual a um dos cases abaixo, cria uma determinada pergunta
        switch (collider.gameObject.name)
        {
            case "Question1":
                questaoAtual = 1;
                m_question.text = "Pergunta número 1";
                m_true.gameObject.SetActive(true);
                m_false.gameObject.SetActive(true);
                break;
            case "Question2":
                questaoAtual = 2;
                m_question.text = "Pergunta número 2: How to handle the active status of gameobjects in the scene, \n both independently and within Hierarchies, using SetActive";
                m_true.gameObject.SetActive(true);
                m_false.gameObject.SetActive(true);
                break;
            case "Question3":
                questaoAtual = 3;
                m_question.text = "Pergunta número 3";
                m_true.gameObject.SetActive(true);
                m_false.gameObject.SetActive(true);
                break;
            case "Question4":
                questaoAtual = 4;
                m_question.text = "Pergunta número 4";
                m_true.gameObject.SetActive(true);
                m_false.gameObject.SetActive(true);
                break;
            case "Question5":
                questaoAtual = 5;
                m_question.text = "Pergunta número 5";
                m_true.gameObject.SetActive(true);
                m_false.gameObject.SetActive(true);
                break;
            case "Question6":
                questaoAtual = 6;
                m_question.text = "Pergunta número 6";
                m_true.gameObject.SetActive(true);
                m_false.gameObject.SetActive(true);
                break;
        }
    }
}