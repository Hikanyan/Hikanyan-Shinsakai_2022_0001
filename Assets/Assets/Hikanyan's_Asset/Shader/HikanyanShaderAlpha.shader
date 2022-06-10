Shader "Unlit/HikanyanShaderAlpha"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)

	}

		SubShader{
			Tags { "Queue" = "AlphaTest"
				"RenderType" = "TransparentCutout"
			}
			LOD 200

			CGPROGRAM
			#pragma surface surf Standard alpha
			#pragma target 3.0

			struct Input {
				float3 worldNormal;
				float3 viewDir;
			};

		fixed4 _Color;

			void surf(Input IN, inout SurfaceOutputStandard o) {
				fixed4 c = _Color;
				o.Albedo = fixed4(_Color);
				float alpha = 1 - (abs(dot(IN.viewDir, IN.worldNormal)));
					o.Alpha = alpha * c.a;
			}
			ENDCG
	}
		FallBack "Standard"
}

