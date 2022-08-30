using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public io.newgrounds.core ngio_core;

    void onMedalUnlocked(io.newgrounds.results.Medal.unlock result) {
		io.newgrounds.objects.medal medal = result.medal;
		Debug.Log( "Medal Unlocked: " + medal.name + " (" + medal.value + " points)" );
	}

    void unlockMedal(int medal_id) {
        io.newgrounds.components.Medal.unlock medal_unlock = new io.newgrounds.components.Medal.unlock();
        medal_unlock.id = medal_id;
        medal_unlock.callWith(ngio_core, onMedalUnlocked);
    }


    public void startGame(GameObject setFalse) {
            SceneManager.LoadScene("Game");        
    }

    void Update(){
        if(Input.GetKey(KeyCode.Return)){
            unlockMedal(70390);
            SceneManager.LoadScene("Game");
        }
    }
}
