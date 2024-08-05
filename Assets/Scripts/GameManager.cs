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
    public Text PointText;
    public Text PointTextOrange;
    public Text GameOverText;

    public Button RestartButton;
    public GameObject TitleObjects;

    private void Awake()
    {
        // Instancing
        if (Instance == null)
        {
            // 스크립트 컴포넌트를 넣어준다 
            Instance = this;
            // 스크립트가 부착된 오브젝트를 Static 처리 
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        RestartButton.onClick.AddListener(Restart);
        ScoreText.gameObject.SetActive(true);
        TitleObjects.gameObject.SetActive(true);
        ResetScore();
        //StartCoroutine(Test());
        //BeforeGameStart();
        StartCoroutine(SpawnTargets(1));
    }

    //IEnumerator Test()
    //{
    //    while(true)
    //    {
    //        yield return new WaitForSeconds(SpawnRate);
    //        Debug.Log("Test");
    //    }
    //}


    IEnumerator SpawnTargets(int level)
    {
        while (true)
        {
            // level이 높을수록 (1/level)의 결과값이 작아진다
            // 즉 레벨이 높을수록 타깃의 스폰주기가 짧아져 난이도 상승
            //Debug.Log($"SpawnRate : {SpawnRate}");
            //Debug.Log($"Level : {level}");
            //Debug.Log(SpawnRate / level);
            yield return new WaitForSeconds(SpawnRate/level);
            int randomIndex = Random.Range(0, Targets.Length);
            Instantiate(Targets[randomIndex]); // Target에서 position을 지정해주므로 여기서 지정하지 않아도 된다 
        }
    }

    internal void ResetScore()
    {
        Score = 0;
    }

    internal void UpdateScore(int point)
    {
        Score += point;
        PointText.text = $"{Score}";
        PointTextOrange.text = $"{Score}";
    }

    internal void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }

    public void Restart()
    {
        // 레벨이 5로 변함 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameOverText.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        ResetScore();
    }

    internal void GameStart(int level)
    {
        Debug.Log($"Level : {level}");
        TitleObjects.gameObject.SetActive(false);
        StopCoroutine(SpawnTargets(1));
        StartCoroutine(SpawnTargets(level));
    }

    //internal void BeforeGameStart()
    //{
    //    StartCoroutine(SpawnTargets(1));
    //}
}
