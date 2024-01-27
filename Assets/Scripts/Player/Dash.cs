using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private float _dashPower;
    private Rigidbody _rb;

    void Start() 
    {
        _rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            DoDash();
        }
    }

    private void DoDash() => _rb.AddForce(_rb.rotation * Vector3.forward * (_dashPower * Time.fixedDeltaTime), ForceMode.Impulse);
}
