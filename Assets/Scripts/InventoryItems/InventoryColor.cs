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

        protected bool Equals(InventoryColor other)
        {
            return Color.Equals(other.Color);
        }

        public override int GetHashCode()
        {
            return Color.GetHashCode();
        }
    }
}
