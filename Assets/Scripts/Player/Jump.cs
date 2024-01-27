using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) DoJump();
    }

    private void DoJump()
    {
        _rb.AddForce(Vector3.up * jumpHeight * Time.deltaTime * 10, ForceMode.Impulse);

        _rb.drag = 1f;
    }
}
