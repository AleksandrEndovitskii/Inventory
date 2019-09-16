using InventoryItems;
using Managers;
using UnityEngine;

namespace Components.Buttons
{
    public class SaveColorButtonComponent : ButtonComponent
    {
        public override void OnClick()
        {
            // TODO: test demo implementation - add correct implementation in future
            GameManager.Instance.ColorSelectionService.SelectedColor =
                ((InventoryColor)GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem).Color;
            GameManager.Instance.ColorSelectionService.SelectedColor = new Color(
                (GameManager.Instance.ColorSelectionService.SelectedColor.r + 0.1f) % 1,
                GameManager.Instance.ColorSelectionService.SelectedColor.g,
                GameManager.Instance.ColorSelectionService.SelectedColor.b,
                GameManager.Instance.ColorSelectionService.SelectedColor.a);
            Debug.Log("Trying to save selected color " + GameManager.Instance.ColorSelectionService.SelectedColor);
            Debug.Log("To replace  " +
                      ((InventoryColor)GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem)
                      .Color);
            //((InventoryColor)SelectedInventoryItem).Color = _selectedColor;
            var selectedInventoryItemChangedColor =
                ((InventoryColor)GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem)
                .TryChangeColor(GameManager.Instance.ColorSelectionService.SelectedColor);
            if (selectedInventoryItemChangedColor)
            {
                GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem =
                    null; // unselect selected inventory item
            }
        }
    }
}
