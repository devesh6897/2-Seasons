using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch2 : MonoBehaviour
{
    public Animator animator; // Drag the Animator component here
      // Set the scene name in the Inspector

    private bool hasSwitchedScene = false;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (animator == null)
        {
            Debug.LogError("Animator is not assigned or found!");
        }
    }

    void Update()
    {
        // Ensure we switch the scene only once
        if (!hasSwitchedScene && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 &&
            !animator.IsInTransition(0))
        {
            hasSwitchedScene = true;
            Debug.Log("Animation ended. Switching to scene: " + "sarvaghya MAIN UPDATED");
            SceneManager.LoadScene("sarvaghya MAIN UPDATED");
        }
    }
}