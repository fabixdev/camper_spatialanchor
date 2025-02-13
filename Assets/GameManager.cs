using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PhotonView targetPhotonView;

    public void ActivateObject()
    {
        targetPhotonView.RPC("On", RpcTarget.All);
    }

    public void DeactivateObject()
    {
        targetPhotonView.RPC("Off", RpcTarget.All);
    }
}
