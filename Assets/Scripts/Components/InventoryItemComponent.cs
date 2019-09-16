using System;
using InventoryItems;
using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    [RequireComponent(typeof(Image))]
    public class InventoryItemComponent : MonoBehaviour
    {
        public Action<IInventoryItem> InventoryItemChanged = delegate { };

        public IInventoryItem InventoryItem
        {
            get
            {
                return _inventoryItem;
            }
            set
            {
                if (value == _inventoryItem)
                {
                    return;
                }

                _inventoryItem = value;

                InventoryItemChanged.Invoke(_inventoryItem);
            }
        }

        private IInventoryItem _inventoryItem;
    }
}
