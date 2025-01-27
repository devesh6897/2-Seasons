using System.Collections;
using UnityEngine;

public class DustParticles : MonoBehaviour
{
    public Animator treeAnimator;       // Reference to the Animator component
    public ParticleSystem particle; // Reference to the Particle System
    public string animationName;       // Name of the tree animation
    public float enableTime = 1.5f;    // Time to enable the particle system

    private bool isTriggered = false;  // Prevent multiple triggers

    void Update()
    {
        if (!isTriggered && treeAnimator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            float animationTime = treeAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            if (animationTime >= enableTime / treeAnimator.GetCurrentAnimatorStateInfo(0).length)
            {
                particle.Play(); // Enable the particle system
                isTriggered = true;
            }
        }
    }
}
