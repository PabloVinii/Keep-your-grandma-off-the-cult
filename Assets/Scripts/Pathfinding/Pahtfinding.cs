using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pahtfinding
{
    public List<Node> FindPath(Vector2 startPosition, Vector2 targetPosition)
    {
        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();

        Node startNode = NodeGrid.Instance.GetNodeFromWorldPosition(startPosition);
        Node targetNode = NodeGrid.Instance.GetNodeFromWorldPosition(targetPosition);

        openSet.Add(startNode);

        while (openSet.Count >= 0)
        {
            Node currentNode = openSet[0];

            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost)
                {
                    if (openSet[i].hCost < currentNode.hCost)
                    {
                        currentNode = openSet[i];
                    }
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                return RetracePath(startNode, targetNode);
            }

            foreach (Node neighbour in NodeGrid.Instance.GetNeighbours(currentNode))
            {
                if(!neighbour.isWalkable || closedSet.Contains(neighbour)) continue;
                
                int newCostToNeighbour = currentNode.gCost + GetDistanceFromNodes(currentNode, neighbour);

                if (newCostToNeighbour < currentNode.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newCostToNeighbour;
                    neighbour.hCost = GetDistanceFromNodes(targetNode, neighbour);
                    neighbour.parent = currentNode;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
            }
        }

        return null;
    }

    private List<Node> RetracePath(Node startNode, Node endNode)
    {
        Node currentNode = endNode;

        List<Node> path = new List<Node>();

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        path.Reverse();
        return path;
    }

    private int GetDistanceFromNodes(Node nodeA, Node nodeB)
    {
        int distanceX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int distanceY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (distanceX > distanceY) return 14 * distanceY + 10 * (distanceX - distanceY);

        return 14 * distanceX + 10 * (distanceY - distanceX);
    }
}
