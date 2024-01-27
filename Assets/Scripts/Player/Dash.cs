using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private float _dashPower;
    private Rigidbody _rb;
    private Quaternion _direction;

    void Start() 
    {
        _rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        _direction = _rb.rotation;

        if (Input.GetKeyUp(KeyCode.W))
        {
            DoDash();
        }
    }

    private void DoDash() => _rb.AddForce(_direction * Vector3.forward * (_dashPower * Time.fixedDeltaTime), ForceMode.Impulse);
}
