using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private int countOfClicks = 0;
    private int numOfSceneToLoad;

    public void PostTick(GameObject tick)
    {
        if (countOfClicks == 0) 
        {
            tick.SetActive(true);
            countOfClicks++;
            
            Invoke("LoadScene", 3);
        }
    }

    public void GetSceneNumber(int numOfScene) =>
        numOfSceneToLoad = numOfScene;

    private void LoadScene() =>
        SceneManager.LoadScene(numOfSceneToLoad);
}
