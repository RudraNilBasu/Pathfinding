using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {
    bool walkable;
    Vector3 worldPosition;

    public Node(bool _walkable, Vector3 _worldPosition)
    {
        walkable = _walkable;
        worldPosition = _worldPosition;
    }

    public bool isWalkable()
    {
        return walkable;
    }

    public Vector3 getWorldPosition()
    {
        return worldPosition;
    }
}
