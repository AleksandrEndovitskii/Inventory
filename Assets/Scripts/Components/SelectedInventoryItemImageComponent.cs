using InventoryItems;
using Managers;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(InventoryItemComponent))]
    public class SelectedInventoryItemImageComponent : MonoBehaviour
    {
        private InventoryItemComponent _inventoryItemComponent;

        private void Awake()
        {
            _inventoryItemComponent = this.gameObject.GetComponent<InventoryItemComponent>();

            OnSelectedInventoryItemChanged(GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem);
            GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItemChanged +=
                OnSelectedInventoryItemChanged;
        }
        private void OnDestroy()
        {
            GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItemChanged -=
                OnSelectedInventoryItemChanged;
        }

        private void OnSelectedInventoryItemChanged(IInventoryItem inventoryItem)
        {
            _inventoryItemComponent.InventoryItem = inventoryItem;

            _inventoryItemComponent.gameObject.SetActive(inventoryItem != null);
        }
    }
}
