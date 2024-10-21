using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace yodan
{
    public class FollowExactlyTargetMono : MonoBehaviour
    {
        public Transform m_wathToMove;
        public Transform m_wathToFollow;

        // Update is called once per frame
        void Update()
        {
            m_wathToMove.position = m_wathToFollow.position;
            m_wathToMove.rotation = m_wathToFollow.rotation;
        }
    }
}
