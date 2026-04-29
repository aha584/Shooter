using Unity.VisualScripting;
using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
    public Animator anim;

    public Rigidbody[] rigids;

    [ContextMenu("Retrieve Rigidbodies")]
    private void RetrieveRigidbodies()
    {
        rigids = GetComponentsInChildren<Rigidbody>();
    }
    [ContextMenu("Clear Ragdoll")]
    private void ClearRagdoll()
    {
        CharacterJoint[] joints = GetComponentsInChildren<CharacterJoint>();
        for(int i = 0; i < joints.Length; i++)
        {
            DestroyImmediate(joints[i]);
        }
        Rigidbody[] rigidList = GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < rigidList.Length; i++)
        {
            DestroyImmediate(rigidList[i]);
        }
        Collider[] colliders = GetComponentsInChildren<Collider>();
        for (int i = 0; i < colliders.Length; i++)
        {
            DestroyImmediate(colliders[i]);
        }
    }

    [ContextMenu("Enable Ragdoll")]
    public void EnableRagdoll() => SetRagdoll(true);

    [ContextMenu("Disable Ragdoll")]
    public void DisableRagdoll() => SetRagdoll(false);
    private void SetRagdoll(bool ragdollEnable)
    {
        anim.enabled = !ragdollEnable;
        for(int i = 0; i < rigids.Length; i++)
        {
            rigids[i].isKinematic = !ragdollEnable;
        }
    }
    [ContextMenu("Add HitSurface")]
    private void AddHitSurface()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach(Collider collider in colliders)
        {
            if(gameObject.GetComponent<HitSurface>() == null)
            {
                var hitSurface = collider.gameObject.AddComponent<HitSurface>();
                hitSurface.surfaceType = HitSurfaceType.Blood;
            }
        }
    }
}
