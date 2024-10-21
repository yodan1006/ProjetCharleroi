using UnityEngine;

public class GridDamier : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;

    [SerializeField] private Vector2Int _gridSize;
    [SerializeField] private float _offset;

    private Transform _transform;
    private GameObject[] _gameObject;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    private void Start()
    {
        int _count = 0;
        _gameObject = new GameObject[_gridSize.x * _gridSize.y];
        for (int y = 0; y < _gridSize.y; y++)
        {
            for (int x = 0; x < _gridSize.x; x++)
            {
                _gameObject[_count] = Instantiate(_prefabToSpawn, new Vector3(x * _offset, y * _offset, 0), Quaternion.identity, _transform);
                _count++;
            }
        }
        ColorChange();
    }


    void ColorChange()
    {
        for (int i = 0; i < _gameObject.Length; i++)
        {
            // Vérification des bords gauche, droit, haut, bas
            if (i % _gridSize.x == 0 ||                          // Bord gauche
                i % _gridSize.x == _gridSize.x - 1 ||            // Bord droit
                i < _gridSize.x ||                               // Bord haut
                i >= _gameObject.Length - _gridSize.x)           // Bord bas
            {
                // Cas des bords haut et bas
                if (i < _gridSize.x || i >= _gameObject.Length - _gridSize.x)
                {
                    // Coloration en fonction de la parité de l'indice
                    _gameObject[i].GetComponentInChildren<MeshRenderer>().material.color = (i % 2 == 0) ? Color.red : Color.blue;
                }
                // Cas des bords gauche et droit
                else
                {
                    // Coloration avec alternance pour les bords gauche et droit
                    int rowIndex = (i / _gridSize.x);
                    int colIndex = (i % _gridSize.x);

                    // Si la ligne est paire, on commence avec bleu à gauche
                    // Si la ligne est impaire, on commence avec rouge à gauche
                    if (rowIndex % 2 == 0)
                    {
                        _gameObject[i].GetComponentInChildren<MeshRenderer>().material.color = (colIndex % 2 == 0) ? Color.blue : Color.red;
                    }
                    else
                    {
                        _gameObject[i].GetComponentInChildren<MeshRenderer>().material.color = (colIndex % 2 == 0) ? Color.red : Color.blue;
                    }
                }
            }
        }
    }
}
    

