using UnityEngine;

namespace Player
{
	public class Jumpable : MonoBehaviour
	{
		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

				rb.mass = 1f;
				rb.drag = 2f;
				other.gameObject.GetComponent<Jump>().canJump = true;
			}
		}
	}
}
