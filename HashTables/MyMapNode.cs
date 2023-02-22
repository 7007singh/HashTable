using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    internal class MyMapNode<K, V>
    {
        public int size;
        public struct KeyValue<k, v>
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }
        private readonly LinkedList<KeyValue<K, V>>[] items;
        public MyMapNode(int size)
        {
            this.size = size;
            items = new LinkedList<KeyValue<K, V>>[size];
        }
        protected int GetArrayPosition(K key)
        {
            int hash = key.GetHashCode();
            int position = hash % size;
            return Math.Abs(position);
        }
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if(linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                    return item.Value;
            }

            return default(V);
        }
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>()
            { Key = key, Value = value };
            if (linkedList.Count != 0)
            {
                foreach (KeyValue<K, V> item1 in linkedList)
                {
                    if (item1.Key.Equals(key))
                    { 
                        break;
                    }
                }
            }
            linkedList.AddLast(item); 
        }
        public bool Exists(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach(KeyValue<K,V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                    //linkedList.Remove(item);
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
                //Console.WriteLine("Removed successfully with key " + foundItem.Key);
            }
        }
        public void Display()
        {
            foreach (var linkedList in items)
            {
                if (linkedList != null)
                    foreach (var element in linkedList)
                    {
                        string res = element.ToString();
                        if (res != null)
                            Console.WriteLine(element.Key + " " + element.Value);
                    }
            }
        }
    }
}
