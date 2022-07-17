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
            _startServerButton.onClick.AddListener(StartServer);
            
            _startClientButton.onClick.AddListener(StartClient);
        }

        private void StartServer()
        {
            NetworkManager.Singleton.StartServer();
            _canvas.SetActive(false);
        }
        
        private void StartClient()
        {
            NetworkManager.Singleton.StartClient();
            _canvas.SetActive(false);
        }
    }
}