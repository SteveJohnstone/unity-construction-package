using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteveJstone
{
    public class FollowGroundCursor : MonoBehaviour
    {
        [SerializeField] private bool _snapToWorldGrid = false;
        [Range(0, 1)]
        [SerializeField] private float _snapSpeed = .5f;
        [SerializeField] private Vector2 _snapOffset = Vector3.zero;
        [SerializeField] private int _snapIncrements = 5;

        private Vector3 _targetPosition;

        private void Start()
        {
            _targetPosition = transform.position;
        }

        private void Update()
        {
            var position = Ground.GetMousePosition();

            if (_snapToWorldGrid)
            {
                position.x = Mathf.Floor(position.x / _snapIncrements) * _snapIncrements;
                position.z = Mathf.Floor(position.z / _snapIncrements) * _snapIncrements;
            }

            _targetPosition = position + transform.rotation * new Vector3(_snapOffset.x, 0, _snapOffset.y);

            transform.position = Vector3.Lerp(transform.position, _targetPosition, _snapSpeed);
        }
    }
}
