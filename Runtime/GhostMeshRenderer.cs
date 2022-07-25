using UnityEngine;

namespace SteveJstone
{
    [ExecuteAlways]
    public class GhostMeshRenderer : MonoBehaviour
    {
        [SerializeField] private Mesh _mesh;
        [SerializeField] private Material _material;

        public Mesh Mesh { get => _mesh; set => _mesh = value; }
        public Material Material { get => _material; set => _material = value; }

        void Update()
        {
            if (_mesh == null || _material == null) return;

            Graphics.DrawMesh(_mesh, transform.localToWorldMatrix, _material, 0);
        }
    }
}
