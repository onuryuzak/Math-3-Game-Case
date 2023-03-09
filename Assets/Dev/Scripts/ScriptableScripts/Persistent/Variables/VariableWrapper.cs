using System;

namespace PersistentSO
{
    [Serializable]
    public struct VariableWrapper<T>
    {
        public T Value;

        public VariableWrapper(T value)
        {
            Value = value;
        }
    }
}