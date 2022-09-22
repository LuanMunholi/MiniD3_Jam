using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneTransitionArena : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Menu");
    }
}