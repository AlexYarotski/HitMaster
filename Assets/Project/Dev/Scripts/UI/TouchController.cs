using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Dev.Scripts.UI
{
    public class TouchController : MonoBehaviour, IPointerDownHandler
    {
        public static event Action<Vector3> Touched = delegate { };

        [SerializeField] private Camera _mainCamera;
        [SerializeField] private float _maxDistance;

        private Vector3 _targetPoint = Vector3.zero;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            Ray ray = _mainCamera.ScreenPointToRay(eventData.position);

            _targetPoint = Physics.Raycast(ray, out RaycastHit hit, _maxDistance) ? hit.point 
                : ray.GetPoint(_maxDistance);

            Touched(_targetPoint);
        }
    }
}