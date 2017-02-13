//Classe responsável pelas responstas das perguntas feitas na classe UIManager.
//A classe possui um método que será chamado no onClick() event dos UI buttons
//Está inserida no gameObject Canvas

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ButtonAnswer : MonoBehaviour {

    public Text m_answer;           //recebe "Correto!" ou "Errado!" dependendo do vetor respostas
    public UIManager uiManager;     //da acesso a classe UIManager para poder ter acesso a variavel questaoAtual
    private string[] respostas = { "Verdadeiro", "Falso", "Verdadeiro", "Falso", "Verdadeiro", "Falso" };   //determina a ordem das respostas

    //Método que determina se a resposta está certa ou errada implementado no OnClick() do botão (passa o botão como parametro)
    public void Respostas(Button botao)
    {
        string tag = botao.gameObject.tag;

        //determina a resposta baseado no vetor respostas 
        if (tag == respostas[uiManager.questaoAtual - 1])
            m_answer.text = "Certo!";
        else
            m_answer.text = "Errado!";
    }

    void OnTriggerExit(Collider collider) {

            m_answer.text = " ";
    }
}