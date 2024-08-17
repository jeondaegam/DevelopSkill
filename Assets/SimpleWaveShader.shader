Shader "Custom/SimpleWaveShader"
{
    Properties
    {
        _Color ("Main Color", Color) = (0.5, 0.5, 1, 1) // 기본 색상
        _WaveFrequency ("Wave Frequency", Float) = 2.0 // 파도 주기
        _WaveAmplitude ("Wave Amplitude", Float) = 0.1 // 파도 크기
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert vertex:vert

        float4 _Color;
        float _WaveFrequency;
        float _WaveAmplitude;

        struct Input
        {
            float2 uv_MainTex;
        };

        void vert(inout appdata_full v)
        {
            // _Time.y를 이용해 Y축 기준으로 흔들림을 적용
            v.vertex.y += sin(_Time.y * _WaveFrequency + v.vertex.x) * _WaveAmplitude;
        }

        void surf(Input IN, inout SurfaceOutput o)
        {
            // 단색을 적용하는 부분
            o.Albedo = _Color.rgb;
            o.Alpha = _Color.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
