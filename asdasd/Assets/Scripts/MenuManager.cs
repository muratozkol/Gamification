using UnityEngine;
using UnityEngine.SceneManagement; // Bu eklemeyi unutmay�n

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // SceneManagement API'sini kullanarak SampleScene'e ge�i� yap�l�r
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
