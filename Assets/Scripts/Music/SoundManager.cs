using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioClip backgroundMusicScene0;
    public AudioClip backgroundMusicScene1;
    public AudioClip backgroundMusicScene2;

    public float musicVolume = 0.1f; // Adjust this value for the desired volume

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check the loaded scene and play the appropriate background music
        switch (scene.buildIndex)
        {
            case 0:
                PlayBackgroundMusic(backgroundMusicScene0);
                break;
            case 1:
                PlayBackgroundMusic(backgroundMusicScene1);
                break;
            case 2:
                PlayBackgroundMusic(backgroundMusicScene2);
                break;
                // Add more cases for additional scenes as needed
        }
    }

    private void PlayBackgroundMusic(AudioClip musicClip)
    {
        if (musicClip != null)
        {
            // Adjust the volume before playing the music
            audioSource.volume = musicVolume;

            // Check if the same clip is already playing to avoid restarting it
            if (audioSource.clip != musicClip || !audioSource.isPlaying)
            {
                audioSource.clip = musicClip;
                audioSource.Play();
            }
        }
    }
}