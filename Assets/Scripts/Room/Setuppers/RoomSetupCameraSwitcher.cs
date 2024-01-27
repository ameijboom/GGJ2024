using Cinemachine;
using MyBox;
using Room.Instances;
using UnityEngine;

namespace Room.Setuppers
{
	[RequireComponent(typeof(RoomCollider))]
	public class RoomSetupCameraSwitcher : MonoBehaviour
	{
		[MustBeAssigned, SerializeField]  private CinemachineVirtualCamera roomCamera;

		private void Awake()
		{
			roomCamera.enabled = false;

			//Instantiate the camera switcher on the gameObject with all the colliders
			Collider roomCollider = GetComponent<RoomCollider>().GetRoomCollider();
			InstantiatedCameraSwitcher cs = roomCollider.gameObject.AddComponent<InstantiatedCameraSwitcher>();
			cs.SetCamera(roomCamera);
		}
	}
}
