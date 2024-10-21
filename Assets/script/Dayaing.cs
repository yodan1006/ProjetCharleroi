using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dayaing : MonoBehaviour
{
    public Animator animator; // Référence à l'Animator
    public float health = 100f; // Valeur initiale de la santé

    void Start()
    {
        // Vérifiez que l'Animator est assigné
        if (animator != null)
        {
            // Initialiser le paramètre Health dans l'Animator au démarrage
            animator.SetFloat("healt", health);
        }
        else
        {
            Debug.LogError("Animator not assigned!");
        }
    }

    void Update()
    {
        // Mettre à jour le paramètre de santé dans l'Animator
        animator.SetFloat("healt", health);

        // Vérifier si la santé est à 0 pour changer l'état
        if (health <= 0)
        {
            // Jouer l'animation de mort ou tout autre traitement nécessaire
            animator.SetTrigger("Dead");
        }
    }

    public void TakeDamage(float damage)
    {
        // Réduire la santé
        health -= damage;

        // Empêcher la santé de devenir négative
        if (health < 0)
        {
            health = 0;
        }

        Debug.Log("healt: " + health);
    }
}


