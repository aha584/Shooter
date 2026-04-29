using UnityEngine;

public class GunRaycaster : MonoBehaviour
{
    public Camera aimingCamera;
    public LayerMask layerMask;
    public int damage;

    public void PerformRaycasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);
        //Debug.Log("Get Aiming Ray");
        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            //Debug.Log("Get Quaternion");
            ShowHitEffect(hitInfo);
            //Debug.Log("Clone marker");
            DeliveryDamage(hitInfo);
        }
    }
    private void DeliveryDamage(RaycastHit hitInfo)
    {
        Health health = hitInfo.collider.GetComponentInParent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }

    private void ShowHitEffect(RaycastHit hitInfo)
    {
        HitSurface hitSurface = hitInfo.collider.GetComponent<HitSurface>();
        if(hitSurface != null)
        {
            GameObject effectPreafb = HitEffectManager.Instance.GetEffectPrefab(hitSurface.surfaceType);
            if(effectPreafb != null)
            {
                Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
                Instantiate(effectPreafb, hitInfo.point, effectRotation);
            }
        }
    }
}
