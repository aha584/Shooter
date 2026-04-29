using UnityEngine;

public enum HitSurfaceType
{
    Dirt = 0,
    Blood = 1,
}

[System.Serializable]
public class HitEffectMapper
{
    public HitSurfaceType surface;
    public GameObject effectPrefab;
}

public class HitEffectManager : Singleton<HitEffectManager>
{
    public HitEffectMapper[] effectMapps;

    public GameObject GetEffectPrefab(HitSurfaceType surfaceType)
    {
        HitEffectMapper mapper = System.Array.Find(effectMapps, x => x.surface == surfaceType);
        return mapper?.effectPrefab;
    }
}
