using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using MyBox;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class GameBoard : MonoBehaviour
{
    #region INSPECTOR FIELDS

    [SerializeField] private int rows = 5;
    [SerializeField] private int cols = 5;
    [SerializeField] private float horizontalSpacing = 1.8f;
    [SerializeField] private float verticalSpacing = 2f;
    [SerializeField] private int spawnCount = 7;
    [SerializeField] private GameObjectFactory cellFactory;
    [SerializeField] private List<GameObjectFactory> minionsFactory = new List<GameObjectFactory>();

    #endregion

    #region PRIVATE FIELDS

    private readonly GameStateMachine stateMachine = new GameStateMachine();
    private List<Minion> spawnedMinions = new List<Minion>();
    private List<Cell> cells = new List<Cell>();

    #endregion


    #region UNITY METHODS

    private void Start()
    {
        SetState(new GameBoardSetupState(this));
    }

    private void Update()
    {
        stateMachine.Update();
    }

    #endregion


    #region PUBLIC METHODS

    public void InitializeCell()
    {
        var cellPositions = CalculateCellPositions();
        foreach (var cell in cellPositions.Select(CreateCell))
        {
            cells.Add(cell);
        }
    }


    public void InitializeGridMinions()
    {
        // Check if there are mergeable minions
        var hasMergeable = HasMergeableMinion();

        // Determine how many minions to spawn
        var count = spawnCount - spawnedMinions.Count;

        if (hasMergeable)
        {
            // Spawn minions randomly from the factory until there are enough minions
            for (int i = 0; i < count; i++)
            {
                // Choose a random minion from the factory and create it at a random position
                var minion = RandomSpawnMinion(i);

                // Add the spawned minion to the list of spawned minions
                spawnedMinions.Add(minion);
            }
        }
        else
        {
            // If there are no mergeable minions, try to merge existing minions until there are enough minions
            for (int i = 0; i < count; i++)
            {
                // If there are at least three spawned minions, try to merge the most frequent type of minion
                if (!hasMergeable && spawnedMinions.Count >= 3)
                {
                    // Find the most frequent type of minion among the spawned minions
                    var mostFrequent = MostFrequentMinion();

                    // Find a minion from the factory that matches the most frequent type of minion
                    var matchedMostFrequentMinion = minionsFactory.Find(x =>
                        mostFrequent != null &&
                        x.Prefab.GetComponent<Minion>().MinionType == mostFrequent.MinionType);

                    // Create the minion at a random position and add it to the list of spawned minions
                    var (randomPos, chosenCell) = GetRandomAvailableCell();
                    var initPosition = new Vector2(0.5f + i, 2);
                    var minion = matchedMostFrequentMinion.Create<Minion>(initPosition);
                    minion.MoveToCell(randomPos);
                    minion.SetCurrentCell(chosenCell);
                    spawnedMinions.Add(minion);
                }
                else
                {
                    // If there are not enough spawned minions to merge, spawn a random minion from the factory
                    var minion = RandomSpawnMinion(i);

                    // Add the spawned minion to the list of spawned minions
                    spawnedMinions.Add(minion);
                }

                // Check if there are mergeable minions after each minion is spawned
                hasMergeable = HasMergeableMinion();
            }
        }
    }

    public Cell GetDropPosition(Transform draggedItem)
    {
        var availableCells = cells.Where(c => !c.isFull);

        // Sort by distance and return the nearest available cell
        return availableCells.OrderBy(c => Vector3.Distance(draggedItem.transform.position, c.transform.position))
            .FirstOrDefault();
    }


    public void SetState(GameBoardState state)
    {
        stateMachine.SetState(state);
    }

    #endregion

    #region PRIVATE METHODS

    private List<Vector3> CalculateCellPositions()
    {
        var cellPositions = new List<Vector3>();
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                // Calculate the position of the cell based on its row and column
                var x = col * horizontalSpacing;
                var y = row * -verticalSpacing;
                cellPositions.Add(new Vector3(x, y, 0));
            }
        }

        return cellPositions;
    }

    private Cell CreateCell(Vector3 position)
    {
        return cellFactory.Create<Cell>(position);
    }

    private Minion RandomSpawnMinion(int index)
    {
        int randomIndex = Random.Range(0, minionsFactory.Count);
        var (randomPos, chosenCell) = GetRandomAvailableCell();
        var initPosition = new Vector2(0.5f + index, 2);
        var minion = minionsFactory[randomIndex].Create<Minion>(initPosition);
        minion.MoveToCell(randomPos);
        minion.SetCurrentCell(chosenCell);
        return minion;
    }

    private MinionBase MostFrequentMinion()
    {
        return spawnedMinions
            .GroupBy(obj => obj)
            .OrderByDescending(group => group.Count())
            .Select(group => group.Key)
            .FirstOrDefault();
    }

    private bool HasMergeableMinion()
    {
        // Loop over each minion type in the factory
        for (int i = 0; i < minionsFactory.Count; i++)
        {
            var mergeCount = 0;
            var baseMinion = minionsFactory[i].Prefab.GetComponent<Minion>();
            // Loop over each spawned minion
            for (int j = 0; j < spawnedMinions.Count; j++)
            {
                // Check if the spawned minion has the same type as the current minion type in the factory
                if (baseMinion.MinionType !=
                    spawnedMinions[j].MinionType) continue;
                mergeCount += 1;

                // If we've found at least three minions of the same type, we can merge them
                if (mergeCount >= 3)
                {
                    // Return true if we can merge the minions
                    return true;
                }
            }
        }

        // If we haven't found any mergeable minions, return false
        return false;
    }

    private (Vector2, Cell) GetRandomAvailableCell()
    {
        // Create a dictionary to hold the cells by position
        var cellsByPosition = cells.ToDictionary(c => c.transform.position, c => c);

        // Get all empty cell positions
        var emptyPositions = cellsByPosition.Where(kvp => !kvp.Value.isFull).Select(kvp => kvp.Key).ToList();

        // Choose a random empty cell position
        var randomIndex = Random.Range(0, emptyPositions.Count);
        var randomPosition = emptyPositions[randomIndex];

        // Set the cell at the chosen position to be full
        cellsByPosition[randomPosition].isFull = true;

        return (randomPosition, cellsByPosition[randomPosition]);
    }

    #endregion
}