using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincileTime : MonoBehaviour
{
    public GameObject Slider
    public bool on_damage = false;  //ダメージフラグ
    private SpriteRenderer renderer;

    //Use this for initialization
    void Start ()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();//点滅処理のため
    }

 
    // Start is called before the first frame update
    void Start()
    {
       

            
        
    }

    // Update is called once per frame
    void Update()
    {
        if (on_damage)
        {
            float level = Math.Abs(Math.Sin(InvincileTime.time *));
            renderer.color = new Color(if,if,if,level);             //ダメージフラグがtrueで点滅させる。
        }
        void OnCollisionEnter2D(Colision2D col)
        {
            if (!on_damage && col.gameObject.tag == "Enemy")
            {
                Slider.gameObjectSendMessage("onDamage", 10);//敵とぶつかったら無効
                OnDamageEffect();
            }
    }
    void OnDamageEffect()
    {
            on_damage = true;     //ダメージフラグ発動

            StartCoroutine("WaitForIt")
    }
    IEnumerator WaitForIt()
        {
            yield return new WaitForSeconds(1); //1秒処理止める。The world


            on_dmage = false;
            renderer.color=new Color(if,if,if,if);/1秒後ダメージフラグをfolseにして点滅を戻す。

        }
          
    }
}
