using UnityEngine;
using System.Collections;

public class GradientTexture : MonoBehaviour
{
    [Header("Type of Gradient")]
    [Tooltip("0 = downward to black")]
    public int type = 0;

    void Start()
    {
        float width = transform.lossyScale.x;
        float height = transform.lossyScale.y;

        Gradient gradient = new Gradient();
        Texture2D texture = new Texture2D(Mathf.CeilToInt(width), Mathf.CeilToInt(height));
        texture.alphaIsTransparency = true;

        switch (type)
        {
            case (0):
                {
                    gradient.SetKeys(DARKNESS_COLOR_KEY, DARKNESS_ALPHA_KEY);

                    float yStep = 1F / height;

                    print("Height: " + height);
                    print("yStep: " + yStep);

                    for (int y = 0; y < Mathf.CeilToInt(height); y++)
                    {
                        Color color = gradient.Evaluate(y * yStep);
                        print("Y: " + y + " | R: " + color.r + " G: " + color.g + " B: " + color.b + " A: " + color.a);

                        for (int x = 0; x < Mathf.CeilToInt(width); x++)
                        {
                            texture.SetPixel(Mathf.CeilToInt(x), Mathf.CeilToInt(y), color);
                        }
                    }

                    break;
                }
        }

        GetComponent<Renderer>().material.mainTexture = texture;
    }

    public static GradientColorKey[] DARKNESS_COLOR_KEY = { new GradientColorKey(Color.black, 0), new GradientColorKey(Color.black, 1) };
    public static GradientAlphaKey[] DARKNESS_ALPHA_KEY = { new GradientAlphaKey(0, 0), new GradientAlphaKey(1, 1) };

}