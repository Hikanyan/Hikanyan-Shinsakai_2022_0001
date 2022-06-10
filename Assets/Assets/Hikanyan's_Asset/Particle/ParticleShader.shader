Shader "HikanyanShader/ParticleWave"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_moveX("MoveX", Range(0, 10)) = 1
		_moveZ("MoveZ", Range(0, 10)) = 1
		_Freq("Frequency", Range(0, 10)) = 1
	}

	SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent"}
		LOD 100
		Blend one One
		ZWrite Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float4 uv : TEXCOORD0; //ダミーとして入れたCustom1.xy(TEXCOORD0.zw)があるのでfloat4にしている
				float4 color : COLOR; //受け取るパーティクルのカラー(Color (COLOR.xyzw))
				float3 center : TEXCOORD1; //受け取るパーティクルの中心座標(Center(TEXCOORD1.xyz))
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float4 uv : TEXCOORD0; //ダミーとして入れたCustom1.xy(TEXCOORD0.zw)があるのでfloat4にしている
				float4 color : COLOR; //受け取るパーティクルのカラー(Color (COLOR.xyzw))
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _moveX;
			float _moveZ;
			float _Freq;

			v2f vert(appdata v)
			{
				v2f o;
				//座標をY方向に上下させる
				float3 center = v.center;
				float moveX = sin(_Time.y * 3. + center.x * _Freq) * _moveX;
				float moveZ = sin(_Time.y * 3. + center.z * _Freq) * _moveZ;
				v.vertex.y += moveX + moveZ;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv.xy = TRANSFORM_TEX(v.uv.xy, _MainTex); //ダミーのuv.zwは使わないのでuv.xyのみ使う。
				//o.center = v.center;
				o.color = v.color;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				//パーティクルの色をテクスチャに乗算
				fixed4 col = tex2D(_MainTex, i.uv) * i.color;
				return col;
			}
			ENDCG
		}
	}
}