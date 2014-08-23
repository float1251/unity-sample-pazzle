Shader "Custom/Background" {
	Properties {
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;

		struct Input {
			float4 screenPos;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = _SinTime.z * IN.screenPos;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
