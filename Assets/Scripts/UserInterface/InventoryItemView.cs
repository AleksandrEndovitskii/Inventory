using InventoryItems;
using UnityEngine;
using UnityEngine.UI;
//using Utilities;

namespace UserInterface
{
    public class InventoryItemView : MonoBehaviour //,IInitializable, IUninitializable
    {
        [SerializeField]
        private Image image;

        private IInventoryItem _inventoryItem;

        public void Initialize(IInventoryItem inventoryItem)
        {
            _inventoryItem = inventoryItem;

            Redraw();
        }

        public void Redraw()
        {
            image.color = ((InventoryColor)_inventoryItem).Color; //TODO
        }

        public void Uninitialize()
        {
            //
        }
    }
}
