using UnityEngine;

public class PlayerCollisionsController : MonoBehaviour {

    public Quiz m_Quiz;
    public QuestionScreenBehavior m_QuestionScreenBehavior;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Question") {
            m_QuestionScreenBehavior.EraseAnswerMessege();
            m_QuestionScreenBehavior.EnableQuestionPanel(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Question") {
            m_QuestionScreenBehavior.EnableQuestionPanel(false);
            m_Quiz.ShowQuestion();
        }
    }

}
