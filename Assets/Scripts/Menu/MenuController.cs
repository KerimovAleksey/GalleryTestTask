using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ChangeScene(int sceneNumber)
    {
        PlayerPrefs.SetInt("SceneToLoad", sceneNumber);
        SceneManager.LoadScene(1);
    }
}
