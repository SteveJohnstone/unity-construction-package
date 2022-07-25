using System.Collections.Generic;
using UnityEngine;

namespace SteveJstone
{
    [CreateAssetMenu(menuName ="SteveJstone/Building Data")]
    public class BuildingData : ScriptableObject
    {
        [SerializeField] private List<BuildingDefinition> _buildings;
        [SerializeField] private List<BuildingCategory> _categories;

        public List<BuildingDefinition> Buildings => _buildings;
        public List<BuildingCategory> Categories => _categories;
    }
}
