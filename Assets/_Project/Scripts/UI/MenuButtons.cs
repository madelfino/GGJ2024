using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [Tooltip("used to check whether Game Over Canvas is active, to check if the game can be paused or not")]
    [SerializeField] private GameObject _gameOverCanvas;
    [Tooltip("used to check whether Game Over Canvas is active, to check if the game can be paused or not")]
    [SerializeField] private GameObject _pauseMenuCanvas;
    [Tooltip("used to check whether Game Over Canvas is active, to check if the game can be paused or not")]
    [SerializeField] private GameObject _toiletReward;
    private bool _isPaused;

    [Header("Script to Stop")] 
    [Tooltip("script to stop when the game is paused")]
    [SerializeField] private PlayerController _playerController;
    [Tooltip("script to stop when the game is paused")]
    [SerializeField] private PainScale _painScale;
    
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Keyboard.current[Key.Escape].wasPressedThisFrame && !_gameOverCanvas.activeSelf && !_pauseMenuCanvas.activeSelf 
                && !_toiletReward.activeSelf && !_isPaused)
            {
                _playerController.enabled = false;
                _painScale.enabled = false;
                _pauseMenuCanvas.SetActive(true);
                _isPaused = true;
            }
            else if (Keyboard.current[Key.Escape].wasPressedThisFrame && !_gameOverCanvas.activeSelf && _pauseMenuCanvas.activeSelf && _isPaused)
            {
                _playerController.enabled = true;
                _painScale.enabled = true;
                _pauseMenuCanvas.SetActive(false);
                _isPaused = false;
            }
        }
    }

    public void Resume()
    {
        if (_isPaused)
        {
            _playerController.enabled = true;
            _painScale.enabled = true;
            _pauseMenuCanvas.SetActive(false);
            _isPaused = false;
        }
    }
    
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
