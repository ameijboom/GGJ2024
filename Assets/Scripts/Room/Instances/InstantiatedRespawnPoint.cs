using JetBrains.Annotations;
using UnityEngine;

namespace Room.Instances
{
	public class InstantiatedRespawnPoint : MonoBehaviour
	{
		[CanBeNull] private Transform _respawnPoint = null;

		public void SetRespawnPoint(Transform respawnPoint)
		{
			if (_respawnPoint != null) throw new UnityException("Respawn point was already set!");
			_respawnPoint = respawnPoint;
		}

		public Transform GetRespawnPoint()
		{
			if (_respawnPoint == null) throw new UnityException("Respawn point was not set!");
			return _respawnPoint;
		}
	}
}
