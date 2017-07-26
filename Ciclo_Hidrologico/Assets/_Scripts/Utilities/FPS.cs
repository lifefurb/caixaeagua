using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Calcula o FPS da cena atual.
/// Para que o script funcione basta colocá-lo em algum objeto Text da cena.
/// </summary>
public class FPS : MonoBehaviour {

    private float deltaTime = 0.0f;
    private float fps;
     
    void Update() {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }
    
    void OnGUI() {
        fps = 1.0f / deltaTime;
        gameObject.GetComponent<Text>().text = "" + (int) fps;
    }
}
