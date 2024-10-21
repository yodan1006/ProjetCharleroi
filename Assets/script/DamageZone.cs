using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageZone : MonoBehaviour
{
    public float damageAmount = 100f; // Montant de dégâts à infliger

    // Cette méthode est appelée lorsqu'un Collider entre dans la zone de déclenchement
    private void OnTriggerEnter(Collider other)
    {
        // Vérifiez si l'objet entrant a le tag "Player" (ou le tag que vous avez utilisé pour votre personnage)
        if (other.CompareTag("Player"))
        {
            // Récupérez le script CharacterAnimationController pour modifier la santé
            Dayaing characterController = other.GetComponent<Dayaing>();
            if (characterController != null)
            {
                // Appliquez les dégâts
                characterController.TakeDamage(damageAmount);
            }
            else
            {
                Debug.LogWarning("CharacterAnimationController not found on the player object!");
            }
        }
    }
}

