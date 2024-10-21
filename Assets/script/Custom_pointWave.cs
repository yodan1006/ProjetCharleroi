using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_pointWave : MonoBehaviour
{
    public static Custom_pointWave Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
