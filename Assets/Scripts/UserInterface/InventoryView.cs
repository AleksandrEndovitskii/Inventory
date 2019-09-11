using System.Collections.Generic;
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
        private InputField selectedColorInputField;

        [SerializeField]
        private Button saveColorButton;

        [SerializeField]
        private InventoryItemView inventoryItemViewPrefab;

        private List<InventoryItemView> _inventoryItemViewInstances;

        private IInventoryItem _selectedInventoryItem;
        public IInventoryItem SelectedInventoryItem
        {
            get
            {
                return _selectedInventoryItem;
            }
            set
            {
                _selectedInventoryItem = value;

                if (_selectedInventoryItem == null)
                {
                    selectedInventoryItemImage.gameObject.SetActive(false);
                    selectedColorInputField.gameObject.SetActive(false);
                }
                else
                {
                    selectedInventoryItemImage.gameObject.SetActive(true);
                    selectedInventoryItemImage.color = ((InventoryColor)_selectedInventoryItem).Color; // TODO

                    selectedColorInputField.gameObject.SetActive(true);
                    var hexString = ColorUtility.ToHtmlStringRGBA(selectedInventoryItemImage.color);
                    selectedColorInputField.text = hexString;

                    _selectedColor = selectedInventoryItemImage.color;
                }
            }
        }

        private Color _selectedColor;

        public void Initialize()
        {
            CreateContent();

            GameManager.Instance.InventoryService.ContentChanged += InventoryItemsOnCollectionChanged;
        }

        public void Uninitialize()
        {
            GameManager.Instance.InventoryService.ContentChanged -= InventoryItemsOnCollectionChanged;

            ClearContent();
        }

        public void OnSelectedColorInputFieldValueChanged(string hexString)
        {

        }

        public void OnSelectedColorInputFieldEndEdit(string hexString)
        {
            var color = selectedInventoryItemImage.color;
            ColorUtility.TryParseHtmlString(hexString, out color);

            // nothing changed
            if (color == selectedInventoryItemImage.color)
            {
                saveColorButton.interactable = false;

                return;
            }

            saveColorButton.interactable = true;

            selectedInventoryItemImage.color = color;
            _selectedColor = selectedInventoryItemImage.color;
        }

        public void OnAddColorButtonClick()
        {
            var inventoryItemAddedToInventoryService = GameManager.Instance.InventoryService.TryAdd(SelectedInventoryItem);
            if (inventoryItemAddedToInventoryService)
            {
                SelectedInventoryItem = null; // unselect selected inventory item
            }
        }

        public void OnRemoveColorButtonClick()
        {
            var inventoryItemRemovedFromInventoryService = GameManager.Instance.InventoryService.TryRemove(SelectedInventoryItem);
            if (inventoryItemRemovedFromInventoryService)
            {
                SelectedInventoryItem = null; // unselect selected inventory item
            }
        }

        public void OnSaveColorButtonClick()
        {
            // TODO: test demo implementation - add correct implementation in future
            _selectedColor = ((InventoryColor)SelectedInventoryItem).Color;
            _selectedColor = new Color((_selectedColor.r + 0.1f) % 1, _selectedColor.g, _selectedColor.b, _selectedColor.a);
            Debug.Log("Trying to save selected color " + _selectedColor);
            Debug.Log("To replace  " + ((InventoryColor)SelectedInventoryItem).Color);
            //((InventoryColor)SelectedInventoryItem).Color = _selectedColor;
            var selectedInventoryItemChangedColor = ((InventoryColor)SelectedInventoryItem).TryChangeColor(_selectedColor);
            if (selectedInventoryItemChangedColor)
            {
                SelectedInventoryItem = null; // unselect selected inventory item
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
            SelectedInventoryItem = inventoryItemView.InventoryItem;
        }

        private void CreateContent()
        {
            selectedInventoryItemImage.gameObject.SetActive(false);
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
    }
}
