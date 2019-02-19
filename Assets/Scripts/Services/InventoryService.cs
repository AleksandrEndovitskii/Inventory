using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using InventoryItems;
using UnityEngine;
using Utilities;

/*
Дизайнер, не владеющий программированием, должен иметь возможность настраивать какие цвета доступны игроку.

3. Необходим API позволяющий другим частям игры работать с этим «инвентарём».
4. Содержание должно сохраняться между сессиями.
 */

namespace Services
{
    public class InventoryService : IInitializable, IUninitializable
    {
        public ObservableCollection<IInventoryItem> InventoryItems;

        public void Initialize()
        {
            InventoryItems = new ObservableCollection<IInventoryItem>();

            Add(new InventoryColor(Color.red));
            Add(new InventoryColor(Color.green));
            Add(new InventoryColor(Color.blue));
            Add(new InventoryColor(Color.black));
            Add(new InventoryColor(Color.black));
            Add(new InventoryColor(Color.white));
            Add(new InventoryColor(Color.white));
        }

        public void Uninitialize()
        {
            InventoryItems.Clear();

            InventoryItems = null;
        }

        public bool Add(InventoryColor inventoryColor)
        {
            if (InventoryItems.Contains(inventoryColor))
            {
                Debug.Log("Inventory already contain this color");

                return false;
            }

            InventoryItems.Add(inventoryColor);
            return true;
        }

        public bool Remove(InventoryColor inventoryColor)
        {
            var result = InventoryItems.Remove(inventoryColor);

            if (!result)
            {
                Debug.Log("Inventory do not contain this color");
            }

            return result;
        }
    }
}
