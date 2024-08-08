using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Static
    public static GameManager Instance;

    // private
    private float SpawnRate = 1f;
    private int Score;

    // referencing
    public GameObject[] Targets;
    public Text ScoreText;
    public Text[] PointTexts;
    public Text GameOverText;

    public Button RestartButton;
    public Button ExitButton;
    public GameObject TitleObjects;

    public GameObject Live;
    public GameObject[] Hearts;

    private int LivesRemaning;
    private Coroutine StartSpawn;

    public GameObject GameOverElements;
    public Text[] FinalScores;

    private bool IsGamePlaying = false;

    private int selectedLevel;

    private void Awake()
    {
        // Instancing
        if (Instance == null)
        {
            // 스크립트 컴포넌트를 넣어준다 
            Instance = this;
            // 스크립트가 부착된 오브젝트를 Static 처리 
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlaySoundBGM();
        LivesRemaning = Hearts.Length;

        // Button
        RestartButton.onClick.AddListener(Restart);
        ExitButton.onClick.AddListener(Exit);

        TitleObjects.gameObject.SetActive(true);
        ResetScore();

        GameOverElements.SetActive(false);

        StartSpawn = StartCoroutine(SpawnTargets(1));
    }

    private void Exit()
    {
        GameOverElements.SetActive(false);
        TitleObjects.gameObject.SetActive(true);
        ResetScore();
        StopCoroutine(StartSpawn);
    }


    IEnumerator SpawnTargets(int level)
    {
        while (true)
        {
            // level이 높을수록 (1/level)의 결과값이 작아진다
            // 즉 레벨이 높을수록 타깃의 스폰주기가 짧아져 난이도 상승
            //Debug.Log($"SpawnRate : {SpawnRate}");
            //Debug.Log($"Level : {level}");
            //Debug.Log(SpawnRate / level);
            yield return new WaitForSeconds(SpawnRate / level);
            int randomIndex = Random.Range(0, Targets.Length);
            Instantiate(Targets[randomIndex]); // Target에서 position을 지정해주므로 여기서 지정하지 않아도 된다 
        }
    }

    internal void ResetScore()
    {
        Score = 0;
        UpdateScore(Score);
    }

    internal void UpdateScore(int point)
    {
        if (IsGamePlaying)
        {
            Score += point;
            foreach (Text score in PointTexts)
            {
                score.text = $"{Score}";
            }

        }
    }

    internal void GameOver()
    {
        GameOverElements.SetActive(true);
        ScoreText.gameObject.SetActive(false);
        PointTexts[0].gameObject.SetActive(false);
        PointTexts[1].gameObject.SetActive(false);

        foreach (Text score in FinalScores)
        {
            score.text = $"{Score}";
        }

        Live.SetActive(false);
        StopCoroutine(StartSpawn);
        IsGamePlaying = false;
    }

    public void Restart()
    {
        SoundManager.Instance.PlaySoundGameStart();
        // 레벨이 5로 변함 
        GameOverElements.SetActive(false);
        // reset health
        ActivateHearts();
        ResetScore();
        GameStart(selectedLevel);

    }

    internal void GameStart(int level)
    {
        SoundManager.Instance.PlaySoundGameStart();
        IsGamePlaying = true;
        selectedLevel = level;

        ResetScore();
        TitleObjects.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(true);
        PointTexts[0].gameObject.SetActive(true);
        PointTexts[1].gameObject.SetActive(true);
        Live.SetActive(true);
        StopCoroutine(StartSpawn);
        StartSpawn = StartCoroutine(SpawnTargets(level));
    }

    internal void LoseLife()
    {
        //UIManager.TakeHealth(); // TODO - UI Manager 만들기 
        LivesRemaning--;
        Debug.Log(LivesRemaning);
        Hearts[LivesRemaning].SetActive(false);
        //Transform childTransform = Hearts[LivesRemaning].transform.Find("Fill");
        //childTransform.gameObject.SetActive(false);

        if (LivesRemaning <= 0)
        {
            GameOver();
        }
    }

    internal void ActivateHearts()
    {
        LivesRemaning = Hearts.Length;
        foreach (Transform child in Live.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

}
