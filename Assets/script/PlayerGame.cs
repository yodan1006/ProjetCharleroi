using UnityEngine;

public class PlayerGame : MonoBehaviour
{
    [SerializeField] Transform _prefabPlayer;
    [SerializeField] GridGenerator _case;
    [SerializeField] private float _Offset;
    Transform _playerTransform;
    int _playerIndex;


    private void Start()
    {
        _playerTransform = Instantiate(_prefabPlayer, _case.GameObject[_playerIndex].transform.position, Quaternion.identity);
        addPlayerOffSet();
    }

    private void addPlayerOffSet()
    {
        _playerTransform.position += new Vector3(0, 0, -_Offset);
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            int newindex = _playerIndex + _case.GridSize.x;
            if (newindex >= _case.GameObject.Length)
            {
                newindex = _playerIndex % _case.GridSize.x;
            }
            if (newindex >= 0 && newindex < _case.GameObject.Length)
            {
                Move(newindex);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            int newIndex = _playerIndex - _case.GridSize.x;
            if (newIndex < 0)
            {
                newIndex = (_case.GridSize.y - 1) * _case.GridSize.x + (_playerIndex % _case.GridSize.x);
            }
            if (newIndex >= 0 && newIndex < _case.GameObject.Length)
            {
                Move(newIndex);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int newindex = _playerIndex - 1;
            if (newindex < 0 || newindex / _case.GridSize.x != _playerIndex / _case.GridSize.x)
            {
                newindex = (_playerIndex / _case.GridSize.x + 1) * _case.GridSize.x - 1;
            }
            if (newindex >= 0 && newindex < _case.GameObject.Length)
            {
                Move(newindex);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int newIndex = _playerIndex + 1;
            if (newIndex % _case.GridSize.x == 0 && newIndex <= _case.GameObject.Length)
            {
                newIndex = _playerIndex - (_playerIndex % _case.GridSize.x);
            }
            if (newIndex < _case.GameObject.Length)
            {
                Move(newIndex);
            }
        }
    }

    private void Move(int newIndex)
    {
        _playerIndex = newIndex;
        _playerTransform.position = _case.GameObject[_playerIndex].transform.position;
        addPlayerOffSet();
    }
}
