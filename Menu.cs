using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject RestartPannel;
    private string scoreNumber;
    public Text score;

    bool Lose;

    private void Update()
    {
        if (Lose == false)
        {
            score.text = scoreNumber;
            scoreNumber = Time.time.ToString("F0");      //f0 allows to show only full numbers, like 4,5,6. NOT 3.14
        }
        
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene("Lvl1");
    }

    public void Restart()
    {
        scoreNumber = "0";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        scoreNumber = "0";
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        Lose = true;
        RestartPannel.SetActive(true);
    }
}
