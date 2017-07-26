using UnityEngine;
using UnityEngine.UI;

public class ScoreTextManager : MonoBehaviour {
    
	public GameObject m_TextPrefab;
    public RectTransform m_CanvasMain;
	public float m_Speed;
	public float m_FadeTime;

	private static ScoreTextManager instance;

	//permite acessar qualquer componente da classe
	public static ScoreTextManager Instance{
		get{ 
			if(instance == null){
				instance = FindObjectOfType<ScoreTextManager>();
			}
			return instance;
		}
	}

	public void CreateText(Vector3 position, string text, Color color){
		Vector3 m_Direction = new Vector3(0, -1, 0);
		GameObject scoreText = Instantiate(m_TextPrefab, position, Quaternion.identity);
		scoreText.transform.SetParent (m_CanvasMain.transform);
		scoreText.GetComponent<ScoreText> ().Inicialize (m_Speed, m_Direction, m_FadeTime);
		scoreText.GetComponent<Text> ().text = text;
		scoreText.GetComponent<Text> ().color = color;
    }
}
