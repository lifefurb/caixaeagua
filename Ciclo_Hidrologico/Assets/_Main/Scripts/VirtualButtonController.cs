using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class VirtualButtonController : MonoBehaviour, IVirtualButtonEventHandler {

    public Text m_Tip;
    //public Game m_Game;

    //private GameObject m_VirtualButtonNext;
    //private GameObject m_VirtualButtonBack;
    private string m_Text;
    private int m_Index;
    private List<string> m_Pages = new List<string>();

    void Awake() {
        //m_VirtualButtonNext = GameObject.Find("VirtualButtonNext");
        //m_VirtualButtonBack = GameObject.Find("VirtualButtonBack");

        //m_VirtualButtonNext.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        //m_VirtualButtonBack.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    void Start()
    {
        VirtualButtonBehaviour[] vb = GetComponentsInChildren<VirtualButtonBehaviour>();

        foreach (VirtualButtonAbstractBehaviour vbb in vb)
        {
            vbb.RegisterEventHandler(this);
        }
    }

    void Update() {
        //m_Text = m_Game.m_Questions[m_Game.m_randomCurrentQuestion].m_Tip;

        m_Pages = SplitInPages(m_Text, 110);
        m_Tip.text = m_Pages[m_Index];
    }

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){

        switch (vb.name) {
            case "VirtualButtonNext":
                Debug.Log("Proximo");
                if (m_Index < m_Pages.Count - 1)
                {
                    m_Index++;
                    m_Tip.text = m_Pages[m_Index];
                }
                break;
            case "VirtualButtonBack":
                Debug.Log("Anterior");
                if (m_Index > 0)
                {
                    m_Index--;
                    m_Tip.text = m_Pages[m_Index];
                }
                break;
        }

    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb){
        Debug.Log("Soltou botão");
    }

    private static List<string> SplitInPages(string text, int charAmount){
        List<string> pages = new List<string>();
        while (text.Length > charAmount) {
            pages.Add(text.Substring(0, charAmount));
            text = text.Substring(charAmount);
        }
        if (text != "")
            pages.Add(text);

        return pages;
    }
}