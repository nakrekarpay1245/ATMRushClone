using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInterfaceManager : MonoBehaviour
{
    public Slider playerSlider;

    public GameObject player;

    public GameObject[] npces;

    public GameObject finishLine;

    public GameObject levelCompletedPanel;

    public GameObject retryButton;

    public GameObject nextButton;


    public GameObject tutorial;

    public Text currentLevelText;
    public Text nextLevelText;

    Vector3 startPosition;


    public int levelNumber;

    bool gameStarted;
    bool gameFinished;

    public static UserInterfaceManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        startPosition = player.transform.position;

        levelCompletedPanel.SetActive(false);

        retryButton.SetActive(false);
        nextButton.SetActive(false);

        currentLevelText.text = levelNumber.ToString();
        nextLevelText.text = (levelNumber + 1).ToString();
    }

    void Update()
    {
        playerSlider.value = (player.transform.position.z - startPosition.z) /
           (finishLine.transform.position.z - startPosition.z);

        if (!gameStarted && Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartGame();
            gameStarted = true;
        }

        if (!gameFinished && Vector3.Distance(ATMRush.instance.transform.position, finishLine.transform.position) < 1)
        {
            ATMRush.instance.GameStop();
            Movement.instance.GameStop();
            FinishAnimation.instance.finishAnimation();
            gameFinished = true;
        }
    }

    public void LevelChanger(int number)
    {
        SceneManager.LoadScene(number);
    }
    public void LevelChanger(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OpenUrl(string url)
    {
        Application.OpenURL(url);
    }

    public void StartGame()
    {
        tutorial.SetActive(false);
        Movement.instance.GameStart();
        foreach (GameObject npc in npces)
        {
            npc.GetComponent<NPC_Car>().CarStart();
        }
    }

    public void FinishGame()
    {
        nextButton.SetActive(true);
        levelCompletedPanel.SetActive(true);
    }
}
