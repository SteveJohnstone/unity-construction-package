using Sirenix.OdinInspector;
using StrategyGame;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace SteveJstone
{
    [ExecuteAlways]
    [RequireComponent(typeof(UIDocument))]
    public class BuildMenuController : MonoBehaviour
    {
        [SerializeField, Required] private BuildingData _data;
        [SerializeField] private UnityEvent<BuildingDefinition> _onBuildingSelected;

        private VisualElement _root;
        private TabbedList _tabbedList;
        private Logger<BuildMenuController> _logger = new Logger<BuildMenuController>(false);

        public UnityEvent<BuildingDefinition> OnBuildingSelected => _onBuildingSelected;

        private void Awake()
        {
            _logger.Info($"{nameof(Awake)}");

            if (_root == null) _root = GetComponent<UIDocument>().rootVisualElement;
            if (_tabbedList == null) _tabbedList = _root?.Q<TabbedList>("BuildMenu");
            
            Assert.IsNotNull(_root, $"{nameof(BuildMenuController)}.{nameof(Awake)} unable to load root document");
            Assert.IsNotNull(_tabbedList, $"{nameof(BuildMenuController)}.{nameof(Awake)} unable to bind to {nameof(TabbedList)}");

            if (_tabbedList != null)
            {
                Refresh(_data.Categories, _data.Buildings);
            }
        }

        private void OnItemClicked(ItemListElement item)
        {
            var building = item.userData as BuildingDefinition;
            Debug.Log($"{nameof(BuildMenuController)}: building={building.Name}");

            _onBuildingSelected?.Invoke(building);
        }

        private void Refresh(IList<BuildingCategory> categories, IList<BuildingDefinition> buildings)
        {
            _logger.Info($"{nameof(Refresh)}");

            _tabbedList.SectionCount = categories.Count;
            for (int categoryIndex = 0; categoryIndex < categories.Count; categoryIndex++)
            {
                _tabbedList.Tabs.AtIndex(categoryIndex).Title = categories[categoryIndex].DisplayName;
                var section = _tabbedList.Sections.AtIndex(categoryIndex);
                var itemList = section.Q<ItemList>();
                itemList.OnItemClicked += OnItemClicked;

                Assert.IsNotNull(section, $"{nameof(BuildMenuController)}.{nameof(Refresh)} unable to find section at index {categoryIndex}");
                Assert.IsNotNull(itemList, $"{nameof(BuildMenuController)}.{nameof(Refresh)} unable to find item list");

                var categoryBuildings = buildings.Where(x => x.Category == categories[categoryIndex].Name);
                itemList.ItemCount = categoryBuildings.Count();

                for (int buildingIndex = 0; buildingIndex < categoryBuildings.Count(); buildingIndex++)
                {
                    var building = categoryBuildings.ElementAt(buildingIndex);
                    var element = itemList.Items.AtIndex(buildingIndex);
                    element.userData = building;

                    var itemText = element.Q<Label>("ItemText");
                    itemText.text = building.DisplayName;
                }
            }
        }

        private void OnSelectionChange(IEnumerable<object> items)
        {
            foreach (var item in items)
            {
                var building = item as BuildingDefinition;
                _logger.Info($"{building.Name} selected");
            }
        }

        private void OnItemsChosen(IEnumerable<object> items)
        {
            foreach (var item in items)
            {
                var building = item as BuildingDefinition;
                _logger.Info($"{building.Name} chosen");
            }
        }
    }
}
