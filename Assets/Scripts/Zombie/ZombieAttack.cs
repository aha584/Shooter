using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public Animator anim;
    public int damage;
    public Health playerHealth;

    public void StartAttack() => anim.SetBool("isAttacking", true);
    public void StopAttack() => anim.SetBool("isAttacking", false);
    public void OnAttack(int index)
    {
        playerHealth.TakeDamage(damage);
        if(index == 1)
        {
            Player.Instance.playerUI.ShowLeftScratch();
        }
        else if(index == 0)
        {
            Player.Instance.playerUI.ShowRightScratch();
        }
    }
}
