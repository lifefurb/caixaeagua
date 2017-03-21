//Responsável pelo gerenciamento dos elementos UI da Main Scene
//e do gerenciamento das perguntas apresentadas
//Está inserido no gameObject ThirdPersonCharacter

using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class Game : MonoBehaviour
{
    public AudioSource m_answerAudio;       //recebe o AudioSource que esta no objeto _gameManager
    public AudioClip m_rightAnswerAudio;    //armazena o AudioClip que é reproduzido quando a resposta estiver certa
    public AudioClip m_wrongAnswerAudio;    //armazena o AudioClip que é reproduzido quando a resposta estiver errada
    public AudioClip m_winAudio;            //armazena o AudioClip que é reproduzido quando o jogador finaliza o jogo (responde todas as perguntas)

    //inicio elementos do canvasMain
    public GameObject m_canvasMain;         
    public GameObject m_panelMessege;       
    public GameObject m_panelPressButton;   
	//public GameObject m_panelScore;
    public RectTransform m_PanelScoreText;
	public Text m_textRightHits;            
    public Button m_buttonShowQuestions;    
    public Text m_textFinalAnswer;          
	//fim elementos do canvasMain

    //inicio elementos canvasQuestions
    public GameObject m_canvasQuestions;    
	public Text m_textQuestion;             
    public Text m_textAnswerA;             
    public Text m_textAnswerB;              
    public Text m_textAnswerC;              
    public Text m_textAnswerD;              
    //fim elementos canvasQuestions

    //inicio elementos do canvasFinal
    public GameObject m_canvasFinal;
    public Text m_textRightFinalScore;
    public Text m_textWrongFinalScore;
    public GameObject m_MobileSingleStickControlRig;
	public int m_score;			//armazena a pontuação do jogador. Utilizada na classe ScoreBar 
    //fim elementos do canvasFinal

    public GameObject m_canvasMessege;
    public Text m_messege;

	public Scene m_currentScene;    
	public Question[] m_Questions = new Question[8];    //armazena todas as perguntas (cada objeto Question possui um script Question)

    private int m_pocas = 8;
    private float m_rightHits;                  //conta a quantidade de respostas certas
    private float m_wrongHits;                  //conta a quantidade de respostas erradas
    private bool m_clicked = false;             //utilizada para ver se o botao foi pressionado ou nao
    private float m_timeFinalAnswer = 5f;       //armazena o tempo maximo que a mensagem de acerto ou erro vai permanecer na tela
    private int[] m_currentQuestion = new int[8] {0, 1, 2, 3, 4, 5, 6, 7};
    private int m_randomCurrentQuestion = 0;
    private int m_answeredQuestions;            //conta o numero de perguntas respondidas corretamente
    private bool m_boolRightAnswer = false;     //recebe true quando a resposta selecionada for a correta     
    private int m_positionQuestion;
    private int index;
    private int m_randomAlternative;
	private bool m_IncrementScore = false;
	private bool m_DecrementScore = false;
	private int m_Less;
	private int m_More;

    private Player m_Player;

	void Awake() {
		m_score = 0;
		m_rightHits = 0;
        
		//m_canvasFinal.gameObject.SetActive(false);
		//m_canvasQuestions.gameObject.SetActive (false);
		//m_canvasMain.gameObject.SetActive(true);
		//m_MobileSingleStickControlRig.gameObject.SetActive(true);
	}

	void Start(){
		m_currentScene = SceneManager.GetActiveScene ();
        ScoreTextManager.Instance.CreateText(m_PanelScoreText.transform.position, "+" + m_More.ToString(), Color.green);
    }

    void Update() {

        //faz com que a mensagem de acerto ou erro desapareça após 5 segundos
        if (m_clicked == true && m_timeFinalAnswer > 0){
            m_timeFinalAnswer -= Time.deltaTime;
            if (m_timeFinalAnswer <= 0)
                m_textFinalAnswer.text = "";
        }

        //instancia o texto de quantos pontos o jogador ganhou ou perdeu
        if (m_DecrementScore){
			ScoreTextManager.Instance.CreateText (m_PanelScoreText.transform.position, "-" + m_Less.ToString() + " ", Color.red);
			m_DecrementScore = false;
		}
		if(m_IncrementScore){
			ScoreTextManager.Instance.CreateText (m_PanelScoreText.transform.position, "+" + m_More.ToString(), Color.green);
			m_IncrementScore = false;
		}
        
		m_textRightHits.text = "Pontos: " + m_score;

    }
    
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Question") {        //só faz as acoes abaixo se o gameObject colidido ter a tag "Question"
            m_boolRightAnswer = false;
            m_clicked = false;                              //garante que sempre que entrar do collider a m_clicou seja falsa para que assim as perguntas possam sempre aparecer ao entrar novamente
            m_timeFinalAnswer = 5;                          //o tempo que a resposta de acerto/erro aparece na tela volta a ser 5 para poder decrescer até 0 novamente
            m_textFinalAnswer.text = "";                    //garante que a resposta de Certo e Errado inicie em branco
			m_panelMessege.gameObject.SetActive(false);
			m_panelPressButton.gameObject.SetActive(true);
            m_buttonShowQuestions.interactable = true;      //torna o buttonPergunta interativo

            System.Random random = new System.Random();
            m_randomAlternative = random.Next(1, 4);
        }
    }
    
    void OnTriggerStay(Collider collider) {
        if (collider.gameObject.tag == "Question") {
            Questions(collider);
            DestroyQuestion(collider);
        }
    }
    
    void OnTriggerExit(Collider collider) {
        if (collider.gameObject.tag == "Question") {            //só faz as acoes abaixo se o gameObject colidido ter a tag "Question"
            m_canvasQuestions.gameObject.SetActive(false);      //desliga novamente o canvas da pergunta e dos botões (caso o jogador saia do collider sem responder a pergunta)
            m_buttonShowQuestions.interactable = false;         //quando o avatar sai do collider o buttonPergunta deixa de ser interativo novamente
            m_panelPressButton.gameObject.SetActive(false);     //e o aviso para apertar o botao desaparece
        }
    }

    //chamado no OnClick() do buttonPergunta
    public void ButtonQ() {
        m_textFinalAnswer.text = "";
        m_panelPressButton.SetActive(false);
        m_canvasQuestions.SetActive(true);
        m_buttonShowQuestions.interactable = false;
        m_clicked = false;
    }

    //Método que gerencia as perguntas
    private void Questions(Collider collider){
        //as perguntas e alternativas só aparecem se o jogador não tiver clicado em nenhuma alternativa 
        if (m_clicked == false) {
            foreach (Question p in m_Questions) {
                if (p.m_QuestionName == collider.gameObject.name) {
                    m_positionQuestion = p.m_Id;
                    QuestionAux();
                }
            }
        }else{
            m_canvasQuestions.gameObject.SetActive(false);
        }
    }
    
    //Método que gerencia as perguntas. Chamado no Questions()
    private void QuestionAux(){

        m_textQuestion.text = m_Questions[m_randomCurrentQuestion].m_Question;

        //faz com que as alternativas apareçam em ordem ""aleatória""
        switch (m_randomAlternative){
            case 1:
			    m_textAnswerA.text = m_Questions[m_randomCurrentQuestion].m_AnswerA;
			    m_textAnswerB.text = m_Questions[m_randomCurrentQuestion].m_AnswerB;
			    m_textAnswerC.text = m_Questions[m_randomCurrentQuestion].m_AnswerC;
			    m_textAnswerD.text = m_Questions[m_randomCurrentQuestion].m_AnswerD;
                break;
            case 2:
			    m_textAnswerA.text = m_Questions[m_randomCurrentQuestion].m_AnswerB;
			    m_textAnswerB.text = m_Questions[m_randomCurrentQuestion].m_AnswerC;
			    m_textAnswerC.text = m_Questions[m_randomCurrentQuestion].m_AnswerD;
			    m_textAnswerD.text = m_Questions[m_randomCurrentQuestion].m_AnswerA;
                break;
            case 3:
                m_textAnswerA.text = m_Questions[m_randomCurrentQuestion].m_AnswerC;
			    m_textAnswerB.text = m_Questions[m_randomCurrentQuestion].m_AnswerD;
			    m_textAnswerC.text = m_Questions[m_randomCurrentQuestion].m_AnswerA;
			    m_textAnswerD.text = m_Questions[m_randomCurrentQuestion].m_AnswerB;
                break;
            case 4:
                m_textAnswerA.text = m_Questions[m_randomCurrentQuestion].m_AnswerD;
			    m_textAnswerB.text = m_Questions[m_randomCurrentQuestion].m_AnswerA;
			    m_textAnswerC.text = m_Questions[m_randomCurrentQuestion].m_AnswerB;
			    m_textAnswerD.text = m_Questions[m_randomCurrentQuestion].m_AnswerC;
                break;
        }
    }

    //método chamado no OnClick() dos 4 botões de alternativas de resposta (ao chamar o método é preciso passar a string dos cases no unity)
    public void Answer(string answer){
        switch (answer) {
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
        if (answer == m_Questions[m_randomCurrentQuestion].m_RightAnswer){
            m_clicked = true;       //ao receber true faz com que as perguntas e alternativas desapareçam da tela
            m_pocas--;
            m_rightHits++;
			RightScoreManager ();
            m_textRightFinalScore.text = "" + m_rightHits;

            //só toca a musica de acerto e imprime a imagem na tela se o numero de acertos for menor do que o numero de perguntas
            if (m_rightHits < 8){
                m_textFinalAnswer.color = new Color(18f/255f, 218f/255f, 0);
				m_textFinalAnswer.text = "Você acertou!\n Faltam " + m_pocas + " perguntas.";
                m_answerAudio.clip = m_rightAnswerAudio;        //faz a variavel m_answerAudio receber o audio clip da resposta correta
            }else {  //se o numero de acertos for igual o numero de perguntas toca a musica de vitoria e ativa o canvasFinal
                WinPanel ();
            }
            m_boolRightAnswer = true;
        }else { //e se estiver errada a m_respostaFinal informa "Você errou!" em vermelho
            m_clicked = true;
            m_wrongHits++;
			m_textWrongFinalScore.text = "" + m_wrongHits;
			WrongScoreManager();

            m_textFinalAnswer.color = new Color(227f/255f, 8f/255f, 8f/255f);
			m_textFinalAnswer.text = "Você errou!\n Tente novamente.";
            m_answerAudio.clip = m_wrongAnswerAudio;        //faz a variavel m_answerAudio receber o audio clip da resposta errada
            m_buttonShowQuestions.interactable = true;      //torna o buttonPergunta interativo

            System.Random random = new System.Random();
            m_randomAlternative = random.Next(1, 4);
        }
    }

    public static bool m_Flag;
    //verifica em qual pergunta o personagem esta para depois destrui-la se a resposta estiver correta
    private void DestroyQuestion(Collider collider){

        for (byte i = 0; i <= m_Questions.Length; i++) {
            if (m_Questions[i].m_QuestionName == collider.gameObject.name) {
                if ((m_textAnswerA.text == m_Questions[m_randomCurrentQuestion].m_RightAnswer) && (m_boolRightAnswer == true)) {
                    Destroy(m_Questions[i].gameObject);
                    ActivateQuestions();
                    m_Flag = true;
                }else if ((m_textAnswerB.text == m_Questions[m_randomCurrentQuestion].m_RightAnswer) && (m_boolRightAnswer == true)) {
                    Destroy(m_Questions[i].gameObject);
                    ActivateQuestions();
                    m_Flag = true;
                }else if ((m_textAnswerC.text == m_Questions[m_randomCurrentQuestion].m_RightAnswer) && (m_boolRightAnswer == true)) {
                    Destroy(m_Questions[i].gameObject);
                    ActivateQuestions();
                    m_Flag = true;
                }else if ((m_textAnswerD.text == m_Questions[m_randomCurrentQuestion].m_RightAnswer) && (m_boolRightAnswer == true)){
                    Destroy(m_Questions[i].gameObject);
                    ActivateQuestions();
                    m_Flag = true;
                }
            }
        }
    }

    List<int> anterior = new List<int>(8);
    public void ActivateQuestions() {

        System.Random rnd = new System.Random();
        
        int aux = m_randomCurrentQuestion;
        anterior.Add(aux);
        
        m_randomCurrentQuestion = rnd.Next(m_currentQuestion.Length);
        m_randomCurrentQuestion = m_currentQuestion[m_randomCurrentQuestion];

        if (m_currentQuestion.Length > 1){
            while (anterior.Contains(m_randomCurrentQuestion)){
                m_randomCurrentQuestion = rnd.Next(m_currentQuestion.Length);
                m_randomCurrentQuestion = m_currentQuestion[m_randomCurrentQuestion];
            }
        }else {
            m_randomCurrentQuestion = m_currentQuestion[0];
        }
        
        for (byte i = 0; i < m_Questions.Length; i++) {
            if (i == m_positionQuestion) {
                m_Questions[i+1].gameObject.SetActive(true);
            }
        }
        m_currentQuestion = this.removeFromArray(m_currentQuestion, aux);
    }

    private int[] removeFromArray(int[] array, int index){
        int[] novoArray = new int[array.Length - 1];
        string chegou = "";
        string saiu = "";
        int posAtual = 0;
        for (int i = 0; i < array.Length; i++){
            chegou += array[i] + ", ";
            if (index != array[i]){
                novoArray[posAtual] = array[i];
                saiu += novoArray[posAtual] + ", ";
                posAtual++;
            }
        }
        return novoArray;
    }

	public void WinPanel(){
        m_canvasMain.gameObject.SetActive(false);
		m_MobileSingleStickControlRig.gameObject.SetActive(false);
		m_canvasFinal.gameObject.SetActive(true);
		m_answerAudio.clip = m_winAudio;         
	}

    public InputField m_PlayerName;
    private List<string> Nomes = new List<string>();
    private List<string> EnviosPendentes = new List<string>();

    public void SendButtom() {
        //string text = File.ReadAllText(Application.streamingAssetsPath + "/users");
        //Nomes = text.Split(';').ToList();

        if ((m_PlayerName.text != "") && (!Nomes.Contains(m_PlayerName.text))) {
            
            m_Player = new Player();
            m_Player.setScore(m_score);
            m_Player.setPlayerName(m_PlayerName.text);
            string json = JsonUtility.ToJson(m_Player);
            Debug.Log(json);

            //File.AppendAllText(Application.streamingAssetsPath + "/users", m_PlayerName.text + ';');

            Nomes.Add(m_PlayerName.text);

            VerificarErro(null, json);
        }
        else {
            Messege("Nome inválido. Tente novamente");
        }
    }
    
    public int VerificarErro(string erro, string data){
        if (erro != null) {
            EnviosPendentes.Add(data);
            Messege("Dados não enviados");
            if (erro == "erro1") {
                Debug.Log("Erro");
            }
        }
        else {
            Messege("Dados enviados com sucesso");
        }   
        return 0;
    }

    private void Messege(string messege) {
        m_CanvasSendScore.SetActive(false);
        m_messege.text = messege;
        m_canvasMessege.SetActive(true);
    }

    public GameObject m_CanvasSendScore;
    public Text m_TextScoreValue;
    public void SendPanelButtom()
    {
        m_TextScoreValue.text = m_score.ToString();
        m_canvasFinal.SetActive(false);
        m_CanvasSendScore.SetActive(true);
    }

    public void Back() {
        m_canvasMessege.SetActive(false);
        m_canvasFinal.SetActive(true);
    }

    public void RightScoreManager(){
		if(m_currentScene.name == "MainScene_Easy"){
			m_More = 10;
		}else if(m_currentScene.name == "MainScene_Medium"){
			m_More = 30;
		}else if(m_currentScene.name == "MainScene_Hard"){
			m_More = 50;
		}
		m_score += m_More;
        m_IncrementScore = true;
    }

	public void WrongScoreManager(){
		if(m_score > 0){
			if(m_currentScene.name == "MainScene_Easy"){
				m_Less = 2;
			}else if(m_currentScene.name == "MainScene_Medium"){
				m_Less = 5;
			}else if(m_currentScene.name == "MainScene_Hard"){
				m_Less = 10;
			}
			m_score -= m_Less;
            m_DecrementScore = true;
        }
	}
}