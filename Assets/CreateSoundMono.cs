using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace yodan
{

    public class CreateSoundMono : MonoBehaviour
    {
        public Transform w_whereToPlaySound;
        public AudioClip m_sound;
        [Range(0, 1)]
        public float m_volume = 1.0f;
    
        [ContextMenu("Create the Sound")]
        public void CreateTheSound()
        {
            GameObject createdGameObject = new GameObject("Sound"+ m_sound.name);
            createdGameObject.transform.position = w_whereToPlaySound.position;
            AudioSource audiosource = createdGameObject.AddComponent<AudioSource>();
            audiosource.clip = m_sound;
            audiosource.volume = m_volume;
            audiosource.Play();
            float timeToBeKilled = m_sound.length;
            Destroy(createdGameObject, timeToBeKilled);
        }
    }

}
