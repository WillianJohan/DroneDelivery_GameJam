using System;

public interface ICurable
{
    event Action<int> OnHeal;
    void Heal(uint cureAmount);
}
