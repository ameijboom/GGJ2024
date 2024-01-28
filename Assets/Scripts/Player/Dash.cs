using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
	public class Dash : MonoBehaviour
	{
		[FormerlySerializedAs("_dashPower")] [SerializeField] private float dashPower;

		private Rigidbody _rb;

		private void Start()
		{
			_rb = GetComponent<Rigidbody>();

		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.W))
			{
				DoDash();
			}
		}

		public void DoDash()
		{
			_rb.AddForce(_rb.rotation * Vector3.forward * (dashPower * Time.fixedDeltaTime), ForceMode.Impulse);
		}
	}
}
