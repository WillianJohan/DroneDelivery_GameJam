using System;
using UnityEngine;

namespace Drone
{
    public class DroneMovement : MonoBehaviour
    {

        [SerializeField]
        Rigidbody2D rb;

        [SerializeField] // input Direction -> updated every second
        Vector3 inputDirection = Vector3.zero;
        [SerializeField]
        Camera cam;

        [SerializeField]
        float defaultMaxDroneHeight = 2.43f;
        bool setMaxDroneHeightByCameraViewport = true;

        public float MaxDroneHeight
        {
            get {
                if (setMaxDroneHeightByCameraViewport && cam != null)
                {
                    Vector3 cameraViewPort = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
                    return cameraViewPort.y - 1.8f; // subtração para compensar o tamanho do drone
                }
                return defaultMaxDroneHeight;
            }
        }

        [Header("Características da mobilidade do drone")]
        [SerializeField] float verticalBonusAceleration = 100.0f;
        [SerializeField] float aceleration = 50.0f;
        [SerializeField] float maxVelocity = 250.0f;
        [SerializeField] float weight = 10.0f;
        [SerializeField, Range(0, 2)] float balance = 1.0f;

        void Start()
        {
            if (!rb) GetComponent<Rigidbody2D>();
            UpdateMobility(verticalBonusAceleration, aceleration, maxVelocity, weight, balance);
        }

        void Update()
        {
            inputDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;

#if UNITY_EDITOR
            // Comandos para fins de DEBUG
            if (Input.GetKeyDown(KeyCode.U)) UpdateMobility(verticalBonusAceleration, aceleration, maxVelocity, weight, balance);
            if (Input.GetKeyDown(KeyCode.I))
            {
                rb.velocity = new Vector2();
                transform.position = new Vector3();
            }
#endif

        }

        void FixedUpdate()
        {
            Vector3 newVelocity = rb.velocity;
            newVelocity.x += horizontalVelocity();
            newVelocity.y += verticalVelocity();

            if (newVelocity.y > 0 && rb.transform.position.y >= MaxDroneHeight)
            {
                newVelocity.y = 0;
            }

            rb.velocity = newVelocity;
        }

        float horizontalVelocity() => Mathf.Clamp(inputDirection.x * aceleration * Time.deltaTime, -maxVelocity, maxVelocity);
        float verticalVelocity()
        {
            float newTorque = 0.0f;
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                newTorque = verticalBonusAceleration;
                Debug.Log("teste");
            }

            return Mathf.Clamp(inputDirection.y * (aceleration + newTorque) * Time.deltaTime, -maxVelocity, maxVelocity);
        }


        public void UpdateMobility(float newVerticalTorque = 0, float newAceleration = 0, float newMaxVelocity = 0, float newWeight = 10, float newBalance = 1.0f)
        {
            verticalBonusAceleration = newVerticalTorque;
            maxVelocity = newMaxVelocity;
            weight = newWeight;
            aceleration = newAceleration;
            balance = Mathf.Clamp(newBalance, 0, 2);

            rb.drag = balance;
            rb.gravityScale = weight / 10;
        }

    }
}