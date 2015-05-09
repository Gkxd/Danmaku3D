using UnityEngine;
using System.Collections;

public enum ColorBlending {
    Multiply = 0,
    Add = 1
}

[System.Serializable]
public class BulletAppearence {
    public Color color;
    public ColorBlending colorBlendMode;
    public Blending blendMode;
}

public class BulletVisual : MonoBehaviour {

    public BulletAppearence appearence;

    private GameObject visual;
    private Renderer visualRenderer;

    void Start() {
        visual = transform.Find("Visual").gameObject;
        visualRenderer = visual.GetComponent<Renderer>();

        visualRenderer.material.SetColor("_Color", appearence.color);
        visualRenderer.material.SetInt("_ColorBlend", (int)appearence.colorBlendMode);
        UnlitBlendMode.setBlendMode(visualRenderer.material, appearence.blendMode);
    }
}
