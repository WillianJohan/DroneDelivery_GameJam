using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] CountDown countdown;
    [SerializeField] PackageDelivery delivery;

    int initialTotalPackages = 0;
    int currentTotalPackages = 0;
    int deliveredTotalPackages = 0;


    private void Start()
    {
        // atribuição de eventos
        delivery.OnPackageDelivered += handleOnPackageDelivered;

        // contabiliza todos os pacotes do mapa
        PackageHealth[] packageHealths = FindObjectsOfType<PackageHealth>();
        foreach(PackageHealth packageHealth in packageHealths)
            packageHealth.OnDestroy += handleOnPackageDestroyed;
        initialTotalPackages = packageHealths.Length;
        currentTotalPackages = initialTotalPackages;

        // Cronômetro
        CountDown.OnFinishedTime += handleFinishedTime;
        countdown.StartCounter();
    }

    private void OnDestroy()
    {
        delivery.OnPackageDelivered -= handleOnPackageDelivered;
        CountDown.OnFinishedTime -= handleFinishedTime;
    }

    void handleFinishedTime() 
    {
        // Game Over
        Debug.Log("handleFinishedTime");
    }

    void handleOnPackageDelivered()
    {
        deliveredTotalPackages++;
        if( deliveredTotalPackages >= currentTotalPackages)
        {
            // end game
        }
        Debug.Log("handleOnPackageDelivered!!! Total Left: " + currentTotalPackages);
    }

    void handleOnPackageDestroyed()
    {
        currentTotalPackages--;
        if(currentTotalPackages <= 0)
        {
            // Game Over
        }

        Debug.Log("handleOnPackageDestroyed!!! Total Left: " + currentTotalPackages);
    }
}
