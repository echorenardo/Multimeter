using UnityEngine;
using Initializing;
using System.Collections.Generic;

namespace Multimeter.View
{
    public class MultimeterScrollerView : MonoBehaviour, IMultimeterScrollerView, IInitializable
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Material _highlightedMaterial;

        private Material _defaultMaterial;

        private Dictionary<PhysicalQuantityType, int> _scrollerAngles = new();

        public void Initialize()
        {
            _defaultMaterial = _renderer.material;

            FillScrollerAngles();
        }

        public void Highlight(bool isHighlighted)
        {
            _renderer.material = isHighlighted ? _highlightedMaterial : _defaultMaterial;
        }

        public void SetScrollerPosition(PhysicalQuantityType physicalQuantity)
        {
            if (_scrollerAngles.ContainsKey(physicalQuantity) == false)
                throw new System.Exception("This quantity is not exist");

            transform.localRotation = Quaternion.Euler(0, 0, _scrollerAngles[physicalQuantity]);
        }

        private void FillScrollerAngles()
        {
            _scrollerAngles.Add(PhysicalQuantityType.None, 0);
            _scrollerAngles.Add(PhysicalQuantityType.Ampere, -87);
            _scrollerAngles.Add(PhysicalQuantityType.Resistance, -45);
            _scrollerAngles.Add(PhysicalQuantityType.ACVoltage, 50);
            _scrollerAngles.Add(PhysicalQuantityType.DCVoltage, 90);
        }
    }
}