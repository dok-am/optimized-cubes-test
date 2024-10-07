using System;
using UnityEngine;

namespace CubeTest.UI.Models
{
    public class ImageItem 
    {
        public string Id { get; private set; }
        public string ImageUrl { get; private set; }
        public int Price { get; private set; }

        public Texture Image { get; private set; }

        public ImageItem(string imageUrl)
        {
            ImageUrl = imageUrl;
            Price = UnityEngine.Random.Range(5, 9999999);
            Id = Guid.NewGuid().ToString();
        }

        public void SetTexture(Texture texture)
        {
            Image = texture;
        }

    }
}