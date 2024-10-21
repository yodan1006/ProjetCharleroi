using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusMoveCube : MonoBehaviour
{
    //[SerializeField] Vector3 _startPosition;
    //[SerializeField] Vector3 _endPosition;

    [SerializeField] float _amplitude;
    [SerializeField] float _frequence;
    [SerializeField] float _speed;
    [SerializeField] float _lerpSpeed;

    float _currentTime;
    float _starPos;
    float _endPos;

    Transform _transform;
    Renderer _renderer;

    private Custom_pointWave _ancorePointWave;

    private void Awake()
    {
        _transform = transform;

        _starPos = _transform.position.z - _amplitude * 0.5f;
        _endPos = _transform.position.z + _amplitude * 0.5f;
        _renderer = GetComponent<Renderer>();

    }

    private void Start()
    {
        _ancorePointWave = Custom_pointWave.Instance;
        _currentTime += Vector3.Distance(_ancorePointWave.GetPosition(), transform.position) * _frequence;    
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime * _speed;

        float positionOnSin = Mathf.Sin(_currentTime + Mathf.PI) * 0.5f + 0.5f;
        Vector3 newPos = new Vector3(_transform.position.x,_transform.position.y, Mathf.Lerp(_starPos, _endPos, positionOnSin));

        _transform.position = newPos;

        float lerpFactor = Mathf.InverseLerp(_starPos, _endPos, _transform.position.z);

        Color targetColor = Color.Lerp(Color.black, Color.white, lerpFactor);
        _renderer.material.color = Color.Lerp(_renderer.material.color, targetColor, Time.deltaTime * _lerpSpeed);
    }
}
