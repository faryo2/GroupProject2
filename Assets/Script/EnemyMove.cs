using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
  [SerializeField] private float enemySpeed;
  [SerializeField] private float enemyLifeTime;

  private GameObject data;
  private Data dataCs;
    private GameObject player;
    private PlayerMove playerCs;

    // Start is called before the first frame update
    void Start()
    {
      data = GameObject.Find("Data");
      dataCs = data.GetComponent<Data>();
        player = GameObject.Find("Player");
        playerCs = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(new Vector3(0, 0, enemySpeed) * Time.deltaTime);

      //enemyLifeTime秒後にオブジェクトを消す
      enemyLifeTime = enemyLifeTime - Time.deltaTime;
      if(enemyLifeTime < 0)
      {
        Destroy(this.gameObject);
      }
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.CompareTag("Bullet"))
      {
        dataCs.score++; //Destroyの前に書くこと！
        playerCs.ex++;
        Destroy(this.gameObject);
        Debug.Log("Bullet");
      }
      if(other.gameObject.CompareTag("Player"))
      {
        Destroy(this.gameObject);
      }
    }
}
