using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPS : MonoBehaviour {

    float deltaTime = 0.0f;
    public Text FPSText;
    private float fps;
     
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        float fps = 1.0f / deltaTime;
        FPSText.text = "" + (int) fps;
    }
}
