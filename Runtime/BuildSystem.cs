using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SteveJstone
{
    public class BuildSystem : MonoBehaviour
    {
        [Title("References")]
        [SerializeField] private ButtonClickHandler _buildButton;
        [SerializeField] private BuildMenuController _buildMenu;
        [SerializeField] private GhostMeshRenderer _ghostMeshRenderer;
        [SerializeField] private BuildGrid _buildGrid;

        [Title("Data")]
        [SerializeField] private BuildingData _buildingData;
        [SerializeField] private PrefabList _prefabs;
        [SerializeField] private MeshList _meshes;

        private BuildingDefinition _currentBuilding;
        private bool _isBuilding;

        private void Awake()
        {
            _buildButton.OnClick.AddListener(OnBuildButtonClick);
            _buildMenu.OnBuildingSelected.AddListener(OnBuildingSelected);

            _ghostMeshRenderer.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (_isBuilding && Mouse.current.leftButton.wasReleasedThisFrame)
            {
                Instantiate(_prefabs.Get(_currentBuilding.Name), _ghostMeshRenderer.transform.position, _ghostMeshRenderer.transform.rotation);
                if (!Keyboard.current.shiftKey.IsPressed())
                {
                    _currentBuilding = null;
                }
            }

            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                _currentBuilding = null;
            }

            _ghostMeshRenderer.gameObject.SetActive(_currentBuilding != null);

            _isBuilding = _currentBuilding != null;
        }

        private void OnBuildingSelected(BuildingDefinition building)
        {
            _ghostMeshRenderer.Mesh = _meshes.Get(building.Name);
            _currentBuilding = building;
            _buildGrid.Show();
        }

        private void OnBuildButtonClick()
        {
            Debug.Log("Build Button Clicked");
        }
    }
}
