Shader "Outfit7/Runner/Env" {
	Properties {
		_FlipX ("_FlipX", Float) = 1
		[Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull", Float) = 2
		[Toggle(UNDERWATER)] UNDERWATER ("Underwater", Float) = 0
		[Header(Underwater parameters________________________________________________________________________)] _Tiling ("Tiling", Float) = 0.1
		_Tint ("Tint", Vector) = (0,0.112,0.114,0)
		_Speed ("Speed", Float) = 0.5
		_TextureSample0 ("Caustics", 2D) = "white" {}
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