using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGrid : MonoBehaviour
{

    public static NodeGrid Instance{get; private set;}

    public Node[,] grid;
    public Vector2 worldGridSize;
    public float nodeRadius;
    float nodeDiameter;
    int gridSizeX, gridSizeY;
    public LayerMask unwalkableLayer;
    public List<Node> path;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(this);

        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(worldGridSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(worldGridSize.y / nodeDiameter);

        CreateGrid();
    }

    private void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector2 position2D = new Vector2(transform.position.x, transform.position.y);

        Vector2 worldBottomLeft =
         position2D - Vector2.right * worldGridSize.x / 2 - Vector2.up * worldGridSize.y / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector2 worldPosition = worldBottomLeft + Vector2.right * (x * nodeDiameter + nodeRadius) + Vector2.up * (y * nodeDiameter + nodeRadius);
                bool isWalkable = !Physics2D.OverlapCircle(worldPosition, nodeRadius, unwalkableLayer);
                grid[x, y] = new Node(isWalkable, worldPosition, x, y);
            }
        }
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (y == 0 & x == 0) continue;

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbours.Add(grid[checkX, checkY]);
                }
            }
        }

        return neighbours;
    }

    public Node GetNodeFromWorldPosition(Vector2 position)
    {
        float percentX = (position.x + worldGridSize.x / 2) / worldGridSize.x;
        float percentY = (position.y + worldGridSize.y / 2) / worldGridSize.y;

        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

        return grid[x, y];
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireCube(transform.position, worldGridSize);
        if (grid != null)
        {
            foreach (Node node in grid)
            {
                Gizmos.color = node.isWalkable ? Color.white : Color.red;
                
                if (path != null)
                {
                    if (path.Contains(node)) Gizmos.color = Color.black;
                }
                
                Gizmos.DrawCube(node.worldPosition, Vector2.one * (nodeDiameter - .1f));
            }
        }
    }
}


