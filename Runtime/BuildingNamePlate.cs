using TMPro;
using UnityEngine;

namespace SteveJstone
{
    [ExecuteAlways]
    public class BuildingNamePlate : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        void OnEnable()
        {
            _text.text = name;
        }
    }
}