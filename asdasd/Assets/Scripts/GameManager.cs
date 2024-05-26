using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI targetNumberText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI countdownText;
    public Image[] hearts;
    public GameObject[] boxes;
    public Transform playerTransform;

    private int targetNumber;
    private int playerHealth = 3;
    private int score = 0;
    private float timeRemaining = 15f;
    private GameObject targetBox;
    private bool isTimerRunning = false;
    private Vector3 playerStartPos;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playerStartPos = playerTransform.position;
        UpdateHearts();
        UpdateScore();
        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimer();
            }
            else
            {
                timeRemaining = 0;
                isTimerRunning = false;
                GameOver();
            }
        }
    }

    IEnumerator StartCountdown()
    {
        countdownText.gameObject.SetActive(true);

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        countdownText.text = "Go!";
        yield return new WaitForSeconds(1);
        countdownText.gameObject.SetActive(false);

        StartNewRound();
        isTimerRunning = true;
    }

    void StartNewRound()
    {
        GenerateTargetNumber();
        AssignNumbersToBoxes();
        StartCoroutine(HideNumbers());
        timeRemaining = 15f;
        isTimerRunning = true;
    }

    void GenerateTargetNumber()
    {
        int operationType = Random.Range(0, 3);
        int num1 = Random.Range(1, 50);
        int num2 = Random.Range(1, 50);

        switch (operationType)
        {
            case 0:
                targetNumber = num1 + num2;
                targetNumberText.text = num1.ToString() + " + " + num2.ToString() + " = ?";
                break;
            case 1:
                targetNumber = num1 - num2;
                targetNumberText.text = num1.ToString() + " - " + num2.ToString() + " = ?";
                break;
            case 2:
                targetNumber = num1 * num2;
                targetNumberText.text = num1.ToString() + " * " + num2.ToString() + " = ?";
                break;
        }

        if (targetNumber < 1 || targetNumber > 99)
        {
            GenerateTargetNumber();
        }
    }

    void AssignNumbersToBoxes()
    {
        List<int> numbers = new List<int>();
        for (int i = 1; i <= 100; i++)
        {
            numbers.Add(i);
        }

        int targetIndex = Random.Range(0, boxes.Length);
        targetBox = boxes[targetIndex];
        targetBox.GetComponentInChildren<TextMeshProUGUI>().text = targetNumber.ToString();
        numbers.Remove(targetNumber);

        foreach (GameObject box in boxes)
        {
            if (box != targetBox)
            {
                int randomIndex = Random.Range(0, numbers.Count);
                int number = numbers[randomIndex];
                box.GetComponentInChildren<TextMeshProUGUI>().text = number.ToString();
                numbers.RemoveAt(randomIndex);
            }
        }
    }

    IEnumerator HideNumbers()
    {
        yield return new WaitForSeconds(2.5f);
        foreach (GameObject box in boxes)
        {
            box.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
    }

    public void CheckBox(GameObject box)
    {
        if (box == targetBox)
        {
            AudioManager.instance.PlaySoundEffect(AudioManager.instance.correctBoxSound);
            score += 10;
            UpdateScore();
            StartNewRound();
        }
        else
        {
            AudioManager.instance.PlaySoundEffect(AudioManager.instance.incorrectBoxSound);
            PlayerHitTrap(false);
        }
    }

    public void PlayerHitTrap(bool isTrap)
    {
        playerHealth--;
        UpdateHearts();
        if (playerHealth <= 0)
        {
            AudioManager.instance.PlaySoundEffect(AudioManager.instance.gameOverSound);
            GameOver();
        }
        else if (isTrap)
        {
            playerTransform.position = playerStartPos;
        }
    }

    void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogError("scoreText is not assigned!");
        }
    }

    void UpdateTimer()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
        }
        else
        {
            Debug.LogError("timerText is not assigned!");
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        PlayerPrefs.SetInt("LastScore", score);
        AudioManager.instance.StopMusic();
        SceneManager.LoadScene("GameOver");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tuzak"))
        {
            PlayerHitTrap(true);
        }
    }
}
