using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrMusicPlayer : MonoBehaviour
{
    public AudioClip menuMusicClip;
    public AudioClip gameMusicClip;
    public AudioClip bounceClip;
    public AudioClip deathClip;
    public AudioClip levelFinishClip;
    public AudioClip reviveClip;
    public AudioClip spikeThrowerShotClip;
    public AudioClip turretShotClip;
    public AudioClip starClip;
    public AudioClip checkpointClip;
    AudioSource audioSource;
    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Music") != gameObject)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;
        }
    }

    public void PlayGameMusic()
    {
        if (audioSource.clip != gameMusicClip && PlayerPrefs.GetInt("MusicIsOn") == 1)
        {
            audioSource.clip = gameMusicClip;
            audioSource.Play();
        }
    }

    public void PlayMenuMusic()
    {
        if (audioSource.clip != menuMusicClip && PlayerPrefs.GetInt("MusicIsOn") == 1)
        {
            audioSource.clip = menuMusicClip;
            audioSource.Play();
        }
    }

    public void TurnOffMusic()
    {
        audioSource.Stop();
    }

    public void TurnOnMusic()
    {
        if (SceneManager.GetActiveScene().name.Contains("Menu"))
            audioSource.clip = menuMusicClip;
        else if (SceneManager.GetActiveScene().name.Contains("Level"))
            audioSource.clip = gameMusicClip;
        audioSource.Play();
    }

    public void PlayBounceSound()
    {
        if (PlayerPrefs.GetInt("SoundIsOn") == 1)
            audioSource.PlayOneShot(bounceClip);
    }

    public void PlayDeathSound()
    {
        if (PlayerPrefs.GetInt("SoundIsOn") == 1)
            audioSource.PlayOneShot(deathClip);
    }

    public void PlayLevelFinishSound()
    {
        if (PlayerPrefs.GetInt("SoundIsOn") == 1)
            audioSource.PlayOneShot(levelFinishClip);
    }

    public void PlayReviveSound()
    {
        if (PlayerPrefs.GetInt("SoundIsOn") == 1)
            audioSource.PlayOneShot(reviveClip);
    }

    public void PlaySpikeThrowerShotSound()
    {
        if (PlayerPrefs.GetInt("SoundIsOn") == 1)
            audioSource.PlayOneShot(spikeThrowerShotClip);
    }

    public void PlayTurretShotSound()
    {
        if (PlayerPrefs.GetInt("SoundIsOn") == 1)
            audioSource.PlayOneShot(turretShotClip);
    }

    public void PlayStarSound()
    {
        if (PlayerPrefs.GetInt("SoundIsOn") == 1)
            audioSource.PlayOneShot(starClip);
    }

    public void PlayCheckpointSound()
    {
        if (PlayerPrefs.GetInt("SoundIsOn") == 1)
            audioSource.PlayOneShot(checkpointClip);
    }
}
