using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchBoolMono : MonoBehaviour
{
    public UnityEvent<bool> m_onValueChanged;

    public bool m_valueIsTrue;

    [ContextMenu("Switch value")]
    public void SwitchValue()
    {
        m_valueIsTrue = !m_valueIsTrue;
        m_onValueChanged.Invoke(m_valueIsTrue);
    }
}
