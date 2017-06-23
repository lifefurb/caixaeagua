using System;

[Serializable]
public class Question {

    public string m_QuestionText;
    public string[] m_Alternatives = new string[4];
    public string m_RightAlternative;
    public int m_Tip;
    public long m_Id;
    
}
