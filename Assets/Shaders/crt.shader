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
			
			float2 curve(float2 pos){
				float2 warp = float2(1.0/12.0,1.0/10.0);
				pos = pos * 2.0 - 1.0;
				pos *= float2(1.0 + (pos.y * pos.y) * warp.x, 1.0 + (pos.x * pos.x) * warp.y);
				return clamp(pos * 0.5 + 0.5, float2(0.0, 0.0),float2(1.0, 1.0));
			}
			
			half4 frag(vert_out i): COLOR {
				float2 uv = curve(i.uv);
				
				// pixelesation
				/* float2 pixel_resolution = float2(128.0, 128.0 * _ScreenParams.y / _ScreenParams.x); */
				/* uv = floor(uv * pixel_resolution) / pixel_resolution; */
				
                half4 color = tex2D(_MainTex, uv);
				
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
				
				// scanlines
				float2 scanline_resolution = 256.0 * _ScreenParams.y / _ScreenParams.x;
				float2 scanUV = floor(uv * scanline_resolution) / scanline_resolution;
				float scans = clamp(1.25 + 0.95 * sin(45.5 * _Time + scanUV.y * 5.1), 0.0, 1.0);
				float s = pow(scans, 1.2);
				float satur = saturate(0.8 + 0.6 * s);
				color *= float4(satur, satur, satur, satur);
				
				// brightness + contrast
				color += (_Br / 255);
				color = color - _Contrast * (color - 1.0) * color *(color - 0.5);
				
				color = color * muls;
				
				// vignetta
				float vig = (0.0 + 4.0 * 16.0 * uv.x * uv.y * (1.0 - uv.x) * (1.0 - uv.y));
				float cc = pow(vig, 0.3);
				color *= float4(cc, cc, cc, cc);
				
				// blink
				float blinkPower = saturate(0.92 + (80.0 * sin(10.0 * _Time) + 80.0));
				color *= blinkPower;
				
				// a little bit greener
				color *= float4(0.95, 1.13, 0.95, 1.0);
					
				return color;
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
}
