using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ListOfQuestions : MonoBehaviour
{

    public static List<QuestionPreview> m_QuestionsList = new List<QuestionPreview>();
    public GameObject m_ButtonPrefab;
    public GameObject m_Grid;

    private long mId = 0;
    private List<GameObject> mButtons = new List<GameObject>();

    void Start() {
        InstantiateQuestionsList();
    }

    //Atualiza a lista de perguntas com todos os questionários existentes na lista m_QuestionsList
    //Futuramente esse método terá que fazer uma consulta no servidor, retornar uma string com todos
    //os questionários, reescrever o json de questionários atual com esse novo json
    //e trabalhar em cima desse mesmo json atualizado
    //É chamada no botão sincronizar do painel PanelQuestionsList
    public void InstantiateQuestionsList() {
        m_QuestionsList = QuestionSingleTon.Instance.m_ListOfQuestions;

        //Destroi todos os botões ja instanciados pra depois instanciar novos
        //Precisa ser otmizado
        GameObject[] oldButtons = GameObject.FindGameObjectsWithTag("ButtonQuestion");
        
        foreach (GameObject obj in oldButtons) {
            Debug.Log(obj);
            Destroy(obj);
        }

        List<GameObject> tempButtons = new List<GameObject>();
        foreach (QuestionPreview p in m_QuestionsList) {
            GameObject temp = Instantiate(m_ButtonPrefab);
            temp.GetComponentInChildren<Text>().text = p.m_NamePreview;
            temp.GetComponent<ButtonQuestionPreview>().m_Id = p.m_IdPreview;
            temp.GetComponent<RectTransform>().SetParent(m_Grid.transform);

            tempButtons.Add(temp);
        }
        mButtons = tempButtons;
    }

    public void SyncQuestionsList() {
        TextAsset json = Resources.Load("AllListOfQuestionsJson") as TextAsset;
        UpdateQuestionsJson(json.text, "Assets/Resources/ListOfQuestionsJson.txt", "ListOfQuestionsJson");
        QuestionSingleTon.Instance.PopulateListOfQuestions();
        InstantiateQuestionsList();
    }

    public void ButtonQuestionOnClick(ButtonQuestionPreview bt) {
        List<Question> tempList = new List<Question>();

        foreach (Question p in QuestionSingleTon.Instance.m_AllQuestions) {
            if (p.m_Id == bt.m_Id) {
                p.m_RightAlternative = p.m_Alternatives[0];
                tempList.Add(p);
            }
        }

        bt.m_clicked = true;

        foreach (GameObject obj in mButtons) {
            if (obj.GetComponent<ButtonQuestionPreview>().m_clicked) {
                obj.GetComponent<ButtonQuestionPreview>().m_clicked = false;
                obj.GetComponent<Image>().color = Color.yellow;
            }
            else {
                obj.GetComponent<Image>().color = Color.white;
            }
        }
        QuestionSingleTon.Instance.PopulateQuestions();

        //Todo esse bloco serve só pra montar o novo json a partir da templist
        //quando usar a conexão com o servidor não será necessário pois o json
        //já vai vir montado bonitinho. Só vai precisar reescrever o arquivo
        //do json antigo pelo novo
        string json = "{" + "\"m_ArrayQuestions\"" + ":[";
        for(int i = 0; i < tempList.Count; i++) {
            if (i < tempList.Count - 1)
                json += JsonUtility.ToJson(tempList[i]) + ",";
            else
                json += JsonUtility.ToJson(tempList[i]);
        }
        json += "]}";

        UpdateQuestionsJson(json, "Assets/Resources/QuestionsJson.txt", "QuestionsJson");

        Debug.Log("Perguntas substituídas com sucesso.");
    }

    private static void UpdateQuestionsJson(string json, string path, string name) {

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);
        writer.Write(json);
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        TextAsset asset = Resources.Load(name) as TextAsset;

        //Print the text from the file
        Debug.Log(asset.text);
    }
}
