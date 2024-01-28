using UnityEngine;
using UnityEngine.UI;

public class DirtSplash : Observer
{
    [SerializeField] private Slider _painScaleSlider;
    [SerializeField] private PlayerHealth _playerHealth;

    [SerializeField] private GameObject _firstSplash;
    [SerializeField] private GameObject _secondSplash;
    public override void ReceiveSignal(SubjectOfObserver subject)
    {
        if (_painScaleSlider.value >= 0.7f && _playerHealth.Health == 1)
        {
            //pop up shit screen
            _firstSplash.SetActive(true);
        }
        else if (_painScaleSlider.value >= 0.7f && _playerHealth.Health == 0)
        {
            //pop up shit screen
            _firstSplash.SetActive(false);
            _secondSplash.SetActive(true);
        }
    }
}
