using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PainScale : Observer
{
    [Tooltip("the time used to let the player breath after loose life (take the wrong action while the scale is red). " +
             "After the set time, the scale can be red again")]
    [SerializeField] private float _recoverTime;
    private float _recoverTimeDecreased;

    [FormerlySerializedAs("_scaleSlider")]
    [Header("Pain Scale Slider")]
    [SerializeField] private Slider _painScaleSlider;
    [SerializeField] private Image _fillImg;
    [SerializeField] private float _scaleSpeed;
    [Tooltip("time used to identify how long to wait so that the next scale's value would be changed")]
    [SerializeField] private float _scalingNextTime;
    private float _endValue;
    private float _scalingNextTimeDecreased;

    private void Start()
    {
        _scalingNextTimeDecreased = _scalingNextTime;
    }

    // Update is called once per frame
    void Update()
    {
        RandomSliderValue();
    }

    private void RandomSliderValue()
    {
        //can * speed after interpolate value
        _painScaleSlider.value = Mathf.Lerp(_painScaleSlider.value, _endValue,  Mathf.SmoothStep(0.0f, 1.0f, _scaleSpeed));
        if (_recoverTimeDecreased > 0)
        {
            _recoverTimeDecreased -= Time.deltaTime;
        }
        _scalingNextTimeDecreased -= Time.deltaTime;
        if (_scalingNextTimeDecreased <= 0)
        {
            if (_recoverTimeDecreased > 0)
            {
                _endValue = Random.Range(0f, 0.5f);
            }
            else if (_endValue >= 0.5f && _endValue < 0.7f)
            {
                _endValue = Random.Range(0.3f, 1f);
            }
            else
            {
                _endValue = Random.Range(0f, 0.6f);
            }

            SetColor();

            _endValue = (float)Math.Round(_endValue, 1);
            _scalingNextTimeDecreased = _scalingNextTime;
        }
    }

    private void SetColor()
    {
        if (_endValue >= 0.7f)
        {
            _fillImg.color = Color.red;
        }
        else if (_endValue >= 0.5f && _endValue < 0.7f)
        {
            _fillImg.color = Color.yellow;
        }
        else
        {
            _fillImg.color = Color.green;
        }
    }

    private void ActionChangeWhileRed()
    {
        _recoverTimeDecreased = 3f;
        _endValue = Random.Range(0, 0.5f);
        _fillImg.color = Color.green;
        print("u die by canceled");
    }

    public override void ReceiveSignal(SubjectOfObserver subject)
    {
        if (_painScaleSlider.value >= 0.7f)
        {
            ActionChangeWhileRed();
        }
    }
}
