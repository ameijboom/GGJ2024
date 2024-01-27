using Cinemachine;
using MyBox;
using UnityEngine;

namespace Camera
{
	public class RoomCameraSwitcher : MonoBehaviour
	{
		[MustBeAssigned] [SerializeField] private CinemachineVirtualCamera roomCamera;
		[MustBeAssigned] [SerializeField] private Collider roomCameraCollider;

		private void Awake()
		{
			roomCamera.enabled = false;
			CameraCollider cc = roomCameraCollider.gameObject.AddComponent<CameraCollider>();
			cc.SetCamera(roomCamera);
		}

		private void OnValidate()
		{
			Collider[] colliders = roomCameraCollider.gameObject.GetComponentsInChildren<Collider>();
			if (colliders.Length == 0)
				Debug.LogError("No colliders found on roomCameraCollider", roomCameraCollider);
			colliders.ForEach(col => col.isTrigger = true);
		}
	}
}
