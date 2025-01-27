using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu; // Reference to the pause menu UI
    private bool isPaused = false;

    void Start()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false); // Ensure pause menu is hidden at the start
        }
    }

    void Update()
    {
        // Toggle pause when the "Escape" key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); // Close the pause menu
            }
            else
            {
                PauseGame(); // Open the pause menu
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Stop the game time
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true); // Show the pause menu
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume the game time
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false); // Hide the pause menu
        }
    }

    public void ReloadScene()
    {
        Time.timeScale = 1f; // Ensure the game is not paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name is invalid or empty.");
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playmode in the Unity Editor
#else
        Application.Quit(); // Quit the game when built
#endif
    }
}
