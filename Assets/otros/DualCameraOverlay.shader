Shader "Custom/DualCameraOverlay"
{
    Properties
    {
        _MainTex ("Main Camera Texture", 2D) = "white" {}
        _OverlayTex ("Overlay Camera Texture", 2D) = "white" {}
        _BlendFactor ("Blend Factor", Range(0, 1)) = 0.5
        _MainOpacity ("Main Texture Opacity", Range(0, 1)) = 0.5
        _OverlayOpacity ("Overlay Texture Opacity", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Overlay" }
        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            TEXTURE2D(_OverlayTex);
            SAMPLER(sampler_OverlayTex);

            float _BlendFactor;
            float _MainOpacity;
            float _OverlayOpacity;

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS);
                OUT.uv = IN.uv;
                return OUT;
            }

            float4 frag(Varyings IN) : SV_Target
            {
                float4 mainColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv);
                float4 overlayColor = SAMPLE_TEXTURE2D(_OverlayTex, sampler_OverlayTex, IN.uv);

                // Aplicar opacidad a cada textura
                mainColor.a *= _MainOpacity;
                overlayColor.a *= _OverlayOpacity;

                // Combinar con el factor de mezcla
                return lerp(mainColor, overlayColor, _BlendFactor);
            }
            ENDHLSL
        }
    }
}