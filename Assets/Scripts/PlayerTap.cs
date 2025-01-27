using UnityEngine;
using UnityEngine.UI; // Import for legacy Text component
using UnityEngine.SceneManagement;

public class PlayerTap : MonoBehaviour
{
    public GameObject bubble;
    public float shootForce = 10f;
    public Text bubblesLeftText;
    public int bubblesLeft = 10;

    // New sound-related fields
    public AudioClip tapSound; // Drag and drop your sound effect in the Inspector
    public AudioClip backgroundMusic;
    public AudioSource audioSource; // Reference to the AudioSource component

    public Text timer;
    private float currentTime = 0f; // Track elapsed time

    public static float GameOverTime { get; private set; }


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
        // Play background music if assigned
        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true; // Enable looping for background music
            audioSource.Play();
        }

        UpdateBubblesLeftText();
    }

    void Update()
    {
        // Update time tracking
        currentTime += Time.deltaTime;        
        timer.text = Mathf.FloorToInt(currentTime).ToString() + " sec";

        if (bubblesLeft <= 0)
        {
            GameOverTime = currentTime;

            SceneManager.LoadScene("Game Over");

        }
        if (Input.GetMouseButtonDown(0) && bubblesLeft > 0)
        {
            // Play tap sound if sound and audio source are assigned
            if (tapSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(tapSound);
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.forward, new Vector3(0, 0, 10));
            float distance;
            if (plane.Raycast(ray, out distance))
            {
                Vector3 hitPoint = ray.GetPoint(distance);
                Vector3 shootDirection = (hitPoint - transform.position).normalized;

                GameObject newBubble = Instantiate(bubble, transform.position, Quaternion.identity);
                Rigidbody bubbleRigidbody = newBubble.GetComponent<Rigidbody>();
                if (bubbleRigidbody != null)
                {
                    bubbleRigidbody.AddForce(shootDirection * shootForce, ForceMode.Impulse);
                }

                bubblesLeft--;
                UpdateBubblesLeftText();

            }
        }
    }

   
    void UpdateBubblesLeftText()
    {
        if (bubblesLeftText != null)
        {
            bubblesLeftText.text = bubblesLeft.ToString();
        }
    }

    public void increaseBallcount_three()
    {
        bubblesLeft = bubblesLeft + 3;
        UpdateBubblesLeftText();
    }

    public void increaseBallcount_five()
    {
        bubblesLeft = bubblesLeft + 5;
        UpdateBubblesLeftText();
    }

    public void decreaseBallcount_five()
    {
        bubblesLeft = bubblesLeft - 1;
        UpdateBubblesLeftText();
    }
}