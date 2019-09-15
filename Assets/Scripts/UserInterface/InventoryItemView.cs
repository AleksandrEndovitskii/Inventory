using System;
using InventoryItems;
using UnityEngine;
using UnityEngine.UI;
//using Utilities;

namespace UserInterface
{
    public class InventoryItemView : MonoBehaviour //,IInitializable, IUninitializable
    {
        public Action<InventoryItemView> WasClicked = delegate { };

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

        public void Uninitialize()
        {
            //
        }

        public void OnClick()
        {
            Debug.Log("WasClicked " + ((InventoryColor)this.InventoryItem).Color);

            WasClicked.Invoke(this);
        }
    }
}
