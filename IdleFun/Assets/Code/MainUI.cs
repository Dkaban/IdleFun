using UnityEngine;

namespace IdleFun
{
    public class MainUI : MonoBehaviour
    {
        #region SINGLETON SETUP
        public static MainUI Instance = null;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);
        }
        #endregion
        public void TappedButton()
        {
            //DO something
            IdleHandler.Instance.ButtonTapped();
        }
    }
}
