using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadShop : MonoBehaviour
{
    private void OnEnable() {
        GameManager.instance.LoadShop();
    }
}
