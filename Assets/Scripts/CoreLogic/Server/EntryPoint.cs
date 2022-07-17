using System.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace CoreLogic.Server
{
    public class EntryPoint : MonoBehaviour
    {
        private const float TimeApproveConnection = 1f;

        [SerializeField] private Button _startServerButton;
        [SerializeField] private Button _startClientButton;
        
        [SerializeField] private GameObject _canvas;

        [SerializeField] private Text _labelWarning;
        
        private void Start()
        {
            _labelWarning.enabled = false;
            
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
            NetworkManager.Singleton.OnClientDisconnectCallback += obj => OnDisconnectClientEvent();
            
            _startClientButton.interactable = false;
            _startServerButton.interactable = false;
            
            StartCoroutine(WaitingForApproveClientConnection());
        }

        private void OnDisconnectClientEvent()
        {
            _canvas.SetActive(true);
            _labelWarning.enabled = true;
        }
        
        private IEnumerator WaitingForApproveClientConnection()
        {
            yield return new WaitForSeconds(TimeApproveConnection);
            
            if (!NetworkManager.Singleton.IsConnectedClient)
            {
                _labelWarning.enabled = true;
            }
            else
            {
                _canvas.SetActive(false);
            }
        }
    }
}