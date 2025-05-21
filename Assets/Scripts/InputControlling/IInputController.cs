using System;

namespace InputControlling
{
    public interface IInputController
    {
        public event Action<bool> MultimeterSwitcherScrolled;

        public void ScrollMultimeterSwitcher(bool isForward);

        public void ChangeAvailableState(bool isAvailable);

    }
}