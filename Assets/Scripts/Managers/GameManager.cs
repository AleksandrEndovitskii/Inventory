using Services;
using UnityEngine;
using Utilities;

/*
Проект на Юнити произвольной версии, но чтобы мы могли открыть его в 2017.4.
 */

namespace Managers
{
    [RequireComponent(typeof(UserInterfaceManager))]
    public class GameManager : MonoBehaviour , IInitializable, IUninitializable
    {
        // static instance of GameManager which allows it to be accessed by any other script 
        public static GameManager Instance;

        public UserInterfaceManager UserInterfaceManager
        {
            get { return this.gameObject.GetComponent<UserInterfaceManager>(); }
        }

        public InventoryService InventoryService = new InventoryService();
        public InventoryItemSelectionService InventoryItemSelectionService = new InventoryItemSelectionService();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                DontDestroyOnLoad(this.gameObject); // sets this to not be destroyed when reloading scene 
            }
            else
            {
                if (Instance != this)
                {
                    Instance.Uninitialize();

                    // this enforces our singleton pattern, meaning there can only ever be one instance of a GameManager 
                    Destroy(this.gameObject);
                }
            }

            Instance.Initialize();
        }

        public void Initialize()
        {
            InventoryService.Initialize();
            InventoryItemSelectionService.Initialize();

            UserInterfaceManager.Initialize();
        }

        public void Uninitialize()
        {
            UserInterfaceManager.Uninitialize();

            InventoryItemSelectionService.Uninitialize();
            InventoryService.Uninitialize();
        }

        public void Reinitialize()
        {
            Uninitialize();
            Initialize();
        }
    }
}
