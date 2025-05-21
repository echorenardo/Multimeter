using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Initializing;
using System;

namespace Multimeter.View
{
    public class MeasuredValuesUI : MonoBehaviour, IMeasuredValuesUI, IInitializable
    {
        private const string ACVoltageLetter = "V";
        private const string AmpereLetter = "A";
        private const string DCVoltageLetter = "~";
        private const string ResistanceLetter = "Ω";

        [SerializeField] private TMP_Text _ACVoltageText;
        [SerializeField] private TMP_Text _ampereText;
        [SerializeField] private TMP_Text _DCVoltageText;
        [SerializeField] private TMP_Text _resistanceText;

        private Dictionary<PhysicalQuantityType, Action<float>> _setttingQuantityValueActions = new();

        public void Initialize()
        {
            _setttingQuantityValueActions.Add(PhysicalQuantityType.ACVoltage, SetACVoltageValue);
            _setttingQuantityValueActions.Add(PhysicalQuantityType.Ampere, SetAmpereValue);
            _setttingQuantityValueActions.Add(PhysicalQuantityType.DCVoltage, SetDCVoltageValue);
            _setttingQuantityValueActions.Add(PhysicalQuantityType.Resistance, SetResistanceValue);
        }

        public void SetValue(PhysicalQuantityType physicalQuantityType, float value)
        {
            foreach (var action in _setttingQuantityValueActions.Values)
                action?.Invoke(0);

            if (_setttingQuantityValueActions.ContainsKey(physicalQuantityType))
                _setttingQuantityValueActions[physicalQuantityType].Invoke(value);
        }

        private void SetACVoltageValue(float value) => _ACVoltageText.text = ACVoltageLetter + " " + value.ToString("F2");
        private void SetDCVoltageValue(float value) => _DCVoltageText.text = DCVoltageLetter + " " + value.ToString("F2");
        private void SetAmpereValue(float value) => _ampereText.text = AmpereLetter + " " + value.ToString("F2");
        private void SetResistanceValue(float value) => _resistanceText.text = ResistanceLetter + " " + value.ToString("F2");
    }
}