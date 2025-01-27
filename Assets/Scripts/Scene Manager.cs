using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // New audio-related fields
    public AudioClip back;
    public AudioClip click;

    public AudioSource backgroundMusicSource;


    void Start()
    {
        // Ensure AudioSource is set up
        if (backgroundMusicSource == null)
        {
            backgroundMusicSource = gameObject.AddComponent<AudioSource>();
            backgroundMusicSource.loop = true; // Continuous playback
        }
        backgroundMusicSource.clip = back;
        backgroundMusicSource.Play();

    }

    // Function to load a new scene by name
    public void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name is invalid or empty.");
        }
    }

    // Function to exit the application
    public void ExitApplication()
    {
        Debug.Log("Exiting application.");
        Application.Quit();
    }
}
