using UnityEngine;
using UnityEngine.SceneManagement; // Bu eklemeyi unutmayýn

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // SceneManagement API'sini kullanarak SampleScene'e geçiþ yapýlýr
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
