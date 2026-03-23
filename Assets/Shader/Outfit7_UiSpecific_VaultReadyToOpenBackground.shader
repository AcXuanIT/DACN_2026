Shader "Outfit7/UiSpecific/VaultReadyToOpenBackground" {
	Properties {
		_MainTex ("Background mask", 2D) = "white" {}
		_Additive1 ("Additive mask1", 2D) = "white" {}
		_Additive2 ("Additive mask2", 2D) = "white" {}
		_Additive3 ("Additive mask3", 2D) = "white" {}
		_RotationSpeed ("Rotation speed", Float) = 1
		_Additive3Color ("Additive 3 Color", Vector) = (1,1,1,1)
		_Alpha1 ("Alpha1", Range(0, 1)) = 1
		_Alpha2 ("Alpha2", Range(0, 1)) = 1
		_Scale1 ("Scale1", Range(0, 10)) = 1
		_Scale2 ("Scale2", Range(0, 10)) = 1
		[Enum(Off,0,On,1)] _Zwrite ("Zwrite", Float) = 0
		[Enum(UnityEngine.Rendering.CompareFunction)] _Ztest ("Ztest", Float) = 4
		[Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull", Float) = 2
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200

		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			float4x4 unity_ObjectToWorld;
			float4x4 unity_MatrixVP;
			float4 _MainTex_ST;

			struct Vertex_Stage_Input
			{
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct Vertex_Stage_Output
			{
				float2 uv : TEXCOORD0;
				float4 pos : SV_POSITION;
			};

			Vertex_Stage_Output vert(Vertex_Stage_Input input)
			{
				Vertex_Stage_Output output;
				output.uv = (input.uv.xy * _MainTex_ST.xy) + _MainTex_ST.zw;
				output.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, input.pos));
				return output;
			}

			Texture2D<float4> _MainTex;
			SamplerState sampler_MainTex;

			struct Fragment_Stage_Input
			{
				float2 uv : TEXCOORD0;
			};

			float4 frag(Fragment_Stage_Input input) : SV_TARGET
			{
				return _MainTex.Sample(sampler_MainTex, input.uv.xy);
			}

			ENDHLSL
		}
	}
}