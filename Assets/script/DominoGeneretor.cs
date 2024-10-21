using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class DominoGeneretor : MonoBehaviour
{
    public GameObject m_kaplaDomino;
    public Transform m_whereToCreateLine;
    public Vector3 m_euleurRotationAtStart;

    // Nombre de Kaplas dans la ligne
    public int m_numberOfKaplas = 10;
    // Distance entre chaque Kapla
    public float m_spacing = 1.0f;

    void Start()
    {
        // Direction de la ligne (exemple : vers l'axe Z)
        Vector3 lineDirection = m_whereToCreateLine.forward; 
        //Vector3 sideDirection = m_whereToCreateLine.right;

        for (int i = 0; i < m_numberOfKaplas; i++)
        {
            // Créer un nouveau Kapla
            GameObject created = GameObject.Instantiate(m_kaplaDomino);

            // Calculer la position du Kapla
            Vector3 positionOffset = lineDirection * i * m_spacing;
            created.transform.position = m_whereToCreateLine.position + positionOffset;

            // Appliquer la rotation initiale
            created.transform.Rotate(m_euleurRotationAtStart, Space.Self);
        }
        //for (int i = 0; i < m_numberOfKaplas; i++)
        //{
        //    // Créer un nouveau Kapla
        //    GameObject created = GameObject.Instantiate(m_kaplaDomino);
        //
        //    // Calculer la position du Kapla
        //    Vector3 positionOffset = sideDirection * i * m_spacing;
        //    created.transform.position = m_whereToCreateLine.position + positionOffset;
        //
        //    // Appliquer la rotation initiale
        //    created.transform.Rotate(m_euleurRotationAtStart, Space.Self);
        //}
    }
}