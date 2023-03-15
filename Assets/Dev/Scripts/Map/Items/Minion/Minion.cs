using System.Collections;
using System.Collections.Generic;
using Base.Core.Pooling;
using DG.Tweening;
using UnityEngine;

public class Minion : MinionBase, IPooledObject
{
    public override void SnapToCell(Vector3 pos)
    {
        base.SnapToCell(pos);
        transform.position = pos;
    }

    public override void MoveToCell(Vector3 cellPos)
    {
        transform.DOMove(cellPos, 0.5f).SetDelay(1f);
    }

    public override void SetCurrentCell(Cell cell)
    {
        currentCell = cell;
    }

    public override void SetCurrentIndex(Vector2 index)
    {
        this.index = index;
    }

    public override void DestroySelf()
    {
        //go to correct UI pos. eğer mavi minionsa mavi UI gidecek. Ama ilk önce hoplayıp animasyon yapacak.
        // currentCell.isFull = false;
        currentCell = null;
        index = Vector2.zero;
        Pooler.Despawn(gameObject);
    }


    public GameObjectPooler Pooler { get; set; }
}