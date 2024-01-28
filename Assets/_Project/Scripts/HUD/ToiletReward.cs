using System;
using UnityEngine;

public class ToiletReward : MonoBehaviour
{
    [Tooltip("define how large the model will be inflated to")]
    [SerializeField] private Vector3 _fullScale;

    [SerializeField] private float _inflateSpeed;
    [Header("Rotated Angle Set Up")]
    [SerializeField] private float _posXToBe;
    [SerializeField] private float _posYToBe;
    [SerializeField] private float _posZToBe;
    
    [Header("Rotated Angle Set Up")]
    [SerializeField] private float _angleXToRotate;
    [SerializeField] private float _angleYToRotate;
    [SerializeField] private float _angleZToRotate;
    [SerializeField] private float _rotateSpeed;
    private void Start()
    {
        print("move");
        Camera.main.GetComponent<CameraController>().SetFollow(false);
        transform.position = new Vector3(_posXToBe, _posYToBe, _posZToBe);
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
