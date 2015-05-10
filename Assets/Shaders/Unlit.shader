Shader "Unlit/Additive (Add-Colorable)" {
Properties {
	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	_Color ("Tint", Color) = (0, 0, 0, 0)
	_ColorBlend ("Tint Blending", int) = 0
	
	SrcMode ("SrcMode", int) = 0
	DstMode ("DstMode", int) = 0
}

SubShader {
	Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	LOD 100
	
    Cull Off
	ZWrite Off
	Blend [SrcMode] [DstMode]
	
	Pass {
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata_t {
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				half2 texcoord : TEXCOORD0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}
			
			fixed4 _Color;
			half _ColorBlend; 
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.texcoord);
				switch(_ColorBlend) {
					case 1:
						col.rgb += _Color.rgb;
						col.rgb *= col.a;
						break;
					case 0: default:
						col.rgb *= _Color.rgb;
						break;
				}
				return col;
			}
		ENDCG
	}
}

}
