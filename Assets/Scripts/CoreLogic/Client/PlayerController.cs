using Cinemachine;
using Unity.Netcode;
using UnityEngine;

namespace CoreLogic.Client
{
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private GameObject _camera;
        [SerializeField] private NetworkObject _networkObject;
        
        public override void OnNetworkSpawn()
        {
            if (_networkObject.IsLocalPlayer)
            {
                var aim = GameObject.Find("Aim");
                SetAim(aim.transform);
            }
            else
            {
                _camera.SetActive(false);
            }
            base.OnNetworkSpawn();
        }

        private void SetAim(Transform aim)
        {
            _virtualCamera.Follow = aim;
            _virtualCamera.LookAt = aim;
        }
    }
}