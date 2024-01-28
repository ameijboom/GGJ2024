using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collisionAudio : MonoBehaviour
{
    [SerializeField] private UnityEvent col;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            col.Invoke();
        }
    }
}
