Shader "Custom/CRTShader" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
		_VertsColor("Verts fill color", Float) = 0
		_VertsColor2("Verts fill color 2", Float) = 0
		_Contrast("Contrast", Float) = 0
		_Br("Brightness", Float) = 0
		_ScansColor ("Scanlime color", COLOR) = (1,1,1,1)
    }

    SubShader {
        Pass {
            ZTest Always Cull Off ZWrite Off Fog { Mode off }

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            #pragma fragmentoption ARB_precision_hint_fastest
            #include "UnityCG.cginc"
            #pragma target 3.0

            struct vert_out {
                float4 pos      : POSITION;
                float2 uv       : TEXCOORD0;
				float4 scr_pos  : TEXCOORD1;
            };

            uniform sampler2D _MainTex;
			uniform float _VertsColor;
			uniform float _VertsColor2;
			uniform float _Contrast;
			uniform float _Br;
			uniform float4 _ScansColor;

            vert_out vert(appdata_base v) {
                vert_out o;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = MultiplyUV(UNITY_MATRIX_TEXTURE0, v.texcoord);
				o.scr_pos = ComputeScreenPos(o.pos);
                return o;
            }

            half4 frag(vert_out i): COLOR {
                half4 color = tex2D(_MainTex, i.uv);
				
				float2 ps = i.scr_pos.xy * _ScreenParams.xy / i.scr_pos.w;
				
				// crt pixels
				int pp = (int)ps.x % 3;
				float4 muls = float4(_VertsColor, _VertsColor, _VertsColor, 1.0);
				
				if(pp == 1) {
					muls.r = 1; muls.g = _VertsColor2;
				} else if(pp == 2) {
					muls.g = 1; muls.b = _VertsColor2;
				} else {
					muls.b = 1; muls.r = _VertsColor2;
				}
				
				// brightness + contrast
				color += (_Br / 255);
				color = color - _Contrast * (color - 1.0) * color *(color - 0.5);
				
				// scanline
				if((int)ps.y % 3 == 0) {
					muls *= _ScansColor;
				}
				
				color = color * muls;
				
				return color;
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
}
