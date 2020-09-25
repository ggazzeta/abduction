using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    bool gameHasEnded = false;
    public static bool GameIsPaused = false;
    bool tutorialHasEnded = false;

    public GameObject EndGameMenu;
    public GameObject NextLevelMenu;
    public GameObject EndTutorialMenu;
    GameObject Playercontrol;
    public GameObject FloatingJoystick;
    public ScriptableObject Script;

    public static bool PauseMyGame = false;
    public static bool SlowMo = false;

    public Text CowScore;
    public Text NumberOfCows;

    private void Start()
    {
        EndGameMenu.SetActive(false);
        NextLevelMenu.SetActive(false);
        GameIsPaused = false;
        SlowMo = false;
        PauseMyGame = false;
    }

    private void Update()
    {
        if(GameIsPaused)
        {
            PauseGame();
        }

        else if(gameHasEnded)
        {
            WinGame();
        }

        else if(tutorialHasEnded)
        {
            BeatTutorial();
        }


        if (PauseMyGame)
        {
            Time.timeScale = 0f;
        }

        if (SlowMo)
        {
            Time.timeScale = 0.1f;
        }

        if (PauseMyGame == false && SlowMo == false)
        {
            Time.timeScale = 1f;
        }
    }

    public void EndTutorial()
    {
        if (tutorialHasEnded == false)
        {
            tutorialHasEnded = true;
            Debug.Log("YouWon");
        }
    }

    public void EndGameVaquinhas()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("YouWon");
        }
    }

    public void EndGameDetected()
    {
        if(GameIsPaused == false)
        {
            GameIsPaused = true;
            Debug.Log("You were detected!");
        }
    }

    public void PauseGame()
    {
        EndGameMenu.SetActive(true);
        FloatingJoystick.SetActive(false);
        Playercontrol = GameObject.Find("Player");
        Playercontrol.tag = "Pause";
        //CowScore.text = Score.NumberOfCows.ToString() + " Cows Left";
        SlowMo = true;
    }

    public void ResumeGame()
    {
        FindObjectOfType<PlayerMovement>().enabled = true;
        FloatingJoystick.SetActive(true);
        EndGameMenu.SetActive(false);
        NextLevelMenu.SetActive(false);
        GameIsPaused = false;
        SlowMo = false;
        PauseMyGame = false;
    }

    public void Restart()
    {
        EndGameMenu.SetActive(false);
        NextLevelMenu.SetActive(false);
        FloatingJoystick.SetActive(true);
        SlowMo = false;
        PauseMyGame = false;
        FindObjectOfType<PlayerMovement>().enabled = true;
        CowCounter.cowCounter = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinGame()
    {
        GetComponent<ScoreManager>().Score();  
        NextLevelMenu.SetActive(true);
        FloatingJoystick.SetActive(false);
        FindObjectOfType<PlayerMovement>().enabled = false;
        PauseMyGame = true;
    }

    public void BeatTutorial()
    {
        EndTutorialMenu.SetActive(true);
        FindObjectOfType<PlayerMovement>().enabled = false;
    }

    public void LoadNextLevel()
    {
        SlowMo = false;
        PauseMyGame = false;
        FindObjectOfType<PlayerMovement>().enabled = true;
        EndGameMenu.SetActive(false);
        GameIsPaused = false;
        Debug.Log("Loading Level 02");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenu()
    {
        SlowMo = false;
        PauseMyGame = false;
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading menu...");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
}
