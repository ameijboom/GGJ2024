using IK;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
	public class Jump : MonoBehaviour
	{
		[SerializeField] private List<IKFootHandler> feet;
		private float jumpHeight = 10;
		[SerializeField] private UnityEvent onJump;
		
		private Rigidbody _rb;
		public bool canJump;

		private void Start()
		{
			_rb = GetComponent<Rigidbody>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space) && canJump)
			{
				foreach(IKFootHandler foot in feet)
				{
					foot.enabled = false;
				}
				DoJump();
			}
		}

		private void DoJump()
		{
			onJump.Invoke();
			_rb.AddForce(Vector3.up * (jumpHeight * Time.deltaTime), ForceMode.Impulse);

			_rb.mass = 10f;
			_rb.drag = .5f;
			canJump = false;
			foreach(IKFootHandler foot in feet)
			{
				foot.enabled = true;
			}
		}
	}
}
