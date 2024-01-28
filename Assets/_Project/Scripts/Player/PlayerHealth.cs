using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Observer
{
    public int Health => health;
    private int health = 2;
    [SerializeField] Slider _painScaleSlider;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip loudFartClip;

    public override void ReceiveSignal(SubjectOfObserver subject)
    {
        if (_painScaleSlider.value >= 0.7f)
        {
            Debug.Log("Player Hurt!");
            health--;
            //pop up shit screen

            if (audioSource != null && loudFartClip != null) {
                audioSource.PlayOneShot(loudFartClip);
            }
        }
    }
}
