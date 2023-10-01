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
        float maxDroneHeight = 2.43f;

        [Header("Características da mobilidade do drone")]
        [SerializeField] float aceleration = 50.0f;
        [SerializeField] float maxVelocity = 250.0f;
        [SerializeField] float weight = 10.0f;
        [SerializeField, Range(0, 2)] float balance = 1.0f;

        void Start()
        {
            if (!rb) GetComponent<Rigidbody2D>();
            UpdateMobility(aceleration, maxVelocity, weight, balance);
        }

        void Update()
        {
            inputDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;

#if UNITY_EDITOR
            // Comandos para fins de DEBUG
            if (Input.GetKeyDown(KeyCode.U)) UpdateMobility(aceleration, maxVelocity, weight, balance);
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
            newVelocity.x += Mathf.Clamp(inputDirection.x * aceleration * Time.deltaTime, -maxVelocity, maxVelocity);
            newVelocity.y += Mathf.Clamp(inputDirection.y * aceleration * Time.deltaTime, -maxVelocity, maxVelocity);

            if(newVelocity.y > 0 && rb.transform.position.y >= maxDroneHeight)
            {
                Debug.Log("vel" + newVelocity.y + " rb: " + rb.transform.position.y + " transform: " + transform.position.y);
                newVelocity.y = 0;
            }

            rb.velocity = newVelocity;
        }



        public void UpdateMobility(float newAceleration = 0, float newMaxVelocity = 0, float newWeight = 10, float newBalance = 1.0f)
        {
            maxVelocity = newMaxVelocity;
            weight = newWeight;
            aceleration = newAceleration;
            balance = Mathf.Clamp(newBalance, 0, 2);

            rb.drag = balance;
            rb.gravityScale = weight / 10;
        }
    }
}