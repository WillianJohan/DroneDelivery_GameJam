// Original Code from: https://gist.github.com/ftvs/5822103
using System;
using UnityEngine;

//todo: refactor
public class CameraShake : MonoBehaviour
{
	[SerializeField] Drone.CameraController cameraController; 
	[SerializeField] Health playerHealthScript;
	[SerializeField] Transform camTransform;

	[Header("On Damage")]
    [SerializeField] bool shakeOnDamage = true;
    [SerializeField] float damageShakeDuration = 0.2f;
	[SerializeField] float damageShakeAmount = 0.2f;
	[SerializeField] float decreaseFactor = 1.0f;
	
	[Header("On Attack")]
    [SerializeField] bool shakeOnAttack = true;
    [SerializeField] float shootShakeAmount = 0.07f;


	float currentShakeTime = 0;
	public bool DoShake   { get; private set;}
	public bool IsShaking { get; private set; }

    void Start()
    {
		DoShake = false;
		IsShaking = false;
    }
    void Awake()		=> SubscribeEvents();
	void OnDestroy()	=> UnsubscriveEvents();

	void SubscribeEvents()
    {
		playerHealthScript.OnDamage += HandleOnPlayerHit;
		//CombatBehaviour.OnShoot += HandleOnShoot;
	}

	void UnsubscriveEvents()
    {
		playerHealthScript.OnDamage -= HandleOnPlayerHit;
		//CombatBehaviour.OnShoot -= HandleOnShoot;
	}

	void Update()
	{
		if (!DoShake)
			return;

		if (currentShakeTime > 0)
		{
			camTransform.position = camTransform.position + UnityEngine.Random.insideUnitSphere * damageShakeAmount;
			currentShakeTime -= decreaseFactor * Time.deltaTime;
			return;
		}

		//Finish Shake Behaviour
		currentShakeTime = 0f;
		IsShaking = false;
	}


	void HandleOnPlayerHit(int damage)
	{
		if (!shakeOnDamage)
			return;

        if (IsShaking)
			return;
		
		currentShakeTime = damageShakeDuration;

		DoShake = true;
		IsShaking = true;
	}

	void HandleOnShoot()
    {
		if (!shakeOnAttack)
			return;

		if (IsShaking)
			return;

		camTransform.position =	
			camTransform.position +	
			UnityEngine.Random.insideUnitSphere * 
			shootShakeAmount;

	}

	/*
	[Serializable]
	struct ShakeProperties
    {
		public float ShakeDuration;
		public float ShakeAmount;
		public float decreaseFactor;
	}
	*/
}