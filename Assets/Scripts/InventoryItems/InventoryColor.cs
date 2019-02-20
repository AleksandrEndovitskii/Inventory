using System;
using UnityEngine;

namespace InventoryItems
{
    public class InventoryColor : IInventoryItem
    {
        //public Action<InventoryColor> InventoryColorChanged = delegate { };

        //private Color _color;
        public Color Color
        {
            get;
            private set;
        }
        //{
        //    get
        //    {
        //        return _color;
        //    }
        //    set
        //    {
        //        var bufferValue = _color;
        //        _color = value;

        //        if (_color != bufferValue)
        //        {
        //            InventoryColorChanged.Invoke(this);
        //        }
        //    }
        //}

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
