using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;

public enum Blending {
    Alpha = 0,
    Add = 1
}

public enum ColorBlending {
    Multiply = 0,
    Add = 1
}

public static class ShaderManager {
    public static void setBlendMode(Material m, Blending b) {
        switch (b) {
            case Blending.Add:
                blend(m, BlendMode.SrcAlpha, BlendMode.One);
                break;
            case Blending.Alpha:
                blend(m, BlendMode.SrcAlpha, BlendMode.OneMinusSrcAlpha);
                break;
        }
    }

    public static void setMaterialColor(Material m, Color c, ColorBlending colorBlending) {
        m.SetColor("_Color", c);
        m.SetInt("_ColorBlend", (int)colorBlending);
    }
    
    public static void setMaterialColor(Material m, Color c) {
        m.SetColor("_Color", c);
    }
    
    public static void setMaterialColorOpaque(Material m, Color c, ColorBlending colorBlending) {
        setMaterialColor(m, c + Color.black, colorBlending);
    }
    
    public static void setMaterialColorOpaque(Material m, Color c) {
        setMaterialColor(m, c + Color.black);
    }


    private static void blend(Material m, BlendMode src, BlendMode dst) {
        m.SetInt("SrcMode", (int)src);
        m.SetInt("DstMode", (int)dst);
    }
}