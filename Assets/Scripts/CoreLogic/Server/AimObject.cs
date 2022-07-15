using Unity.Netcode;
using UnityEngine;

namespace CoreLogic.Server
{
    public class AimObject : NetworkBehaviour
    {
        private void Update()
        {
            transform.Rotate(0, 1f * Time.deltaTime, 0);
        }
    }
}