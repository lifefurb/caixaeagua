//Classe responsável pelo gerenciamento dos elementos UI da Main Scene
//E do gerenciamento das perguntas apresentadas
//Está inserido no gameObject ThirdPersonCharacter

using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Game : MonoBehaviour
{

    public AudioSource m_answerAudio;       //recebe o AudioSource que esta no objeto _gameManager
    public AudioClip m_rightAnswerAudio;    //armazena o AudioClip que é reproduzido quando a resposta estiver certa
    public AudioClip m_wrongAnswerAudio;    //armazena o AudioClip que é reproduzido quando a resposta estiver errada
    public AudioClip m_winAudio;            //armazena o AudioClip que é reproduzido quando o jogador finaliza o jogo (responde todas as perguntas)

    //inicio elementos do canvasMain
    public GameObject m_canvasMain;         //armazena o canvasMain
    public GameObject m_panelMessege;       //mensagem inicial que aparece ao iniciar o aplicativo
    public GameObject m_panelPressButton;   //mensagem que aparece ao entrar no collider Question dizendo para apertar o botao R
    public Text m_textRightHits;            //armazena a pontuação do jogador (calculado no metodo Resposta)
    public Button m_buttonShowQuestions;    //armazena o botão R que chama o canvasQuestions
    public Text m_textFinalAnswer;          //armazena a mensagem "Você acertou!" ou "Você errou!" dependendo da resposta
    //fim elementos do canvasMain

    //inicio elementos canvasQuestions
    public GameObject m_canvasQuestions;    //armazena o objeto Canvas para poder ativar ou desativar
    public Text m_textQuestion;             //armazena o texto da pergunta
    public Text m_textAnswerA;              //armazena o texto da alternativa A
    public Text m_textAnswerB;              //armazena o texto da alternativa B
    public Text m_textAnswerC;              //armazena o texto da alternativa C
    public Text m_textAnswerD;              //armazena o texto da alternativa D
    public string[] m_questions;            //armazena todas as perguntas
    public string[] m_answerA;              //armazena todas as alternativas A
    public string[] m_answerB;              //armazena todas as alternativas B
    public string[] m_answerC;              //armazena todas as alternativas C
    public string[] m_answerD;              //armazena todas as alternativas D
    public string[] m_rightAnswers;         //armazena todas as alternativas corretas
    //fim elementos canvasQuestions

    //inicio elementos do canvasFinal
    public GameObject m_canvasFinal;
    public Text m_textRightFinalScore;
    public Text m_textWrongFinalScore;
    public GameObject m_MobileSingleStickControlRig;
    //fim elementos do canvasFinal

    //armezena os colliders das perguntas
    public GameObject m_question1;
    public GameObject m_question2;
    public GameObject m_question3;
    public GameObject m_question4;
    public GameObject m_question5;
    public GameObject m_question6;
    public GameObject m_question7;
    public GameObject m_question8;

    private int m_pocas = 8;
    private float m_rightHits;                  //conta a quantidade de respostas certas
    private float m_wrongHits;                  //conta a quantidade de respostas erradas
    private bool m_clicked = false;             //utilizada para ver se o botao foi pressionado ou nao
    private float m_time = 10f;                 //armazena o tempo maximo que o titulo vai permanecer na tela
    private float m_timeFinalAnswer = 5f;       //armazena o tempo maximo que a mensagem de acerto ou erro vai permanecer na tela
    //private int m_currentQuestion = 0;          //recebe o número da questão, que será referenciado no vetor respostas[]
    private int[] m_currentQuestion = new int[8] {0, 1, 2, 3, 4, 5, 6, 7};
    private int m_randomCurrentQuestion = 0;
    private int m_answeredQuestions;            //conta o numero de perguntas respondidas corretamente
    private bool m_boolRightAnswer = false;     //recebe true quando a resposta selecionada for a correta     
    private int m_positionQuestion;
    private int index;
    private int randomAlternative;

    /*
    void Awake() {
        m_question1 = GameObject.Find("Question1");
        m_question2 = GameObject.Find("Question2");
        m_question3 = GameObject.Find("Question3");
        m_question4 = GameObject.Find("Question4");
        m_question5 = GameObject.Find("Question5");
        m_question6 = GameObject.Find("Question6");
        m_question7 = GameObject.Find("Question7");
        m_question8 = GameObject.Find("Question8");
    }*/

    void Update()
    {
        //faz com que a mensagem inicial desapareça após 10 segundos
        if (m_time > 0)
        {
            m_time -= Time.deltaTime;
            m_panelMessege.gameObject.SetActive(true);
        }
        else
        {
            m_panelMessege.gameObject.SetActive(false);
        }

        //faz com que a mensagem de acerto ou erro desapareça após 5 segundos
        if (m_clicked == true && m_timeFinalAnswer > 0)
        {
            m_timeFinalAnswer -= Time.deltaTime;
            if (m_timeFinalAnswer <= 0)
                m_textFinalAnswer.text = "";
        }

        m_textRightFinalScore.text = "" + m_rightHits;
        m_textWrongFinalScore.text = "" + m_wrongHits;
    }

    //ao entrar no colldier
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Question")          //só faz as acoes abaixo se o gameObject colidido ter a tag "Question"
        {
            m_boolRightAnswer = false;
            m_clicked = false;                              //garante que sempre que entrar do collider a m_clicou seja falsa para que assim as perguntas possam sempre aparecer ao entrar novamente
            m_timeFinalAnswer = 5;                          //o tempo que a resposta de acerto/erro aparece na tela volta a ser 5 para poder decrescer até 0 novamente
            m_textFinalAnswer.text = "";                    //garante que a resposta de Certo e Errado inicie em branco
            m_panelPressButton.gameObject.SetActive(true);
            m_buttonShowQuestions.interactable = true;      //torna o buttonPergunta interativo

            System.Random random = new System.Random();
            randomAlternative = random.Next(1, 4);
        }
    }

    //enquanto está no collider
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Question")          //só faz as acoes abaixo se o gameObject colidido ter a tag "Question"
        {
            //Chama o método das perguntas quando o personagem esta em contato com algum collider
            Questions(collider);

            //destroi a pergunta se a resposta estiver certa
            DestroyQuestion(collider);
        }
    }

    //ao sair do collider
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Question")          //só faz as acoes abaixo se o gameObject colidido ter a tag "Question"
        {
            m_canvasQuestions.gameObject.SetActive(false);      //desliga novamente o canvas da pergunta e dos botões (caso o jogador saia do collider sem responder a pergunta)
            m_buttonShowQuestions.interactable = false;         //quando o avatar sai do collider o buttonPergunta deixa de ser interativo novamente
            m_panelPressButton.gameObject.SetActive(false);     //e o aviso para apertar o botao desaparece
        }
    }

    //chamado no OnClick() do buttonPergunta
    public void ButtonQ()
    {
        m_textFinalAnswer.text = "";
        m_panelPressButton.gameObject.SetActive(false);     //desativa o aviso para apertar o botao
        m_canvasQuestions.gameObject.SetActive(true);       //ativa o canvas das perguntas
        m_buttonShowQuestions.interactable = false;         //torna o buttonPergunta nao interativo (para nao poder recarregar a pergunta enquanto esta no collider)
        m_clicked = false;
    }

    //Método que gerencia as perguntas
    private void Questions(Collider collider)
    {
        //as perguntas e alternativas só aparecem se o jogador não tiver clicado em nenhuma alternativa 
        if (m_clicked == false)
        {
            //Se o nome do objeto com o qual o personagem colidiu for igual a um dos cases abaixo, cria uma determinada pergunta com suas alternativas
            switch (collider.gameObject.name)
            {
                case "Question1":
                    m_positionQuestion = 1;
                    QuestionAux(m_randomCurrentQuestion);
                    break;
                case "Question2":
                    m_positionQuestion = 2;
                    QuestionAux(m_randomCurrentQuestion);
                    break;
                case "Question3":
                    m_positionQuestion = 3;
                    QuestionAux(m_randomCurrentQuestion);
                    break;
                case "Question4":
                    m_positionQuestion = 4;
                    QuestionAux(m_randomCurrentQuestion);
                    break;
                case "Question5":
                    m_positionQuestion = 5;
                    QuestionAux(m_randomCurrentQuestion);
                    break;
                case "Question6":
                    m_positionQuestion = 6;
                    QuestionAux(m_randomCurrentQuestion);
                    break;
                case "Question7":
                    m_positionQuestion = 7;
                    QuestionAux(m_randomCurrentQuestion);
                    break;
                case "Question8":
                    m_positionQuestion = 8;
                    QuestionAux(m_randomCurrentQuestion);
                    break;
            }

            /*if (collider.gameObject == m_question1) {
                QuestionAux(m_currentQuestion[m_randomCurrentQuestion]);
                //m_currentQuestion++;
            }*/
        }
        else
        {
            m_canvasQuestions.gameObject.SetActive(false);
        }
    }

    //Método que gerencia as perguntas. Chamado no Questions()
    private void QuestionAux(int currentQuestion) {

        m_textQuestion.text = m_questions[m_randomCurrentQuestion];

        //faz com que as alternativas apareçam em ordem ""aleatória""
        switch (randomAlternative) {
            case 1:
                m_textAnswerA.text = m_answerA[m_randomCurrentQuestion];
                m_textAnswerB.text = m_answerB[m_randomCurrentQuestion];
                m_textAnswerC.text = m_answerC[m_randomCurrentQuestion];
                m_textAnswerD.text = m_answerD[m_randomCurrentQuestion];
                break;
            case 2:
                m_textAnswerA.text = m_answerB[m_randomCurrentQuestion];
                m_textAnswerB.text = m_answerC[m_randomCurrentQuestion];
                m_textAnswerC.text = m_answerD[m_randomCurrentQuestion];
                m_textAnswerD.text = m_answerA[m_randomCurrentQuestion];
                break;
            case 3:
                m_textAnswerA.text = m_answerC[m_randomCurrentQuestion];
                m_textAnswerB.text = m_answerD[m_randomCurrentQuestion];
                m_textAnswerC.text = m_answerA[m_randomCurrentQuestion];
                m_textAnswerD.text = m_answerB[m_randomCurrentQuestion];
                break;
            case 4:
                m_textAnswerA.text = m_answerD[m_randomCurrentQuestion];
                m_textAnswerB.text = m_answerA[m_randomCurrentQuestion];
                m_textAnswerC.text = m_answerB[m_randomCurrentQuestion];
                m_textAnswerD.text = m_answerC[m_randomCurrentQuestion];
                break;
        }
    }

    //método chamado no OnClick() dos 4 botões de alternativas de resposta (ao chamar o método é preciso passar a string dos cases no unity)
    public void Answer(string answer)
    {
        switch (answer)
        {
            case "A":
                RightWrongAnswer(m_textAnswerA.text);
                break;
            case "B":
                RightWrongAnswer(m_textAnswerB.text);
                break;
            case "C":
                RightWrongAnswer(m_textAnswerC.text);
                break;
            case "D":
                RightWrongAnswer(m_textAnswerD.text);
                break;
        }
        m_answerAudio.Play();       //toca o som de resposta
    }

    //metodo que verifica se a resposta esta certa ou errada. Recebe o vetor da pergunta como parametro
    private void RightWrongAnswer(string answer) {
        //se a resposta selecionada estiver certa a variavel m_hits é implementada e a m_respostaFinal informa "Você acertou!" em verde
        if (answer == m_rightAnswers[m_randomCurrentQuestion])
        {
            m_clicked = true;                               //ao receber true faz com que as perguntas e alternativas desapareçam da tela
            m_pocas--;
            m_rightHits++;
            m_textRightHits.text = "Acertos: " + m_rightHits;

            //só toca a musica de acerto e imprime a imagem na tela se o numero de acertos for menor do que o numero de perguntas
            if (m_rightHits < 8)
            {
                m_textFinalAnswer.GetComponent<Text>().color = Color.green;
                m_textFinalAnswer.text = "Você acertou!\n Faltam " + m_pocas + " poças.";
                m_answerAudio.clip = m_rightAnswerAudio;        //faz a variavel m_answerAudio receber o audio clip da resposta correta
            }
            else    //se o numero de acertos for igual o numero de perguntas toca a musica de vitoria e ativa o canvasFinal
            {
                m_canvasMain.gameObject.SetActive(false);
                m_MobileSingleStickControlRig.gameObject.SetActive(false);
                m_canvasFinal.gameObject.SetActive(true);
                m_answerAudio.clip = m_winAudio;
            }
            m_boolRightAnswer = true;
        }
        else
        { //e se estiver errada a m_respostaFinal informa "Você errou!" em vermelho
            m_clicked = true;
            m_wrongHits++;
            m_textFinalAnswer.GetComponent<Text>().color = Color.red;
            m_textFinalAnswer.text = "Você errou!\n Tente novamente.";
            m_answerAudio.clip = m_wrongAnswerAudio;        //faz a variavel m_answerAudio receber o audio clip da resposta errada
            m_buttonShowQuestions.interactable = true;      //torna o buttonPergunta interativo

            System.Random random = new System.Random();
            randomAlternative = random.Next(1, 4);
        }
    }

    //verifica em qual pergunta o personagem esta para depois destrui-la se a resposta estiver correta
    private void DestroyQuestion(Collider collider)
    {
        switch (collider.gameObject.name)
         {
             case "Question1":
                 DestroyQuestionAux(m_question1);
                 break;
             case "Question2":
                 DestroyQuestionAux(m_question2);
                 break;
             case "Question3":
                 DestroyQuestionAux(m_question3);
                 break;
             case "Question4":
                 DestroyQuestionAux(m_question4);
                 break;
             case "Question5":
                 DestroyQuestionAux(m_question5);
                 break;
             case "Question6":
                 DestroyQuestionAux(m_question6);
                 break;
             case "Question7":
                 DestroyQuestionAux(m_question7);
                 break;
             case "Question8":
                 DestroyQuestionAux(m_question8);
                 break;
         }
    }

    //metodo que verifica se a resposta esta correta e, se estiver, destroi a pergunta
    private void DestroyQuestionAux(GameObject question) {
        if ((m_textAnswerA.text == m_rightAnswers[m_randomCurrentQuestion]) && (m_boolRightAnswer == true))
        {
            Destroy(question);
            ActivateQuestions();
        }
        else if ((m_textAnswerB.text == m_rightAnswers[m_randomCurrentQuestion]) && (m_boolRightAnswer == true))
        {
            Destroy(question);
            ActivateQuestions();
        }
        else if ((m_textAnswerC.text == m_rightAnswers[m_randomCurrentQuestion]) && (m_boolRightAnswer == true))
        {
            Destroy(question);
            ActivateQuestions();
        }
        else if ((m_textAnswerD.text == m_rightAnswers[m_randomCurrentQuestion]) && (m_boolRightAnswer == true))
        {
            Destroy(question);
            ActivateQuestions();
        }
    }
    
    List<int> anterior = new List<int>(8);
    public void ActivateQuestions() {

        System.Random rnd = new System.Random();
        
        int aux = m_randomCurrentQuestion;
        anterior.Add(aux);
        
        m_randomCurrentQuestion = rnd.Next(m_currentQuestion.Length);
        m_randomCurrentQuestion = m_currentQuestion[m_randomCurrentQuestion];

        if (m_currentQuestion.Length > 1)
        {
            while (anterior.Contains(m_randomCurrentQuestion))
            {
                m_randomCurrentQuestion = rnd.Next(m_currentQuestion.Length);
                m_randomCurrentQuestion = m_currentQuestion[m_randomCurrentQuestion];
                //Debug.Log("Numero sorteado " + m_randomCurrentQuestion);
            }
        }
        else {
            m_randomCurrentQuestion = m_currentQuestion[0];
        }

        //Debug.Log(m_randomCurrentQuestion);
        //Debug.Log("index = " + m_randomCurrentQuestion);
        //Debug.Log("tamanho = " + m_currentQuestion.Length);

        switch (m_positionQuestion)
        {
            case 1:
                m_question2.gameObject.SetActive(true);
                break;
            case 2:
                m_question3.gameObject.SetActive(true);
                break;
            case 3:
                m_question4.gameObject.SetActive(true);
                break;
            case 4:
                m_question5.gameObject.SetActive(true);
                break;
            case 5:
                m_question6.gameObject.SetActive(true);
                break;
            case 6:
                m_question7.gameObject.SetActive(true);
                break;
            case 7:
                m_question8.gameObject.SetActive(true);
                break;
        }
        
        m_currentQuestion = this.removeFromArray(m_currentQuestion, aux);
    }

    private int[] removeFromArray(int[] array, int index)
    {
        int[] novoArray = new int[array.Length - 1];
        string chegou = "";
        string saiu = "";
        int posAtual = 0;
        for (int i = 0; i < array.Length; i++)
        {
            chegou += array[i] + ", ";
            if (index != array[i])
            {
                novoArray[posAtual] = array[i];
                saiu += novoArray[posAtual] + ", ";
                posAtual++;
            }
        }
        //Debug.Log("Chegou = " + chegou);
        //Debug.Log("Saiu = " + saiu);
        return novoArray;
    }
}