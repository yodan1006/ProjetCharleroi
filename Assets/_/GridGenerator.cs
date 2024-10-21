using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{

    [SerializeField] private GameObject _prefabToSpawn;

    public Vector2Int GridSize;
    [SerializeField] private float _offset;

    private Transform _transform;
    public GameObject[] GameObject;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        GenereGrid();
    }
    private void Start()
    {
        
    }

    private void GenereGrid()
    {
        int _count = 0;
        GameObject = new GameObject[GridSize.x * GridSize.y];
        for (int y = 0; y < GridSize.y; y++)
        {
            for (int x = 0; x < GridSize.x; x++)
            {
                GameObject[_count] = Instantiate(_prefabToSpawn, new Vector3(x * _offset, y * _offset, 0), Quaternion.identity, _transform);
                _count++;
            }
        }
        ColorChange();
    }

    void ColorChange()
    {
        for (int i = 0; i < GameObject.Length; i++)
        {
            if (i % GridSize.x == 0 || i % GridSize.x == GridSize.x -1 || i < GridSize.x || i >= GameObject.Length - GridSize.x) 
            { GameObject[i].GetComponentInChildren<MeshRenderer>().material.color = Color.red; }
        } 
        }
    }
