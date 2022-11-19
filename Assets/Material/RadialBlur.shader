Shader "Hidden/RadiulBlur"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurRange("BlurRange", Range(0, 0.6)) = 0.5
        _BlurPower("BlurPower", Range(0, 6)) = 3
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
            float _BlurRange;
            float _BlurPower;

            static float2 center = (0.5, 0.5);

            fixed4 frag (v2f i) : SV_Target
            {
                float2 dis = i.uv - center;
                float2 dir = normalize(dis) * _BlurRange;
                float3 col = tex2D(_MainTex, i.uv - dir * 0.1).rgb;
                col += tex2D(_MainTex, i.uv - dir * 0.09).rgb;
                col += tex2D(_MainTex, i.uv - dir * 0.08).rgb;
                col += tex2D(_MainTex, i.uv - dir * 0.07).rgb;
                col += tex2D(_MainTex, i.uv - dir * 0.06).rgb;
                col += tex2D(_MainTex, i.uv - dir * 0.05).rgb;
                col += tex2D(_MainTex, i.uv - dir * 0.04).rgb;
                col += tex2D(_MainTex, i.uv - dir * 0.03).rgb;
                col += tex2D(_MainTex, i.uv - dir * 0.02).rgb;
                col += tex2D(_MainTex, i.uv - dir * 0.01).rgb;
                col += tex2D(_MainTex, i.uv + dir * 0.01).rgb;
                col += tex2D(_MainTex, i.uv + dir * 0.02).rgb;
                col += tex2D(_MainTex, i.uv + dir * 0.03).rgb;
                col += tex2D(_MainTex, i.uv + dir * 0.04).rgb;
                col += tex2D(_MainTex, i.uv + dir * 0.05).rgb;
                col += tex2D(_MainTex, i.uv + dir * 0.06).rgb;
                col += tex2D(_MainTex, i.uv + dir * 0.07).rgb;
                col += tex2D(_MainTex, i.uv + dir * 0.08).rgb;
                col += tex2D(_MainTex, i.uv + dir * 0.09).rgb;
                col += tex2D(_MainTex, i.uv + dir * 0.1).rgb;


                float d = length(dis);

                col = lerp(tex2D(_MainTex, i.uv), col /22, saturate(_BlurPower * d));
                
                return float4(col, 1);
            }
            ENDCG
        }
    }
}
