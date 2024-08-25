using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class GameManager : MonoBehaviour
{
    public GameObject retryUI; // Reference to the Game Over UI Button

    private void Start()
    {
        // Ensure the UI elements are hidden at the start
        retryUI.SetActive(false);
    }

    // Call this method when the player dies
    public void GameOver()
    {
        retryUI.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    // Restart the game
    public void RetryGame()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

}
