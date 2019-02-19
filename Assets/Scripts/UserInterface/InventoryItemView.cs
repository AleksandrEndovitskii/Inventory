using System;
using InventoryItems;
using UnityEngine;
using UnityEngine.UI;
//using Utilities;

namespace UserInterface
{
    public class InventoryItemView : MonoBehaviour //,IInitializable, IUninitializable
    {
        public Action<InventoryItemView> WasSelected = delegate { };

        [SerializeField]
        private Image image;

        public IInventoryItem InventoryItem;

        public void Initialize(IInventoryItem inventoryItem)
        {
            this.InventoryItem = inventoryItem;

            Redraw();
        }

        public void Redraw()
        {
            image.color = ((InventoryColor)InventoryItem).Color; //TODO
        }

        public void Uninitialize()
        {
            //
        }

        public void OnClick()
        {
            WasSelected.Invoke(this);
        }
    }
}
