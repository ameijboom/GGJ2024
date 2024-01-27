using Cinemachine;
using JetBrains.Annotations;
using UnityEngine;

namespace Room.Instances
{
	public class InstantiatedCameraSwitcher : MonoBehaviour
	{
		[CanBeNull] private CinemachineVirtualCamera _roomCamera = null;

		public void SetCamera(CinemachineVirtualCamera virtualCamera)
		{
			if (_roomCamera != null) throw new UnityException("Camera was already set!");
			_roomCamera = virtualCamera;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!other.CompareTag("Player")) return;
			if (_roomCamera == null) throw new UnityException("Camera was not set!");
			Debug.Log("Player entered room " + transform.parent.name);
			_roomCamera.enabled = true;
		}

		private void OnTriggerExit(Collider other)
		{
			if (!other.CompareTag("Player")) return;
			if (_roomCamera == null) throw new UnityException("Camera was not set!");
			Debug.Log("Player exited room " + transform.parent.name);
			_roomCamera.enabled = false;
		}
	}
}
