using CubeTest.Application;
using CubeTest.Managers.Interfaces;
using CubeTest.UI.Models;
using CubeTest.UI.Views;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using VContainer.Unity;

namespace CubeTest.UI.Controllers
{
    public class ImagesWindowController : IStartable
    {
        private ImagesWindowView _windowView;

        private ImageItem[] _items;
        private Dictionary<string, ImageItemView> _itemViews = new();

        public ImagesWindowController(UIContext context, IInputManager inputManager)
        {
            inputManager.OnMouseClicked += OnMouseClicked;

            _windowView = context.ImagesWindowView;

            //Too out of time, so let's just hardcode it for now
            _items = new ImageItem[]
            {
                new ImageItem("https://img.freepik.com/free-photo/wet-monstera-deliciosa-plant-leaves-in-a-garden_53876-139810.jpg"),
                new ImageItem("https://img.freepik.com/free-photo/wet-monstera-deliciosa-plant-leaves-in-a-garden_53876-144999.jpg"),
                new ImageItem("https://cs4.pikabu.ru/post_img/2015/07/03/8/1435930239_61382028.jpg"),
                new ImageItem("https://altcraft.com/uploads/mem_s_kotami_fc9dd6ee5d.png"),
                new ImageItem("https://habrastorage.org/r/w1560/webt/m9/z5/vw/m9z5vwnbzblbe0xgppboty60nbo.png"),
                new ImageItem("https://i.pinimg.com/236x/05/d0/e3/05d0e3691c10c2ee4e1b7c32305cecb3.jpg")
            };
        }

        private void OnMouseClicked(Instances.Interfaces.IClickable clickable)
        {
            ShowWindow(!_windowView.gameObject.activeSelf);
        }

        public void Start()
        {
            foreach (ImageItem item in _items)
            {
                _itemViews[item.Id] = _windowView.AddItem(item.Price);
                _ = DownloadItem(item);
            }
        }

        public void ShowWindow(bool show)
        {
            _windowView.gameObject.SetActive(show);
        }

        private async UniTask DownloadItem(ImageItem item)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(item.ImageUrl);
            try
            {
                await request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                    throw new Exception();
            }
            catch
            {
                Debug.LogError($"Can't download {item.ImageUrl}, have to time for try again feature");
                return;
            }


            item.SetTexture(((DownloadHandlerTexture)request.downloadHandler).texture);

            ImageItemView itemView = _itemViews[item.Id];
            if (itemView != null)
                itemView.SetData(item.Image, item.Price);
        }
    }
}
