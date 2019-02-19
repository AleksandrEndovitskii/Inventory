using UnityEngine;
using UserInterface;
using Utilities;

namespace Managers
{
    public class UserInterfaceManager : MonoBehaviour, IInitializable, IUninitializable
    {
        [SerializeField]
        private Canvas canvas;

        [SerializeField]
        private InventoryView inventoryViewPrefab;

        private InventoryView _inventoryViewInstance;

        public void Initialize()
        {
            _inventoryViewInstance = Instantiate(inventoryViewPrefab, canvas.transform);
            _inventoryViewInstance.Initialize();
        }

        public void Uninitialize()
        {
            Destroy(_inventoryViewInstance);

            _inventoryViewInstance = null;
        }
    }
}
