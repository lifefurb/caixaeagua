using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListOfQuestions : MonoBehaviour {

    public static List<QuestionPreview> m_QuestionsList = new List<QuestionPreview>();
    public GameObject m_ButtonPrefab;
    public GameObject m_Grid;

    private static List<GameObject> mButtons = new List<GameObject>();
    
    public void QuestionListButton() {
        m_QuestionsList = QuestionSingleTon.Instance.m_ListOfQuestions;

        foreach (QuestionPreview p in m_QuestionsList) {
            GameObject temp = Instantiate(m_ButtonPrefab, m_Grid.transform);
            temp.GetComponentInChildren<Text>().text = p.m_NamePreview;

            mButtons.Add(temp);
        }
    }

}
