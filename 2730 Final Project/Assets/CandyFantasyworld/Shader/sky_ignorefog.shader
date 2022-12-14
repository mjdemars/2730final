// Unlit shader. Simplest possible textured shader.
// - no lighting
// - no lightmap support
// - no per-material color

Shader "DracoGame/Unlit/sky_IgnoreFog" {
Properties {
_MainTex ("Base (RGB)", 2D) = "white" {}
}

SubShader {
Tags { "RenderType"="Opaque" }
LOD 100
Fog { Mode Off }
Lighting Off

Pass {
SetTexture [_MainTex] { combine texture } 
}
}
}