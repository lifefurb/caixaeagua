using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public AudioManager m_AudioManager;

    public GameObject m_MainMenuPanel;
    public GameObject m_InstructionsPanel;
    public GameObject m_DiffucultyPanel;
    public GameObject m_ConfigurationsPanel;
    public GameObject m_QuestionnairePanel;
    public GameObject m_MessegePanel;
    public InputField m_QuestionnaireCode;

    public Text m_QuestionnaireCodeText;
    public Text m_Messege;
    public Text m_QuestionnairePanelTitleText;
    public Text m_DifficultyPanelTitleText;

    public GameObject m_SendIcon;
    public Sprite m_Confirm;
    public Sprite m_Error;

    public void EnableInstructionsPanel(bool active) {
        m_ConfigurationsPanel.SetActive(!active);
        m_InstructionsPanel.SetActive(active);
    }

    public void EnableDifficultyPanel(bool active) {
        m_MainMenuPanel.SetActive(!active);
        m_DifficultyPanelTitleText.text = QuestionSingleTon.Instance.m_JsonQuestions.m_Questionnaire.result.title;
        m_DiffucultyPanel.SetActive(active);
    }

    public void EnableQuestionnairePanel(bool active) {
        m_ConfigurationsPanel.SetActive(!active);
        m_QuestionnairePanelTitleText.text = QuestionSingleTon.Instance.m_JsonQuestions.m_Questionnaire.result.title;
        m_QuestionnairePanel.SetActive(active);
    }

    /// <summary>
    /// Ativa ou desativa o ConfigurationsPanel.
    /// Chamado no método OnClick do objeto ConfigurationsButton na interface da Unity.
    /// </summary>
    /// <param name="active">True (checkbox marcado) para ativar o painel ou False (checkbox desmarcado) para desativar</param>
    public void EnableConfigurationsPanel(bool active) {
        m_MainMenuPanel.SetActive(!active);
        m_ConfigurationsPanel.SetActive(active);
    }

    public void ChooseDifficultyButton(Button bt) {
        switch (bt.name) {
            case "EasyButton":
                QuestionSingleTon.Instance.m_Difficulty = Difficulty.EASY;
                break;
            case "NormalButton":
                QuestionSingleTon.Instance.m_Difficulty = Difficulty.NORMAL;
                break;
            case "HardButton":
                QuestionSingleTon.Instance.m_Difficulty = Difficulty.HARD;
                break;
        }
    }

    public void Quit() {
        Application.Quit();
    }

    public void OpenLink(string link) {
        Application.OpenURL(link);
    }
    
    public void EnableMessegePanel(bool active) {
        m_QuestionnairePanel.SetActive(!active);
        m_MessegePanel.SetActive(active);
    }
    
    private void EnableMessegePanel(string messege, bool active) {
        m_QuestionnairePanel.SetActive(!active);
        m_Messege.text = messege;
        m_MessegePanel.SetActive(active);
    }

    public void EnableSendIcon() {
        m_SendIcon.gameObject.SetActive(false);
    }

    public void SendCodeQuestionnaire() {
        if (m_QuestionnaireCodeText.text == "") {
            EnableMessegePanel("Informe algum código!", true);
            m_AudioManager.PlayWrongAnswerAudio();
        } else {
            StartCoroutine(ServerConnection.RequestQuestion(m_QuestionnaireCodeText.text, CallBackRequestQuestion));
        }
    }

    /// <summary>
    /// Salva o resultado do request no PlayerPrefs e 
    /// preenche a lista m_Questions da classe QuestionSingleton com as perguntas do novo questionário.
    /// É passada como parâmetro da função SendScore.requestQuestion().
    /// </summary>
    /// <param name="err">Erro da consulta ao servidor.</param>
    /// <param name="resultStr">Resultado da consulta ao servidor.</param>
    /// <returns>Retorna 0</returns>
    private int CallBackRequestQuestion(string err, string resultStr) {
        if (err == null) {
            PlayerPrefs.SetString("Questionnaire", "{\"m_Questionnaire\":" + resultStr + "}"); //precisa fazer isso para ficar no formato certo para gerar o objeto
            QuestionSingleTon.Instance.PopulateQuestionsFromQuestionnaireJson();

            m_SendIcon.GetComponent<Image>().sprite = m_Confirm;
            m_SendIcon.gameObject.SetActive(true);
            EnableMessegePanel("Questionário substituído com sucesso!", true);
            m_AudioManager.PlayRightAnswerAudio();
            m_QuestionnairePanelTitleText.text = QuestionSingleTon.Instance.m_JsonQuestions.m_Questionnaire.result.title;
        }else {
            Debug.Log(err);
            m_SendIcon.GetComponent<Image>().sprite = m_Error;
            m_SendIcon.gameObject.SetActive(true);
            EnableMessegePanel("Código inválido. Tente novamente!", true);
            m_AudioManager.PlayWrongAnswerAudio();
        }
        return 0;
    }
}
