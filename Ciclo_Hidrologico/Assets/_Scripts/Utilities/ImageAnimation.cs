using UnityEngine;

public class ImageAnimation : MonoBehaviour {

    public float m_MaxSize;
    public float m_Speed;

    private bool mMaxSize;

	// Update is called once per frame
	void Update () {
        if (!mMaxSize && transform.localScale.x < m_MaxSize)
            transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * m_Speed, transform.localScale.y + Time.deltaTime * m_Speed, transform.localScale.z + Time.deltaTime * m_Speed);
        else
            mMaxSize = true;

        if (mMaxSize && transform.localScale.x > 1)
            transform.localScale = new Vector3(transform.localScale.x - Time.deltaTime * m_Speed, transform.localScale.y - Time.deltaTime * m_Speed, transform.localScale.z - Time.deltaTime * m_Speed);
        else
            mMaxSize = false;
    }
}
