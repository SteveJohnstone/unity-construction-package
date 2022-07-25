using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using SteveJstone;
using UnityEngine;

namespace SteveJstone
{
    public class RotateBuilding : MonoBehaviour
    {
        [SerializeField] private BuildSystemInputReader _inputReader;
        [SerializeField] private float _rotation;
        [SerializeField] private float _rotationDuration = 1f;
        private bool _isRotating;
        private TweenerCore<float, float, FloatOptions> _rotationTween;

        private void Start()
        {
            _inputReader.RotateBuildingEvent += OnRotateBuilding;
        }

        public void Update()
        {
            var rotation = transform.localEulerAngles;
            _rotation %= 360;
            rotation.y = _rotation;
            transform.localEulerAngles = rotation;
        }

        private void OnRotateBuilding()
        {
            if (_rotationTween != null && _rotationTween.IsActive()) return;

            _rotationTween = DOTween.To(() => _rotation, x => _rotation = x, _rotation - 90, _rotationDuration);
        }
    }
}
