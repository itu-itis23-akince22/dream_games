using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelData
{
    public ItemType[,] GridData { get; protected set; }
    public List<LevelGoal> Goals { get; protected set; }
    public int Moves { get; protected set; }

    public LevelData(LevelInfo levelInfo)
    {
        int numberOfBoxes = 0;
        int numberOfStones = 0;
        int numberOfVases = 0;

        int rows = levelInfo.grid_height;
        int cols = levelInfo.grid_width;
        int totalCells = rows * cols;

        GridData = new ItemType[rows, cols];

        int gridIndex = 0;

        for (int i = rows - 1; i >= 0; --i)
        {
            for (int j = 0; j < cols; ++j)
            {
                string cellValue;

                if (gridIndex < levelInfo.grid.Length)
                {
                    cellValue = levelInfo.grid[gridIndex];
                }
                else
                {
                    cellValue = "bo";
                }

                gridIndex++;

                switch (cellValue)
                {
                    case "bo":
                        GridData[i, j] = ItemType.Box;
                        numberOfBoxes++;
                        break;
                    case "s":
                        GridData[i, j] = ItemType.Stone;
                        numberOfStones++;
                        break;
                    case "v":
                        GridData[i, j] = ItemType.VaseLayer2;
                        numberOfVases++;
                        break;
                    case "b":
                        GridData[i, j] = ItemType.BlueCube;
                        break;
                    case "g":
                        GridData[i, j] = ItemType.GreenCube;
                        break;
                    case "r":
                        GridData[i, j] = ItemType.RedCube;
                        break;
                    case "y":
                        GridData[i, j] = ItemType.YellowCube;
                        break;
                    case "rand":
                        GridData[i, j] = GetRandomCubeItemType();
                        break;
                    case "vro":
                        GridData[i, j] = ItemType.VerticalRocket; 
                        break;
                    case "hro":
                        GridData[i, j] = ItemType.HorizontalRocket; 
                        break;
                    default:
                        GridData[i, j] = GetRandomCubeItemType();
                        break;
                }
            }
        }

        Goals = new List<LevelGoal>();
        if (numberOfBoxes > 0) Goals.Add(new LevelGoal { ItemType = ItemType.Box, Count = numberOfBoxes });
        if (numberOfStones > 0) Goals.Add(new LevelGoal { ItemType = ItemType.Stone, Count = numberOfStones });
        if (numberOfVases > 0) Goals.Add(new LevelGoal { ItemType = ItemType.VaseLayer2, Count = numberOfVases });

        Moves = levelInfo.move_count;
    }

    public static ItemType GetRandomCubeItemType()
    {
        ItemType[] cubes = new ItemType[]
        {
            ItemType.GreenCube,
            ItemType.YellowCube,
            ItemType.BlueCube,
            ItemType.RedCube
        };

        return cubes[Random.Range(0, cubes.Length)];
    }
}
