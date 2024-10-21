using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Walking : MonoBehaviour
{
    public Transform _whatToMove;
    public float axisX;
    public float axisY;
    public float moveSpeed = 2f;
    public bool Walk;
    public float _health = 100f;

    public InputActionReference _play;
    public Animator _animator;
    public bool _isWalking;
    public bool _isDead = false;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (_isDead) return;

        Vector2 input = context.ReadValue<Vector2>();

        axisX = input.x;
        axisY = input.y;

        if (input.magnitude > 0)
        {
            _isWalking = true;
            _animator.SetBool("Walking", _isWalking);
        }
    }

    private void Start()
    {
         _animator = GetComponent<Animator>();
        if (_animator != null)
        {
            _play.action.Enable();
            _play.action.performed += OnPlayPressed;
            _play.action.canceled += OnPlayRelease;
        }
        _animator.SetFloat("healt", _health);
    }

    private void OnPlayRelease(InputAction.CallbackContext context)
    {
        if ( _isDead) return;

        _isWalking = false;
        _animator.SetBool("Walking", _isWalking);
    }

    private void OnPlayPressed(InputAction.CallbackContext context)
    {
        _isWalking = true;
        _animator.SetBool("Walking", _isWalking);
    }

    private void OnValidate()
    {
        if (_animator != null) { _animator.SetBool("Walking", _isWalking); }
    }
    // Update is called once per frame
    void Update()
    {
        if (_isWalking && !_isDead) {
            Vector3 mouve = new Vector3(axisX, 0, axisY) * moveSpeed * Time.deltaTime;
            _whatToMove.Translate(mouve, Space.World);
        }

        // Exemple de d�tection d'un �v�nement de perte de vie
        if (Input.GetKeyDown(KeyCode.Space))
        { // Simule une touche qui fait perdre de la vie
            _health -= 50f; // Perdre 50 points de vie
        }

        // Mettre � jour le param�tre de l'Animator
        _animator.SetFloat("healt", _health);

        // Si la sant� est inf�rieure ou �gale � 0, on s'assure que le personnage est bien en �tat "Dead"
        if (_health <= 0)
        {
            _health = 0; // Emp�che la sant� de devenir n�gative
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("deadzone"))
        {
            _isDead = true;
            _animator.SetTrigger("Death");
        }
    }

    private void OnDestroy()
    {
        if (_play != null)
        {
            _play.action.performed -= OnPlayPressed;
            _play.action.canceled -= OnPlayRelease;
        }
    }
}
