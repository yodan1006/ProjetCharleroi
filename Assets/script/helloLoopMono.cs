using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloLoopMono : MonoBehaviour
{
    public Vector3 m_euleurRotationAtStart;  // Rotation du Kapla à la création
    public GameObject domino;  // Le modèle de domino/Kapla à instancier
    public Transform m_whereToCreateside;  // Point de départ
    public int m_numberOfKaplas;  // Nombre de Kaplas à créer
    public float m_spacing = 1.0f;  // Distance entre les Kaplas
    public float spaceDepart = 0.02f;  // Décalage initial pour le premier Kapla (2 cm)

    // Start est appelé au démarrage de la scène
    void Start()
    {
        int i = 0;
        Vector3 sideDirection = m_whereToCreateside.right;  // Direction dans laquelle les Kaplas seront créés
        Vector3 startPosition = m_whereToCreateside.position + sideDirection * spaceDepart;  // Ajouter le décalage initial

        while (i < m_numberOfKaplas)
        {
            // Créer un nouveau Kapla
            GameObject created = GameObject.Instantiate(domino);

            // Calculer la position du Kapla en prenant en compte le décalage de départ et l'espacement
            Vector3 positionOffset = sideDirection * (i * m_spacing);
            created.transform.position = startPosition + positionOffset;  // Position basée sur startPosition (avec décalage)

            // Appliquer la rotation initiale
            created.transform.Rotate(m_euleurRotationAtStart, Space.Self);

            // Incrémenter le compteur
            i++;
        }
    }

    // Update est appelé à chaque frame
    void Update()
    {

    }
}
