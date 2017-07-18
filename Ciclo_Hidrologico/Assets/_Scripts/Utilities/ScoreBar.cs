using UnityEngine;
using UnityEngine.UI;

//Responsável pela apresentação dos pontos conseguidos no CanvasFinal
//Usa a variavel m_score da classe Game que conta a pontuação
//Utilizada no gameObject ProgressBar (filho de CanvasFinal/PanelFinal)
public class ScoreBar : MonoBehaviour {

	public Transform m_LoadingBar;
	public Transform m_TextIndicator;
	public PlayerBehavior m_PlayerBehavior;

	private float mCurrentScore;
	private float mCurrentTime;
	private float mFullScore;
	private float mSpeed = 50f;
	private float mCount = 0f;

	void Start() {
        Debug.Log("Quantidade de perguntas: " + QuestionSingleTon.Instance.m_QuestionsAmount);
        switch (QuestionSingleTon.Instance.m_Difficulty) {
            case Difficulty.EASY:
                mFullScore = QuestionSingleTon.Instance.m_QuestionsAmount * 10;
                break;
            case Difficulty.NORMAL:
                mFullScore = QuestionSingleTon.Instance.m_QuestionsAmount * 30;
                break;
            case Difficulty.HARD:
                mFullScore = QuestionSingleTon.Instance.m_QuestionsAmount * 50;
                break;
        }
	}

	// Update is called once per frame
	void FixedUpdate () {
		mCurrentScore = m_PlayerBehavior.m_Player.points;			//variavel da classe Game que é incrementada/decrementada a cada acerto/erro

		mCurrentTime += mSpeed * Time.deltaTime;

		if(mCurrentTime <= mCurrentScore){
			m_TextIndicator.GetComponent<Text>().text = ((int)mCurrentTime).ToString();
			m_LoadingBar.GetComponent<Image>().fillAmount = mCurrentTime / mFullScore;
		}
	}
}