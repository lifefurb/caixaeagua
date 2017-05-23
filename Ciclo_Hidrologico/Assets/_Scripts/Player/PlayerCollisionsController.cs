﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionsController : MonoBehaviour {

    public QuestionBehavior m_QuestionBehavior;
    public QuestionScreenBehavior m_ScreenBehavior;
    
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Question") {
            m_ScreenBehavior.EnableQuestionPanel(true);
            m_QuestionBehavior.ShowQuestion();
            m_ScreenBehavior.EraseAnswerMessege();       
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Question")
            m_ScreenBehavior.EnableQuestionPanel(false);

    }

}
