using UnityEngine;

public class Trees : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public string animationName; // Name of the animation to play
    public ParticleSystem particleSystems; // Reference to the Particle System

    private void Start()
    {
        // Assign Animator and Particle System if not assigned in the Inspector
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (particleSystems == null)
        {
            particleSystems = GetComponentInChildren<ParticleSystem>(); // Try to find Particle System in child objects
        }

        // Log warnings if components are missing
        if (animator == null)
        {
            Debug.LogError("Animator component not found or assigned on " + gameObject.name);
        }

        if (particleSystems == null)
        {
            Debug.LogError("Particle System not found or assigned on " + gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Trigger animation and particle system on entering the trigger zone
        if (animator != null)
        {
            animator.Play(animationName); // Play the specified animation
        }
        else
        {
            Debug.LogWarning("Animator is not assigned. Cannot play the animation.");
        }

        if (particleSystems != null)
        {
            particleSystems.Play(); // Play the particle effect
        }
        else
        {
            Debug.LogWarning("Particle System is not assigned. Cannot play particles.");
        }
    }
}
