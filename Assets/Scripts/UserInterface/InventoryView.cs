using System.Collections.Generic;
using System.Collections.Specialized;
using InventoryItems;
using Managers;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace UserInterface
{
    public class InventoryView : MonoBehaviour ,IInitializable, IUninitializable
    {
        [SerializeField]
        private RectTransform inventoryItemsContainer;

        [SerializeField]
        private Image selectedInventoryItemImage;

        [SerializeField]
        private InventoryItemView inventoryItemViewPrefab;

        private List<InventoryItemView> _inventoryItemViewInstances;

        public Color SelectedColor;

        public void Initialize()
        {
            CreateContent();

            GameManager.Instance.InventoryService.InventoryItems.CollectionChanged += InventoryItemsOnCollectionChanged;
        }

        public void Uninitialize()
        {
            GameManager.Instance.InventoryService.InventoryItems.CollectionChanged -= InventoryItemsOnCollectionChanged;

            ClearContent();
        }

        public void OnAddColorButtonClick()
        {
            GameManager.Instance.InventoryService.Add(new InventoryColor(SelectedColor));
        }

        public void OnRemoveColorButtonClick()
        {
            GameManager.Instance.InventoryService.Remove(new InventoryColor(SelectedColor));
        }

        public void OnSaveColorButtonClick()
        {

        }

        //TODO: re-implement with more arguments
        private void InstantiateElement(IInventoryItem inventoryItem)
        {
            var instance = Instantiate(inventoryItemViewPrefab, inventoryItemsContainer);
            instance.Initialize(inventoryItem);
            instance.WasSelected += WasSelected;
            _inventoryItemViewInstances.Add(instance);
        }

        private void WasSelected(InventoryItemView inventoryItemView)
        {
            selectedInventoryItemImage.gameObject.SetActive(true);
            selectedInventoryItemImage.color = ((InventoryColor)inventoryItemView.InventoryItem).Color; // TODO
        }

        private void CreateContent()
        {
            selectedInventoryItemImage.gameObject.SetActive(false);

            _inventoryItemViewInstances = new List<InventoryItemView>();

            foreach (var inventoryItem in GameManager.Instance.InventoryService.InventoryItems)
            {
                InstantiateElement(inventoryItem);
            }
        }

        private void ClearContent()
        {
            foreach (var inventoryItemViewInstance in _inventoryItemViewInstances)
            {
                Destroy(inventoryItemViewInstance.gameObject);
            }

            _inventoryItemViewInstances.Clear();
            _inventoryItemViewInstances = null; // TODO: do not required?
        }

        private void InventoryItemsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //TODO: not optimized
            ClearContent();
            CreateContent();
        }
    }
}
