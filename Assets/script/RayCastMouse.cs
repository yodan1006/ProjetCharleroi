using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastMouse : MonoBehaviour
{

    Color color;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast touche : " + hit.transform.name);

                hit.transform.GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }
}
