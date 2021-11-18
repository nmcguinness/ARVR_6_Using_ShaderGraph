// MIT License

// Copyright (c) 2020 NedMakesGames

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files(the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions :

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using UnityEngine;

public class InteractiveRippleController : MonoBehaviour
{
    private Material material;
    private Color previousColor;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;

        // Set the base and ripple colors as equal so the ripple will not flash when the game loads
        previousColor = material.GetColor("_BaseColor");
        material.SetColor("_RippleColor", previousColor);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastClickRay();
        }
    }

    private void CastClickRay()
    {
        var camera = Camera.main;
        var mousePosition = Input.mousePosition;
        // The XY coordinates are in screen space, while the Z coordinate is in view space
        var ray = camera.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y, camera.nearClipPlane));
        // If our ray hits a collider, and that collider is attached to this game object
        if (Physics.Raycast(ray, out var hit) && hit.collider.gameObject == gameObject)
        {
            StartRipple(hit.point);
        }
    }

    private void StartRipple(Vector3 center)
    {
        // Choose a random color
        Color rippleColor = Color.HSVToRGB(Random.value, 1, 1);

        material.SetVector("_RippleCenter", center);
        // The Time.time value is the same as the Time node in shader graph
        material.SetFloat("_RippleStartTime", Time.time);
        material.SetColor("_BaseColor", previousColor);
        material.SetColor("_RippleColor", rippleColor);

        // Store the current ripple color so we can set the base color to it next time
        previousColor = rippleColor;
    }
}