Shader "Unity Shaders/Forest/Simple Shader Property"
{
    Properties
    {
        // Declare a property of type Color
        _Color("Color Tint", Color) = (1.0, 1.0, 1.0, 1.0)
    }

        SubShader
    {
        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            fixed4 _Color;

            // use this struct to define the output of the vertex shader
            struct a2v
            {
                float4 vertex : POSITION; 
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                // pos stores the position information of the vertex in the clipping space
                float4 pos : SV_POSITION;
                // COLOR0 semantics are used to store color information
                fixed3 color : COLOR0;
            };

            v2f vert(a2v v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                
                // Convert the normal value to a color value and present it to the model
                o.color = v.normal * 0.5 + fixed3(0.5, 0.5, 0.5);
                return o;
            }

            // Pass the vertex output structure into the fragment shader
            fixed4 frag(v2f i) : SV_Target
            {
                fixed3 color = i.color;
                color *= _Color.rgb;
                return fixed4(color, 1.0);
            }

            ENDCG
        }
    }
}