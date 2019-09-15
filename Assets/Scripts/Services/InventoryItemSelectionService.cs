using System;
using InventoryItems;
using UnityEngine;

namespace Services
{
    public class InventoryItemSelectionService
    {
        public Action<IInventoryItem> SelectedInventoryItemChanged = delegate { };

        private IInventoryItem _selectedInventoryItem;
        public IInventoryItem SelectedInventoryItem
        {
            get
            {
                return _selectedInventoryItem;
            }
            set
            {
                if (value == _selectedInventoryItem)
                {
                    return;
                }

                Debug.Log(string.Format("SelectedInventoryItem value changed from {0} to {1}",
                    _selectedInventoryItem, value));

                _selectedInventoryItem = value;

                SelectedInventoryItemChanged.Invoke(_selectedInventoryItem);
            }
        }
    }
}
