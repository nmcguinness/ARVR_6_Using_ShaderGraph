using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBehaviour : MonoBehaviour
{
    private Material material;

    void Start()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;

        material.SetColor("_DiffuseColor", Color.HSVToRGB(Random.value, 1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
