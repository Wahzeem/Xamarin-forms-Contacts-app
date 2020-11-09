using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Contacts.Classes
{
    public class ListGroup<K, T> : ObservableCollection<T>
    {
        public K Key { get; private set; }

        public ListGroup(K key, IEnumerable<T> items)
        {
            Key = key;

            foreach (var item in items)
                this.Items.Add(item);
        }

    }
}
