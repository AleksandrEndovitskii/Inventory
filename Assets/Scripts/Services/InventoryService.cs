using System.Collections.Generic;
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
        public List<InventoryColor> Items;

        public void Initialize()
        {
            Items = new List<InventoryColor>();

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
            Items.Clear();

            Items = null;
        }

        public bool Add(InventoryColor inventoryColor)
        {
            if (Items.Contains(inventoryColor))
            {
                Debug.Log("Inventory already contain this color");

                return false;
            }

            Items.Add(inventoryColor);
            return true;
        }

        public bool Remove(InventoryColor inventoryColor)
        {
            var result = Items.Remove(inventoryColor);

            if (!result)
            {
                Debug.Log("Inventory do not contain this color");
            }

            return result;
        }
    }
}
