using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DroneHealth))]
public class DroneOnDamageBehaviour : MonoBehaviour
{
    
    [SerializeField] DroneHealth health = null;

    private void Start()
    {
        if (!health) GetComponent<DroneHealth>();
        health.OnDamage += HandleDamage;
    }
    private void OnDestroy()
    {
        health.OnDamage -= HandleDamage;
    }

    protected virtual void HandleDamage(int damage)
    {
        // executar ação do dano aqui

        // executa uma ação de força 

    }

}
