using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace SteveJstone
{

	[CreateAssetMenu(fileName = "BuildSystemInputReader", menuName = "SteveJstone/Build System Input Reader")]
	public class BuildSystemInputReader : DescriptionBaseSO, BuildSystemControls.IBuildActions
	{
		public event UnityAction RotateBuildingEvent;

		private BuildSystemControls _controls;

		private void OnEnable()
		{
			//Debug.Log("InputReader.OnEnable");
			if (_controls == null)
			{
				_controls = new BuildSystemControls();
				_controls.Build.SetCallbacks(this);
				_controls.Build.Enable();
			}
		}

		private void OnDisable()
		{
			DisableAllInput();
		}

		public void DisableAllInput()
		{
			_controls.Build.Disable();
		}

		public bool LeftMouseDown => Mouse.current.leftButton.isPressed;
		public bool MiddleMouseDown => Mouse.current.middleButton.isPressed;


		public void OnRotateBuilding(InputAction.CallbackContext context)
		{
			RotateBuildingEvent?.Invoke();
		}
	}
}