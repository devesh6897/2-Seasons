using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    public AudioClip shakesound;
    public AudioSource audioSource;

    public PlayerTap decreament;

    void Start()
    {
       
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {

        Debug.LogWarning("gttttt");

        Shake();
        if (other.CompareTag("scarecrow"))
        {
            decreament.decreaseBallcount_five();
        }
    }

    private void OnTriggerExit(Collider other)
    {

        
            decreament.decreaseBallcount_five();
        
    }


    // Update is called once per frame
    public void Shake()
    {
        if (CameraShaker.Instance != null)
        {
            audioSource.PlayOneShot(shakesound);

            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);

        }
        else
        {
            Debug.LogWarning("CameraShaker instance is null. Make sure EZCameraShake is set up correctly.");
        }

    }
}
