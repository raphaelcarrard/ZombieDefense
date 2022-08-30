using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static PlayerController instance;
    public LayerMask enemy;
    public Animator playerAnim;
    public GameObject bulletPos;
    RaycastHit2D hit;
    public int gunType;
    public SpriteRenderer playerSpr;
    public Gun[] gun = new Gun[4];

    void Start () {
        instance = this;
        bulletPos.transform.localPosition = new Vector3(0.7f, 0.7f, 0);
        playerAnim.Play("Idle1");
        playerSpr.sortingOrder = -3;
	}

    void FinishLevel()
    {
        Time.timeScale = 0;
        GameManager.instance.winMenu.SetActive(true);
    }

    void AddMoney(int enemyType)
    {
        if (enemyType == 0)
        {
            switch (PlayerPrefs.GetInt("increase"))
            {
                case 0:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel0);
                    GameManager.instance.moneyEarn.text = "+"+(GameManager.instance.moneyGot[enemyType].moneyLevel0).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
                case 1:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel1);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel1).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
                case 2:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel2);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel2).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
                case 3:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel3);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel3).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
                case 4:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel4);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel4).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
            }
            GameManager.instance.SetMoney(PlayerPrefs.GetInt("money"));
        }
        else if (enemyType == 1)
        {
            switch (PlayerPrefs.GetInt("increase"))
            {
                case 0:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel0);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel0).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
                case 1:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel1);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel1).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
                case 2:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel2);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel2).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
                case 3:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel3);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel3).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
                case 4:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel4);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel4).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
            }
            GameManager.instance.SetMoney(PlayerPrefs.GetInt("money"));
        }
        else if (enemyType == 2)
        {
            switch (PlayerPrefs.GetInt("increase"))
            {
                case 0:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel0);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel0).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
                case 1:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel1);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel1).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
                case 2:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel2);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel2).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
                case 3:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel3);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel3).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
                case 4:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel4);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel4).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
            }
            GameManager.instance.SetMoney(PlayerPrefs.GetInt("money"));
        }
        else if (enemyType == 3)
        {
            switch (PlayerPrefs.GetInt("increase"))
            {
                case 0:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel0);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel0).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
                case 1:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel1);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel1).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
                case 2:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel2);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel2).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
                case 3:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel3);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel3).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
                case 4:
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + GameManager.instance.moneyGot[enemyType].moneyLevel4);
                    GameManager.instance.moneyEarn.text = "+" + (GameManager.instance.moneyGot[enemyType].moneyLevel4).ToString();
                    GameManager.instance.Earn.transform.position = hit.point;
                    GameManager.instance.Earn.SetActive(true);
                    break;
            }
            GameManager.instance.SetMoney(PlayerPrefs.GetInt("money"));
        }
    }

    public void Shoot()
    {
		SoundManager.instance.source.PlayOneShot (SoundManager.instance.clip[1]);
        RaycastHit2D hit = Physics2D.Raycast(bulletPos.transform.position, transform.right,100f, 1<<9);
        if (hit.collider!=null)
        {
            ObjectPooling.instance.GetBlood().transform.position = hit.point;
            ObjectPooling.instance.GetBlood().SetActive(true);
            switch (gunType)
            {
                case 0:
                    hit.collider.gameObject.GetComponent<AIController>().health -= gun[gunType].dam;
                    if (hit.collider.gameObject.GetComponent<AIController>().health <= 0)
                    {
                        hit.collider.gameObject.layer = 0;

                        PlayerPrefs.SetInt("totalkill", PlayerPrefs.GetInt("totalkill") + 1);
                        GameManager.instance.SetTotalKill(PlayerPrefs.GetInt("totalkill"));

                        AddMoney(hit.collider.gameObject.GetComponent<AIController>().type);
                        GameManager.instance.Earn.transform.position = hit.point;
                        GameManager.instance.Earn.SetActive(true);

                        hit.collider.gameObject.GetComponent<AIController>().canMove = false;

                        GameManager.instance.zombieCount -= 1;
                        GameManager.instance.SetZbCount(GameManager.instance.zombieCount);
                        if (GameManager.instance.zombieCount == 0)
                        {
                            PlayerPrefs.SetInt("day", PlayerPrefs.GetInt("day") + 1);
                            Invoke("FinishLevel", 1);
                        }
                    }
                    break;
                case 1:
                    hit.collider.gameObject.GetComponent<AIController>().health -= gun[gunType].dam;
                    iTween.MoveTo(hit.collider.gameObject, iTween.Hash("position", new Vector3(hit.collider.gameObject.transform.position.x + 2.5f, hit.collider.gameObject.transform.position.y, 0), "time", 0.5f, "easeType", iTween.EaseType.linear));
                    if (hit.collider.gameObject.GetComponent<AIController>().health <= 0)
                    {
                        hit.collider.gameObject.layer = 0;

                        PlayerPrefs.SetInt("totalkill", PlayerPrefs.GetInt("totalkill") + 1);
                        GameManager.instance.SetTotalKill(PlayerPrefs.GetInt("totalkill"));

                        AddMoney(hit.collider.gameObject.GetComponent<AIController>().type);
                        GameManager.instance.Earn.transform.position = hit.point;
                        GameManager.instance.Earn.SetActive(true);

                        hit.collider.gameObject.GetComponent<AIController>().canMove = false;

                        GameManager.instance.zombieCount -= 1;
                        GameManager.instance.SetZbCount(GameManager.instance.zombieCount);
                        if (GameManager.instance.zombieCount == 0)
                        {
                            PlayerPrefs.SetInt("day", PlayerPrefs.GetInt("day") + 1);
                            Invoke("FinishLevel", 1);
                        }
                    }
                    break;
                case 2:
                    hit.collider.gameObject.GetComponent<AIController>().health -= gun[gunType].dam;
                    if (hit.collider.gameObject.GetComponent<AIController>().health <= 0)
                    {
                        hit.collider.gameObject.layer = 0;

                        PlayerPrefs.SetInt("totalkill", PlayerPrefs.GetInt("totalkill") + 1);
                        GameManager.instance.SetTotalKill(PlayerPrefs.GetInt("totalkill"));

                        AddMoney(hit.collider.gameObject.GetComponent<AIController>().type);
                        GameManager.instance.Earn.transform.position = hit.point;
                        GameManager.instance.Earn.SetActive(true);

                        hit.collider.gameObject.GetComponent<AIController>().canMove = false;

                        GameManager.instance.zombieCount -= 1;
                        GameManager.instance.SetZbCount(GameManager.instance.zombieCount);
                        if (GameManager.instance.zombieCount == 0)
                        {
                            PlayerPrefs.SetInt("day", PlayerPrefs.GetInt("day") + 1);
                            Invoke("FinishLevel", 1);
                        }
                    }
                    break;
                case 3:
                    hit.collider.gameObject.GetComponent<AIController>().health -= gun[gunType].dam;
                    if (hit.collider.gameObject.GetComponent<AIController>().health <= 0)
                    {
                        hit.collider.gameObject.layer = 0;

                        PlayerPrefs.SetInt("totalkill", PlayerPrefs.GetInt("totalkill") + 1);
                        GameManager.instance.SetTotalKill(PlayerPrefs.GetInt("totalkill"));

                        AddMoney(hit.collider.gameObject.GetComponent<AIController>().type);
                        GameManager.instance.Earn.transform.position = hit.point;
                        GameManager.instance.Earn.SetActive(true);

                        hit.collider.gameObject.GetComponent<AIController>().canMove = false;

                        GameManager.instance.zombieCount -= 1;
                        GameManager.instance.SetZbCount(GameManager.instance.zombieCount);
                        if (GameManager.instance.zombieCount == 0)
                        {
                            PlayerPrefs.SetInt("day", PlayerPrefs.GetInt("day") + 1);
                            Invoke("FinishLevel", 1);
                        }
                    }
                    break;
            }
        }
    }
}
[System.Serializable]
public class Gun
{
    public int dam;
    public float fillAmoutValue;
}
