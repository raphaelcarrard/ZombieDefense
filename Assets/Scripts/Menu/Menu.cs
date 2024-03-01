using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void startGame(GameObject setFalse) {
            NGHelper.instance.unlockMedal(70390);
            SceneManager.LoadScene("Game");        
    }

    void Update(){
        if(Input.GetKey(KeyCode.Return)){
            NGHelper.instance.unlockMedal(70390);
            SceneManager.LoadScene("Game");
        }
    }

    public void ExitGame(){
        Application.Quit();
    }
}
