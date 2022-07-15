using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace CoreLogic.Server
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Button _startServerButton;
        [SerializeField] private Button _startClientButton;
        
        [SerializeField] private GameObject _canvas;
        
        private void Start()
        {
            _startServerButton.onClick.AddListener(() =>
            {
                NetworkManager.Singleton.StartServer();
                _canvas.SetActive(false);
            });
            
            _startClientButton.onClick.AddListener(() =>
            {
                NetworkManager.Singleton.StartClient();
                _canvas.SetActive(false);
            });
        }
    }
}