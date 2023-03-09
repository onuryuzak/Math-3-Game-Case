using System;
using System.Collections.Generic;
using System.Linq;
using Base.ObjectPooling;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class GameBoard : MonoBehaviour
{
    private readonly GameStateMachine stateMachine = new GameStateMachine();
    private readonly int gridSize = 5;
    private List<CellItem> cellItems = new List<CellItem>();
    private List<MinionItem> minionItems = new List<MinionItem>();
    public int GridSize => gridSize;

    private void Start()
    {
        SetState(new GameBoardSetupState(this));
    }

    public void SpawnCell(int x, int y)
    {
        var cell = ObjectCamp.PullObject<CellItem>();
        cellItems.Add(cell.Result);
    }

    public void SpawnMinion(int count)
    {
        for (int i = 0; i < count; i++)
        {
        }
    }

    private Vector2Int GetRandomEmptyCell()
    {
        // Generate a random cell coordinate that is not already occupied.
        int attempts = 0;
        while (attempts < 100)
        {
            int x = Random.Range(0, gridSize);
            int y = Random.Range(0, gridSize);

            bool cellEmpty = true;
            foreach (var item in minionItems)
            {
                Vector3 itemPosition = item.transform.position;
                if (Mathf.RoundToInt(itemPosition.x / 1) == x &&
                    Mathf.RoundToInt(itemPosition.z / 1) == y)
                {
                    cellEmpty = false;
                    break;
                }
            }

            if (cellEmpty)
            {
                return new Vector2Int(x, y);
            }

            attempts++;
        }

        return Vector2Int.zero;
    }

    public void SetState(GameBoardState state)
    {
        stateMachine.SetState(state);
    }

    public void Update()
    {
        stateMachine.Update();
    }

    public bool IsValidCell(int x, int y)
    {
        return x >= 0 && x < gridSize && y >= 0 && y < gridSize;
    }
}