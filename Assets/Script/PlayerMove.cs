using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float firstMoveSpeed;
    [SerializeField] private float xMax;
    [SerializeField] private float xMin;
    [SerializeField] private float zMax;
    [SerializeField] private float zMin;
    [SerializeField] private int maxHp;
    [SerializeField] private int firstMaxHp;

    public int number;
    public int Hp;
    public int level;
    public int ex;
    public float speed;
    public Slider slider;

    private bool isInvincible = false;
    public float invincibilityTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        number = 0;
        Hp = firstMaxHp;
        level = 0;
        ex = 0;
        speed = firstMoveSpeed;
        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInvincible || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveX, 0, moveZ);
            transform.position += movement * moveSpeed * Time.deltaTime;

            // ˆÚ“®”ÍˆÍ‚Ì§ŒÀ
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, xMin, xMax);
            clampedPosition.z = Mathf.Clamp(clampedPosition.z, zMin, zMax);
            transform.position = clampedPosition;
        }

        if (ex >= 10)
        {
            ex -= 10;
            level++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !isInvincible)
        {
            Hp--;
            if (Hp <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                StartCoroutine(InvincibilityCooldown());
            }

            slider.value = (float)Hp / (float)maxHp;
        }
    }

    private System.Collections.IEnumerator InvincibilityCooldown()
    {
        isInvincible = true;

        yield return new WaitForSeconds(invincibilityTime);

        isInvincible = false;
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene("End");
    }
}
