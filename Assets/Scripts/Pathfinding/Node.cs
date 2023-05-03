using System;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Node parent;
    public Vector2 worldPosition;
    public bool isWalkable;
    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;

    public Node(bool isWalkable, Vector2 worldPosition, int gridX, int gridY)
    {
        this.isWalkable = isWalkable;
        this.worldPosition = worldPosition;
        this.gridX = gridX;
        this.gridY = gridY;
    }

    public int fCost {get => gCost + hCost;}

    public override bool Equals(object obj)
    {
        return obj is Node node &&
               EqualityComparer<Node>.Default.Equals(parent, node.parent) &&
               worldPosition.Equals(node.worldPosition) &&
               isWalkable == node.isWalkable &&
               gridX == node.gridX &&
               gridY == node.gridY &&
               gCost == node.gCost &&
               hCost == node.hCost &&
               fCost == node.fCost;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(parent, worldPosition, isWalkable, gridX, gridY, gCost, hCost, fCost);
    }
}
