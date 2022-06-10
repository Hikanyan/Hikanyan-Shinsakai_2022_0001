Shader "MyShader/Line"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Color("MainColor", Color) = (0, 0, 0, 1)
		_GridColor("GridColor", Color) = (1, 1, 1, 1)
		_GridSize("GridSize", Range(0, 50)) = 1
		_LineWidth("LineWidth", Range(0.4, 1)) = 0.1
		_Edge("Edge", Range(0.001, 0.8)) = 0.1
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 200
			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					UNITY_FOG_COORDS(1)
					float4 vertex : SV_POSITION;
					float4 pos : TEXCOORD1;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;

				float4 _GridColor;
				float4 _Color;
				float _GridSize;
				float _LineWidth;
				float _Edge;

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.uv, _MainTex);
					o.pos = v.vertex;
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					fixed4 col = tex2D(_MainTex, i.uv) * _Color;

					float3 f = smoothstep(_LineWidth, _Edge + _LineWidth, frac(i.pos.xyz * _GridSize))
						+ smoothstep(1 - _LineWidth, 1 - _Edge - _LineWidth, frac(i.pos.xyz * _GridSize));
					f *= step(0.001, fwidth(i.pos.xyz));
					//float grid = saturate(f.x + f.y + f.z);
					float grid = max(max(f.x, f.y), f.z);
					col.rgb = col.rgb * (1 - grid) + grid * _GridColor.rgb;

					col = fixed4(grid, grid, grid, 1);
					return col;
				}
				ENDCG
			}
		}
}
