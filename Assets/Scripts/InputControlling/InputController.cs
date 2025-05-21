using System;
using UnityEngine;

namespace InputControlling
{
    public class InputController : MonoBehaviour, IInputController
    {
        public event Action<bool> MultimeterSwitcherScrolled;

        private const string MouseScrollAxisName = "Mouse ScrollWheel";

        private float _scrollValue;
        private bool _isAvailable;

        private void Update()
        {
            if (_isAvailable)
                CheckMouseScroll();
        }

        public void ScrollMultimeterSwitcher(bool isForward)
        {
            MultimeterSwitcherScrolled?.Invoke(isForward);
        }

        public void ChangeAvailableState(bool isAvailable)
        {
            _isAvailable = isAvailable;
        }

        private void CheckMouseScroll()
        {
            _scrollValue = Input.GetAxis(MouseScrollAxisName);

            if (_scrollValue != 0)
                OnMouseScroll();
        }

        #region Event Handles

        private void OnMouseScroll()
        {
            if (_scrollValue > 0)
                ScrollMultimeterSwitcher(true);
            else
                ScrollMultimeterSwitcher(false);
        }

        #endregion
    }
}