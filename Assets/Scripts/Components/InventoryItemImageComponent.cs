using InventoryItems;
using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    [RequireComponent(typeof(InventoryItemComponent))]
    public class InventoryItemImageComponent : MonoBehaviour
    {
        private InventoryItemComponent _inventoryItemComponent;
        private Image _image;

        private void Awake()
        {
            _inventoryItemComponent = this.gameObject.GetComponent<InventoryItemComponent>();
            _image = this.gameObject.GetComponent<Image>();

            InventoryItemChanged(_inventoryItemComponent.InventoryItem);
            _inventoryItemComponent.InventoryItemChanged += InventoryItemChanged;
        }
        private void OnDestroy()
        {
            _inventoryItemComponent.InventoryItemChanged -= InventoryItemChanged;
        }

        private void InventoryItemChanged(IInventoryItem inventoryItem)
        {
            if (inventoryItem == null)
            {
                return;
            }

            _image.color = ((InventoryColor)inventoryItem).Color; //TODO
        }
    }
}
