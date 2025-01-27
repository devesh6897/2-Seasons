using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleTime : MonoBehaviour
{
    public GameObject dust;
    public float destroytime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroytime);

    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    GameObject newBubble = Instantiate(dust, transform.position, Quaternion.identity);

    //}
}
