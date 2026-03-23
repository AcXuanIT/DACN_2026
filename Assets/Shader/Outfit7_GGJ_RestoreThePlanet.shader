Shader "Outfit7/GGJ_RestoreThePlanet" {
	Properties {
		_Intensity ("Intensity", Float) = 1
		_CleanTex ("Clean tex", 2D) = "white" {}
		_CleanMaskTex ("Clean mask tex", 2D) = "white" {}
		_DirtyTex ("Dirty tex", 2D) = "white" {}
		_DirtyMaskTex ("Dirty mask tex", 2D) = "white" {}
		_OceanNoiseStagesTex ("Combined ocean & stages tex", 2D) = "black" {}
		_DirtinessStage ("Dirtiness stage", Float) = 1
		_WaterGradientTex ("Water gradient tex", 2D) = "white" {}
		_WaterMovementParameters ("Water movement speed, strength", Vector) = (1,1,1,1)
		_SmoothingDiff ("Smoothing difference", Float) = 0.05
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