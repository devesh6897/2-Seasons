using UnityEngine;

public class PlayerGesture : MonoBehaviour
{
    public GameObject bubble;
    public float shootForce = 10f;
    public float minSlideDistance = 50f; // Minimum slide distance to trigger shoot

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    void Update()
    {
        // Mobile touch input handling
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    endTouchPosition = touch.position;

                    // Check if slide distance is sufficient
                    if (Vector2.Distance(startTouchPosition, endTouchPosition) > minSlideDistance)
                    {
                        // Create a ray from the camera through the end touch position
                        Ray ray = Camera.main.ScreenPointToRay(endTouchPosition);

                        // Create a plane at a fixed distance
                        Plane plane = new Plane(Vector3.forward, new Vector3(0, 0, 10));

                        // Calculate the point where the ray intersects the plane
                        float distance;
                        if (plane.Raycast(ray, out distance))
                        {
                            // Get the point of intersection
                            Vector3 hitPoint = ray.GetPoint(distance);

                            // Calculate shoot direction
                            Vector3 shootDirection = (hitPoint - transform.position).normalized;

                            // Instantiate bubble at player's position
                            GameObject newBubble = Instantiate(bubble, transform.position, Quaternion.identity);

                            // Add force to bubble
                            Rigidbody bubbleRigidbody = newBubble.GetComponent<Rigidbody>();
                            if (bubbleRigidbody != null)
                            {
                                bubbleRigidbody.AddForce(shootDirection * shootForce, ForceMode.Impulse);
                            }
                        }
                    }
                    break;
            }
        }
    }
}