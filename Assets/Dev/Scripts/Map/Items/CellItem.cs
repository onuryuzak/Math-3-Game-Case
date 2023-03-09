using System.Collections;
using System.Collections.Generic;
using Base.ObjectPooling;
using Base.Scriptables;
using UnityEngine;

public class CellItem : MonoBehaviour, IUIDataObserver<CellItemDTO>, IObjectCampMember, IUIDTO
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void SetContainerData(CellItemDTO data)
    {
        spriteRenderer.sprite = data.itemIcon;
    }
}