using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IUIDataObserver<T> where T : IUIDTO
{
    public void SetContainerData(T data);
}