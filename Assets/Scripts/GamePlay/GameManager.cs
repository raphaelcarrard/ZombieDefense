using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Level{
    public int totalZb1;
    public int totalZb2;
    public int totalZb3;
    public int totalZb4;
}
[System.Serializable]
public class EnemyAttack{
    public float enemyAttack;
}
[System.Serializable]
public class EarnMoney{
    public int moneyLevel0;
    public int moneyLevel1;
    public int moneyLevel2;
    public int moneyLevel3;
    public int moneyLevel4;
}
[System.Serializable]
public class IncreaseDefense{
    public int boxPower;
}
public class GameManager : MonoBehaviour
{

    public io.newgrounds.core ngio_core;

    public static GameManager instance;
    public Level[] level = new Level[15];
    public EnemyAttack[] enemyDam = new EnemyAttack[4];
    public EarnMoney[] moneyGot = new EarnMoney[4];
    public IncreaseDefense[] boxpower = new IncreaseDefense[4];
    public Sprite[] gunIconSpr;
    public Image gunIcon;
    public Text zombieCountTxt;
    public GameObject btnLeft, btnRight;
    public int zombieCount;
    public Text collectedMoney;
    public Text totalKill;
    public Text daySurvival;
    public GameObject winMenu,loseMenu;

    [Header("Shop")]
    public Image[] buttonShop;
    public GameObject[] shopOption;

    [Header("Upgrade")]
    public Sprite[] status;
    public Image[] gunStatus;
    public Image[] upgradeStatus;
    public Image[] increaseStatus;
    public Text upgradePriceShop, upgradePrice, increasePrice;
    public GameObject button1, button2;
    private int priceUp, priceIn;
    public Image gunIconShop, upgradeIcon, increaseIcon;
    public Sprite[] upgradeIconSpr;
    public Sprite[] increaseIconSpr;

    [Header("Box Sprite")]
    public Sprite box1;
    public Sprite[] box2;
    public Sprite[] box3;
    public Sprite[] box4;

    [Header("Day Notifice")]
    public Text day;
    public GameObject dayNotice;

    [Header("Money Earned")]
    public GameObject Earn;
    public Text moneyEarn;

    [Header("Medals for Newgrounds")]
    public Image medal1, medal2, medal3, medal4;

    private bool isGamePause;
    void NoticeDone(){
        dayNotice.SetActive(false);
    }

    void Start() {
        if(PlayerPrefs.GetInt("totalkill") >= 100){
            unlockMedal(70391);
            medal1.enabled = false;
        }
        if(PlayerPrefs.GetInt("totalgun") >= 3){
            unlockMedal(70392);
            medal2.enabled = false;
        }
        if(PlayerPrefs.GetInt("money") >= 30000){
            unlockMedal(70393);
            medal3.enabled = false;
        }
        if(PlayerPrefs.GetInt("day") >= 15){
            unlockMedal(70394);
            medal4.enabled = false;
        }    
    }
    
    private void Awake(){
        day.text = PlayerPrefs.GetInt("day").ToString();
        iTween.ScaleTo(dayNotice, iTween.Hash("scale", new Vector3(1, 1, 1), "time", 1f, "easeType", iTween.EaseType.easeOutBounce,"oncomplete", "NoticeDone"));
        instance = this;
        if(PlayerPrefs.GetInt("totalgun") == 0){
            btnLeft.SetActive(false);
            btnRight.SetActive(false);
        }
        else 
        {
            btnLeft.SetActive(false);
            btnRight.SetActive(true);
        }
        for (int i = 0; i < level.Length; i++){
            if(PlayerPrefs.GetInt("day") == i){
                zombieCount = level[i].totalZb1+level[i].totalZb2+level[i].totalZb3+level[i].totalZb4;
            }
        }
        SetZbCount(zombieCount);
        SetMoney(PlayerPrefs.GetInt("money"));
        SetTotalKill(PlayerPrefs.GetInt("totalkill"));
        buttonShop[0].color = new Color32(255, 255, 255, 255);
        shopOption[0].SetActive(true);
        for(int i = 1; i < buttonShop.Length; i++){
            buttonShop[i].color = new Color32(255, 255, 255, 255);
            shopOption[i].SetActive(false);
        }
    }

    void Update(){
            if(Input.GetKeyDown(KeyCode.A)){
            if(PlayerController.instance.gunType == 0){
                btnLeft.SetActive(false);
            }else if(PlayerController.instance.gunType >= 1){
                ChangeGunLeft();
            }
            }
            if(Input.GetKeyDown(KeyCode.D)){
            if(PlayerController.instance.gunType == 3){
                btnRight.SetActive(false);
            }else if(PlayerController.instance.gunType <= 2){
                ChangeGunRight();
            }
        }
    }

    void unlockMedal(int medal_id) {
        io.newgrounds.components.Medal.unlock medal_unlock = new io.newgrounds.components.Medal.unlock();
        medal_unlock.id = medal_id;
        medal_unlock.callWith(ngio_core, onMedalUnlocked);
    }

    void onMedalUnlocked(io.newgrounds.results.Medal.unlock result) {
        io.newgrounds.objects.medal medal = result.medal;
        Debug.Log( "Medal Unlocked: " + medal.name + " (" + medal.value + " points)" );
    }

    public void ChangeGunRight(){
        if(PlayerInput.startFill){
            PlayerInput.startFill = false;
        }
        if(PlayerController.instance.gunType < PlayerPrefs.GetInt("totalgun")){
                PlayerController.instance.gunType += 1;
                if(PlayerController.instance.gunType == PlayerPrefs.GetInt("totalgun")){
                    btnRight.SetActive(false);
                }
                PlayerController.instance.playerAnim.Play("Idle" + (PlayerController.instance.gunType + 1).ToString());
                gunIcon.sprite = gunIconSpr[PlayerController.instance.gunType];
                btnLeft.SetActive(true);
        }
    }

    public void ChangeGunLeft(){
	  if(PlayerInput.startFill){
            PlayerInput.startFill = false;
        }
        PlayerController.instance.gunType -= 1;
	  PlayerController.instance.playerAnim.Play("Idle" + (PlayerController.instance.gunType + 1).ToString());
	  gunIcon.sprite = gunIconSpr[PlayerController.instance.gunType];	
	    if(!btnRight.activeInHierarchy){
             btnRight.SetActive(true);
          }
	    if(PlayerController.instance.gunType == 0){
              btnLeft.SetActive(false);
	    }
    }

    public void SetZbCount(int value){
        zombieCountTxt.text = value.ToString()+" *";
    }

    public void SetMoney(int value){
        collectedMoney.text = "+  "+value.ToString();
    }

    public void SetTotalKill(int value){
        totalKill.text = "-  " + value.ToString();
    }
    public void SetDaySurvival(int value){
        daySurvival.text = value.ToString();
    }

    [Header("Pause")]
    public GameObject pauseMenu;
    public void PauseGame(int index){
        if(index == 0){
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else if(index == 1){
            Time.timeScale = 1;
            MusicPlayer.instance.DestroyGameObject();
            SceneManager.LoadScene("Menu");
        }
        else if(index == 2){
            Time.timeScale = 1;
            Application.LoadLevel(Application.loadedLevel);
        }
        else if(index == 3){
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        else if(index == 4){
            isGamePause = true;
            pauseMenu.SetActive(false);
            winMenu.SetActive(true);
        }
    }

    public GameObject gameOverPanel;
    public void GameOver(int index){
        if(index == 0){
            Time.timeScale = 1;
            MusicPlayer.instance.DestroyGameObject();
            SceneManager.LoadScene("Menu");
        }
        else if(index == 1){
            Time.timeScale = 1;
            Application.LoadLevel(Application.loadedLevel);
        }
        else if(index == 2){
            gameOverPanel.SetActive(false);
            winMenu.SetActive(true);
        }
    }

    public void NextLevel(){
        if(!isGamePause){
            Time.timeScale = 1;
            Application.LoadLevel(Application.loadedLevel);
        }
        else 
        {
            Time.timeScale = 1;
            winMenu.SetActive(false);
            LoadUpgrade();
        }
    }

    public void ShopFunction(int index){
        for(int i = 0; i< buttonShop.Length; i++){
            if(i == index){
                buttonShop[i].color = new Color32(255, 255, 255, 255);
                shopOption[i].SetActive(true);
            }
            else 
            {
                buttonShop[i].color = new Color32(255, 255, 255, 100);
                shopOption[i].SetActive(false);
            }
        }
    }

    private int gunValue;
    public GameObject buyBtn;

    public void LoadShop()
    {
	for (int i = 1; i <= gunStatus.Length; i++)
        {
            if (PlayerPrefs.GetInt("totalgun") == i)
            {
                for (int j = 0; j < i; j++)
                {
                    gunStatus[j].sprite = status[0];
                }
                for (int k = i; k < gunStatus.Length; k++)
                {
                    gunStatus[k].sprite = status[1];
                }
            }
        }
        	switch(PlayerPrefs.GetInt("totalgun"))
                {
                    case 0:
                            gunValue = 3000;
                            upgradePriceShop.text = "Get Rifle for $" + gunValue.ToString();
                            break;
                    case 1:
                            gunValue = 8000;
                            upgradePriceShop.text = "Get Shotgun for $" + gunValue.ToString();
                            break;
                    case 2:
                            gunValue = 30000;
                            upgradePriceShop.text = "Get Super Weapon for $" + gunValue.ToString();
                            break;
                }
                if(PlayerPrefs.GetInt("totalgun") == 3){
                    buyBtn.SetActive(false);
                    upgradePriceShop.gameObject.SetActive(false);
                }
                if (PlayerPrefs.GetInt("totalgun") >= 1)
                {
                    gunIcon.sprite = gunIconSpr[PlayerPrefs.GetInt("totalgun") - 1];
                }
    }


    public GameObject noMoney;
    public void NoMoney(){
        noMoney.SetActive(false);
    }

    public GameObject noSkull;
    public void NoSkull(){
        noSkull.SetActive(false);
    }

    public void BuyGun(){
            if(PlayerPrefs.GetInt("money") >= gunValue){
                PlayerPrefs.SetInt("totalgun", PlayerPrefs.GetInt("totalgun") + 1);
                gunStatus[PlayerPrefs.GetInt("totalgun") - 1].sprite = status[0];
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - gunValue);
                SetMoney(PlayerPrefs.GetInt("money"));
                LoadShop();
            }
            else
            {
                noMoney.SetActive(true);
            }
    }

    public void LoadUpgrade(){
        for (int i = 1; i <= upgradeStatus.Length; i++){
            if(PlayerPrefs.GetInt("upgrade") == i){
                for(int j = 0; j < i; j++){
                    upgradeStatus[j].sprite = status[0];
                }
                for(int k = i; k < upgradeStatus.Length; k++){
                    upgradeStatus[k].sprite = status[1];
                }
            }
        }

        for (int i = 1; i <= increaseStatus.Length; i++){
            if(PlayerPrefs.GetInt("increase") == i){
                for(int j = 0; j < i; j++){
                    increaseStatus[j].sprite = status[0];
                }
                for(int k = i; k < upgradeStatus.Length; k++){
                    increaseStatus[k].sprite = status[1];
                }
            }
        }

        switch(PlayerPrefs.GetInt("upgrade")){
            case 0:
                priceUp = 3;
                upgradePrice.text = "- " + priceUp.ToString();
                break;
            case 1:
                priceUp = 5;
                upgradePrice.text = "- " + priceUp.ToString();
                break;
            case 2:
                priceUp = 8;
                upgradePrice.text = "- " + priceUp.ToString();
                break;
            case 3:
                priceUp = 12;
                upgradePrice.text = "- " + priceUp.ToString();
                break;
        }

        switch(PlayerPrefs.GetInt("increase")){
            case 0:
                priceIn = 5;
                increasePrice.text = "- " + priceIn.ToString();
                break;
            case 1:
                priceIn = 8;
                increasePrice.text = "- " + priceIn.ToString();
                break;
            case 2:
                priceIn = 12;
                increasePrice.text = "- " + priceIn.ToString();
                break;
            case 3:
                priceIn = 16;
                increasePrice.text = "- " + priceIn.ToString();
                break;
        }

        if(PlayerPrefs.GetInt("upgrade") == 4){
            button1.SetActive(false);
            upgradePrice.gameObject.SetActive(false);
        }
        if(PlayerPrefs.GetInt("increase") == 4){
            button2.SetActive(false);
            increasePrice.gameObject.SetActive(false);
        }
        if(PlayerPrefs.GetInt("upgrade") >= 1){
            upgradeIcon.sprite = upgradeIconSpr[PlayerPrefs.GetInt("upgrade") - 1];
        }
        if(PlayerPrefs.GetInt("increase") >= 1){
            increaseIcon.sprite = increaseIconSpr[PlayerPrefs.GetInt("increase") - 1];
        }
    }

    public void Upgrade(int index){

        //Upgrade defense
        if(index == 0){
            if(PlayerPrefs.GetInt("totalkill") >= priceUp){
                PlayerPrefs.SetInt("upgrade", PlayerPrefs.GetInt("upgrade") + 1);
                upgradeStatus[PlayerPrefs.GetInt("upgrade") - 1].sprite = status[0];
                PlayerPrefs.SetInt("totalkill", PlayerPrefs.GetInt("totalkill") - priceUp);
                SetTotalKill(PlayerPrefs.GetInt("totalkill"));
                LoadUpgrade();
            }
            else 
            {
                noSkull.SetActive(true);
            }
        }
        //Increase earning
        else if(index == 1){
            if(PlayerPrefs.GetInt("totalkill") >= priceIn){
                PlayerPrefs.SetInt("increase", PlayerPrefs.GetInt("increase") + 1);
                increaseStatus[PlayerPrefs.GetInt("increase") - 1].sprite = status[0];
                PlayerPrefs.SetInt("totalkill", PlayerPrefs.GetInt("totalkill") - priceIn);
                SetTotalKill(PlayerPrefs.GetInt("totalkill"));
                LoadUpgrade();
            }
            else 
            {
                noSkull.SetActive(true);
            }
        }
    }
}
