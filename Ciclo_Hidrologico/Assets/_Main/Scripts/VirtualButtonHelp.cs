using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class VirtualButtonHelp : MonoBehaviour,  IVirtualButtonEventHandler {

    public GameObject m_VirtualButtonUp;
    public GameObject m_VirtualButtonDown;
    public GameObject m_CanvasHelp;
    public Scrollbar m_Scroll;

    void Awake() {
        m_VirtualButtonUp.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        m_VirtualButtonDown.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        m_Scroll = m_Scroll.GetComponent<Scrollbar>();
    }

    void Update() {

    }

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {

        if (vb.name == m_VirtualButtonUp.name) {
            Debug.Log("Botão Up foi apertado");
            m_Scroll.value += 0.3f;
        }else if (vb.name == m_VirtualButtonDown.name) { 
            Debug.Log("Botão Down foi apertado");
            m_Scroll.value -= 0.3f;
        }
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {

    }

}
