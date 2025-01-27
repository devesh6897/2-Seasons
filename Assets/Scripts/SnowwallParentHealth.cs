using System.Collections.Generic;
using UnityEngine;

public class SnowwallParentHealth : MonoBehaviour
{

    public GameObject FloatingText;
    public int Maxhealth = 90; // Health of the snowwall parent\
    public int CurrentHealth = 90;
    public int hit = 30;

    public AudioClip destroy; // Drag and drop your sound effect in the Inspector

    public AudioSource audioSource; // Reference to the AudioSource component


    public List<GameObject> SNOWWALL;

    public PlayerTap increment;
    [SerializeField] private bool SnowWall, other;

    void Start()
    {
        // If no AudioSource is assigned, try to get component or add one
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        // Automatically add and enable the Outline component for SnowWall and "other" objects
        if (SnowWall || other)
        {
            var outline = GetComponent<Outline>();
            if (outline == null)
            {
                outline = gameObject.AddComponent<Outline>();
            }
            outline.enabled = true;
            outline.OutlineColor = Color.red; // Adjust outline color if needed
            outline.OutlineWidth = 2.5f;       // Adjust outline width if needed
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        CurrentHealth = CurrentHealth - hit;
        Debug.Log("currenthealt:" + CurrentHealth);
        if (CurrentHealth == 0)
        {

            if (SnowWall)
            {

                foreach (var blocks in SNOWWALL)
                {
                    //Check if the collider is a damaging object (e.g., "Bubble")
                    if (blocks != null)
                    {
                        blocks.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                        blocks.gameObject.GetComponent<Rigidbody>().useGravity = true;





                    }
                }
                showfloatingtext();
                increment.increaseBallcount_five();

            }
            if (other)
            {
                increment.increaseBallcount_five();


                Destroy(collision.gameObject);

                Destroy(gameObject);
                showfloatingtext();

                increment.increaseBallcount_three();
            }

            audioSource.PlayOneShot(destroy);


        }


    }

    void showfloatingtext()
    {
        Debug.Log("float");

        Instantiate(FloatingText, transform.position, Quaternion.identity);
    }


}
