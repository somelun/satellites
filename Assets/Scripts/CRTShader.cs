using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]

public class CRTShader : MonoBehaviour 
{
    public Shader shader;
	[Range(0, 1)] public float verts_force = 0.0f;
	[Range(0, 1)] public float verts_force_2 = 0.0f;
	[Range(-3, 20)] public float contrast = 0.0f;
	[Range(-200, 200)] public float brightness = 0.0f;
	public Color scanlineColor = Color.white;
	
    private Material _material;

    protected Material material {
        get {
            if(_material == null) {
                _material = new Material(shader);
                _material.hideFlags = HideFlags.HideAndDontSave;
            }
            return _material;
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        if(shader == null) {
			return;
		}
		
        Material mat = material;
		mat.SetFloat("_VertsColor", 1.0f - verts_force);
		mat.SetFloat("_VertsColor2", 1.0f - verts_force_2);
		mat.SetFloat("_Contrast", contrast);
		mat.SetFloat("_Br", brightness);
		mat.SetColor("_ScansColor", scanlineColor);
        Graphics.Blit(source, destination, mat);
    }

    void OnDisable() {
        if(_material) {
            DestroyImmediate(_material);
		}
    }
}
