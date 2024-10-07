using System;
using TMPro;
using TriInspector;
using UnityEngine;

namespace CubeTest.UI.Views
{
    public class DistanceView : MonoBehaviour
    {
        public event Action<float> OnDistanceChanged;

        [SerializeField, Required] private TMP_InputField _text;

        private void Awake()
        {
            _text.onSubmit.AddListener(TextChanged);
        }

        public void SetText(string text)
        {
            if (!_text.isFocused)
                _text.text = text;
        }

        private void TextChanged(string text)
        {
            if (float.TryParse(text, out float result))
            {
                OnDistanceChanged?.Invoke(result);
                return;
            }
        }
    }
}
