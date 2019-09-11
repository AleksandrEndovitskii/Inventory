using System;
using System.Collections.Generic;
using InventoryItems;
using Managers;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace UserInterface
{
    public class InventoryView : MonoBehaviour, IInitializable, IUninitializable
    {
        [SerializeField]
        private RectTransform inventoryItemsContainer;

        [SerializeField]
        private InputField selectedColorInputField;

        [SerializeField]
        private Button saveColorButton;

        [SerializeField]
        private InventoryItemView inventoryItemViewPrefab;

        private List<InventoryItemView> _inventoryItemViewInstances;

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

        public void OnSelectedColorInputFieldValueChanged(string hexString)
        {

        }

        public void OnSelectedColorInputFieldEndEdit(string hexString)
        {
            var color = ((InventoryColor) GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem)
                .Color;
            ColorUtility.TryParseHtmlString(hexString, out color);

            // nothing changed
            if (color == ((InventoryColor) GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem)
                .Color)
            {
                saveColorButton.interactable = false;

                return;
            }

            saveColorButton.interactable = true;

            GameManager.Instance.ColorSelectionService.SelectedColor = color;
        }

        public void OnAddColorButtonClick()
        {
            var inventoryItemAddedToInventoryService =
                GameManager.Instance.InventoryService.TryAdd(GameManager.Instance.InventoryItemSelectionService
                    .SelectedInventoryItem);
            if (inventoryItemAddedToInventoryService)
            {
                GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem =
                    null; // unselect selected inventory item
            }
        }

        public void OnRemoveColorButtonClick()
        {
            var inventoryItemRemovedFromInventoryService =
                GameManager.Instance.InventoryService.TryRemove(GameManager.Instance.InventoryItemSelectionService
                    .SelectedInventoryItem);
            if (inventoryItemRemovedFromInventoryService)
            {
                GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem =
                    null; // unselect selected inventory item
            }
        }

        public void OnSaveColorButtonClick()
        {
            // TODO: test demo implementation - add correct implementation in future
            GameManager.Instance.ColorSelectionService.SelectedColor =
                ((InventoryColor) GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem).Color;
            GameManager.Instance.ColorSelectionService.SelectedColor = new Color(
                (GameManager.Instance.ColorSelectionService.SelectedColor.r + 0.1f) % 1,
                GameManager.Instance.ColorSelectionService.SelectedColor.g,
                GameManager.Instance.ColorSelectionService.SelectedColor.b,
                GameManager.Instance.ColorSelectionService.SelectedColor.a);
            Debug.Log("Trying to save selected color " + GameManager.Instance.ColorSelectionService.SelectedColor);
            Debug.Log("To replace  " +
                      ((InventoryColor) GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem)
                      .Color);
            //((InventoryColor)SelectedInventoryItem).Color = _selectedColor;
            var selectedInventoryItemChangedColor =
                ((InventoryColor) GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem)
                .TryChangeColor(GameManager.Instance.ColorSelectionService.SelectedColor);
            if (selectedInventoryItemChangedColor)
            {
                GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem =
                    null; // unselect selected inventory item
            }
        }

        //TODO: re-implement with more arguments
        private void InstantiateElement(IInventoryItem inventoryItem)
        {
            var instance = Instantiate(inventoryItemViewPrefab, inventoryItemsContainer);
            instance.Initialize(inventoryItem);
            instance.WasClicked += WasClicked;
            _inventoryItemViewInstances.Add(instance);
        }

        private void WasClicked(InventoryItemView inventoryItemView)
        {
            GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem = inventoryItemView.InventoryItem;
        }

        private void CreateContent()
        {
            saveColorButton.interactable = false;

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

        private void InventoryItemsOnCollectionChanged(IEnumerable<IInventoryItem> inventoryItems)
        {
            //TODO: not optimized
            ClearContent();
            CreateContent();
        }

        private void InventoryItemSelectionServiceOnSelectedInventoryItemChanged(IInventoryItem inventoryItem)
        {
            if (inventoryItem == null)
            {
                selectedColorInputField.gameObject.SetActive(false);
            }
            else
            {
                selectedColorInputField.gameObject.SetActive(true);
                var hexString = ColorUtility.ToHtmlStringRGBA(((InventoryColor) inventoryItem).Color);
                selectedColorInputField.text = hexString;

                GameManager.Instance.ColorSelectionService.SelectedColor = ((InventoryColor) inventoryItem).Color;
            }
        }
    }
}
