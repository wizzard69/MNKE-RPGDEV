using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public bool walkable;
    public Vector3 worldPosition;

    public int gridX;
    public int gridY;

    public Node parent;

    public Node(bool _walkable, Vector3 _worldpos, int _gridX, int _gridY)
    {
        walkable = _walkable;
        worldPosition = _worldpos;
        gridX = _gridX;
        gridY = _gridY;
    }
}
