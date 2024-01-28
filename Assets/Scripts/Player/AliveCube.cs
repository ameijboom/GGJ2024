using MyBox;
using UnityEngine;

namespace Player
{
	[RequireComponent(typeof(Collider))]
	public class AliveCube : MonoBehaviour
	{
		private void OnValidate()
		{
			Collider[] colliders = GetComponents<Collider>();
			if (colliders.Length != 1)
				Debug.LogError("AliveCube must have exactly one collider!", this);

			colliders.ForEach(col => col.isTrigger = true);
		}

		private void OnTriggerExit(Collider other)
		{
			PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();
			if (playerRespawn == null) return;
			Debug.Log("Player play area! Resetting...");
			playerRespawn.Respawn();
		}
	}
}
