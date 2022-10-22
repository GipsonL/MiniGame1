using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager2 : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text HighScore;
    public GameObject GameOverText;

    private bool m_Started = false;
    private int m_Points;

    private bool m_GameOver = false;

    public float time_limit;
    public bool timer_active = false;
    public TextMeshProUGUI timer_text;

    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        timer_active = true;
        m_Points = MySharedData.GetIntermediateScore();
        //Set High score and name
        ScoreText.text = $"User :{MySharedData.GetName()}, Score {m_Points}";
        HighScore.text = string.Format("Best Score : {0} : {1}",
            PlayerPrefs.GetString("first_string"),
            PlayerPrefs.GetInt("first_int"));

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
                InvokeRepeating("speedUpBall", 0, 15);
            }
        }
        else if (GameObject.Find("BrickPrefab(Clone)") == null)
            SceneManager.LoadScene("GameOver");
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (timer_active)
        {
            if (time_limit > 0)
            {
                time_limit -= Time.deltaTime;
                UpdateTimer(time_limit);
            }
            else
            {
                GameOver();
                time_limit = 0;
                timer_active = false;
            }
        }
    }

    public void speedUpBall()
    {
        Rigidbody rb = Ball.GetComponent<Rigidbody>();
        rb.velocity *= 2;
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"User :{MySharedData.GetName()}, Score {m_Points}";
    }


    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        Set_intermediate_score(time_limit);
        SceneManager.LoadScene("GameOver");
    }
    public void Set_intermediate_score(float numtFactor)
    {
        MySharedData.SetIntermediateScore(m_Points * (int)numtFactor);
    }

    void UpdateTimer(float currentt_time)
    {
        currentt_time += 1;

        float minutes = Mathf.FloorToInt(currentt_time / 60);
        float seconds = Mathf.FloorToInt(currentt_time % 60);

        timer_text.text = string.Format(" Time Remaining:\n {0:00} : {1:00}", minutes, seconds);
    }
}