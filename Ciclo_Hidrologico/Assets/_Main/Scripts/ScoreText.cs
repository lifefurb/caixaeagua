using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

	private float m_Speed;
	private Vector3 m_Direction;
	private float m_FadeTime;
	
	// Update is called once per frame
	void Update () {
		float translation = m_Speed * Time.deltaTime;

		transform.Translate (m_Direction * translation);
	}

	public void Inicialize(float speed, Vector3 direction, float fadeTime){
		m_Speed = speed;
		m_Direction = direction;
		m_FadeTime = fadeTime;

		StartCoroutine (FadeOut());
	}

	private IEnumerator FadeOut(){
		float starAlpha = GetComponent<Text> ().color.a;

		float rate = 1.0f / m_FadeTime;
		float progress = 0.0f;

		while(progress < 1.0){
			Color tempColor = GetComponent<Text> ().color;
			GetComponent<Text> ().color = new Color (tempColor.r, tempColor.g, tempColor.b, Mathf.Lerp(starAlpha, 0, progress));

			progress += rate * Time.deltaTime;
		
			yield return null;
		}

		Destroy (gameObject);
	}
}
