using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageZone : MonoBehaviour
{
    public float damageAmount = 100f; // Montant de d�g�ts � infliger

    // Cette m�thode est appel�e lorsqu'un Collider entre dans la zone de d�clenchement
    private void OnTriggerEnter(Collider other)
    {
        // V�rifiez si l'objet entrant a le tag "Player" (ou le tag que vous avez utilis� pour votre personnage)
        if (other.CompareTag("Player"))
        {
            // R�cup�rez le script CharacterAnimationController pour modifier la sant�
            Dayaing characterController = other.GetComponent<Dayaing>();
            if (characterController != null)
            {
                // Appliquez les d�g�ts
                characterController.TakeDamage(damageAmount);
            }
            else
            {
                Debug.LogWarning("CharacterAnimationController not found on the player object!");
            }
        }
    }
}

