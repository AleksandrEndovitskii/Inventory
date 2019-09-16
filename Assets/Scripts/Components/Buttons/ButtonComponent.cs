using UnityEngine;
using UnityEngine.UI;

namespace Components.Buttons
{
    [RequireComponent(typeof(Button))]
    public class ButtonComponent : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = this.gameObject.GetComponent<Button>();

            _button.onClick.AddListener(OnClick);
        }
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        public virtual void OnClick()
        {

        }
    }
}
