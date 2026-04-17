using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SurvivalManager : MonoBehaviour
{
    // timer
    public float timeRemaining = 300f;
    public TextMeshProUGUI timerText;
    // game over
    public GameObject gameOverPanel;
    private bool isGameOver = false;
    // flashing timer
    public Color flashColor = Color.red;
    public Color normalColor = Color.white;
    public float flashSpeed = 5f;

    void Update()
    {
        if (isGameOver) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay(timeRemaining);

            if (timeRemaining <= 10f) {
                flashSpeed = 1f;
            }

            if (timeRemaining <= 20f) {
                flashSpeed = 3f;
            }

            if (timeRemaining <= 30f)
            {
                HandleFlashing();
            }

        } else {
            TriggerGameOver();
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay/60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void HandleFlashing()
    {
        float lerp = Mathf.PingPong(Time.time * flashSpeed, 1.0f);
        timerText.color = Color.Lerp(normalColor, flashColor, lerp);
        float scale = 1f + (lerp * 0.1f);
        timerText.transform.localScale = new Vector3(scale, scale, 1f);
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        timeRemaining = 0;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        flashSpeed = 2f;
    }

    public void RestartGame()
    {
        Time.timeScale= 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
