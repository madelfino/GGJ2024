using System;
using UnityEngine;

public class ToiletReward : MonoBehaviour
{
    [Tooltip("define how large the model will be inflated to")]
    [SerializeField] private Vector3 _fullScale;

    [SerializeField] private float _inflateSpeed;
    
    [Header("Rotated Angle Set Up")]
    [SerializeField] private float _angleXToRotate;
    [SerializeField] private float _angleYToRotate;
    [SerializeField] private float _angleZToRotate;
    [SerializeField] private float _rotateSpeed;
    private void Start()
    {
        print("move");
        transform.position =
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 5));
    }

    private void Update()
    {
        if (transform.localScale != _fullScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _fullScale, _inflateSpeed * Time.deltaTime);
        }
        transform.Rotate(new Vector3(_angleXToRotate * _rotateSpeed * Time.deltaTime,_angleYToRotate * _rotateSpeed  * Time.deltaTime,_angleZToRotate * _rotateSpeed  * Time.deltaTime));
    }
}
