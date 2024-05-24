using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class GameManager : MonoBehaviour
{
    internal static GameManager Instance;

    public TextMeshProUGUI timerText;  // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI fineText;  
    public TextMeshProUGUI gameoverfineText;  
    public TextMeshProUGUI winfineText;  
    public TextMeshProUGUI wintimeLeftText;  
    public GameObject gameOverPopup;   // Reference to the Game Over popup GameObject
    private float timeRemaining = 60f; // Total time in seconds
    private bool isGameOver = false;
    public int totalFine = 0;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        gameOverPopup.SetActive(false); // Ensure the game over popup is inactive at the start
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        while (timeRemaining > 0 && !isGameOver)
        {
            yield return new WaitForSeconds(1f); // Wait for 1 second
            timeRemaining--; // Decrease the time remaining
            UpdateTimerDisplay(); // Update the timer UI
        }

        if (timeRemaining <= 0)
        {
            GameOver();
        }
    }
    private void Update()
    {
        fineText.text = "Total Fine: " + Mathf.CeilToInt(totalFine).ToString();
        gameoverfineText.text = "Total Fine: " + Mathf.CeilToInt(totalFine).ToString();
        winfineText.text = "Total Fine: " + Mathf.CeilToInt(totalFine).ToString();
        wintimeLeftText.text = "Time Left: " + Mathf.CeilToInt(timeRemaining).ToString();
    }
    void UpdateTimerDisplay()
    {
        // Display the time remaining in seconds
        timerText.text = "Time Left: " + Mathf.CeilToInt(timeRemaining).ToString();
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0; // Stop the game
        gameOverPopup.SetActive(true); // Show the game over popup

    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

   
}
