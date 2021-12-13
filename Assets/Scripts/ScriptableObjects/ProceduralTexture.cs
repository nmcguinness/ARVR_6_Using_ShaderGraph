using UnityEngine;

/// <summary>
/// Procedural Texture Demo
/// https://docs.unity3d.com/ScriptReference/Texture2D.GetPixels.html
/// https://docs.unity3d.com/Manual/class-ScriptableObject.html
/// https://docs.unity3d.com/ScriptReference/EditorUtility.DisplayDialog.html
/// </summary>
[CreateAssetMenu(fileName = "ProceduralTexture", menuName = "Scriptable Objects/Texture/Procedural Texture ")]
public class TexturePacker_Cartesian_Spherical : ScriptableObject
{
    [SerializeField]
    private Texture2D inputTexture;

    [SerializeField]
    private int inputMipMapLevel = 0;

    [SerializeField]
    private int outputMipMapLevel = 0;

    [SerializeField]
    private string outputTextureName = "default.png";

    private Texture2D outputTexture;

    [ContextMenu("Reverse Texture")]
    public void ReverseTexture()
    {
        Color[] pixels = inputTexture.GetPixels(inputMipMapLevel);
        System.Array.Reverse(pixels, 0, pixels.Length);

        outputTexture = new Texture2D(inputTexture.width, inputTexture.height, TextureFormat.ARGB32, false);
        outputTexture.SetPixels(pixels, outputMipMapLevel);

        byte[] png = outputTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes($"{outputTextureName}.png", png);

        UnityEditor.EditorUtility.DisplayDialog("Texture", $"{inputTexture.name} has been packed to the output texture {outputTextureName}", "OK");
    }

    [ContextMenu("Create Normal Map")]
    public void CreateSampleNormalMap()
    {
        int width = 4, height = 4;
        Color32[] pixels = new Color32[width * height];
        for (int i = 0; i < width * height; i++)
        {
            pixels[i] = new Color32(127, 127, 255, 255);
        }

        Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false);
        texture.name = "sample_normal_4x4.png";
        texture.SetPixels32(pixels);

        byte[] png = texture.EncodeToPNG();
        System.IO.File.WriteAllBytes($"{texture.name}.png", png);

        UnityEditor.EditorUtility.DisplayDialog("Create Sample Normal Map", $"Sample normal map {texture.name} has been created", "OK");
    }
}