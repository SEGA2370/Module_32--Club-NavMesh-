using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class RayCastAll : MonoBehaviour
{
    [SerializeField] private float maxDistance = 10f;

    private void Start()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        Debug.DrawRay(transform.position, Vector3.forward * maxDistance, Color.red, 1000);

        if (Physics.Raycast(ray, maxDistance))
        {
            Debug.Log("Object detected");
        }
        else
        {
            Debug.Log("No Objects detected");
        }
    }
}
