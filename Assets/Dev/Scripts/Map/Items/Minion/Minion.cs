using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Minion : MinionBase
{
    public override void SnapToCell(Vector3 pos)
    {
        base.SnapToCell(pos);
        transform.position = pos;
    }

    public void MoveToCell(Vector3 cellPos)
    {
        transform.DOMove(cellPos, 0.5f).SetDelay(1f);
    }

    public void SetCurrentCell(Cell cell)
    {
        currentCell = cell;
    }
}