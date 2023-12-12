using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class ListChangedEventArgs<T> : EventArgs
    {
        public enum ChangeType
        {
            Added,
            Inserted,
            Removed,
            Cleared
        }

        public ChangeType Type { get; private set; }
        public T ChangedItem { get; private set; }
        public int? Index { get; private set; }

        public ListChangedEventArgs(ChangeType type, T changedItem, int? index = null)
        {
            Type = type;

            ChangedItem = changedItem;

            Index = index;
        }
    }

    public class ObservedList<T> : MyList<T>
    {

        public override void Add(T? item)
        {
            base.Add(item);

            OnItemAdded(new ListChangedEventArgs<T>(ListChangedEventArgs<T>.ChangeType.Added, item));
        }

        private void OnItemAdded(ListChangedEventArgs<T> e)
        {
            ItemAdded?.Invoke(this, e);
        }

        public override void Insert(int index, T? item)
        {
            base.Insert(index, item);

            OnItemInserted(new ListChangedEventArgs<T>(ListChangedEventArgs<T>.ChangeType.Inserted, item, index));
        }

        private void OnItemInserted(ListChangedEventArgs<T> e)
        {
            ItemInserted?.Invoke(this, e);
        }

        public override void Remove(T? item)
        {
            int index = IndexOf(item);

            if (index != -1)
            {
                base.Remove(item);
            }
        }

        private void OnItemRemoved(ListChangedEventArgs<T> e)
        {
            ItemRemoved?.Invoke(this, e);
        }

        public override void RemoveAt(int index)
        {
           T? removedItem = this[index];

            base.RemoveAt(index);

            OnItemRemovedAt(new ListChangedEventArgs<T>(ListChangedEventArgs<T>.ChangeType.Removed, removedItem, index));
        }

        private void OnItemRemovedAt(ListChangedEventArgs<T> e)
        {
            ItemRemoved?.Invoke(this, e);
        }

        public override void Clear()
        {
            base.Clear();

            OnListCleared(EventArgs.Empty);
        }

        private void OnListCleared(EventArgs e)
        {
            ListCleared?.Invoke(this, e);
        }

        public event EventHandler<ListChangedEventArgs<T>> ItemAdded;

        public event EventHandler<ListChangedEventArgs<T>> ItemInserted;

        public event EventHandler<ListChangedEventArgs<T>> ItemRemoved;

        public event EventHandler<EventArgs> ListCleared;
    }


}
