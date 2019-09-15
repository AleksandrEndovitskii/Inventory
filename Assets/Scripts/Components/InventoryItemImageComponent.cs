using InventoryItems;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    [RequireComponent(typeof(Image))]
    public class InventoryItemImageComponent : MonoBehaviour
    {
        private Image _image;

        public IInventoryItem InventoryItem;

        private void Awake()
        {
            _image = this.gameObject.GetComponent<Image>();

            if (InventoryItem == null)
            {
                return;
            }
            _image.color = ((InventoryColor)InventoryItem).Color; //TODO
        }

        public void OnClick()
        {
            Debug.Log("WasClicked " + ((InventoryColor)this.InventoryItem).Color);

            GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem = InventoryItem;
        }
    }
}
