using UnityEngine;

//Responsável pelo controle da seta de localização utilizada na scene MainScene_Easy.
//Está inserida no gameObject canvasArrow (filho do gameObject ThirdPersonCharacter)
public class Arrow : MonoBehaviour {

    public GameObject m_Arrow;

    private GameObject m_Ref;
	private Vector3 v;
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Question")
            m_Arrow.SetActive(false);
    }

    void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Question")
			m_Arrow.SetActive (true);
		
    }
    
    void Update() {

        m_Ref = GameObject.FindGameObjectWithTag("Question");

        if (Quiz.m_FlagArrow) {
            m_Arrow.SetActive(true);
            Quiz.m_FlagArrow = false;
        }

        v = m_Ref.transform.position;
        v.y = 0;

        //arrow always looks forward so it will show correctly to viewer, and world-up changes the rotation
        transform.LookAt(transform.position + transform.forward, v - transform.position);

    }
}