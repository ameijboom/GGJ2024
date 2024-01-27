using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    private Rigidbody _rb;
    public bool canJump;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump) DoJump();
    }

    private void DoJump()
    {
        _rb.AddForce(Vector3.up * jumpHeight * Time.deltaTime, ForceMode.Impulse);

        _rb.mass = 10f;
        _rb.drag = .5f;
        canJump = false;
    }
}
