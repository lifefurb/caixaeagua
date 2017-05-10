using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour {

    public Game m_Game;
    public Text m_Text;
    public int m_Max;

    private string[] m_Page;
    private string m_Tip;
    private int m_Index;

    void Awake() {
        m_Max = 25;
    }

    // Update is called once per frame
    void Update () {
        m_Tip = m_Game.m_Questions[m_Game.m_randomCurrentQuestion].m_Tip;
        m_Page = m_Tip.Split();
        
        while (m_Index <= m_Max) {
            m_Text.text += (m_Page[m_Index] + " ");
            m_Index++;
        }
        
    }
}
