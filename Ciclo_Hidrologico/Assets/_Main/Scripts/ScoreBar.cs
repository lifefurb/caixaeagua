//Responsável pela apresentação dos pontos conseguidos no CanvasFinal
//Usa a variavel m_score da classe Game que conta a pontuação
//Utilizada no gameObject ProgressBar (filho de CanvasFinal/PanelFinal)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour {

	public Transform m_LoadingBar;
	public Transform m_TextIndicator;
	public Game m_Game;

	private float m_CurrentScore;
	private float m_CurrentTime;
	private float m_FullScore = 400f;
	private float m_Speed = 50f;
	private float m_Count = 0f;

	void Awake(){
		m_CurrentScore = 0f;
		m_CurrentTime = 0f;
		m_Count = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {
		m_CurrentScore = m_Game.m_score;			//variavel da classe Game que é incrementada/decrementada a cada acerto/erro

		m_CurrentTime += m_Speed * Time.deltaTime;
		//m_CurrentTime += m_Speed * m_Count;

		if(m_CurrentTime <= m_CurrentScore){
			m_TextIndicator.GetComponent<Text>().text = ((int)m_CurrentTime + 1).ToString();
			m_LoadingBar.GetComponent<Image>().fillAmount = m_CurrentTime / m_FullScore;
			//m_Count += 0.01f;
		}
	}
}