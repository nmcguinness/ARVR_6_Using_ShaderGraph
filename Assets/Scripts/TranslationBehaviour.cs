using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationBehaviour : MonoBehaviour
{
    private Material material;
    private int transProperty;
    private Vector3 translation;

    // Start is called before the first frame update
    private void Start()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
        transProperty = Shader.PropertyToID("_Translation");
    }

    // Update is called once per frame
    private void Update()
    {
        //  translation = Vector3.up * Mathf.Sin(Time.unscaledTime);
        material.SetVector(transProperty, Vector3.up * Mathf.Sin(Time.unscaledTime));
    }
}