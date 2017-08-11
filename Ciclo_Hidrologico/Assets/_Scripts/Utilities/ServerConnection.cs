using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsável por realizar as conexões necessárias com o servidor
/// </summary>
public class ServerConnection : MonoBehaviour {

    //private const string URL_SERVER = "http://201.54.204.8:3000";
    private const string URL_SERVER = "http://10.9.30.85:3000";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user">Json do objeto jogador a ser enviado</param>
    /// <param name="CallBackSaveScore"></param>
    /// <returns></returns>
    public static IEnumerator SaveScore(string user, Func<string, string, int> CallBackSaveScore) {

        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers["Content-Type"] = "application/json";

        byte[] pData = System.Text.Encoding.ASCII.GetBytes(user.ToCharArray());

        WWW www = new WWW(URL_SERVER + "/api/player/save-points", pData, headers);

        yield return www;

        Debug.Log(www.error);
        Debug.Log(www.text);

        CallBackSaveScore(www.error, www.text);
    }

    public static IEnumerator RequestQuestion(string codigo, Func<string, string, int> CallBackRequestQuestion) {
        Debug.Log(codigo);
        Debug.Log("POSTING");
        Debug.Log("CREATING WWW");
        WWW www = new WWW(URL_SERVER + "/api/questionnaire/code/" + codigo);
        yield return www;
        Debug.Log("HAVE RESULTS");

        Debug.Log(www.text);
        Debug.Log(www.error);
        CallBackRequestQuestion(www.error, www.text);
    }
}
