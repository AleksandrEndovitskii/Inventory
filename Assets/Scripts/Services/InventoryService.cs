using System.Collections.Generic;
using InventoryItems;
using UnityEngine;

/*
Дизайнер, не владеющий программированием, должен иметь возможность настраивать какие цвета доступны игроку.

3. Необходим API позволяющий другим частям игры работать с этим «инвентарём».
4. Содержание должно сохраняться между сессиями.
 */

namespace Services
{
    public class InventoryService : MonoBehaviour
    {
        private List<InventoryColor> _inventoryColors = new List<InventoryColor>();

        public bool Add(InventoryColor inventoryColor)
        {
            if (_inventoryColors.Contains(inventoryColor))
            {
                Debug.Log("Inventory already contain this color");

                return false;
            }

            _inventoryColors.Add(inventoryColor);
            return true;
        }

        public bool Remove(InventoryColor inventoryColor)
        {
            var result = _inventoryColors.Remove(inventoryColor);

            if (!result)
            {
                Debug.Log("Inventory do not contain this color");
            }

            return result;
        }
    }
}
