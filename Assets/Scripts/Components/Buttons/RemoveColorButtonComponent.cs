using Managers;

namespace Components.Buttons
{
    public class RemoveColorButtonComponent : ButtonComponent
    {
        public override void OnClick()
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
    }
}
