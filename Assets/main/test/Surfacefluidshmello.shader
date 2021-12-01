Shader "Custom/Surfacefluidshmello"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Normals ("Normals", 2D) = "bump" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _DissolveMask("dissolve", 2D) = "black"{}
        _StepRange("range",Range(0,2)) = 2.0
        _FallOff("falloff",Range(0,1)) = 0.15
        _Edge("edge",Range(0,1)) = 0.15
        _inMinMax("msms",float) = 0.0
        _inMinMaxx("msms",float) = 1.0
        _outMinMax("wds",float) = 0.0
        _outMinMaxx("wds",float) = 1.0
        _test1("test1",Range(-1,1)) = 0.15
        _test2("test2",Range(-1,1)) = 0.15
        _testt1("testt1",Range(-1,1)) = 0.15
        _testt2("testt2",Range(-1,1)) = 0.15
        _testtt1("testtt1",Range(-1,1)) = 0.15
        _testtt2("testtt2",Range(-1,1)) = 0.15
    }
    SubShader
    {
        Tags {"Queue"="Transparent"  "RenderType"="Transparent" }
        LOD 200
        

        CGPROGRAM
        
        #pragma surface surf Standard Lambert fullforwardshadows alpha:fade

        

        sampler2D _MainTex;
        sampler2D _DissolveMask;
        sampler2D _Normals;
        float _StepRange;
        float _FallOff;
        float _inMinMax;
        float _inMinMaxx;
        float _outMinMax;
        float _outMinMaxx;
        float _Edge;
        float _test1;
        float _test2;
        float _testt1;
        float _testt2;
        float _testtt1;
        float _testtt2;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_DissolveMask;            
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        float Remap(float Value, float InMinMax, float InMinMaxx,  float OutMinMax, float OutMinMaxx)
        {
            return OutMinMax + (Value - InMinMax) * (OutMinMaxx - OutMinMax) / (InMinMaxx - InMinMax);
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            fixed4 mask = tex2D(_DissolveMask, IN.uv_DissolveMask);
            fixed4 normal = tex2D(_Normals, IN.uv_DissolveMask);
            float remap = Remap(mask.r,0.0,1.0,-1 * _StepRange,_StepRange) + _Edge;

            o.Albedo = c.rgb;
            c.a = smoothstep(IN.uv_MainTex.y - _FallOff,IN.uv_MainTex.y,remap) *
                  (1 - smoothstep(IN.uv_MainTex.y + _test1,IN.uv_MainTex.y + _test2,remap)) *
                  smoothstep(IN.uv_MainTex.x + _testt1,IN.uv_MainTex.x + _testt2,remap) *
                  (1 - smoothstep(IN.uv_MainTex.x + _testtt1,IN.uv_MainTex.x + _testtt2,remap));
            o.Metallic = _Metallic;
            o.Normal = normal;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
