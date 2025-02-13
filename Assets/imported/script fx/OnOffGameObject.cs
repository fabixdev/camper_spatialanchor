using Photon.Pun;
using UnityEngine;

public class OnOffGameObject : MonoBehaviourPun
{
    // Metodo per accendere il GameObject
    [PunRPC]
    public void TurnOn()
    {
        UnityEngine.Debug.Log($"{gameObject.name}: TurnOn called");
        gameObject.SetActive(true);
    }

    // Metodo per spegnere il GameObject
    [PunRPC]
    public void TurnOff()
    {
        UnityEngine.Debug.Log($"{gameObject.name}: TurnOff called");
        gameObject.SetActive(false);
    }

    // Metodi pubblici per chiamare i metodi RPC
    public void ActivateGameObject()
    {
        UnityEngine.Debug.Log($"{gameObject.name}: ActivateGameObject called");
        photonView.RPC("TurnOn", RpcTarget.AllBuffered);
    }

    public void DeactivateGameObject()
    {
        UnityEngine.Debug.Log($"{gameObject.name}: DeactivateGameObject called");
        photonView.RPC("TurnOff", RpcTarget.AllBuffered);
    }

    // Metodo di test per attivare o disattivare manualmente
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y)) // Premi 'Y' per attivare
        {
            UnityEngine.Debug.Log($"{gameObject.name}: 'Y' key pressed, calling ActivateGameObject");
            ActivateGameObject();
        }

        if (Input.GetKeyDown(KeyCode.U)) // Premi 'U' per disattivare
        {
            UnityEngine.Debug.Log($"{gameObject.name}: 'U' key pressed, calling DeactivateGameObject");
            DeactivateGameObject();
        }
    }
}
