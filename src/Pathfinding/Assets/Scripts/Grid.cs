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
        // store grid world position and walkable (bool)
        // to fill the array

        // calculate the bottom left of the world
        Vector3 worldBottomLeftPosition = transform.position
                                          - (Vector3.left * (gridWorldSize.x / 2))
                                          - (Vector3.back * (gridWorldSize.y / 2));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));
    }
}
