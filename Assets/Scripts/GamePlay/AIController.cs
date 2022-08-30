using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
    public static AIController instance;
    [HideInInspector] public Animator aiAnim;
    [HideInInspector] public SpriteRenderer aiSpr;
    [HideInInspector]public bool canMove;
    public int type;
    [HideInInspector]public GameObject healthSprite;


    private BoxCollider2D aiCollider;
    private int randomValue;
    private float yPos;
    private int zbType;
    public int health;
    private float rootHealth;
	private bool isDead;
    
    private void OnEnable()
    {
		isDead = false;

        aiCollider.enabled = true;

        aiAnim.Play("zbMove"+(type+1).ToString());

        if (type == 0)
        {
            health = 4;
            rootHealth = 4;
        }
        else if (type == 1)
        {
            health = 6;
            rootHealth = 6;
        }
        else if (type == 2)
        {
            health = 8;
            rootHealth = 8;
        }
        else if (type == 3)
        {
            health = 10;
            rootHealth = 10;
        }

        canMove = true;

        gameObject.layer = 9;

        healthSprite.transform.parent.gameObject.SetActive(true);
        healthSprite.transform.localScale = new Vector3(1, 1, 0);

        switch (Random.Range(0, 3))
        {
            case 0:
                yPos = 0.8f;
                aiSpr.sortingOrder = -3;
                break;
            case 1:
                yPos = -0.8f;
                aiSpr.sortingOrder = -2;
                break;
            case 2:
                yPos = -2.8f;
                aiSpr.sortingOrder = -1;
                break;
        }

        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width + 30, 0)).x, yPos, 0);
    }

    private void Awake()
    {
        instance = this;

        canMove = true;

        aiAnim = GetComponent<Animator>();

        aiSpr = GetComponent<SpriteRenderer>();

        aiCollider = GetComponent<BoxCollider2D>();

        healthSprite = transform.Find("health bar 1").gameObject.transform.Find("health bar 2").gameObject;
    }

    private void Update()
    {
        if (canMove && Time.timeScale!=0)
        {
            transform.position = new Vector3(transform.position.x - 0.025f, yPos, 0);
        }
        if (transform.position.x <= PlayerController.instance.gameObject.transform.position.x)
        {
            canMove = false;
            aiAnim.Play("zbAttack" + (type + 1).ToString());
        }
        if (health <= 0)
        {
			if (!isDead) {
				isDead = true;
				SoundManager.instance.source.PlayOneShot (SoundManager.instance.clip[2]);
			}

            aiCollider.enabled = false;

            aiAnim.Play("zbDead"+(type+1).ToString());
        }

        if (health / rootHealth > 0)
        {
            healthSprite.transform.parent.gameObject.SetActive(true);
            healthSprite.transform.localScale = new Vector3((float)(health / rootHealth), 1, 0);
        }
        else
        {
            healthSprite.transform.parent.gameObject.SetActive(false);
        }
    }
    void Attack()
    {
        if (transform.position.x <= PlayerController.instance.gameObject.transform.position.x)
        {
            GameManager.instance.SetDaySurvival(PlayerPrefs.GetInt("day"));
            GameManager.instance.loseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        switch (type)
        {
            case 0:
                if (target.GetComponent<Box>() != null)
                {
                    target.GetComponent<Box>().boxHealth -= GameManager.instance.enemyDam[type].enemyAttack;
                }
                break;
            case 1:
                if (target.GetComponent<Box>() != null)
                {
                    target.GetComponent<Box>().boxHealth -= GameManager.instance.enemyDam[type].enemyAttack;
                }
                break;
            case 2:
                if (target.GetComponent<Box>() != null)
                {
                    target.GetComponent<Box>().boxHealth -= GameManager.instance.enemyDam[type].enemyAttack;
                }
                break;
            case 3:
                if (target.GetComponent<Box>() != null)
                {
                    target.GetComponent<Box>().boxHealth -= GameManager.instance.enemyDam[type].enemyAttack;
                }
                break;
        }
        
        if (target.GetComponent<Box>().boxHealth<=0f)
        {
            canMove = true;

            aiAnim.Play("zbMove"+(type+1).ToString());
        }
        
    }
    void DisAppear()
    {
        gameObject.SetActive(false);
        canMove = true;
    }

    GameObject target;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            target = collision.gameObject;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            aiAnim.Play("zbAttack"+(type+1).ToString());

            canMove = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            aiAnim.Play("zbAttack" + (type + 1).ToString());

            canMove = true;
        }
    }
}
