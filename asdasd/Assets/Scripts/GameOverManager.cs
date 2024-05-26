using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro kütüphanesini ekleyin
using UnityEngine.SceneManagement; // Sahne yönetimi için

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);
        scoreText.text = "Your Score: " + lastScore.ToString();
    }

    public void RestartGame()
    {
        AudioManager.instance.StopMusic();
        SceneManager.LoadScene("SampleScene"); // Oyun sahnesinin ismini kullanýn

        // Restarting the music
        AudioManager.instance.PlayMusic(AudioManager.instance.backgroundMusic);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
