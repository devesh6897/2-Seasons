using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text timeText;

    void Start()
    {
        Debug.Log("Game Over Time: " + PlayerTap.GameOverTime);
        timeText.text = "Time: " + Mathf.FloorToInt(PlayerTap.GameOverTime).ToString() + " sec";
    }


}