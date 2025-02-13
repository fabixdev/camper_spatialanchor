using UnityEngine;

public class DisableMeshAtStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Disable this GameObject
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.enabled = false;
        }
    }
}
