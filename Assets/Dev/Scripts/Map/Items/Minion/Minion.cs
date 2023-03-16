using System;
using System.Collections;
using System.Collections.Generic;
using Base.Core.Pooling;
using Base.Events;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class Minion : MinionBase, IPooledObject
{
    #region PUBLIC PROPERTIES

    public GameObjectPooler Pooler { get; set; }

    #endregion

    #region PUBLIC FIELDS

    public bool isDoneMovementToUI;
    public int moveAnimationTime = 1;
    public float jumpAnimationTime = 0.25f;

    #endregion

    #region PRIVATE FIELDS

    private bool waitForJumpComplete = false;

    #endregion


    #region PUBLIC METHODS

    public override void SnapToCell(Vector3 pos)
    {
        base.SnapToCell(pos);
        transform.position = pos;
    }

    public override void MoveToCell(Vector3 cellPos)
    {
        transform.DOMove(cellPos, 0.5f).SetDelay(1f).SetLink(gameObject);
    }

    public override void SetCurrentCell(Cell cell)
    {
        currentCell = cell;
    }

    public override void SetCurrentIndex(Vector2 index)
    {
        this.index = index;
    }

    public override void JumpAnimation()
    {
        transform.DOMoveY(transform.position.y + 0.5f, jumpAnimationTime).SetLoops(3, LoopType.Restart)
            .SetLink(gameObject).OnComplete((() =>
            {
                waitForJumpComplete = true;
                ResetVariables();
            }));
    }

    public IEnumerator MoveCorrectUIPanel(CountPanel foundedCountPanel)
    {
        yield return new WaitUntil(() => waitForJumpComplete);
        var screenPoint = foundedCountPanel.transform.position;
        var worldPos = Camera.main.ScreenToWorldPoint(screenPoint);
        transform.DOMove(worldPos, moveAnimationTime).OnComplete((() =>
        {
            isDoneMovementToUI = true;
            Pooler.Despawn(gameObject);
        })).SetLink(gameObject);
    }

    #endregion


    #region PRIVATE METHODS

    private void ResetVariables()
    {
        currentCell.isFull = false;
        DOVirtual.DelayedCall(Time.deltaTime, (() => currentCell = null)).SetLink(gameObject);
        index = Vector2.zero;
    }

    #endregion
}