using Cinemachine;
using MyBox;
using UnityEngine;

public class Room : MonoBehaviour
{
	[MustBeAssigned] [SerializeField] private Collider roomCameraCollider;
	[MustBeAssigned] [SerializeField] private CinemachineVirtualCamera roomCamera;

	private void Awake()
	{
		roomCamera.enabled = false;
		CameraCollider cc = roomCameraCollider.gameObject.AddComponent<CameraCollider>();
		cc.roomCamera = roomCamera;
	}

	private void OnValidate()
	{
		roomCameraCollider.isTrigger = true;
	}
}
