using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpable : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<Rigidbody>().mass = 1f;
            other.gameObject.GetComponent<Rigidbody>().drag = 2f;
            other.gameObject.GetComponent<Jump>().canJump = true;
        }
    }
}
