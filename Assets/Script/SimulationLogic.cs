using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class SimulationLogic : MonoBehaviour
{
    [SerializeField] Tilemap currentState;
    [SerializeField] Tilemap nextState;
    [SerializeField] Tile AliveTile;
    [SerializeField] Tile DeadTile;
    [SerializeField] StartingPatterns pattern;
    [SerializeField] float UpdateInterval;

    HashSet<Vector3Int> AliveCells = new HashSet<Vector3Int>();
    HashSet<Vector3Int> NeedToCheckCells = new HashSet<Vector3Int>();

    bool isDrag = false;

    private void Start()
    {
        //SetPatterns(pattern);
        isDrag = false;
    }

    void SetPatterns(StartingPatterns pattern)
    {
        clear();
        Vector2Int center = pattern.GetCenter();

        foreach (Vector2Int i in pattern.cells)
        {
            Vector3Int cell = (Vector3Int)(i - center);
            currentState.SetTile(cell, AliveTile);
            AliveCells.Add(cell);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrag = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
        }

        if (isDrag)
        {
            SetTile();
        }
    }

    void clear()
    {
        currentState.ClearAllTiles();
        nextState.ClearAllTiles();
    }

    private void OnEnable()
    {
        //StartCoroutine(Simulation());
    }

    public void StartSim()
    {
        StartCoroutine(Simulation());
    }

    public void RestartSim()
    {
        enabled = false;
        SceneManager.LoadScene(0);
    }


    IEnumerator Simulation()
    {
        while (enabled)
        {
            UpdateState();
            yield return new WaitForSeconds(UpdateInterval);
        }
    }

    void UpdateState()
    {
        NeedToCheckCells.Clear();

        foreach (Vector3Int cell in AliveCells)
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    NeedToCheckCells.Add(cell + new Vector3Int(x, y));
                }
            }
        }

        foreach (Vector3Int cell in NeedToCheckCells)
        {
            int neighbors = CountNeighbour(cell);
            bool alive = (currentState.GetTile(cell) == AliveTile);

            if (!alive && neighbors == 3)
            {
                //Debug.Log("calling");
                nextState.SetTile(cell, AliveTile);
                AliveCells.Add(cell);
            }
            else if (alive && (neighbors < 2 || neighbors > 3))
            {
                //Debug.Log("calling");
                nextState.SetTile(cell, DeadTile);
                AliveCells.Remove(cell);
            }
            else
            {
                nextState.SetTile(cell, currentState.GetTile(cell));
            }
        }

        Tilemap temp = currentState;
        currentState = nextState;
        nextState = temp;
        nextState.ClearAllTiles();
    }

    int CountNeighbour(Vector3Int cell)
    {
        int count = 0;

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) continue;
                else
                {
                    Vector3Int neighbor = cell + new Vector3Int(x, y, 0);
                    if (currentState.GetTile(neighbor) == AliveTile) count++;
                }
            }
        }

        return count;
    }

    void SetTile()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(string.Format("Co-ords of mouse is [X: {0} Y: {0}]", pos.x, pos.y));
        Vector3Int coordinate = currentState.WorldToCell(pos);
        //Debug.Log(coordinate);
        if (currentState.GetTile(coordinate) == AliveTile)
        {
            //AliveCells.Remove(coordinate);
            //currentState.SetTile(coordinate, DeadTile);
        }
        else
        {
            AliveCells.Add(coordinate);
            currentState.SetTile(coordinate, AliveTile);
        }
    }

}
