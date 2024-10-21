using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;

public class IntroRayCast : MonoBehaviour
{
    Ray _ray;
    private void Update()
    {
        _ray = new Ray(transform.position, transform.forward * 10f);


        if (Physics.Raycast(_ray, out RaycastHit hit))
        {
            Debug.Log(hit.collider.gameObject.name);
        };
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 10f);
    }
}
