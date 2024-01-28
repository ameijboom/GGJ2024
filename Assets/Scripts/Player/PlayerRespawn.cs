using JetBrains.Annotations;
using MyBox;
using Room.Instances;
using UnityEngine;

namespace Player
{
	[RequireComponent(typeof(BasePlayerMovement))]
	public class PlayerRespawn : MonoBehaviour
	{
		[SerializeField, ReadOnly] [CanBeNull] private Transform lastRespawnPoint = null;

		private Rigidbody _rb;
		private BasePlayerMovement _playerMovement;

		private void Awake()
		{
			_rb = GetComponent<Rigidbody>();
			_playerMovement = GetComponent<BasePlayerMovement>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				Respawn();
			}
		}

		private void OnCollisionEnter(Collision other)
		{
			OnTriggerEnter(other.collider);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Room"))
			{
				InstantiatedRespawnPoint respawnPoint = other.GetComponent<InstantiatedRespawnPoint>();
				if (respawnPoint == null) throw new UnityException("Room collider has no respawn point!");
				lastRespawnPoint = respawnPoint.GetRespawnPoint();
			}
			else if (other.CompareTag("Respawn"))
			{
				Respawn();
			}
		}

		[ButtonMethod]
		public void Respawn()
		{
			if (lastRespawnPoint == null) throw new UnityException("Don't have a respawn point!");

			Quaternion spawnRotation = lastRespawnPoint.rotation;
			Vector3 spawnPosition = lastRespawnPoint.position;

			Transform playerTransform = transform;
			playerTransform.position = spawnPosition;
			playerTransform.rotation = spawnRotation;

			_rb.position = spawnPosition;
			_rb.rotation = spawnRotation;
			_rb.velocity = Vector3.zero;
			_rb.angularVelocity = Vector3.zero;

			_playerMovement.ResetDirection();
		}
	}
}
