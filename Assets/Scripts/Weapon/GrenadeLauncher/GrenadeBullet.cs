using System;
using UnityEngine;
using System.Collections.Generic;

public class GrenadeBullet : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionRadius;
    public float explosionForce;
    public int damage;

    private List<Health> oldVictims = new();

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        BlowObject();
    }

    private void BlowObject()
    {
        oldVictims.Clear();
        Collider[] detecedObject = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(var obj in detecedObject)
        {
            DeliverDamage(obj);
            AddForceToObject(obj);
        }
    }
    private void DeliverDamage(Collider victim)
    {
        Health health = victim.GetComponentInParent<Health>();
        if (health != null && !oldVictims.Contains(health))
        {
            health.TakeDamage(damage);
            oldVictims.Add(health);
        }
    }
    private void AddForceToObject(Collider affectedObject)
    {
        Rigidbody objRigidbody = affectedObject.attachedRigidbody;
        if (objRigidbody)
        {
            objRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
        }
    }
}
