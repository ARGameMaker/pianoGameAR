Shader "Custom/OutLine"
{
        Properties
        {
                _OutlineColor("OutlineColr",COLOR) = (1,0,0,1)
                _OutlineFactor("OutlineFactor",Range(0,1)) = 0.1
 
                _MainTex("Tex",2D) = "white"{}
        }
        SubShader
        {
                Tags{ "RenderType" = "Opaque" }
                LOD 200
 
                pass 
                {
                
                        CGPROGRAM
                        #include "UnityCG.cginc"
                        #pragma vertex vert
                        #pragma fragment frag
 
                        fixed4 _OutlineColor;
                        float _OutlineFactor;
 
                        struct appdata
                        {
                                float4 vertex:POSITION;
                        };
 
                        struct v2f
                        {
                                float4 vertex :SV_POSITION;
                                half4 color:COLOR;
                        };
 
                        v2f vert(appdata v)
                        {
                                v2f o;
                                float3 viewDir = normalize(
                                        UNITY_MATRIX_P[3][3] * -UNITY_MATRIX_V[2].xyz +
                                        (1 - UNITY_MATRIX_P[3][3]) * (v.vertex.xyz - _WorldSpaceCameraPos));
                                float3 offset = _OutlineFactor * v.vertex.xyz + viewDir*0.001;
                                v.vertex.xyz += offset;
                                o.vertex = UnityObjectToClipPos(v.vertex);
                                o.color = _OutlineColor;
                                return o;
                        }
 
                        fixed4 frag(v2f i):SV_TARGET
                        {
                                return _OutlineColor;
                        }
 
                        ENDCG
                }
 
                pass
                {
                        
                        CGPROGRAM
                        #pragma vertex vert
                        #pragma fragment frag
                        #include"UnityCG.cginc"//using for unity object to world normal
                        struct appdata
                        {
                                float4 vertex:POSITION;
                                float2 uv : TEXCOORD0;
                        };
 
                        struct v2f
                        {
                                float2 uv :TEXCOORD0;
                                float4 vertex :SV_POSITION;
                        };
 
                        sampler2D _MainTex;
 
                        v2f vert(appdata v)
                        {
                                v2f o;
                                o.vertex = UnityObjectToClipPos(v.vertex);
                                o.uv = v.uv;
                                return o;
                        }
 
                        fixed4 frag(v2f i) :SV_TARGET
                        {
                                return tex2D(_MainTex,i.uv);
                        }
                        ENDCG
                }
        }
        FallBack "Diffuse"
}