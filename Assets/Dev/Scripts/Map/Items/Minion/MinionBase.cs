using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBase : MonoBehaviour
{
    public MinionType MinionType;
    [HideInInspector] public Cell currentCell;
    public SpriteRenderer minionSprite;
    public Vector2 index;

    public virtual void SnapToCell(Vector3 pos)
    {
    }

    public virtual void MoveToCell(Vector3 cellPos)
    {
    }

    public virtual void SetCurrentCell(Cell cell)
    {
    }

    public virtual void SetCurrentIndex(Vector2 index)
    {
    }

    public virtual void JumpAnimation()
    {
    }
}

public enum MinionType
{
    Red,
    Blue,
    Green
}