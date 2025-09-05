using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    private enum SceneName { DeathScene, MainMenu, Base, nullScene }
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
            case (SceneName.Base):
                SceneManager.LoadScene("Base");
                break;
            case (SceneName.MainMenu):
                SceneManager.LoadScene("Main Menu");
                break;
            case (SceneName.DeathScene):
                SceneManager.LoadScene("Death Scene");
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
