using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Observer
{
    public int Health => health;
    private int health = 2;
    [SerializeField] Slider _painScaleSlider;

    public override void ReceiveSignal(SubjectOfObserver subject)
    {
        if (_painScaleSlider.value >= 0.7f)
        {
            health--;
            //pop up shit screen
        }
    }
}
