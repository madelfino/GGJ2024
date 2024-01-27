using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform toFollow;
    [SerializeField] private Vector3 offset = new Vector3(0f, 10f, -30f);

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = toFollow.position + offset;
    }
}
