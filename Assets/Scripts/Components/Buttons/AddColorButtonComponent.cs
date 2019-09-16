using Managers;

namespace Components.Buttons
{
    public class AddColorButtonComponent : ButtonComponent
    {
        public override void OnClick()
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
    }
}
