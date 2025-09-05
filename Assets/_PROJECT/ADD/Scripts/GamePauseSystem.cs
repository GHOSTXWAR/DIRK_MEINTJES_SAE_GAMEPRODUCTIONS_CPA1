using UnityEngine;
using UnityEngine.InputSystem;
public class GamePauseSystem : MonoBehaviour
{
    public static bool inPausedState = false;
    private InputSystem_Actions inputSystem;
    private InputAction pause;
    public GameObject PauseMenu;


    // Update is called once per frame
    private void Awake()
    {
        inputSystem = new InputSystem_Actions();

    }
    private void OnEnable()
    {

        pause = inputSystem.Player.Pause;
        pause.Enable();
    }

    private void OnDisable()
    {
        pause.Disable();
    }
    void Update()
    {

        if (pause.WasPressedThisFrame()) //IMPORTANT!!
        {
            PauseGame();
        }
    }

    public void PauseGameNoMenu()
    {
        if (inPausedState)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void PauseGame()
    {
        inPausedState = !inPausedState;
        if (!inPausedState)
        {
            Time.timeScale = 1f; //Unpause game
            if (PauseMenu != null)
                //PauseMenu.GetComponent<Canvas>().enabled = false;
                PauseMenu.SetActive(false);
            inPausedState = false;
            Debug.Log("Game is unpaused");
        }
        else
        {
            Time.timeScale = 0f; //Pause game
            if (PauseMenu != null)
                //PauseMenu.GetComponent<Canvas>().enabled = true;
                PauseMenu.SetActive(true);
            inPausedState = true;
            Debug.Log("Game is paused");

        }
    }

}
