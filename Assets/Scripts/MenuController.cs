using UnityEngine;

public class MenuController : MonoBehaviour
{
    public string sceneName;

   
    void Update()
    {
        if(Input.anyKeyDown){
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
