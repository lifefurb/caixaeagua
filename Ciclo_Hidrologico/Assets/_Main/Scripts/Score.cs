using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    private bool m_IncrementScore;
    private bool m_DecrementScore;
    private GameObject m_PanelScore;
    private int m_Less;
    private int m_More;
    private int m_Score;

    void Awake() {
        m_IncrementScore = false;
        m_DecrementScore = false;
        m_PanelScore = GameObject.Find("PanelScore");
        m_Score = 0;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (m_DecrementScore){
            ScoreTextManager.Instance.CreateText(m_PanelScore.transform.position, "-" + m_Less.ToString() + " ", Color.red);
            m_DecrementScore = false;
        }

        if (m_IncrementScore){
            ScoreTextManager.Instance.CreateText(m_PanelScore.transform.position, "+" + m_More.ToString(), Color.green);
            m_IncrementScore = false;
        }
    }
}
