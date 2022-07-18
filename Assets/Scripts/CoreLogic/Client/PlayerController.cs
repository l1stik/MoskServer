using Unity.Netcode;
using UnityEngine;

namespace CoreLogic.Client
{
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField] private GameObject _camera;
        [SerializeField] private NetworkObject _networkObject;
        
        [SerializeField] private Vector3 _spawnPoint;
        
        public override void OnNetworkSpawn()
        {
            if (_networkObject.IsLocalPlayer)
            {
                transform.position = _spawnPoint;
            }
            else
            {
                _camera.SetActive(false);
            }
            base.OnNetworkSpawn();
        }

        private void OnTriggerExit(Collider other)
        {
            transform.position = _spawnPoint;
        }
    }
}