using System.Collections.Generic;
using Components;
using InventoryItems;
using Managers;
using UnityEngine;
using Utilities;

namespace UserInterface
{
    public class InventoryView : MonoBehaviour, IInitializable, IUninitializable
    {
#pragma warning disable 0649
        [SerializeField]
        private RectTransform _inventoryItemsContainer;

        [SerializeField]
        private InventoryItemComponent _inventoryItemComponentPrefab;
#pragma warning restore 0649

        private List<InventoryItemComponent> _inventoryItemComponentInstances;

        public void Initialize()
        {
            CreateContent();

            GameManager.Instance.InventoryService.ContentChanged += InventoryItemsOnCollectionChanged;
            GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItemChanged +=
                InventoryItemSelectionServiceOnSelectedInventoryItemChanged;
        }
        public void Uninitialize()
        {
            GameManager.Instance.InventoryService.ContentChanged -= InventoryItemsOnCollectionChanged;
            GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItemChanged -=
                InventoryItemSelectionServiceOnSelectedInventoryItemChanged;

            ClearContent();
        }

        //TODO: re-implement with more arguments
        private void InstantiateElement(IInventoryItem inventoryItem)
        {
            var instance = Instantiate(_inventoryItemComponentPrefab, _inventoryItemsContainer);
            instance.InventoryItem = inventoryItem;
            _inventoryItemComponentInstances.Add(instance);
        }

        private void CreateContent()
        {
            //TODO
            //_saveColorButton.interactable = false;

            _inventoryItemComponentInstances = new List<InventoryItemComponent>();

            foreach (var inventoryItem in GameManager.Instance.InventoryService.InventoryItems)
            {
                InstantiateElement(inventoryItem);
            }
        }
        private void ClearContent()
        {
            foreach (var inventoryItemViewInstance in _inventoryItemComponentInstances)
            {
                Destroy(inventoryItemViewInstance.gameObject);
            }

            _inventoryItemComponentInstances.Clear();
            _inventoryItemComponentInstances = null; // TODO: do not required?
        }

        private void InventoryItemsOnCollectionChanged(IEnumerable<IInventoryItem> inventoryItems)
        {
            //TODO: not optimized
            ClearContent();
            CreateContent();
        }

        private void InventoryItemSelectionServiceOnSelectedInventoryItemChanged(IInventoryItem inventoryItem)
        {
            //TODO
            //if (inventoryItem == null)
            //{
            //    _selectedColorInputField.gameObject.SetActive(false);
            //}
            //else
            //{
            //    _selectedColorInputField.gameObject.SetActive(true);
            //    var hexString = ColorUtility.ToHtmlStringRGBA(((InventoryColor) inventoryItem).Color);
            //    _selectedColorInputField.text = hexString;

            //    GameManager.Instance.ColorSelectionService.SelectedColor = ((InventoryColor) inventoryItem).Color;
            //}
        }
    }
}
