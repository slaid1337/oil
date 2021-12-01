Shader "Unlit/test"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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
    }
    SubShader
    {
        Tags {"Queue"="Transparent"  "RenderType"="Transparent" }
        LOD 100

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

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
                float2 uvMask : TEXCOORD1;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float2 uvMask : TEXCOORD1;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _DissolveMask;
            float4 _DissolveMask_ST;
            float _StepRange;
            float _FallOff;
            float _inMinMax;
            float _inMinMaxx;
            float _outMinMax;
            float _outMinMaxx;
            float _Edge;
            float _test1;
            float _test2;

            float Remap(float Value, float InMinMax, float InMinMaxx,  float OutMinMax, float OutMinMaxx)
            {
                return OutMinMax + (Value - InMinMax) * (OutMinMaxx - OutMinMax) / (InMinMaxx - InMinMax);
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uvMask = TRANSFORM_TEX(v.uvMask, _DissolveMask);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {                                
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 mask = tex2D(_DissolveMask, i.uvMask);
                float remap = Remap(mask.r,0.0,1.0,-1 * _StepRange,_StepRange) + _Edge;
               
                col.a =smoothstep(i.uv.y - _FallOff,i.uv.y,remap) * (1 - smoothstep(i.uv.y + _test1,i.uv.y + _test2,remap));
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
