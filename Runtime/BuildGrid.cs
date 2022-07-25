using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SteveJstone
{
    public class BuildGrid : MonoBehaviour
    {
        [SerializeField] private Material _gridMaterial;
        [SerializeField] private float _gridFadeTime = 1f;

        [ReadOnly, SerializeField] private float _gridVisibility = 0;

        private void Update()
        {
            _gridMaterial.SetVector("_Center", Ground.GetMousePosition());
            _gridMaterial.SetFloat("_Opacity", _gridVisibility);
        }

        private void OnDestroy()
        {
            _gridMaterial.SetVector("_Center", Vector3.zero);
        }

        public void Show()
        {
            DOTween.To(() => _gridVisibility, x => _gridVisibility = x, 1f, _gridFadeTime);
        }

        public void Hide()
        {
            DOTween.To(() => _gridVisibility, x => _gridVisibility = x, 0f, _gridFadeTime);
        }
    }
}