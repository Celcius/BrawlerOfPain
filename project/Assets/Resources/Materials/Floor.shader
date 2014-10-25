// Shader created with Shader Forge Beta 0.36 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.36;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:1,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32430,y:32799|diff-122-OUT,diffpow-69-OUT,spec-69-OUT,normal-48-RGB;n:type:ShaderForge.SFN_Tex2d,id:2,x:33174,y:32951,ptlb:diffTex,ptin:_diffTex,tex:e89e107ece010d44baa0f82037ce746c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8,x:33259,y:32481,ptlb:specular,ptin:_specular,tex:ed70c594304aa554eac5bbf77bfd76c3,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:16,x:33061,y:32470,ptlb:gloss,ptin:_gloss,tex:9a3ad021dddbd9745b95a190887acb38,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:48,x:33259,y:32690,ptlb:normal,ptin:_normal,tex:ab538883ebdfa144f9b54f11558bded1,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:56,x:33142,y:33194,ptlb:bloodTex,ptin:_bloodTex,tex:63cae6b97e19a974ebd7043019eca775,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:69,x:32784,y:33058|A-2-RGB,B-56-RGB,T-85-OUT;n:type:ShaderForge.SFN_ValueProperty,id:85,x:32939,y:33552,ptlb:bloodBlend,ptin:_bloodBlend,glob:False,v1:1;n:type:ShaderForge.SFN_Tex2d,id:121,x:33763,y:33052,ptlb:node_121,ptin:_node_121,tex:9c5a087d692711e45af3a7a832e3661e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:122,x:32918,y:32853|A-2-RGB,B-148-OUT,T-85-OUT;n:type:ShaderForge.SFN_Color,id:147,x:33626,y:32787,ptlb:node_147,ptin:_node_147,glob:False,c1:0.8455882,c2:0.1865268,c3:0.1865268,c4:1;n:type:ShaderForge.SFN_Multiply,id:148,x:33439,y:32899|A-147-RGB,B-121-RGB;proporder:2-8-16-48-56-85-121-147;pass:END;sub:END;*/

Shader "Custom/FLoor" {
    Properties {
        _diffTex ("diffTex", 2D) = "white" {}
        _specular ("specular", 2D) = "white" {}
        _gloss ("gloss", 2D) = "white" {}
        _normal ("normal", 2D) = "black" {}
        _bloodTex ("bloodTex", 2D) = "white" {}
        _bloodBlend ("bloodBlend", Float ) = 1
        _node_121 ("node_121", 2D) = "white" {}
        _node_147 ("node_147", Color) = (0.8455882,0.1865268,0.1865268,1)
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _diffTex; uniform float4 _diffTex_ST;
            uniform sampler2D _normal; uniform float4 _normal_ST;
            uniform sampler2D _bloodTex; uniform float4 _bloodTex_ST;
            uniform float _bloodBlend;
            uniform sampler2D _node_121; uniform float4 _node_121_ST;
            uniform float4 _node_147;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_166 = i.uv0;
                float3 normalLocal = tex2D(_normal,TRANSFORM_TEX(node_166.rg, _normal)).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 node_69 = lerp(tex2D(_diffTex,TRANSFORM_TEX(node_166.rg, _diffTex)).rgb,tex2D(_bloodTex,TRANSFORM_TEX(node_166.rg, _bloodTex)).rgb,_bloodBlend);
                float3 diffuse = pow(max( 0.0, NdotL), node_69) * attenColor + UNITY_LIGHTMODEL_AMBIENT.rgb;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = node_69;
                float3 specular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * lerp(tex2D(_diffTex,TRANSFORM_TEX(node_166.rg, _diffTex)).rgb,(_node_147.rgb*tex2D(_node_121,TRANSFORM_TEX(node_166.rg, _node_121)).rgb),_bloodBlend);
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _diffTex; uniform float4 _diffTex_ST;
            uniform sampler2D _normal; uniform float4 _normal_ST;
            uniform sampler2D _bloodTex; uniform float4 _bloodTex_ST;
            uniform float _bloodBlend;
            uniform sampler2D _node_121; uniform float4 _node_121_ST;
            uniform float4 _node_147;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_167 = i.uv0;
                float3 normalLocal = tex2D(_normal,TRANSFORM_TEX(node_167.rg, _normal)).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 node_69 = lerp(tex2D(_diffTex,TRANSFORM_TEX(node_167.rg, _diffTex)).rgb,tex2D(_bloodTex,TRANSFORM_TEX(node_167.rg, _bloodTex)).rgb,_bloodBlend);
                float3 diffuse = pow(max( 0.0, NdotL), node_69) * attenColor;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = node_69;
                float3 specular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * lerp(tex2D(_diffTex,TRANSFORM_TEX(node_167.rg, _diffTex)).rgb,(_node_147.rgb*tex2D(_node_121,TRANSFORM_TEX(node_167.rg, _node_121)).rgb),_bloodBlend);
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
