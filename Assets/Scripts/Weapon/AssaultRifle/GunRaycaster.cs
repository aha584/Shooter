using UnityEngine;

public class GunRaycaster : MonoBehaviour
{
    public GameObject hitMarkerPrefab;
    public Camera aimingCamera;
    public LayerMask layerMask;
    public int damage;

    public void PerformRaycasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);
        //Debug.Log("Get Aiming Ray");
        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            //Debug.Log("Get Quaternion");
            Instantiate(hitMarkerPrefab, hitInfo.point, effectRotation);
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
}
