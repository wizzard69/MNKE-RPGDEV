using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node: MonoBehaviour
{
    [HideInInspector]
    public bool walkable;
    [HideInInspector]
    public Vector3 worldPosition;
    [HideInInspector]
    public int gridX;
    [HideInInspector]
    public int gridY;
    [HideInInspector]
    public Node parent;

    public Node(bool _walkable, Vector3 _worldpos, int _gridX, int _gridY)
    {
        walkable = _walkable;
        worldPosition = _worldpos;
        gridX = _gridX;
        gridY = _gridY;
    }
}
