using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;

public class QuickPhotonTest : MonoBehaviour
{
    public void QuickPhotonTestCall(InputAction.CallbackContext context)
    {
        Debug.Log("Sending a message to the other player!");
        Net_TestMessage();
    }

    private void Net_TestMessage()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC(nameof(Rpc_TestMessage), RpcTarget.Others);
    }

    [PunRPC]
    private void Rpc_TestMessage()
    {
        Debug.Log("Received a photon message!");
    }
}
