using UnityEngine;

public class DisableObjectsByName : MonoBehaviour
{
    // Nome del GameObject da cercare
    public string targetName;

    // Metodo per spegnere tutti i GameObject con il nome specificato
    public void DisableGameObjectsByName()
    {
        // Trova tutti i GameObject nella scena
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        // Itera su ogni GameObject e controlla il nome
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == targetName)
            {
                obj.SetActive(false);
                UnityEngine.Debug.Log($"GameObject '{targetName}' disattivato: {obj.name}");
            }
        }
    }

    // Esempio di utilizzo con un tasto
    private void Update()
    {
        // Premi il tasto 'D' per disattivare i GameObject
        if (Input.GetKeyDown(KeyCode.D))
        {
            DisableGameObjectsByName();
        }
    }
}
