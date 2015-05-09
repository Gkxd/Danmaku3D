using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;

public enum Blending {
    Alpha = 0,
    Add = 1
}

public static class UnlitBlendMode {
    public static void setBlendMode(Material m, Blending b) {
        switch (b) {
            case Blending.Add:
                blend(m, BlendMode.One, BlendMode.One);
                break;
            case Blending.Alpha:
                blend(m, BlendMode.SrcAlpha, BlendMode.OneMinusSrcAlpha);
                break;
        }
    }

    private static void blend(Material m, BlendMode src, BlendMode dst) {
        m.SetInt("SrcMode", (int)src);
        m.SetInt("DstMode", (int)dst);
    }
}