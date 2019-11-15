using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Lighting Preset GI", menuName = "Scriptables/Lighting Preset GI", order = 1)]
public class LightingPresetGI : ScriptableObject
{
    public Gradient SkyboxColor;
    public Gradient DirectionalColor;
    public Gradient FogColor;
    public AnimationCurve EmissionStrength;

}
