using System;

[Serializable]
public class Questionnaire {

    public string _id;
    public string code;
    public string title;
    public string teacherID;
    public string description;
    public string criationDate;
    public Question[] questions;

}
