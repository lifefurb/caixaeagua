//Classe responsável por fazer o cenário se movimentar
//o material precisa estar com uma texture com a opção Repeat ativada

using UnityEngine;
using System.Collections;

public class MoveOffSet : MonoBehaviour {

    public float m_speed;   //velocidade de movimento do cenário

    private Material m_currentMaterial; //irá guardar o material a ser movimentado (material usado como background)
    private float m_offSet;             //responsável pela movimentação

	// Use this for initialization
	void Start () {
        m_currentMaterial = GetComponent<Renderer>().material;
	}

    void FixedUpdate(){
        m_offSet += 0.01f;
        m_currentMaterial.SetTextureOffset("_MainTex", new Vector2(0, m_offSet * m_speed));
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
