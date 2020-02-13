using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuFunctionality : MonoBehaviour
{

   public void LevelOne()
    {
        SceneManager.LoadScene(2);
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene(3);
    }
    public void LevelThree()
    {
        SceneManager.LoadScene(4);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenMenu(GameObject menu)
    {
        menu.SetActive(true);
    }
  
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        
#else
      Application.Quit();
#endif
    }
   
}