using System.Collections;
using UnityEngine;

namespace Car
{
	public class CarSpawner : MonoBehaviour
	{
		[SerializeField] private GameObject carPrefab;

		private float _time;

		private void Update()
		{
			_time += Random.Range(0f, 0.4f) * Time.deltaTime;

			if (_time > 1)
			{
				_time -= Random.Range(0f, 1.2f);
				Transform t = transform;
				GameObject car = Instantiate(carPrefab, t.position, t.rotation);
				StartCoroutine(KillCar(car));
			}
		}

		private static IEnumerator KillCar(Object car)
		{
			yield return new WaitForSeconds(15f);
			Destroy(car);
		}
	}
}
