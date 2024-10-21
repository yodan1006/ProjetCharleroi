using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dayaing : MonoBehaviour
{
    public Animator animator; // R�f�rence � l'Animator
    public float health = 100f; // Valeur initiale de la sant�

    void Start()
    {
        // V�rifiez que l'Animator est assign�
        if (animator != null)
        {
            // Initialiser le param�tre Health dans l'Animator au d�marrage
            animator.SetFloat("healt", health);
        }
        else
        {
            Debug.LogError("Animator not assigned!");
        }
    }

    void Update()
    {
        // Mettre � jour le param�tre de sant� dans l'Animator
        animator.SetFloat("healt", health);

        // V�rifier si la sant� est � 0 pour changer l'�tat
        if (health <= 0)
        {
            // Jouer l'animation de mort ou tout autre traitement n�cessaire
            animator.SetTrigger("Dead");
        }
    }

    public void TakeDamage(float damage)
    {
        // R�duire la sant�
        health -= damage;

        // Emp�cher la sant� de devenir n�gative
        if (health < 0)
        {
            health = 0;
        }

        Debug.Log("healt: " + health);
    }
}


