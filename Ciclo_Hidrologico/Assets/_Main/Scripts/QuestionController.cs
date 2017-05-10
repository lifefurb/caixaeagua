using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestionController {

    public NewQuestion[] perguntas;

    public QuestionController(){}

    public static QuestionController CreateFromJson() {
        TextAsset assets = Resources.Load("questionsList") as TextAsset;
        return JsonUtility.FromJson<QuestionController>(assets.text);
    }
    
}

[Serializable]
public class NewQuestion {

    public int id;
    public string question;
    public string[] answers;
    public int rightAnswer;
    public string tip;

}