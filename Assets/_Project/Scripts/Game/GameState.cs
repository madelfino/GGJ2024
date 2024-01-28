using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : Observer
{
    [Tooltip("used this object to check whether it's active. if it's active then Time Load Next Scene will work")]
    [SerializeField] private GameObject _toiletReward;
    [Tooltip("define time, used for loading to wait Toilet Reward to finish displaying, then load to next scene")]
    [SerializeField] private float _timeLoadNextScene;

    [SerializeField] private GameObject _gameOverCanvas;
    [Header("Script to Stop")] 
    [SerializeField] private PlayerHealth _playerHealth; 
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PainScale _painScale;

    private bool _isGameOver;
    private void Update()
    {
        DecreaseTime();
    }

    private void DecreaseTime()
    {
        if (_toiletReward.activeSelf && _timeLoadNextScene > 0)
        {
            _timeLoadNextScene -= Time.deltaTime;
        }
        else if (_timeLoadNextScene <= 0)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        if (_timeLoadNextScene <= 0)
        {
            SceneManager.LoadScene(((SceneManager.GetActiveScene().buildIndex + 1) + SceneManager.sceneCountInBuildSettings) % SceneManager.sceneCountInBuildSettings);
        }
    }

    public override void ReceiveSignal(SubjectOfObserver subject)
    {
        if (_playerHealth && _playerHealth.Health <= 0)
        {
            //pop up game over obj
            _isGameOver = true;
            StartCoroutine(nameof(GameOver));
        }
        else if(_playerHealth == null)
        {
            throw new NullReferenceException();
        }
    }

    IEnumerator GameOver()
    {
        yield return null;
        if (_isGameOver)
        {
            _playerHealth.enabled = false;
            _playerController.enabled = false;
            _painScale.enabled = false;
            _gameOverCanvas.SetActive(true);
        }
    }
}
