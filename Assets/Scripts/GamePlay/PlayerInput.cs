using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public GameObject player;

    [Header("for shoot button")]
    [Space(25)]
    public static bool startFill;
    public Image fillToShoot;

    private void Update()
    {
        MoveInWebAndPC();
        if(Input.GetKey(KeyCode.Space)){
            Shoot();
        }
        if (startFill){
            fillToShoot.fillAmount += PlayerController.instance.gun[PlayerController.instance.gunType].fillAmoutValue;
            if(fillToShoot.fillAmount >= 1){
                startFill = false;
            }
        }
        else {
            fillToShoot.fillAmount = 1;
        }
    }

    public void Move(int direction){
            PlayerController.instance.playerAnim.Play("Move"+(PlayerController.instance.gunType+1).ToString());
            if(direction == 1){
                if (player.transform.position.y == -0.8f){
                    PlayerController.instance.playerSpr.sortingOrder = -3;
                    iTween.MoveTo(player, iTween.Hash("position", new Vector3(player.transform.position.x, 0.8f, 0), "time", 0.5f, "easeType", iTween.EaseType.linear));
                }else if (player.transform.position.y == -2.8f){
                    PlayerController.instance.playerSpr.sortingOrder = -2;
                    iTween.MoveTo(player, iTween.Hash("position", new Vector3(player.transform.position.x, -0.8f, 0), "time", 0.5f, "easeType", iTween.EaseType.linear));
            }
        }
        else if(direction == -1){
            if (player.transform.position.y == 0.8f){
                    PlayerController.instance.playerSpr.sortingOrder = -2;
                    iTween.MoveTo(player, iTween.Hash("position", new Vector3(player.transform.position.x, -0.8f, 0), "time", 0.5f, "easeType", iTween.EaseType.linear));
                }else if (player.transform.position.y == -0.8f){
                    PlayerController.instance.playerSpr.sortingOrder = -1;
                    iTween.MoveTo(player, iTween.Hash("position", new Vector3(player.transform.position.x, -2.8f, 0), "time", 0.5f, "easeType", iTween.EaseType.linear));
            }
        }
    }

    public void MoveInWebAndPC(){
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
                PlayerController.instance.playerAnim.Play("Move"+(PlayerController.instance.gunType+1).ToString());
                if (player.transform.position.y == -0.8f){
                    PlayerController.instance.playerSpr.sortingOrder = -3;
                    iTween.MoveTo(player, iTween.Hash("position", new Vector3(player.transform.position.x, 0.8f, 0), "time", 0.5f, "easeType", iTween.EaseType.linear));
                }else if (player.transform.position.y == -2.8f){
                    PlayerController.instance.playerSpr.sortingOrder = -2;
                    iTween.MoveTo(player, iTween.Hash("position", new Vector3(player.transform.position.x, -0.8f, 0), "time", 0.5f, "easeType", iTween.EaseType.linear));
            }
        }
            if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
                PlayerController.instance.playerAnim.Play("Move"+(PlayerController.instance.gunType+1).ToString());
                if (player.transform.position.y == 0.8f){
                    PlayerController.instance.playerSpr.sortingOrder = -2;
                    iTween.MoveTo(player, iTween.Hash("position", new Vector3(player.transform.position.x, -0.8f, 0), "time", 0.5f, "easeType", iTween.EaseType.linear));
                }else if (player.transform.position.y == -0.8f){
                    PlayerController.instance.playerSpr.sortingOrder = -1;
                    iTween.MoveTo(player, iTween.Hash("position", new Vector3(player.transform.position.x, -2.8f, 0), "time", 0.5f, "easeType", iTween.EaseType.linear));
            }
        }
    }
                

    public void Shoot(){
            if(fillToShoot.fillAmount == 1){
                PlayerController.instance.playerAnim.Play("Shoot"+(PlayerController.instance.gunType+1).ToString());
                fillToShoot.fillAmount = 0;
                startFill = true;
        }
    }
}
