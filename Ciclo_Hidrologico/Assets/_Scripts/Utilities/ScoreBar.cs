﻿using UnityEngine;
using UnityEngine.UI;

//Responsável pela apresentação dos pontos conseguidos no CanvasFinal
//Usa a variavel m_score da classe Game que conta a pontuação
//Utilizada no gameObject ProgressBar (filho de CanvasFinal/PanelFinal)
public class ScoreBar : MonoBehaviour {

	public Transform m_LoadingBar;
	public Transform m_TextIndicator;
	public Quiz m_Quiz;

	private float mCurrentScore;
	private float mCurrentTime;
	private float mFullScore;
	private float mSpeed = 50f;
	private float mCount = 0f;

    private int mScore;

	void Start() {
        switch (QuestionSingleTon.Instance.m_Difficulty) {
            case Difficulty.EASY:
                mScore = 10;
                break;
            case Difficulty.NORMAL:
                mScore = 30;
                break;
            case Difficulty.HARD:
                mScore = 50;
                break;
        }
        mFullScore = QuestionSingleTon.Instance.m_QuestionsAmount * mScore;
    }

	// Update is called once per frame
	void FixedUpdate () {
		mCurrentScore = m_Quiz.m_Score;			//variável da classe Game que é incrementada/decrementada a cada acerto/erro

		mCurrentTime += mSpeed * Time.deltaTime;

		if(mCurrentTime <= mCurrentScore){
			m_TextIndicator.GetComponent<Text>().text = ((int)mCurrentTime).ToString() + "/" + (QuestionSingleTon.Instance.m_QuestionsAmount * mScore).ToString();
			m_LoadingBar.GetComponent<Image>().fillAmount = mCurrentTime / mFullScore;
		}
	}
}