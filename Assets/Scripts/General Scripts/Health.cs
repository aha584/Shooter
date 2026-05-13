using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealthPoint;
    public UnityEvent onDie;
    public UnityEvent<int, int> onHealthChanged;
    public UnityEvent onTakeDamage;

    [SerializeField] private int currentHealthPoint;

    public int HealthPoint
    {
        get => currentHealthPoint;
        set
        {
            currentHealthPoint = value;
            onHealthChanged?.Invoke(currentHealthPoint, maxHealthPoint);
        }
    }

    public bool IsDead => HealthPoint <= 0;

    private void Start()
    {
        HealthPoint = maxHealthPoint;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        HealthPoint -= damage;
        onTakeDamage?.Invoke();
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
