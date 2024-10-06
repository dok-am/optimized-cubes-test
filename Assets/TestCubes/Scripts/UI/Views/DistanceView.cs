using TMPro;
using TriInspector;
using UnityEngine;

namespace CubeTest.UI.Views
{
    public class DistanceView : MonoBehaviour
    {
        [SerializeField, Required] private TMP_Text _text;

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}
