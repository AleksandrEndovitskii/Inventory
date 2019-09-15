using UnityEngine;
using UserInterface;
using Utilities;

namespace Managers
{
    public class UserInterfaceManager : MonoBehaviour, IInitializable, IUninitializable
    {
#pragma warning disable 0649
        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        private InventoryView _inventoryViewPrefab;

        private InventoryView _inventoryViewInstance;
#pragma warning restore 0649

        public void Initialize()
        {
            _inventoryViewInstance = Instantiate(_inventoryViewPrefab, _canvas.transform);
            _inventoryViewInstance.Initialize();
        }

        public void Uninitialize()
        {
            Destroy(_inventoryViewInstance);

            _inventoryViewInstance = null;
        }
    }
}
