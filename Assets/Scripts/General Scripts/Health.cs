using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealthPoint;
    public UnityEvent onDie;

    [SerializeField] private int currentHealthPoint;
    public bool IsDead => currentHealthPoint <= 0;

    private void Start()
    {
        currentHealthPoint = maxHealthPoint;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        currentHealthPoint -= damage;
        if(IsDead)
        {
            Die();
        }
    }
    private void Die()
    {
        onDie?.Invoke();
    }
}
