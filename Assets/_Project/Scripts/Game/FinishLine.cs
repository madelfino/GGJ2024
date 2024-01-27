using System;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject _toiletReward;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //toilet reward pop up
            if(_toiletReward != null)
                _toiletReward.SetActive(true);
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
