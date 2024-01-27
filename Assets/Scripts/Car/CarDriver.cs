using UnityEngine;

namespace Car
{
	public class CarDriver : MonoBehaviour
	{
		[SerializeField] private float speed;

		private void Update()
		{
			Transform t = transform;
			t.position += t.forward * (speed * Time.deltaTime);
		}
	}
}
