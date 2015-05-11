using UnityEngine;
using System.Collections;

public enum ColorBlending {
    Multiply = 0,
    Add = 1
}

public enum AppearenceType {
    Flat,
    Diamond
}

[System.Serializable]
public class BulletAppearence {
    public Color color;
    public ColorBlending colorBlendMode; // Only used when there is a texture involved
    public Blending blendMode;
}

public class BulletVisual : MonoBehaviour {
    public AppearenceType appearenceType = AppearenceType.Flat;
    public BulletAppearence appearence;
    private GameObject visual;

    void Start() {
        visual = transform.Find("Visual").gameObject;
        switch (appearenceType) {
            case AppearenceType.Diamond:
            {
                Renderer visualRenderer = visual.transform.Find("DiamondCore").gameObject.GetComponent<Renderer>();

                visualRenderer.material.SetColor("_Color", Color.white);
                UnlitBlendMode.setBlendMode(visualRenderer.material, appearence.blendMode);
                
                visualRenderer = visual.transform.Find("DiamondOutline").gameObject.GetComponent<Renderer>();
                
                visualRenderer.material.SetColor("_Color", appearence.color);
                UnlitBlendMode.setBlendMode(visualRenderer.material, appearence.blendMode);

                break;
            }
            case AppearenceType.Flat:
            default:
            {
                Renderer visualRenderer = visual.GetComponent<Renderer>();

                visualRenderer.material.SetColor("_Color", appearence.color);
                visualRenderer.material.SetInt("_ColorBlend", (int)appearence.colorBlendMode);
                UnlitBlendMode.setBlendMode(visualRenderer.material, appearence.blendMode);
                break;
            }
        }
    }
}
