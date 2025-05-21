using Initializing;
using InputControlling;
using System;

namespace Multimeter.View
{
    public class MultimeterPresenter : IInitializable, IDisposable
    {
        private MultimeterModel _multimeter;
        private MouseInterceptor _scrollerMouseInterceptor;

        private IMultimeterScrollerView _scrollerView;
        private IMultimeterDisplayView _displayView;
        private IMeasuredValuesUI _measuredValuesUI;

        public MultimeterPresenter(MultimeterModel multimeter, IMultimeterScrollerView scrollerView, IMultimeterDisplayView displayView,
                                   IMeasuredValuesUI measuredValuesUI, MouseInterceptor scrollerMouseInterceptor)
        {
            _multimeter = multimeter;
            _scrollerMouseInterceptor = scrollerMouseInterceptor;

            _scrollerView = scrollerView;
            _displayView = displayView;
            _measuredValuesUI = measuredValuesUI;
        }

        public void Initialize()
        {
            _multimeter.StateChanged += OnMultimeterStateChanged;
            _scrollerMouseInterceptor.MouseEnteredZoneChanged += OnMouseScrollerZoneChanged;
        }

        public void Dispose()
        {
            _multimeter.StateChanged -= OnMultimeterStateChanged;
            _scrollerMouseInterceptor.MouseEnteredZoneChanged -= OnMouseScrollerZoneChanged;
        }

        #region Event Handles

        private void OnMultimeterStateChanged()
        {
            PhysicalQuantityType physicalQuantity = _multimeter.CurrentState.PhysicalQuantityType;

            _scrollerView.SetScrollerPosition(physicalQuantity);
            _displayView.SetValue(_multimeter.CurrentMeasuredValue);
            _measuredValuesUI.SetValue(physicalQuantity, _multimeter.CurrentMeasuredValue);
        }

        private void OnMouseScrollerZoneChanged(bool isEntered)
        {
            _scrollerView.Highlight(isEntered);
        }

        #endregion
    }
}