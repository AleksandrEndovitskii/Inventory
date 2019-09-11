using InventoryItems;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    [RequireComponent(typeof(Image))]
    public class SelectedInventoryItemImageComponent : MonoBehaviour
    {
        private Image _selectedInventoryItemImage;

        private void Awake()
        {
            _selectedInventoryItemImage = this.gameObject.GetComponent<Image>();

            InventoryItemSelectionServiceOnSelectedInventoryItemChanged(
                GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem);
            GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItemChanged +=
                InventoryItemSelectionServiceOnSelectedInventoryItemChanged;
        }
        private void OnDestroy()
        {
            GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItemChanged -=
                InventoryItemSelectionServiceOnSelectedInventoryItemChanged;
        }

        private void InventoryItemSelectionServiceOnSelectedInventoryItemChanged(IInventoryItem inventoryItem)
        {
            if (inventoryItem == null)
            {
                _selectedInventoryItemImage.gameObject.SetActive(false);
            }
            else
            {
                _selectedInventoryItemImage.gameObject.SetActive(true);
                _selectedInventoryItemImage.color = ((InventoryColor)inventoryItem).Color; // TODO
            }
        }
    }
}
