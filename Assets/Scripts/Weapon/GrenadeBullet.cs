using System;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionRadius;
    public float explosionForce;

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        BlowObject();
    }

    private void BlowObject()
    {
        Collider[] detecedObject = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(var obj in detecedObject)
        {
            Rigidbody objRigidbody = obj.attachedRigidbody;
            if(objRigidbody)
            {
                objRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
            }
        }
    }
}
