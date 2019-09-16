using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    [RequireComponent(typeof(InventoryItemComponent))]
    public class InventoryItemButtonComponent : MonoBehaviour
    {
        private InventoryItemComponent _inventoryItemComponent;
        private Button _button;

        private void Awake()
        {
            _inventoryItemComponent = this.gameObject.GetComponent<InventoryItemComponent>();
            _button = this.gameObject.GetComponent<Button>();

            _button.onClick.AddListener(OnClick);
        }
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        public void OnClick()
        {
            GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem =
                _inventoryItemComponent.InventoryItem;
        }
    }
}
