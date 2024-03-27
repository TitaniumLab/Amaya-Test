using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Test1
{
    public class UIManager : MonoBehaviour
    {
        public static Action GameOver = delegate { };
        [SerializeField] private Button _restartButton;

        private void Start()
        {
            GameOver += ShowRestartButton;
        }

        private void OnDestroy()
        {
            GameOver -= ShowRestartButton;
        }


        public void ShowRestartButton()
        {
            _restartButton.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Restart()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}