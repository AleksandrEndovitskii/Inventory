using TMPro;
using UnityEngine;

namespace Components.InputFields
{
    [RequireComponent(typeof(TMP_InputField))]
    public class InputFieldComponent : MonoBehaviour
    {
        private TMP_InputField _inputField;

        private void Awake()
        {
            _inputField = this.gameObject.GetComponent<TMP_InputField>();

            _inputField.onEndEdit.AddListener(OnEndEdit);
        }
        private void OnDestroy()
        {
            _inputField.onEndEdit.RemoveListener(OnEndEdit);
        }

        public virtual void OnEndEdit(string value)
        {

        }
    }
}
