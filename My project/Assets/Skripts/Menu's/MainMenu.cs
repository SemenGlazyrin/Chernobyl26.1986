using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;

    public void StartGame() => 
        SceneManager.LoadScene(1);

    public void ExitGame() => 
        Application.Quit();

    public void OpenSettings() =>
        settingsMenu.SetActive(true);

    public void CloseSettings() =>
        settingsMenu.SetActive(false);
}
