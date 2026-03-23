Shader "Outfit7/FX/FX_Flame" {
	Properties {
		_Intensity ("Intensity", Float) = 1
		_MainTex ("Main Tex", 2D) = "white" {}
		_MainColorBright ("Color Bright", Vector) = (1,1,1,1)
		_MainColorMid ("Color Mid", Vector) = (1,1,1,1)
		_MainColorDark ("Color Dark", Vector) = (1,1,1,1)
		_Speed ("Displacement Speed", Float) = 3
		_Amplitude ("Displacement Amplitude", Float) = 1
		_Frequency ("Displacement Frequency", Float) = 1
		_FlickerSpeed ("Flicker Speed", Float) = 10
		_FlickerStrength ("Flicker Strength", Float) = 0.4
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