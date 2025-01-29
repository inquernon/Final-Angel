Shader "Custom/VisionDobleShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Separation ("Separation", Float) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float2 texcoord : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Separation;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Dibuja dos imágenes ligeramente separadas
                float2 offset = float2(_Separation, 0);
                fixed4 color1 = tex2D(_MainTex, i.texcoord + offset);
                fixed4 color2 = tex2D(_MainTex, i.texcoord - offset);
                return (color1 + color2) * 0.5;
            }
            ENDCG
        }
    }
}