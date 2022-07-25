using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace SteveJstone
{
    [RequireComponent(typeof(UIDocument))]
    public class ButtonClickHandler : MonoBehaviour
    {
        [SerializeField] private string _buttonId;
        [SerializeField] private UnityEvent _onButtonClick;
        private UnityEngine.UIElements.Button _button;

        public UnityEvent OnClick => _onButtonClick;

        public void Awake()
        {
            _button = GetComponent<UIDocument>().rootVisualElement.Q<UnityEngine.UIElements.Button>(_buttonId);

            _button.clicked += OnButtonClick;
        }

        private void OnButtonClick()
        {
            _onButtonClick?.Invoke();
        }
    }
}
