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
				float4 uv : TEXCOORD0; //�_�~�[�Ƃ��ē��ꂽCustom1.xy(TEXCOORD0.zw)������̂�float4�ɂ��Ă���
				float4 color : COLOR; //�󂯎��p�[�e�B�N���̃J���[(Color (COLOR.xyzw))
				float3 center : TEXCOORD1; //�󂯎��p�[�e�B�N���̒��S���W(Center(TEXCOORD1.xyz))
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float4 uv : TEXCOORD0; //�_�~�[�Ƃ��ē��ꂽCustom1.xy(TEXCOORD0.zw)������̂�float4�ɂ��Ă���
				float4 color : COLOR; //�󂯎��p�[�e�B�N���̃J���[(Color (COLOR.xyzw))
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _moveX;
			float _moveZ;
			float _Freq;

			v2f vert(appdata v)
			{
				v2f o;
				//���W��Y�����ɏ㉺������
				float3 center = v.center;
				float moveX = sin(_Time.y * 3. + center.x * _Freq) * _moveX;
				float moveZ = sin(_Time.y * 3. + center.z * _Freq) * _moveZ;
				v.vertex.y += moveX + moveZ;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv.xy = TRANSFORM_TEX(v.uv.xy, _MainTex); //�_�~�[��uv.zw�͎g��Ȃ��̂�uv.xy�̂ݎg���B
				//o.center = v.center;
				o.color = v.color;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				//�p�[�e�B�N���̐F���e�N�X�`���ɏ�Z
				fixed4 col = tex2D(_MainTex, i.uv) * i.color;
				return col;
			}
			ENDCG
		}
	}
}