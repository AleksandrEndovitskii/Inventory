using System.Collections.ObjectModel;
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

            TryAdd(new InventoryColor(Color.red));
            TryAdd(new InventoryColor(Color.green));
            TryAdd(new InventoryColor(Color.blue));
            TryAdd(new InventoryColor(Color.black));
            TryAdd(new InventoryColor(Color.black));
            TryAdd(new InventoryColor(Color.white));
            TryAdd(new InventoryColor(Color.white));
        }

        public void Uninitialize()
        {
            InventoryItems.Clear();

            InventoryItems = null;
        }

        public bool TryAdd(IInventoryItem inventoryItem)
        {
            if (inventoryItem is InventoryColor inventoryColor)
            {
                return TryAdd(inventoryColor);
            }

            return false; // TODO
        }

        public bool TryAdd(InventoryColor inventoryColor)
        {
            Debug.Log("Trying to add " + inventoryColor.Color + "to inventory");
            var result = "";
            foreach (var inventoryItem in InventoryItems)
            {
                if (inventoryItem is InventoryColor ic)
                {
                    result += ic.Color + " ";
                }
            }
            Debug.Log("Content of inventory: " + result);

            if (InventoryItems.Contains(inventoryColor))
            {
                Debug.Log("Inventory already contain this color");

                return false;
            }

            InventoryItems.Add(inventoryColor);
            return true;
        }

        public bool TryRemove(IInventoryItem inventoryItem)
        {
            if (inventoryItem is InventoryColor inventoryColor)
            {
                return TryRemove(inventoryColor);
            }

            return false; // TODO
        }

        public bool TryRemove(InventoryColor inventoryColor)
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
