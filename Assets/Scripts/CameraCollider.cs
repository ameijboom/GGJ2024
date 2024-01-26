using Cinemachine;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
	public CinemachineVirtualCamera roomCamera;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("Player entered room " + transform.parent.name);
			roomCamera.enabled = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("Player exited room " + transform.parent.name);
			roomCamera.enabled = false;
		}
	}
}
