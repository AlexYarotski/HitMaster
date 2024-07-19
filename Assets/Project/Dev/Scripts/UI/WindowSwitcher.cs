using System.Collections.Generic;
using UnityEngine;

namespace Project.Dev.Scripts.UI
{
    public class WindowSwitcher : MonoBehaviour
    {
        private readonly List<Window> WindowList = new List<Window>();

        private Window _currentWindow = null;
    
        private void Awake()
        {
            var windowArray = GameManager.Instance.SceneContexts.SceneWindowSetting.GetWindows();

            for (var i = 0; i < windowArray.Length; i++)
            {
                var newWindow = Instantiate(windowArray[i], transform);
            
                newWindow.gameObject.SetActive(false);
            
                WindowList.Add(newWindow);
            }
        }
        public void Show<T>() where T : Window
        {
            var windowToShow = GetWindow<T>();

            if (_currentWindow != null && !windowToShow.IsPopUp)
            {
                _currentWindow.Hide();
            }

            if (!windowToShow.IsPopUp)
            {
                _currentWindow = windowToShow;
            }
        
            windowToShow.Show();
        }
    
        private Window GetWindow<T>() where T : Window
        {
            foreach(var window in WindowList)
            {
                if(window is T)
                {
                    return window;
                }
            }

#if UNITY_EDITOR
            Debug.LogError($"Window type not found {typeof(T)}"); 
#endif
        
            return null;
        }
    }
}