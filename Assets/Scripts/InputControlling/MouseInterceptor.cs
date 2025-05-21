using System;
using UnityEngine;

namespace InputControlling
{
    public class MouseInterceptor : MonoBehaviour
    {
        public event Action<bool> MouseEnteredZoneChanged;

        private IInputController _inputController;

        public void OnConstruct(IInputController inputController)
        {
            _inputController = inputController;
        }

        private void OnMouseEnter()
        {
            OnEnteredZoneStateChanged(true);
        }

        private void OnMouseExit()
        {
            OnEnteredZoneStateChanged(false);
        }

        private void OnEnteredZoneStateChanged(bool isEntered)
        {
            _inputController.ChangeAvailableState(isEntered);

            MouseEnteredZoneChanged?.Invoke(isEntered);
        }
    }
}