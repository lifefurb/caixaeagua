using UnityEngine;
using System.Collections;

public class GCCamera : MonoBehaviour {

    void Start()
    {
        if (PlayerPrefs.GetInt("volume") == 1)
            EnableSound();
        else
            DisableSound();
    }

    public void EnableSound()
    {
        AudioListener.volume = 1; //Audio do jogo em 100%
    }

    public void DisableSound()
    {
        AudioListener.volume = 0; //Audio do jogo em 0%
    }
}
