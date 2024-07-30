using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private Material greenMaterial;

    private void Start()
    {
        Ray ray = new Ray(transform.position, Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit , maxDistance))
        {
            Debug.Log(hit.transform.position);
            hit.transform.position += new Vector3(0, 2, 0);
            hit.transform.gameObject.GetComponent<Renderer>().material = greenMaterial;
            Debug.Log("Object detected");
        }
        else 
        {
            Debug.Log("No Objects detected");
        }
    }
}
