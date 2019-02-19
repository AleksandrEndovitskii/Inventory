using UnityEngine;

namespace InventoryItems
{
    public class InventoryColor : IInventoryItem
    {
        public readonly Color Color;

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
    }
}
