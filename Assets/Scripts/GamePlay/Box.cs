using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    public float boxHealth;
    private SpriteRenderer boxSpr;
    Animator aim;

    private void Awake() {
        boxSpr = GetComponent<SpriteRenderer>();
        aim = GetComponent<Animator>();
        aim.enabled = false;
    }

    private void Start()
    {
        switch(PlayerPrefs.GetInt("upgrade"))
        {
            case 0:
                boxHealth = 2;
                boxSpr.sprite = GameManager.instance.box1;
                break;
            case 1:
                boxHealth = GameManager.instance.boxpower[PlayerPrefs.GetInt("upgrade") - 1].boxPower;
                boxSpr.sprite = GameManager.instance.box1;
                break;
            case 2:
                boxHealth = GameManager.instance.boxpower[PlayerPrefs.GetInt("upgrade") - 1].boxPower;
                boxSpr.sprite = GameManager.instance.box2[0];
                break;
            case 3:
                boxHealth = GameManager.instance.boxpower[PlayerPrefs.GetInt("upgrade") - 1].boxPower;
                boxSpr.sprite = GameManager.instance.box3[0];
                break;
            case 4:
                boxHealth = GameManager.instance.boxpower[PlayerPrefs.GetInt("upgrade") - 1].boxPower;
                boxSpr.sprite = GameManager.instance.box4[0];
                break;
        }
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("upgrade") == 2){
            if(boxHealth == 4){
                boxSpr.sprite = GameManager.instance.box2[0];
            }
            else if(boxHealth < 4 && boxHealth >= 3){
                    boxSpr.sprite = GameManager.instance.box2[1];
                }
            else if(boxHealth < 3 && boxHealth >= 2){
                    boxSpr.sprite = GameManager.instance.box2[2];
                } 
            else {
                    boxSpr.sprite = GameManager.instance.box2[3];
                }
            }
        else if(PlayerPrefs.GetInt("upgrade") == 3){
                if(boxHealth == 6){
                    boxSpr.sprite = GameManager.instance.box3[0];
                }
                else if(boxHealth < 6 && boxHealth >= 4){
                        boxSpr.sprite = GameManager.instance.box3[1];
                    }
                else if(boxHealth < 4 && boxHealth >= 2){
                        boxSpr.sprite = GameManager.instance.box3[2];
                    } 
                else {
                        boxSpr.sprite = GameManager.instance.box3[3];
                    }
            }
        else if(PlayerPrefs.GetInt("upgrade") == 4){
                if(boxHealth == 8){
                    boxSpr.sprite = GameManager.instance.box4[0];
                }
            else if(boxHealth < 8 && boxHealth >= 6){
                    boxSpr.sprite = GameManager.instance.box4[1];
                }
            else if(boxHealth < 6 && boxHealth >= 3){
                    boxSpr.sprite = GameManager.instance.box4[2];
                } 
            else {
                    boxSpr.sprite = GameManager.instance.box4[3];
                }
            }
        if(boxHealth <= 0){
            aim.enabled = true;
            aim.Play("boxExplosion");
        }
    }

    void Disappear(){
        gameObject.SetActive(false);
    }
}
