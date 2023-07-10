using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
  [SerializeField] private Text scoreText;
  [SerializeField] private Text highScoreText;
  private float score;
  private float highScore = 0;
  private GameObject data;
  private Data dataCs;

    // Start is called before the first frame update
    void Start()
    {
      score = 0;
      data = GameObject.Find("Data");
      dataCs = data.GetComponent<Data>();
    }

    public void AddPoint()
    {
      score = dataCs.score;
      if (highScore < score)
      {
        highScore = score;
      }
    }
    // Update is called once per frame
    void Update()
    {
      AddPoint();
      score = dataCs.score;
      scoreText.text = "Score：" + score.ToString();
      highScoreText.text = "High Score：" + highScore.ToString();
    }
}
