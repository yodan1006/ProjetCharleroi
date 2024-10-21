using UnityEngine;
using UnityEngine.Events;

public class OnCollisionWithPlayerScriptMono : MonoBehaviour
{

    public UnityEvent m_onCollisionDetected;
    public LayerMask m_whatToAllow;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerScriptTagMono>() != null)
        {
            m_onCollisionDetected.Invoke();
        }
    }
    private bool IsTargetInLayer(GameObject target)
    {
        return m_whatToAllow == (m_whatToAllow | (1 << target.layer));
    }
}
