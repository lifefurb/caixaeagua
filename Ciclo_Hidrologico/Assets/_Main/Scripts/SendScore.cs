using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class SendScore : MonoBehaviour {

    private const string URL_SERVER = "http://201.54.204.10:3000";
    
    public static IEnumerator saveScore(string user, Func<string, string, int>VerificaErro) {
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
        if (www.error != null){
            Debug.Log("Erro: " + www.error);
            VerificaErro(www.error, user);
        }
        else{
            Debug.Log("All OK");
            //Debug.Log("Text: " + www.text);
            VerificaErro(null, www.text);
        }
    }
}
