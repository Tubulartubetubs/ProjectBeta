using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{    public void LoadScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
}
