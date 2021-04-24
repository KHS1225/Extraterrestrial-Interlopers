using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverCamera : MonoBehaviour
{
    public Text DisplayedMessage;

    void Start()
    {
        DisplayedMessage.text = $"You destroyed {PlayerPrefs.GetInt("score")} enemies\nPress 'Q' to quit or Enter to play again.";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DisplayedMessage.text = "Thanks for playing!";
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
