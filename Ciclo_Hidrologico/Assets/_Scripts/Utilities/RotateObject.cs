using UnityEngine;

/// <summary>
/// Rotaciona o objeto no eixo y.
/// A velocidade de rotação pode ser controlada através da variável pública m_Speed.
/// </summary>
public class RotateObject : MonoBehaviour {

    public int m_Speed = 1;
    
	void Update () {
        float y = transform.eulerAngles.y + (Time.deltaTime * m_Speed);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, y, transform.eulerAngles.z);
    }
}
