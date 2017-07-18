using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public GameObject m_LoadingScreenPanel;
    public Image m_LoadingBar;
    public Text m_LoadingBarProgressText;

    public void LoadLevel(int sceneIndex) {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex) {
        m_LoadingScreenPanel.SetActive(true);

        AsyncOperation assync = SceneManager.LoadSceneAsync(sceneIndex);
        assync.allowSceneActivation = false;

        while (!assync.isDone) {

            m_LoadingBar.fillAmount = assync.progress;
            m_LoadingBarProgressText.text = (int)(assync.progress * 100) + "%";

            if (assync.progress == .9f) {
                m_LoadingBar.fillAmount = 1f;
                m_LoadingBarProgressText.text = (int)(m_LoadingBar.fillAmount * 100) + "%";

                assync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
