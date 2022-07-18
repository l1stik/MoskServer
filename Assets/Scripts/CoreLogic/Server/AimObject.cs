using Unity.Netcode;
using UnityEngine;

namespace CoreLogic.Server
{
    public class AimObject : NetworkBehaviour
    {
        [SerializeField] private float _speed = 5f;
        
        private void Update()
        {
            transform.Rotate(0, _speed * Time.deltaTime, 0);
        }
    }
}