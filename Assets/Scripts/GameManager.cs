using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class GameManager : MonoBehaviour
{
    internal static GameManager Instance;

    public TextMeshProUGUI timerText;       
    public TextMeshProUGUI fineText;  
    public TextMeshProUGUI gameoverfineText;  
    public TextMeshProUGUI winfineText;  
    public TextMeshProUGUI wintimeLeftText;  
    public GameObject gameOverPopup;          
    private float timeRemaining = 60f;     
    private bool isGameOver = false;
    public int totalFine = 0;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        gameOverPopup.SetActive(false);           
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        while (timeRemaining > 0 && !isGameOver)
        {
            yield return new WaitForSeconds(1f);     
            timeRemaining--;     
            UpdateTimerDisplay();     
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
        timerText.text = "Time Left: " + Mathf.CeilToInt(timeRemaining).ToString();
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;    
        gameOverPopup.SetActive(true);      

    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

   
}
