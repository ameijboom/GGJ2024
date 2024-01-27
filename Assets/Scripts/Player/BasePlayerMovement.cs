using UnityEngine;

namespace Player
{
	public class BasePlayerMovement : MonoBehaviour
	{
		[SerializeField] private float movementSpeed;
		[SerializeField] private float rotationSpeed;

		private Rigidbody _rb;
		private Quaternion _direction;

		private void Awake()
		{
			_rb = GetComponent<Rigidbody>();
			_direction = _rb.rotation;
		}


		private void FixedUpdate()
		{
			float horizontal = Input.GetAxis("Horizontal");
			//rotate direction according to horizontal input
			_direction *= Quaternion.AngleAxis(horizontal * rotationSpeed * Time.fixedDeltaTime, Vector3.up);
			_rb.rotation = _direction;
			//move player in the direction it's facing
			_rb.AddForce(_direction * Vector3.forward * (movementSpeed * Time.fixedDeltaTime), ForceMode.Force);
		}
	}
}
