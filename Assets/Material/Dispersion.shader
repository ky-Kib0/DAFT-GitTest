Shader "Hidden/Dispersion"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DispersionRange("DispersionRange", Range(0, 2)) = 1
        _DispersionPower("DispersionPower", Range(0, 6)) = 3
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _DispersionRange;
            float _DispersionPower;

            static float2 center = (0.5, 0.5);

            fixed4 frag (v2f i) : SV_Target
            {  
                fixed4 col = fixed4(0, 0, 0, 1);
                float2 dis = i.uv - center;
                float d = length(dis);
                half2 uv_0 = half2((i.uv.x - 0.5f) * _DispersionRange + 0.5f, (i.uv.y - 0.5f) * _DispersionRange + 0.5f);
                half2 uv_1 = half2((i.uv.x - 0.5f) / _DispersionRange + 0.5f, (i.uv.y - 0.5f) / _DispersionRange + 0.5f);

                col.r = lerp(tex2D(_MainTex, i.uv),tex2D(_MainTex, uv_0),saturate(_DispersionPower * d)).r;
                col.g = tex2D(_MainTex, i.uv).g;
                col.b = lerp(tex2D(_MainTex, i.uv),tex2D(_MainTex, uv_1),saturate(_DispersionPower * d)).b;
                return col;
            }
            ENDCG
        }
    }
}
