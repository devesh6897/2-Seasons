using UnityEngine;

public class materialchanger : MonoBehaviour
{
    // Material references
    public Material AutumnMaterial;
    public Material WinterMaterial;
    public Renderer objectRenderer;
    public GameObject autumn;
    public GameObject winter;
    public GameObject leafs;
    public GameObject snowfall;
    public Material AutumnSkybox;
    public Material WinterSkybox;



    private float elapsedTime = 0f;
    public float update_Time = 20.0f;
    private bool isAutumnActive = true;

    void Start()
    {


        objectRenderer = GetComponent<Renderer>();
        SetAutumnMaterial();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= update_Time)
        {
            // Reset timer
            elapsedTime = 0f;
            // Toggle between autumn and winter
            if (isAutumnActive)
            {
                SetWinterMaterial();
            }
            else
            {
                SetAutumnMaterial();
            }
        }
    }

    void SetAutumnMaterial()
    {
        if (AutumnMaterial != null)
        {
            autumn.SetActive(true);
            leafs.SetActive(true);
            objectRenderer.material = AutumnMaterial;
            RenderSettings.skybox = AutumnSkybox; // Set autumn skybox
            winter.SetActive(false);
            snowfall.SetActive(false);
            isAutumnActive = true;


        }
    }

    void SetWinterMaterial()
    {
        if (WinterMaterial != null)
        {
            winter.SetActive(true);
            snowfall.SetActive(true);
            objectRenderer.material = WinterMaterial;
            RenderSettings.skybox = WinterSkybox; // Set winter skybox
            autumn.SetActive(false);
            leafs.SetActive(false);
            isAutumnActive = false;


        }
    }
}