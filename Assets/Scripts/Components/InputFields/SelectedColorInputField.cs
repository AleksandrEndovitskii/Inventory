using InventoryItems;
using Managers;
using UnityEngine;

namespace Components.InputFields
{
    public class SelectedColorInputField : InputFieldComponent
    {
        public override void OnEndEdit(string hexString)
        {
            var color = ((InventoryColor)GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem)
                .Color;
            ColorUtility.TryParseHtmlString(hexString, out color);

            //TODO
            // nothing changed
            //if (color == ((InventoryColor)GameManager.Instance.InventoryItemSelectionService.SelectedInventoryItem)
            //    .Color)
            //{
            //    _saveColorButton.interactable = false;

            //    return;
            //}

            //_saveColorButton.interactable = true;

            GameManager.Instance.ColorSelectionService.SelectedColor = color;
        }
    }
}
