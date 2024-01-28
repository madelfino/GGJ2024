using System;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject _toiletReward;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player reached the restroom!");
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
