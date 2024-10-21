using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloLoopMono : MonoBehaviour
{
    public Vector3 m_euleurRotationAtStart;  // Rotation du Kapla � la cr�ation
    public GameObject domino;  // Le mod�le de domino/Kapla � instancier
    public Transform m_whereToCreateside;  // Point de d�part
    public int m_numberOfKaplas;  // Nombre de Kaplas � cr�er
    public float m_spacing = 1.0f;  // Distance entre les Kaplas
    public float spaceDepart = 0.02f;  // D�calage initial pour le premier Kapla (2 cm)

    // Start est appel� au d�marrage de la sc�ne
    void Start()
    {
        int i = 0;
        Vector3 sideDirection = m_whereToCreateside.right;  // Direction dans laquelle les Kaplas seront cr��s
        Vector3 startPosition = m_whereToCreateside.position + sideDirection * spaceDepart;  // Ajouter le d�calage initial

        while (i < m_numberOfKaplas)
        {
            // Cr�er un nouveau Kapla
            GameObject created = GameObject.Instantiate(domino);

            // Calculer la position du Kapla en prenant en compte le d�calage de d�part et l'espacement
            Vector3 positionOffset = sideDirection * (i * m_spacing);
            created.transform.position = startPosition + positionOffset;  // Position bas�e sur startPosition (avec d�calage)

            // Appliquer la rotation initiale
            created.transform.Rotate(m_euleurRotationAtStart, Space.Self);

            // Incr�menter le compteur
            i++;
        }
    }

    // Update est appel� � chaque frame
    void Update()
    {

    }
}
