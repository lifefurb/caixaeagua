using UnityEngine;

public class QuestionTriggerController : MonoBehaviour {

    private Quiz mQuiz;
    private QuestionScreenBehavior mQuestionScreenBehavior;

    void Start() {
        mQuiz = FindObjectOfType<Quiz>();
        mQuestionScreenBehavior = FindObjectOfType<QuestionScreenBehavior>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            mQuestionScreenBehavior.EraseAnswerMessege();
            mQuestionScreenBehavior.EnableQuestionPanel(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            mQuestionScreenBehavior.EnableQuestionPanel(false);
            mQuiz.ShowQuestion();
        }
    }
}
