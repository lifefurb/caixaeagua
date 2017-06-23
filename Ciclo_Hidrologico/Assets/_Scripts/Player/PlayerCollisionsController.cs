using UnityEngine;

public class PlayerCollisionsController : MonoBehaviour {

    public Quiz m_QuestionBehavior;
    public QuestionScreenBehavior m_QuestionScreenBehavior;
    

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Question") {
            m_QuestionScreenBehavior.EraseAnswerMessege();
            m_QuestionScreenBehavior.EnablePressButtonPanel(true);
            m_QuestionScreenBehavior.EnableButtonQ(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Question") {
            m_QuestionScreenBehavior.EnableQuestionPanel(false);
            m_QuestionScreenBehavior.EnablePressButtonPanel(false);
            m_QuestionScreenBehavior.EnableButtonQ(false);
        }
    }

}
