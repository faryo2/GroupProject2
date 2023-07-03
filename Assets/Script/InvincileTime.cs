using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincileTime : MonoBehaviour
{
    public GameObject Slider
    public bool on_damage = false;  //�_���[�W�t���O
    private SpriteRenderer renderer;

    //Use this for initialization
    void Start ()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();//�_�ŏ����̂���
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
            renderer.color = new Color(if,if,if,level);             //�_���[�W�t���O��true�œ_�ł�����B
        }
        void OnCollisionEnter2D(Colision2D col)
        {
            if (!on_damage && col.gameObject.tag == "Enemy")
            {
                Slider.gameObjectSendMessage("onDamage", 10);//�G�ƂԂ������疳��
                OnDamageEffect();
            }
    }
    void OnDamageEffect()
    {
            on_damage = true;     //�_���[�W�t���O����

            StartCoroutine("WaitForIt")
    }
    IEnumerator WaitForIt()
        {
            yield return new WaitForSeconds(1); //1�b�����~�߂�BThe world


            on_dmage = false;
            renderer.color=new Color(if,if,if,if);/1�b��_���[�W�t���O��folse�ɂ��ē_�ł�߂��B

        }
          
    }
}
