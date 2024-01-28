using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool follow;
    [SerializeField] private Transform toFollow;
    [SerializeField] private Vector3 offset = new Vector3(0f, 10f, -30f);

    void Start() {
        follow = true;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (follow) {
            transform.position = toFollow.position + offset;
        }
    }

    public void SetFollow(bool shouldFollow) {
        follow = shouldFollow;
    }
}
