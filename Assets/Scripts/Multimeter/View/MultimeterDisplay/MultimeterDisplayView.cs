using UnityEngine;
using TMPro;

namespace Multimeter.View
{
    public class MultimeterDisplayView : MonoBehaviour, IMultimeterDisplayView
    {
        [SerializeField] private TMP_Text _text;

        public void SetValue(float value)
        {
            _text.text = value.ToString("F2");
        }
    }
}
