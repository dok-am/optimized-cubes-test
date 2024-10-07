using System.Collections.Generic;
using UnityEngine;

namespace CubeTest.UI.Views
{
    public class ImagesWindowView : MonoBehaviour
    {
        [SerializeField] private ImageItemView _itemPrefab;
        [SerializeField] private Transform _itemsContainer;

        private List<ImageItemView> _items = new();

        public ImageItemView AddItem(int price)
        {
            ImageItemView item = Instantiate(_itemPrefab, _itemsContainer);
            item.SetData(null, price);

            _items.Add(item);
            return item;
        }

        //Really should implemente removing items and cleanup, but out of time
    }
}
