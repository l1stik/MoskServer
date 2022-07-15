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

        private void Start()
        {
            if (!_networkObject.IsLocalPlayer)
            {
                _camera.SetActive(false);
                return;
            }
            
            var aim = GameObject.Find("Aim");
            SetAim(aim.transform);
        }

        private void SetAim(Transform aim)
        {
            _virtualCamera.Follow = aim;
            _virtualCamera.LookAt = aim;
        }
    }
}