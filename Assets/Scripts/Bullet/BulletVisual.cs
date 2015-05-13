using UnityEngine;
using System.Collections;

public enum AppearenceType {
    Flat,
    Diamond,
    Butterfly,
    TetrahedronShell
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
                Material material = visual.transform.Find("DiamondCore").gameObject.GetComponent<Renderer>().material;

                ShaderManager.setMaterialColor(material, Color.white);
                ShaderManager.setBlendMode(material, appearence.blendMode);
                
                material = visual.transform.Find("DiamondOutline").gameObject.GetComponent<Renderer>().material;
                
                ShaderManager.setMaterialColorOpaque(material, appearence.color);
                ShaderManager.setBlendMode(material, appearence.blendMode);
                
                break;
            }
            case AppearenceType.Butterfly:
            {
                Material material = visual.transform.Find("ButterflyBodyCore").gameObject.GetComponent<Renderer>().material;

                ShaderManager.setMaterialColor(material, Color.white);
                ShaderManager.setBlendMode(material, appearence.blendMode);
                
                material = visual.transform.Find("ButterflyBodyOutline").gameObject.GetComponent<Renderer>().material;

                ShaderManager.setMaterialColorOpaque(material, appearence.color);
                ShaderManager.setBlendMode(material, appearence.blendMode);

                material = visual.transform.Find("Wing 1/Visual").gameObject.GetComponent<Renderer>().material;

                ShaderManager.setMaterialColorOpaque(material, appearence.color);
                ShaderManager.setBlendMode(material, appearence.blendMode);

                material = visual.transform.Find("Wing 2/Visual").gameObject.GetComponent<Renderer>().material;

                ShaderManager.setMaterialColorOpaque(material, appearence.color);
                ShaderManager.setBlendMode(material, appearence.blendMode);

                break;
            }
            case AppearenceType.TetrahedronShell:
            {
                Material material = visual.transform.Find("TetrahedronCore").gameObject.GetComponent<Renderer>().material;

                ShaderManager.setMaterialColor(material, Color.white);
                ShaderManager.setBlendMode(material, appearence.blendMode);

                material = visual.transform.Find("TetrahedronShell").gameObject.GetComponent<Renderer>().material;
                
                ShaderManager.setMaterialColorOpaque(material, appearence.color, appearence.colorBlendMode);
                ShaderManager.setBlendMode(material, appearence.blendMode);

                break;
            }
            case AppearenceType.Flat:
            {
                Material material = visual.GetComponent<Renderer>().material;

                ShaderManager.setMaterialColorOpaque(material, appearence.color, appearence.colorBlendMode);
                ShaderManager.setBlendMode(material, appearence.blendMode);
                break;
            }
            default:
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
