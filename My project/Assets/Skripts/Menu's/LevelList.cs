using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelList : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
    }

    public void OpenInfoAboutLevel(GameObject levelPanel) =>
        levelPanel.SetActive(true);

    public void CloseInfoAboutLevel(GameObject levelPanel) =>
        levelPanel.SetActive(false);

    public void LoadLevel(int levelIndex) =>
        SceneManager.LoadScene(levelIndex);

    public void LoadTrainingLevel(int trainingLevelIndex) =>
        SceneManager.LoadScene(trainingLevelIndex);
}
