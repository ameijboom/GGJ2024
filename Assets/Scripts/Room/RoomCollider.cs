using MyBox;
using UnityEngine;

namespace Room
{
	public class RoomCollider : MonoBehaviour
	{
		[MustBeAssigned] [SerializeField] private Collider roomCollider;
		public Collider GetRoomCollider() => roomCollider;

		private void OnValidate()
		{
			Collider[] colliders = roomCollider.gameObject.GetComponentsInChildren<Collider>();
			if (colliders.Length == 0)
				Debug.LogError("No colliders found on roomCameraCollider", roomCollider);
			colliders.ForEach(col => col.isTrigger = true);
		}
	}
}
