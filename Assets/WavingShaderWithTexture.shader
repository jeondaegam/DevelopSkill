Shader "Custom/WavingShaderWithTexture"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {} // Albedo 텍스처
        _WaveFrequency ("Wave Frequency", Float) = 2.0
        _WaveAmplitude ("Wave Amplitude", Float) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            Name "FORWARD"
            Tags { "LightMode" = "ForwardBase" }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex; // 텍스처 샘플러
            float _WaveFrequency; // 파라미터: 파동 주파수
            float _WaveAmplitude; // 파라미터: 파동 진폭

            struct appdata_t
            {
                float4 vertex : POSITION; // 버텍스 위치
                float2 uv : TEXCOORD0;    // UV 좌표
            };

            struct v2f
            {
                float4 pos : POSITION; // 변형된 위치
                float2 uv : TEXCOORD0; // UV 좌표
            };

            v2f vert(appdata_t v)
            {
                v2f o;
                float wave = sin(_Time.y * _WaveFrequency + v.vertex.x) * _WaveAmplitude;
                v.vertex.y += wave; // Y 좌표에 파동 적용
                o.pos = UnityObjectToClipPos(v.vertex); // 화면 공간으로 변환
                o.uv = v.uv; // UV 좌표 유지
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                return tex2D(_MainTex, i.uv); // 텍스처에서 색상 가져오기
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
