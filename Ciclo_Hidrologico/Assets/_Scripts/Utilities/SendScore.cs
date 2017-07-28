using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendScore : MonoBehaviour {

    private const string URL_SERVER = "http://201.54.204.10:3000";

    //private const string URL_SERVER = "http://10.13.3.198:3000";

    public static IEnumerator saveScore(string user, Func<string, string, int> CallBackSaveScore) {
        Debug.Log("POSTING");
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers["user"] = user;
        // Post a request to an URL with our custom headers
        Debug.Log("CREATING WWW");
        WWW www = new WWW(URL_SERVER + "/api/caixa-e-agua/ranking/save", new byte[1], headers);
        yield return www;
        //float i = www.uploadProgress;
        //Debug.Log(i);
        Debug.Log("HAVE RESULTS");
        //.. process results from WWW request here...

        Debug.Log(www.text);
        Debug.Log(www.error);
        CallBackSaveScore(www.error, www.text);
    }

    public static IEnumerator requestQuestion(string codigo, Func<string, string, int> CallBackRequestQuestion) {
        Debug.Log(codigo);
        Debug.Log("POSTING");
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers["Content-Type"] = "aplication/json";
        // Post a request to an URL with our custom headers
        Debug.Log("CREATING WWW");
        WWW www = new WWW(URL_SERVER + "/api/questionnaire/code/" + codigo);
        yield return www;
        //float i = www.uploadProgress;
        //Debug.Log(i);
        Debug.Log("HAVE RESULTS");
        //.. process results from WWW request here...

        Debug.Log(www.text);
        Debug.Log(www.error);
        CallBackRequestQuestion(www.error, www.text);
    }
}
