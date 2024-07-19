using UnityEngine;

namespace Project.Dev.Scripts.UI
{
    public class LookAtCamera : MonoBehaviour
    {
        private Camera _targetCamera;

        void Start()
        {
            _targetCamera = Camera.main;
        }

        void Update()
        {
            transform.LookAt(transform.position + _targetCamera.transform.rotation * Vector3.forward,
                _targetCamera.transform.rotation * Vector3.up);
        }
    }
}