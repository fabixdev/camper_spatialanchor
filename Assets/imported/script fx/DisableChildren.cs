using Photon.Pun;
using UnityEngine;

public class DisableChildren : MonoBehaviourPun
{
    // Metodo per disabilitare tutti i figli e sincronizzarli
    public void DisableAllChildren()
    {
        // Disabilita i figli localmente
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        // Invoca il metodo remoto per sincronizzare con gli altri client
        photonView.RPC("RPC_DisableAllChildren", RpcTarget.OthersBuffered);
    }

    // Metodo remoto che sarà chiamato su tutti i client
    [PunRPC]
    void RPC_DisableAllChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
