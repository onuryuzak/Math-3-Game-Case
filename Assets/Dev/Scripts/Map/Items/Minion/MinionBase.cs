using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBase : MonoBehaviour
{
    public MinionType MinionType;
    [HideInInspector] public Cell currentCell;
    public SpriteRenderer minionSprite;

    public virtual void MoveToCell(Vector3 pos)
    {
    }
}

public enum MinionType
{
    Red,
    Blue,
    Green
}