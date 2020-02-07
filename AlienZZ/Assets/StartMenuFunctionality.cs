using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuFunctionality : MonoBehaviour
{
    public GameObject loadGameMenu;
    public GameObject optionsMenu;
    public GameObject background;
    public Sprite[] imageToChange;

    void Awake()
    {
        loadGameMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenMenu(GameObject menu)
    {
        menu.SetActive(true);
    }
    public void CloseMenu()
    {
        optionsMenu.SetActive(false);
        loadGameMenu.SetActive(false);
    }
    public void LoadGame(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
    public void OptionMenu()
    {
        SceneManager.LoadScene("Options");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Application.OpenURL("www.Twitch.tv/AfroShezz");
#else
      Application.Quit();
#endif
    }
    public void NextImage(int nextImage)
    {
        background.GetComponent<Image>().sprite = imageToChange[nextImage];
    }
}