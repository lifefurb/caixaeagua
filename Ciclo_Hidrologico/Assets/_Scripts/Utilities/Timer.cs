using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text m_TimerText;
	public QuestionScreenBehavior m_QuestionScreenBehavior;

	private float m_StartTime;
	private float m_Time;
	private string m_Seconds;
	private string m_Minutes;
	private int m_SubtractTime;
	private float m_Speed = 0.017f;

	void Awake(){
		m_StartTime = 120f;		//armazena o valor inicial do cronômetro em segundos
		m_Time = 0f;
        m_QuestionScreenBehavior = GameObject.Find("Canvas").GetComponent<QuestionScreenBehavior>();
	}

	void FixedUpdate(){

		m_Time = m_StartTime - m_SubtractTime * m_Speed;

		if (m_Time > 0) {
			m_Minutes = ((int)m_Time / 60).ToString ("00");
			m_Seconds = (m_Time % 60).ToString ("00");
			m_TimerText.text = m_Minutes + ":" + m_Seconds;
		} else {
            m_QuestionScreenBehavior.EnableMainPanel(false);
            m_QuestionScreenBehavior.EnableQuestionPanel(false);
            m_QuestionScreenBehavior.EnableFinalPanel(true);
            gameObject.SetActive(false);
		}

		m_SubtractTime++;

        if (Quiz.m_GameOver)
            gameObject.SetActive(false);

    }
}
