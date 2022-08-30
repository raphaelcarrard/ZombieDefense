using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUpgrade : MonoBehaviour
{
    private void OnEnable() {
        GameManager.instance.LoadUpgrade();       
    }
}
