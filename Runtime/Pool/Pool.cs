using System;
using System.Collections.Generic;
using UnityEngine;

namespace AHGenericPatterns.PoolPattern
{
    [Serializable]
    public class Pool<T> where T : Component
    {
        [SerializeField] Transform _parent;
        [SerializeField] T _prefab;
        private List<T> _items = new List<T>();
        private Func<Transform,T> factory;
        
        public void SetFactory(Func<Transform,T> factory) =>
            this.factory = factory;

        public T[] ActiveItems
        {
            get
            {
                List<T> _itemesActive = new List<T>();

                for (int i = 0; i < _items.Count; i++)
                    if (_items[i].gameObject.activeSelf)
                        _itemesActive.Add(_items[i]);

                return _itemesActive.ToArray();
            }
        }

        public T Get
        {
            get
            {
                for (int i = 0; i < _items.Count; i++)
                    if (!_items[i].gameObject.activeSelf)
                        return _items[i];

                return AddNewItem();
            }
        }

        public T GetActive { get { var t = Get; t.gameObject.SetActive(true); return t; } }

        private T AddNewItem()
        {
            var item = factory != null ? factory(_parent) : GameObject.Instantiate(_prefab, _parent);
            item.transform.localPosition = Vector3.zero;
            item.transform.localRotation = Quaternion.identity;
            _items.Add(item);
#if UNITY_EDITOR
            item.name = typeof(T) + "_" + _items.Count;
#endif
            return item;
        }
    }
}