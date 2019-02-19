using System.Collections.Generic;
using Managers;
using UnityEngine;
using Utilities;

namespace UserInterface
{
    public class InventoryView : MonoBehaviour ,IInitializable, IUninitializable
    {
        [SerializeField]
        private RectTransform colorsContainer;

        [SerializeField]
        private InventoryItemView inventoryItemViewPrefab;

        private List<InventoryItemView> _inventoryItemViewInstances;

        public Color SelectedColor;

        public void Initialize()
        {
            _inventoryItemViewInstances = new List<InventoryItemView>();

            foreach (var item in GameManager.Instance.InventoryService.Items)
            {
                var instance = Instantiate(inventoryItemViewPrefab, colorsContainer);
                instance.Initialize(item);
            }
        }

        public void Uninitialize()
        {
            _inventoryItemViewInstances.Clear();
            _inventoryItemViewInstances = null;
        }

        public void OnAddColorButtonClick()
        {

        }

        public void OnRemoveColorButtonClick()
        {

        }

        public void OnSaveColorButtonClick()
        {

        }
    }
}
