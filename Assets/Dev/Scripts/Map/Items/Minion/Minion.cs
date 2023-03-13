using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MinionBase
{
    public override void MoveToCell(Vector3 pos)
    {
        base.MoveToCell(pos);
        transform.position = pos;
    }
}