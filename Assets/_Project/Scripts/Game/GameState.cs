using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [Tooltip("used this object to check whether it's active. if it's active then Time Load Next Scene will work")]
    [SerializeField] private GameObject _toiletReward;
    [Tooltip("define time, used for loading to wait Toilet Reward to finish displaying, then load to next scene")]
    [SerializeField] private float _timeLoadNextScene;
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
}
