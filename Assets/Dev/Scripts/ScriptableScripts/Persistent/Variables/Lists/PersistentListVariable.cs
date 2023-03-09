using System;
using System.Collections.Generic;
using MyBox;

namespace PersistentSO
{
    public abstract class PersistentListVariable<T> : PersistentVariable<List<T>>
    {
        public void Add(T element)
        {
            var list = Value;
            list.Add(element);
            Value = list;
        }

        public void AddOrChange(T element, Predicate<T> predicate)
        {
            var list = Value;

            var existingIndex = list.FirstIndex(predicate);
            if (existingIndex > -1)
                list[existingIndex] = element;
            else
                list.Add(element);

            Value = list;
        }

        public void Remove(T element)
        {
            var list = Value;
            list.Remove(element);
            Value = list;
        }
    }
}