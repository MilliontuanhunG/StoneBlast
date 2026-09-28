using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadScene( string sceneName)
    {
        Debug.Log("HNHUCCCC");
        SceneManager.LoadScene( sceneName );
    }
}
