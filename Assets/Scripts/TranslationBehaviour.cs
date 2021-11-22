using UnityEngine;

public class TranslationBehaviour : MonoBehaviour
{
    private Material material;
    private int transProperty;

    // Start is called before the first frame update
    private void Start()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
        transProperty = Shader.PropertyToID("_Translation");
    }

    // Update is called once per frame
    private void Update()
    {
        material.SetVector("_Translation", Vector3.up * Mathf.Sin(Time.unscaledTime));
    }
}