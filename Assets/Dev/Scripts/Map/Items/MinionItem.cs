using System.Collections;
using System.Collections.Generic;
using Base.ObjectPooling;
using Base.Scriptables;
using UnityEngine;

public class MinionItem : MonoBehaviour, IUIDataObserver<MinionItemDTO>, IObjectCampMember, IUIDTO
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void SetContainerData(MinionItemDTO data)
    {
        spriteRenderer.sprite = data.itemIcon;
    }
}