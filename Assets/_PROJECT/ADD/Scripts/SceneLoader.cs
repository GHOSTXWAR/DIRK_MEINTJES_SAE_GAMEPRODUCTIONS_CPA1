using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    private enum SceneName { DeathScene, MainMenu, LEVEL1, LEVEL2, nullScene }
    [SerializeField] private SceneName sceneName;

    private void Awake()
    {
        /*if (SceneManager.GetActiveScene().name == "Death Scene")
        {
            switch (PlayerPrefs.GetString("CurrScene"))
            {
                case ("LEVEL One"):
                    sceneName = SceneName.LEVELOne;
                    break;
                case ("LEVEL Two"):
                    sceneName =SceneName.LEVELTwo;
                    break;
                case ("LEVEL Three"):
                    sceneName=SceneName.LEVELThree;
                    break;
                case ("LEVEL Four"):
                    sceneName=SceneName.LEVELFour;
                    break;
            }
        }*/
    }
    public void LoadScene()
    {
        switch (sceneName)
        {
            case (SceneName.LEVEL1):
                SceneManager.LoadScene("LEVEL 1");
                break;
            case (SceneName.MainMenu):
                SceneManager.LoadScene("Main Menu");
                break;
            case (SceneName.DeathScene):
                SceneManager.LoadScene("Death Scene");
                break;
            case (SceneName.LEVEL2):
                SceneManager.LoadScene("LEVEL 2");
                break;

        }
    }

    private void OnDisable()
    {
        if (sceneName == SceneName.DeathScene)
        {
           Scene currentscene = SceneManager.GetActiveScene();
            PlayerPrefs.SetString("CurrScene",currentscene.name);
        }
    }
}
