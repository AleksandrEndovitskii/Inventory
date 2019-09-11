using System;
using UnityEngine;
using Utilities;

namespace Services
{
    public class ColorSelectionService : IInitializable, IUninitializable
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

        public void Initialize()
        {

        }
        public void Uninitialize()
        {

        }
    }
}
