using UnityEngine;

namespace SteveJstone
{
    [CreateAssetMenu(menuName = "SteveJstone/Building Type")]
    public class BuildingType : ScriptableObject
    {
        [SerializeField] private string _displayName;

        public string DisplayName => _displayName;
    }
}