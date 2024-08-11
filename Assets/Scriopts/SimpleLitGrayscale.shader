Shader "Custom/SimpleLitGrayscale"
{
    Properties
    {
        _BaseColor("Base Color", Color) = (1,1,1,1)
        _BaseMap("Base Map", 2D) = "white" {}
        _Grayscale("Grayscale", Range(0, 1)) = 0.0
        _Cutoff("Alpha Cutoff", Range(0, 1)) = 0.5
    }

        SubShader
        {
            Tags{"RenderType" = "Opaque" "Queue" = "Geometry"}
            LOD 200

            Pass
            {
                Name "ForwardLit"
                Tags{ "LightMode" = "UniversalForward" }

                HLSLPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
                #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

                struct Attributes
                {
                    float4 positionOS : POSITION;
                    float3 normalOS : NORMAL;
                    float2 uv : TEXCOORD0;
                    float4 tangentOS : TANGENT;
                };

                struct Varyings
                {
                    float4 positionHCS : SV_POSITION;
                    float2 uv : TEXCOORD0;
                    float3 normalWS : TEXCOORD1;
                    float3 viewDirWS : TEXCOORD2;
                };

                CBUFFER_START(UnityPerMaterial)
                    float4 _BaseColor;
                    float _Grayscale;
                    float _Cutoff;
                    TEXTURE2D(_BaseMap);
                    SAMPLER(sampler_BaseMap);
                CBUFFER_END

                Varyings vert(Attributes v)
                {
                    Varyings o;
                    o.positionHCS = TransformObjectToHClip(v.positionOS);
                    o.uv = v.uv;
                    o.normalWS = TransformObjectToWorldNormal(v.normalOS);
                    o.viewDirWS = GetCameraPositionWS() - TransformObjectToWorld(v.positionOS);
                    return o;
                }

                half4 frag(Varyings i) : SV_Target
                {
                    // Sample the base texture
                    half4 baseColor = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, i.uv) * _BaseColor;

                    // Calculate lighting using URP's SimpleLit shading model
                    half3 normalWS = normalize(i.normalWS);
                    half3 viewDirWS = normalize(i.viewDirWS);

                    // Lighting and shading
                    half3 diffuseColor = baseColor.rgb;
                    half3 lighting = Lambert(normalWS) * LIGHT_ATTENUATION(i.positionHCS) * _BaseColor.rgb;

                    // Apply grayscale
                    if (_Grayscale > 0)
                    {
                        float grayscale = dot(baseColor.rgb, half3(0.299, 0.587, 0.114));
                        baseColor.rgb = lerp(baseColor.rgb, half3(grayscale, grayscale, grayscale), _Grayscale);
                    }

                    // Combine lighting with color
                    baseColor.rgb *= lighting;

                    // Alpha cutoff (if needed)
                    if (baseColor.a < _Cutoff)
                        discard;

                    return baseColor;
                }

                ENDHLSL
            }
        }

            FallBack "Hidden/InternalErrorShader"
}
