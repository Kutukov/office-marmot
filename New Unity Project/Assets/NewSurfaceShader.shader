Shader "Custom/NewSurfaceShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_SpecularColor("цвет отражения", Color) = (1,1,1,1)
		_SpecularPower("сила отражение", Range(0,5)) = 0.0
		_Gloss("блеск",range(0,1)) = 0.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf CustomPhong

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		float4 _SpecularColor;
		float _SpecularPower;
		float _Gloss;
		struct Input {
			float2 uv_MainTex;
		};

		
		

		}
		struct SurfaceCustomOutput
		{
			fixed3 Albedo;
			fixed3 Normal;
			fixed3 Emission;
			fixed3 SpecularColor;
			fixed Alpha;
			fixed Gloss;
		
		}
		;
			inline fixed4 LightingCustomPhong(SurfaceOutput s, fixed3 lightDir,half3 viewDir,fixed atten)
				{
			float diff = dot(s.Normal, lightDir);
			float reflectionVector = normalize(2.0*s.Normal*diff - lightDir);
			float spec = pow(max(0.1, dot(reflectionVector, viewDir)), _SpecularPower);
			fixed4 c;
			float finalspec = spec*_SpecularColor.rgb;
				c.rgb = (s.Albedo*diff*_LightColor0.rgb)+ (finalspec*_LightColor0.rgb*_SpecularColor.rgb);
				c.a = 1.0;
				return c;



		
		fixed4 _Color;

		void surf (Input IN, inout  SurfaceCustomOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Gloss = _Gloss;
			o.Alpha = c.a;
			o.Specular = _SpecularPower;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
