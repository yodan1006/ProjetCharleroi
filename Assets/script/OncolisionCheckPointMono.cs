using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace yodan
{
    //[RequireComponent(typeof(SphereCollider))]
    public class OncolisionCheckPointMono : MonoBehaviour
    {

        public UnityEvent m_onCollisionEnter;
        public UnityEvent m_onCollisionExit;

        public UnityEvent m_onTriggerEnter;
        public UnityEvent m_onTriggerExit;

        public LayerMask m_layerMask;


        public void OnCollisionEnter(Collision collision)
        {
            if(IsTargetInLayer(collision))
            m_onCollisionEnter.Invoke();
        }
        

        public void OnCollisionExit(Collision collision)
        {
            if (IsTargetInLayer(collision))
                m_onCollisionExit.Invoke();
        }
        public void OnTriggerEnter(Collider other)
        {
            if (IsTargetInLayer(other))
                m_onTriggerEnter.Invoke();
        }
        public void OnTriggerExit(Collider other)
        {
            if (IsTargetInLayer(other))
                m_onTriggerExit.Invoke();
        }

        private bool IsTargetInLayer(Collision collision)
        {
            return IsTargetInLayer(collision.gameObject);
        }
        private bool IsTargetInLayer(Collider collider)
        {
            return IsTargetInLayer(collider.gameObject);
        }
        private bool IsTargetInLayer(GameObject target)
        {
            return m_layerMask == (m_layerMask | (1 << target.layer));
        }
        public void Reset()
        {
            CheckforColider();
        }
        public void Start()
        {
            CheckforColider();
        }

        private void CheckforColider()
        {
            Collider c = GetComponent<Collider>();
            if (c == null)
            {
                Debug.LogError("OnCollisionEventMono need a collider to work", this.gameObject);
            }
        }
    }
}
