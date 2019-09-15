using System;
using UnityEngine;

namespace Services
{
    public class ColorSelectionService
    {
        public Action<Color> SelectedColorChanged = delegate { };

        private Color _selectedColor;
        public Color SelectedColor
        {
            get
            {
                return _selectedColor;
            }
            set
            {
                if (value == _selectedColor)
                {
                    return;
                }

                Debug.Log(string.Format("SelectedColor value changed from {0} to {1}",
                    _selectedColor, value));

                _selectedColor = value;

                SelectedColorChanged.Invoke(_selectedColor);
            }
        }
    }
}
