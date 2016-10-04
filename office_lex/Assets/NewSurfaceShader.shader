Shader "Custom/NewSurfaceShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_SpecularColor("цвет отражения", Color) = (1,1,1,1)
		_SpecularPower("сила отражения", Range(0,5)) = 0.0
		//_Emission("свечение", Range(0,1)) = 0.1
		//_Roughness("шероховатость",Range(0,1)) = 0.1
		_Frenel("величина блика",Range(0,30)) = 0.5
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma surface surf CustomPhong
			float4 _Color;
			float4 _SpecularColor;
			float _SpecularPower;
			float _Emission;
			float _Roughness;
			float _Frenel;
		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};
		struct SurfaceCustomOutput {
			fixed3 Albedo;
			fixed3 Normal;
			fixed3 SpecularColor;
			fixed Gloss;
			fixed Alpha;
			fixed3 Emission;
			half Specular;


		};


		inline fixed4 LightingCustomPhong(SurfaceOutput s, fixed3 lightDir, half3 viewDir, fixed atten)
		{
		
			fixed4 c;
			float4 ambient;
			fixed4 diff;
			float4 specular;
			ambient.rgb = s.Albedo;
			diff.rgb = dot(s.Normal, lightDir)+_LightColor0.rgb/2.5;
			float3 reflect =normalize(2* s.Normal*dot(s.Normal, lightDir)- lightDir);
			specular =pow(dot(viewDir,reflect),_SpecularPower)*_Frenel;
			c.rgb = dot(specular, ambient.rgb);
			float3 H = normalize(lightDir + viewDir);
			float4 D = dot(s.Normal, H);
		
			c.rgb =  (_SpecularColor.rgb*_SpecularPower*D/(_Frenel -D*_Frenel +D))+ diff.rgb*(s.Albedo / 2.5);// *(s.Albedo / 2.5)
			c.a = 1.0;
			return c;

		}




		

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			//o.Specular = c.a;
			//o.Emission = 0.5;
			o.Alpha = c.a;
			
		}
		ENDCG
	}
	FallBack "Diffuse"
}
