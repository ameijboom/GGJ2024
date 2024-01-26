using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody _rb;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		_rb.AddForce(new Vector3(horizontal, 0, vertical) * 10f);
	}
}
