using UnityEngine;

namespace Drone
{

    public class CameraController : MonoBehaviour
    {
        [SerializeField] Camera MainCamera;
        [SerializeField] Transform TargetView;
        [SerializeField] Vector3 Offset = new Vector3(0, 0, -7.0f);
        [SerializeField] float SmoothSpeed = 0.125f;
        
        public Vector3 CameraDesiredPosition { get => TargetView.transform.position + Offset; }

        void FixedUpdate() => handleUpdateCameraMovement();

        void handleUpdateCameraMovement()
        {
            Vector3 smoothedPosition = Vector3.Lerp(MainCamera.transform.position, CameraDesiredPosition, SmoothSpeed);
            MainCamera.transform.position = smoothedPosition;
        }
    }
}