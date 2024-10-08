using System.Globalization;
using TMPro;
using TriInspector;
using UnityEngine;
using UnityEngine.UI;

namespace CubeTest.UI.Views
{
    public class ImageItemView : MonoBehaviour
    {
        [SerializeField, Required] private RawImage _image;
        [SerializeField, Required] private TMP_Text _price;
        [SerializeField, Required] private RectTransform _bottomPart;
        [SerializeField] private float _imageOffset = 10.0f;

        [SerializeField, ReadOnly] private RectTransform _rectTransform;

        public void SetData(Texture image, int price)
        {            
            if (image != null)
            {
                _image.texture = image;
                float width = _rectTransform.sizeDelta.x;
                float ratio = image.height / (float)image.width;
                Vector2 imageSize = new(width, width * ratio);
                _image.rectTransform.sizeDelta = imageSize;

                float itemHeight = imageSize.y + _bottomPart.sizeDelta.y + _imageOffset;
                _rectTransform.sizeDelta = new Vector2(width, itemHeight);
                LayoutRebuilder.MarkLayoutForRebuild(_rectTransform);
            }

            _price.text = price.ToString("#,#", CultureInfo.InvariantCulture).Replace(',', ' ');
        }

        private void OnValidate()
        {
            Validate();
        }

        private void Validate()
        {
            if (_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();
        }
    }
}