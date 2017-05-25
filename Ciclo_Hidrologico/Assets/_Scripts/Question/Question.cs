using System;

[Serializable]
public class Question {

    public string m_QuestionText;
    public string[] m_Alternatives = new string[4];
    public string m_RightAlternative;
    public string m_Tip;
    
}
