using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public Animator anim;
    public int damage;
    public Health playerHealth;

    public void StartAttack() => anim.SetBool("isAttacking", true);
    public void StopAttack() => anim.SetBool("isAttacking", false);
    public void OnAttack()
    {
        playerHealth.TakeDamage(damage);
    }
}
