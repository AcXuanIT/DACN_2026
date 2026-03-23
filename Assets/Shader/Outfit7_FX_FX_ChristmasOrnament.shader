Shader "Outfit7/FX/FX_ChristmasOrnament" {
	Properties {
		_Intensity ("Intensity", Range(0, 6)) = 1
		_MainColorBright ("Color Bright", Vector) = (1,1,1,1)
		_MainColorMid ("Color Mid", Vector) = (1,1,1,1)
		_MainColorDark ("Color Dark", Vector) = (1,1,1,1)
		_PatternTex ("Pattern Tex", 2D) = "black" {}
		_PatternColor ("Pattern Color", Vector) = (1,1,1,1)
		_PatternIntensity ("Pattern Intensity", Range(0, 2)) = 1
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