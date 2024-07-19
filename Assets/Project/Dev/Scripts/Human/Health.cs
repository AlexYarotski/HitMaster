using UnityEngine;
using UnityEngine.UI;

namespace Project.Dev.Scripts.Human
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _health;
        [SerializeField] private Slider _slider;
        public float Count => _health;

        private float _startHealth = 0;
        
        private void Start()
        {
            _startHealth = _health;
            _slider.value = 1;
        }

        public void SetDamage(float damage)
        {
            _health -= damage;
            
            SetSliderValue(_health / _startHealth);
        }

        public void AddHealth(float health)
        {
            _health += health;
        
            SetSliderValue(_health / _startHealth);
        }

        public void Die()
        {
            _slider.gameObject.SetActive(false);
        }

        private void SetSliderValue(float value)
        {
            _slider.value = value;
        }
    }
}
