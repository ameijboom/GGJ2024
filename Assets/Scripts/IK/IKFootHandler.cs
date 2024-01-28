using Player;
using UnityEngine;
using UnityEngine.Events;

namespace IK
{
	public class IKFootHandler : MonoBehaviour
	{
		[SerializeField] private LayerMask terrainLayer = default;
		[SerializeField] private Transform body = default;
		[SerializeField] private IKFootHandler otherFoot = default;
		[SerializeField] private float speed = 1;
		[SerializeField] private float stepDistance = 4;
		[SerializeField] private float stepLength = 4;
		[SerializeField] private float stepHeight = 1;
		[SerializeField] private Vector3 footOffset = default;
		[SerializeField] private UnityEvent onSteppy = new();

		private Jump _jump;
		private float _footSpacing;
		private Vector3 _oldPosition, _currentPosition, _newPosition;
		private Vector3 _oldNormal, _currentNormal, _newNormal;
		private float _lerp;

		private void Awake()
		{
			_jump = GetComponentInParent<Jump>();
		}

		private void Start()
		{
			Transform t = transform;
			_footSpacing = t.localPosition.x;
			_currentPosition = _newPosition = _oldPosition = t.position;
			_currentNormal = _newNormal = _oldNormal = t.up;
			_lerp = 1;
		}

		private void Update()
		{
			Transform t = transform;
			t.position = _currentPosition;
			t.up = _currentNormal;

			Ray ray = new(body.position + body.right * _footSpacing, Vector3.down);

			if (Physics.Raycast(ray, out RaycastHit info, 10, terrainLayer.value))
			{
				if (Vector3.Distance(_newPosition, info.point) > stepDistance && !otherFoot.IsMoving() && _lerp >= 1)
				{
					_lerp = 0;
					int direction = body.InverseTransformPoint(info.point).z > body.InverseTransformPoint(_newPosition).z ? 1 : -1;
					_newPosition = info.point + body.forward * (stepLength * direction) + footOffset;
					_newNormal = info.normal;
					if (_jump.canJump)
					{
						onSteppy.Invoke();
					}
				}
			}

			if (_lerp < 1)
			{
				Vector3 tempPosition = Vector3.Lerp(_oldPosition, _newPosition, _lerp);
				tempPosition.y += Mathf.Sin(_lerp * Mathf.PI) * stepHeight;

				_currentPosition = tempPosition;
				_currentNormal = Vector3.Lerp(_oldNormal, _newNormal, _lerp);
				_lerp += Time.deltaTime * speed;
			}
			else
			{
				_oldPosition = _newPosition;
				_oldNormal = _newNormal;
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawSphere(_newPosition, 0.2f);
		}

		public bool IsMoving()
		{
			return _lerp < 1;
		}
	}
}
