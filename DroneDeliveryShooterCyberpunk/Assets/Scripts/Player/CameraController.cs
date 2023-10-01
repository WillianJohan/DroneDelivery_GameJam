using System;
using UnityEngine;

namespace Drone
{

    public class CameraController : MonoBehaviour
    {
        [SerializeField] Camera MainCamera;
        [SerializeField] Transform TargetView;
        [SerializeField] Rigidbody2D targetPhysics; 
        [SerializeField] Vector3 DefaultOffset = new Vector3(0, 0, -7.0f);
        [SerializeField] bool onlyHorizontalMovement = true;
        [SerializeField] bool dynamicOffsetByPlayerDirection = true;
        [SerializeField] float SmoothSpeed = 0.125f;
        
        Vector3 dynamicOffset = Vector3.zero;

        private void Start()
        {
            dynamicOffset = DefaultOffset;
        }

        public Vector3 CameraDesiredPosition { get {
                Vector3 desired;
                if (dynamicOffsetByPlayerDirection) {
                    float horizontalDirection = Input.GetAxisRaw("Horizontal");
                    float target_x = Mathf.Clamp(horizontalDirection * DefaultOffset.x, -DefaultOffset.x, DefaultOffset.x);
                    dynamicOffset.x = Mathf.Lerp(dynamicOffset.x, target_x, .1f);
                    desired = TargetView.transform.position + dynamicOffset;
                }
                else
                {
                    desired = TargetView.transform.position + DefaultOffset;
                }

                if (onlyHorizontalMovement) 
                    desired.y = DefaultOffset.y;

                return desired;
            } 
        }

        void FixedUpdate() => handleUpdateCameraMovement();

        void handleUpdateCameraMovement()
        {
            Vector3 smoothedPosition = Vector3.Lerp(MainCamera.transform.position, CameraDesiredPosition, SmoothSpeed);
            MainCamera.transform.position = smoothedPosition;
        }
    }
}
