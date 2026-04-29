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

public class HitEffectManager : MonoBehaviour
{
    public HitEffectMapper[] effectMapps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
