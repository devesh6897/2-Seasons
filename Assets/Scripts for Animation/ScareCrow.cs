using UnityEngine;

public class ScareCrow : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public string Name;
    public ParticleSystem part;
    private void Start()
    {
        // Try to assign the Animator component if not assigned in the Inspector
        if (animator == null)
        {
            part = GetComponent<ParticleSystem>();
            animator = GetComponent<Animator>();
        }

        // Log an error if Animator is still null
        if (animator == null)
        {
            Debug.LogError("Animator component not found or assigned on " + gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Trigger animation on entering the trigger zone
        if (animator != null)
        {
            animator.Play(Name);
          
        }
        else
        {
            Debug.LogWarning("Animator is not assigned. Cannot play 'scare' animation.");
        }
    }

 
}
