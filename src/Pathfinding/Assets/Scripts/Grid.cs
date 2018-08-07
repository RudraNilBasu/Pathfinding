using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    [SerializeField]
    LayerMask unwalkableMask;

    [SerializeField]
    Vector2 gridWorldSize;

    [SerializeField]
    float nodeSize;

    Node[,] grid;

    int gridCountX, gridCountY;

	// Use this for initialization
	void Start () {
        gridCountX = Mathf.RoundToInt(gridWorldSize.x / nodeSize);
        gridCountY = Mathf.RoundToInt(gridWorldSize.y / nodeSize);

        CreateGrids();
    }

    private void CreateGrids()
    {
        grid = new Node[gridCountX, gridCountY];
        float nodeRadius = nodeSize / 2; // Doing a `nodeSize / 2` for every x and y might be costly

        Vector3 worldBottomLeftPosition = transform.position
                                          - (Vector3.right * (gridWorldSize.x / 2))
                                          - (Vector3.forward * (gridWorldSize.y / 2));

        for (int x = 0; x < gridCountX; x++) {
            for (int y = 0; y < gridCountY; y++) {
                Vector3 _worldPosition = worldBottomLeftPosition
                                         + Vector3.right * (x * nodeSize + nodeRadius)
                                         + Vector3.forward * (y * nodeSize + nodeRadius);
                bool _walkable = !Physics.CheckSphere(_worldPosition, nodeRadius, unwalkableMask);
                grid[x, y] = new Node(_walkable, _worldPosition);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

        if (grid != null) {
            foreach (Node n in grid) {
                Gizmos.color = (n.isWalkable()) ? Color.green: Color.red;
                Gizmos.DrawCube(n.getWorldPosition(), Vector3.one * (nodeSize - .1f));
            }
        }
    }
}

