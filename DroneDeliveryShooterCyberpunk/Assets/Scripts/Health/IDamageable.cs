using System;

public interface IDamageable
{
    event Action<int> OnDamage;
    void DealDamage(uint damageAmount);
}
