using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource m_AudioSource;
    public AudioClip m_RightAnswerAudio;
    public AudioClip m_WrongAnswerAudio;
    public AudioClip m_WinAudio;

    public void PlayRightAnswerAudio() {
        m_AudioSource.clip = m_RightAnswerAudio;
        m_AudioSource.Play();
    }

    public void PlayWrongAnswerAudio() {
        m_AudioSource.clip = m_WrongAnswerAudio;
        m_AudioSource.Play();
    }

    public void PlayWinAudio() {
        m_AudioSource.clip = m_WinAudio;
        m_AudioSource.Play();
    }
}
