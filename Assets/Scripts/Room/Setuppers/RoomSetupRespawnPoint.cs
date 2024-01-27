using MyBox;
using Room.Instances;
using UnityEngine;

namespace Room.Setuppers
{
	public class RoomSetupRespawnPoint : MonoBehaviour
	{
		[MustBeAssigned, SerializeField] private Transform respawnPoint;

		private void Awake()
		{
			//Instantiate the respawn point on the gameObject with all the colliders
			Collider roomCollider = GetComponent<RoomCollider>().GetRoomCollider();
			InstantiatedRespawnPoint rp = roomCollider.gameObject.AddComponent<InstantiatedRespawnPoint>();
			rp.SetRespawnPoint(respawnPoint);
		}
	}
}
