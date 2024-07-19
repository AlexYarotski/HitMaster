using UnityEngine;
using UnityEngine.UI;

namespace Project.Dev.Scripts.UI
{
    public class StartWindow : Window
    {
        public override bool IsPopUp => false;

        [SerializeField] private Button _start;
    
        private void Awake()
        {
            _start.onClick.AddListener(Hide);
        }
    
        public override void Show()
        {
            Time.timeScale = 0;

            base.Show();
        }

        public override void Hide()
        {
            Time.timeScale = 1;
        
            base.Hide();
        }
    }
}
