
Shader "ShaderMan/Caves"
	{

	Properties{
	_MainTex ("MainTex", 2D) = "white" {}
	}

	SubShader
	{
	Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }

	Pass
	{
	ZWrite Off
	Blend SrcAlpha OneMinusSrcAlpha

	CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag
	#include "UnityCG.cginc"

	struct VertexInput {
    fixed4 vertex : POSITION;
	fixed2 uv:TEXCOORD0;
    fixed4 tangent : TANGENT;
    fixed3 normal : NORMAL;
	//VertexInput
	};


	struct VertexOutput {
	fixed4 pos : SV_POSITION;
	fixed2 uv:TEXCOORD0;
	//VertexOutput
	};

	//Variables
sampler2D _MainTex;

	



	VertexOutput vert (VertexInput v)
	{
	VertexOutput o;
	o.pos = UnityObjectToClipPos (v.vertex);
	o.uv = v.uv;
	//VertexFactory
	return o;
	}
	fixed4 frag(VertexOutput i) : SV_Target
	{
	
	fixed2 pixel = i.uv - 1*.5;
	
	// pixellate
	const fixed pixelSize = 4.0;
	pixel = floor(pixel/pixelSize);
	
	fixed2 offset = fixed2(_Time.y*3000.0,pow(max(-sin(_Time.y*.2),.0),2.0)*16000.0)/pixelSize;
	
	fixed3 col;
	for ( int i=0; i < 8; i++ )
	{
		// parallax position, whole pixels for retro feel
		fixed depth = 20.0+fixed(i);
		fixed2 uv = pixel + floor(offset/depth);
		
		uv /= 1;
		uv *= depth/20.0;
		uv *= .4*pixelSize;
		
		col = tex2D( _MainTex, uv+.5 ).rgb;
		
		if ( 1.0-col.y < fixed(i+1)/8.0 )
		{
			col = lerp( fixed3(.4,.6,.7), col, exp2(-fixed(i)*.1) );
			break;
		
	    } 
	
	}
            return float4(col,1.0);

  }
  ENDCG
}
}
}

