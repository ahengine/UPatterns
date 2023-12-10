﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace UPatterns
{
    [Serializable]
    public class Pool<T> where T : Component
    {
        [SerializeField] Transform parent;
        [SerializeField] T prefab;
        private List<T> items = new List<T>();
        private Func<Transform,T> factory;
        
        public void SetFactory(Func<Transform,T> factory) =>
            this.factory = factory;

        /// <summary>
        /// Expensive Property
        /// </summary>
        public T[] ActiveItems
        {
            get
            {
                List<T> _itemesActive = new List<T>();

                for (int i = 0; i < items.Count; i++)
                    if (items[i].gameObject.activeSelf)
                        _itemesActive.Add(items[i]);

                return _itemesActive.ToArray();
            }
        }

        public T Get
        {
            get
            {
                for (int i = 0; i < items.Count; i++)
                    if (!items[i].gameObject.activeSelf)
                        return items[i];

                return AddNewItem();
            }
        }

        public T GetActive { get { var t = Get; t.gameObject.SetActive(true); return t; } }

        private T AddNewItem()
        {
            var item = factory != null ? factory(parent) : GameObject.Instantiate(prefab, parent);
            item.transform.localPosition = Vector3.zero;
            item.transform.localRotation = Quaternion.identity;
            items.Add(item);
#if UNITY_EDITOR
            item.name = typeof(T) + "_" + items.Count;
#endif
            return item;
        }
        
        public void RemoveInstance(T item)
        {
            items.Remove(item);
            GameObject.Destroy(item);
        }

        public void RemoveAllInstance()
        {
            while(items.Count > 0)
                RemoveInstance(items[0]);
        }  
    }
}