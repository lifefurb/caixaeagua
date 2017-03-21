//Responsável pelo controle da seta de localização utilizada na scene MainScene_Easy.
//Está inserida no gameObject canvasArrow (filho do gameObject ThirdPersonCharacter)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public GameObject m_arrow;

    private GameObject m_ref;
	private Vector3 v;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Question")
            m_arrow.SetActive(false);        
    }

    void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Question") {
			m_arrow.SetActive (true);
		}
    }

    void Update() {

        m_ref = GameObject.FindGameObjectWithTag("Question");

        if (Game.m_Flag) {
            m_arrow.SetActive(true);
            Game.m_Flag = false;
        }

        v = m_ref.transform.position;
        v.y = 0;

        //arrow always looks forward so it will show correctly to viewer, and world-up changes the rotation
        transform.LookAt(transform.position + transform.forward, v - transform.position);
    }
}
