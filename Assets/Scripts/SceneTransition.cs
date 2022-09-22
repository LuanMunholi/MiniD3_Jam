using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneTransition : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Arena");
    }

    public void QuitGame(){

        Application.Quit();

    }

}