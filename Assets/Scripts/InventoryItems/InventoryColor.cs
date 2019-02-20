using System;
using UnityEngine;

namespace InventoryItems
{
    public class InventoryColor : IInventoryItem
    {
        public Action<InventoryColor> InventoryColorChanged = delegate { };

        private Color _color;
        public Color Color
        {
            get
            {
                return _color;
            }
            private set
            {
                var bufferValue = _color;
                _color = value;

                if (_color != bufferValue)
                {
                    Debug.Log(string.Format("Inventory color changed from {0} to {1}", bufferValue, _color));
                    InventoryColorChanged.Invoke(this);
                }
            }
        }

        public InventoryColor(Color color)
        {
            Color = color;
        }

        public override bool Equals(object other)
        {
            var item = other as InventoryColor;

            if (item == null)
            {
                return false;
            }

            return Color.Equals(item.Color);
        }

        public override int GetHashCode()
        {
            return Color.GetHashCode();
        }

        public bool TryChangeColor(Color color)
        {
            if (Color != color)
            {
                Color = color;

                return true;
            }

            return false;
        }
    }
}
