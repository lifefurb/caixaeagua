using UnityEngine;
using UnityEngine.SceneManagement;
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

	void Start(){
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name) {
            case "MainScene_Easy": mFullScore = 80;
                break;
            case "MainScene_Normal": mFullScore = 240;
                break;
            case "MainScene_Hard": mFullScore = 400;
                break;
            case "Teste_Easy": mFullScore = 80;
                break;
            case "Teste_Normal": mFullScore = 240;
                break;
            case "Teste_Hard": mFullScore = 400;
                break;
        }

	}

	// Update is called once per frame
	void FixedUpdate () {
		mCurrentScore = m_PlayerBehavior.m_Player.points;			//variavel da classe Game que é incrementada/decrementada a cada acerto/erro

		mCurrentTime += mSpeed * Time.deltaTime;
		//m_CurrentTime += m_Speed * m_Count;

		if(mCurrentTime <= mCurrentScore){
			m_TextIndicator.GetComponent<Text>().text = ((int)mCurrentTime).ToString();
			m_LoadingBar.GetComponent<Image>().fillAmount = mCurrentTime / mFullScore;
			//m_Count += 0.01f;
		}
	}
}