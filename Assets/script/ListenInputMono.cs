using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class ListenInputMono : MonoBehaviour
{

    public InputActionReference m_whatToListen;
    public UnityEvent m_onButtonPressed;
    public UnityEvent m_onButtonReleased;
    public UnityEvent<bool> m_onButtonChanged;
    public bool m_currentValue;
    private void OnEnable()
    {
        m_whatToListen.action.Enable();
        m_whatToListen.action.performed += NotifyChanged;
        m_whatToListen.action.canceled += NotifyChanged;
    }


    private void OnDisable()
    {
        m_whatToListen.action.performed += NotifyChanged;
        m_whatToListen.action.canceled += NotifyChanged;
    }

    private void NotifyChanged(InputAction.CallbackContext context)
    {
        bool value = context.ReadValue<float>() > 0.5f;
        if (value != m_currentValue )
        {
            m_currentValue = value;
            m_onButtonChanged.Invoke( m_currentValue );
            if (m_currentValue)
            {
                m_onButtonPressed.Invoke();
            }
            else 
            {
                m_onButtonReleased.Invoke();
            }
        }
    }
}
