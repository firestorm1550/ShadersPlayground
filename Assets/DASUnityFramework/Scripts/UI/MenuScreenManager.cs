using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DASUnityFramework.Scripts.UI
{
    /// <summary>
    /// This is a simple solution to managing multiple UI screens. It is used in Devastate, Die Up, and Starship Architect.
    ///
    /// It allows you to:
    ///     Change screen -- SetScreen(MenuScreen)
    ///     Go back one screen -- BackOne()
    ///
    /// In addition, it allows you to spread out your screens wherever you want in the scene,
    /// so they can all be active and visible at once, making it much easier to work on them.
    ///
    /// EXAMPLE USAGE:
    /// The main menu of my game has a Home screen, a matchmaking screen, and a store screen.
    ///
    /// I'd make one class for each screen, each extending MenuScreen.
    ///     public class HomeScreen : MenuScreen
    ///     public class MatchmakingScreen : MenuScreen
    ///     public class StoreScreen : MenuScreen
    ///
    /// I'd then place my MenuScreenManager script onto any gameobject in my scene.
    ///
    /// Anywhere in my scene (though probably as a direct child of the canvas, or some organizing object) I'd
    /// create three empty gameobjects (one for each screen), and apply one Screen script to each.
    ///
    /// Then I'd drag the home screen into the MenuScreenManager's startScreen field.
    ///
    /// To transfer between screens, you can either reference the menuscreen manager to call SetScreen, or on MenuScreen,
    /// You'll find a utility method called SetMeActive() 
    /// </summary>
    public class MenuScreenManager : MonoBehaviour
    {
        public MenuScreen CurrentScreen => _currentScreen;


        [HideInInspector] public List<MenuScreen> menuScreens = new List<MenuScreen>();
        [HideInInspector] public Stack<MenuScreen> _screenHistory = new Stack<MenuScreen>();
        
        [SerializeField] private MenuScreen startScreen;
        [SerializeField] private bool initializeInAwake = true; 
        
        public UnityEvent<MenuScreen, MenuScreen> onScreenChanged;
        
        private MenuScreen _currentScreen;
        private bool _initialized;

        private void Awake()
        {
            if(initializeInAwake)
                Initialize();
        }

        public void Initialize()
        {
            if (!_initialized)
            {
                _initialized = true;
                menuScreens = GetComponentsInChildren<MenuScreen>(true).ToList();
                foreach (MenuScreen menuScreen in menuScreens)
                {
                    menuScreen.Initialize(this);
                    menuScreen.gameObject.SetActive(false);
                }
                SetScreen(startScreen);
            }
        }
        
        /// <summary>
        /// Gets the first screen of type T or returns null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetScreen<T>() where T : MenuScreen
        {
            return (T) menuScreens.FirstOrDefault(m => m is T);
        }

        public MenuScreen GetScreen(Type t)
        {
            return menuScreens.FirstOrDefault(m => m.GetType() == t);
        }

        public void SetScreen(MenuScreen screenToBe, bool addToScreenHistory = true)
        {
            if (screenToBe == _currentScreen)
                return;

            MenuScreen previousScreen = _currentScreen;
            

            if (_currentScreen is null)
            {
                screenToBe.transform.position = transform.position;
            }
            else
            {
                _currentScreen.transform.position = _currentScreen.StartPosition;
                _currentScreen.gameObject.SetActive(false);
            
                screenToBe.transform.position = transform.position;
                
                if(addToScreenHistory)
                    _screenHistory.Push(_currentScreen);
            }
            
            _currentScreen = screenToBe;
            _currentScreen.gameObject.SetActive(true);
            onScreenChanged?.Invoke(previousScreen, _currentScreen);
        }

        public void BackOne()
        {
            if (_currentScreen is ISpecialBackAction b)
            {           
                //_screenHistory.Pop();
                b.Back(this);
            }
            else if (_screenHistory.Any())
            {
                SetScreen(_screenHistory.Pop(), false);
            }
        }
    }
}