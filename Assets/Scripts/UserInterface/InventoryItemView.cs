using InventoryItems;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class InventoryItemView : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private Image _image;
#pragma warning restore 0649

        public IInventoryItem InventoryItem;

        public void Initialize(IInventoryItem inventoryItem)
        {
            this.InventoryItem = inventoryItem;

            Redraw();
        }

        public void Redraw()
        {
            _image.color = ((InventoryColor)InventoryItem).Color; //TODO
        }

        public void OnClick()
        {
            Debug.Log("WasClicked " + ((InventoryColor)this.InventoryItem).Color);

            GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem = InventoryItem;
        }
    }
}
