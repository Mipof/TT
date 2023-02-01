using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAScene : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
