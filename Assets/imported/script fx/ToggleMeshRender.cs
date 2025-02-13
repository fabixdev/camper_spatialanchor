using UnityEngine;
using Photon.Pun;

public class ToggleMeshRender : MonoBehaviour
{
    private PhotonView photonView; // Dichiarazione della variabile photonView

    void Awake()
    {
        photonView = GetComponent<PhotonView>(); // Inizializzazione di photonView
    }

    [PunRPC]
    public void TurnOn()
    {
        UnityEngine.Debug.Log($"{gameObject.name}: TurnOn called");
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.enabled = true;
        }
    }

    [PunRPC]
    public void TurnOff()
    {
        UnityEngine.Debug.Log($"{gameObject.name}: TurnOff called");
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.enabled = false;
        }
    }

    public void Toggle()
    {
        if (photonView == null) // Controllo di sicurezza per evitare NullReferenceException
        {
            UnityEngine.Debug.LogError($"{gameObject.name}: photonView is null!");
            return;
        }

        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
        bool isEnabled = meshRenderers.Length > 0 && meshRenderers[0].enabled;

        UnityEngine.Debug.Log($"{gameObject.name}: Toggle called");

        if (isEnabled)
        {
            UnityEngine.Debug.Log($"{gameObject.name}: MeshRenderer is enabled, turning off");
            photonView.RPC("TurnOff", RpcTarget.AllBuffered);
        }
        else
        {
            UnityEngine.Debug.Log($"{gameObject.name}: MeshRenderer is disabled, turning on");
            photonView.RPC("TurnOn", RpcTarget.AllBuffered);
        }
    }
}
