using UnityEngine;

[ExecuteAlways]
public class MaterialGI : MonoBehaviour
{
    public Gradient Color;
    public float Multiply;

    private MaterialPropertyBlock propertyBlock;
    private new Renderer renderer;

    private void OnEnable()
    {
        LightingManagerGI giManager = FindObjectOfType<LightingManagerGI>();
        giManager?.RegisterMaterial(this);
        GetReferences();
    }

    private void OnDisable()
    {
        LightingManagerGI giManager = FindObjectOfType<LightingManagerGI>();
        giManager?.DeregisterMaterial(this);
    }

    public void Start()
    {

    }

    public void UpdateGI(float timeLerp)
    {
        GetReferences();
        Color color = this.Color.Evaluate(timeLerp);
        propertyBlock.SetColor("_EmissionColor", color * this.Multiply);
        renderer.SetPropertyBlock(this.propertyBlock);
        DynamicGI.SetEmissive(this.renderer, color * this.Multiply);
    }

    void GetReferences()
    {
        if (propertyBlock == null)
        {
            propertyBlock = new MaterialPropertyBlock();
        }
        if (renderer == null)
        {
            renderer = base.GetComponent<Renderer>();
            renderer.SetPropertyBlock(this.propertyBlock);
        }
    }
}
