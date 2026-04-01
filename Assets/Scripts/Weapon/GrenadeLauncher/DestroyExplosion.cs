using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    public float lifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
