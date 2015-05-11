Shader "Unlit/Solid Color" {
Properties {
	_Color ("Tint", Color) = (0, 0, 0, 0)
	
	SrcMode ("SrcMode", int) = 0
	DstMode ("DstMode", int) = 0
}

SubShader {
	Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	LOD 100
	
    Cull Back
	ZWrite Off
	Blend [SrcMode] [DstMode]
	
	Pass {
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata_t {
				float4 vertex : POSITION;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
			};
			
			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				return o;
			}
			
			fixed4 _Color;
			
			fixed4 frag (v2f i) : SV_Target
			{
				return _Color;
			}
		ENDCG
	}
}

}
