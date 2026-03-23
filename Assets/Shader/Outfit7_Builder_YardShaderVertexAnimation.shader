Shader "Outfit7/Builder/YardShaderVertexAnimation" {
	Properties {
		_Tint ("Tint", Vector) = (1,0,0,1)
		_TintAmount ("TintAmount", Float) = 1
		_TransitionWidth ("_TransitionWidth", Float) = 0.1
		_AnimationFrequency ("Animation Frequency", Range(0, 10)) = 1
		_AnimationAmplitude ("Animation Amplitude", Range(0, 1)) = 1
		_AnimationSampleRate ("Animation Sample Rate", Range(0, 10)) = 1
		[Enum(Off,0,On,1)] _Zwrite ("Zwrite", Float) = 1
		[Enum(UnityEngine.Rendering.CompareFunction)] _Ztest ("Ztest", Float) = 4
		[Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull", Float) = 2
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			float4x4 unity_ObjectToWorld;
			float4x4 unity_MatrixVP;

			struct Vertex_Stage_Input
			{
				float4 pos : POSITION;
			};

			struct Vertex_Stage_Output
			{
				float4 pos : SV_POSITION;
			};

			Vertex_Stage_Output vert(Vertex_Stage_Input input)
			{
				Vertex_Stage_Output output;
				output.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, input.pos));
				return output;
			}

			float4 frag(Vertex_Stage_Output input) : SV_TARGET
			{
				return float4(1.0, 1.0, 1.0, 1.0); // RGBA
			}

			ENDHLSL
		}
	}
}