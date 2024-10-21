using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialRender : MonoBehaviour
{

    private MeshRenderer _Renderer;
    [SerializeField]
    private Material _material;
     public Transform wathToMove;

    private Color _currentColor;
    private Color _targetColor;
    private float _colorChangeDuration = 2f;
    private float _timesElabe;

    private Vector3 _currentposition;
    private Vector3 _targetposition;
    private float _positionChange = 5f;
    private float _timesElabePosition;

    // Start is called before the first frame update
    void Start()
    {
        _Renderer = GetComponent<MeshRenderer>();
        _currentColor = GetRandomColor();
        _targetColor = GetRandomColor();
        _material.color = GetRandomColor();
        _Renderer.material = _material;

        _currentposition = wathToMove.position;
        _targetposition = GetRandomPosition();
    }



    // Update is called once per frame
    void Update()
    {
        _timesElabe += Time.deltaTime;
        _material.color = Color.Lerp(_currentColor, _targetColor, _timesElabe / _colorChangeDuration);
            if (_timesElabe >= _colorChangeDuration)
        {
            _timesElabe = 0f;
            _currentColor = _targetColor;
            _targetColor = GetRandomColor();
        }

        _timesElabePosition += Time.deltaTime;
        wathToMove.position = Vector3.Lerp(_currentposition, _targetposition, _timesElabePosition / _positionChange);

            if(_timesElabePosition>= _positionChange)
        {
            _timesElabePosition = 0f;
            _currentposition = _targetposition;
            _targetposition= GetRandomPosition();
        }

    }
    Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);

    }
    private Vector3 GetRandomPosition()
    {
        return new Vector3(
            Random.Range(-5f, 5f), 
            Random.Range(-5f, 5f), 
            Random.Range(-5f, 5f)
            );
    }
}
