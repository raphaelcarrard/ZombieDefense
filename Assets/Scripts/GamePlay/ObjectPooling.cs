using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour {
    public static ObjectPooling instance;

    public GameObject zombieObject, zombie2, zombie3, zombie4;
    public GameObject blood;

    public List<GameObject> pooledZombie, pooledZombie2, pooledZombie3, pooledZombie4;
    public List<GameObject> pooledBlood;


    public float yPos;
    private int zb1Count, zb2Count, zb3Count, zb4Count;

    private void Awake()
    {
        instance = this;

        for (int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate(zombieObject, transform.position, transform.rotation);
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            pooledZombie.Add(obj);
        }
        for (int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate(zombie2, transform.position, transform.rotation);
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            pooledZombie2.Add(obj);
        }
        for (int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate(zombie3, transform.position, transform.rotation);
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            pooledZombie3.Add(obj);
        }
        for (int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate(zombie4, transform.position, transform.rotation);
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            pooledZombie4.Add(obj);
        }
        for (int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate(blood, transform.position, transform.rotation);
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            pooledBlood.Add(obj);
        }
        zb1Count = 0;
        zb2Count = 0;
        zb3Count = 0;
        zb4Count = 0;
    }

    private void Start()
    {
        InvokeRepeating("GenZoombie", 0, 7f);
        InvokeRepeating("GenZoombie2", 3, 7f);
        InvokeRepeating("GenZoombie3", 6, 7);
        InvokeRepeating("GenZoombie4", 9, 7);
    }

    void GenZoombie()
    {
        zb1Count += 1;
        if (zb1Count <= GameManager.instance.level[PlayerPrefs.GetInt("day")].totalZb1)
        {
            GetZoombie().SetActive(true);
        }
        else
            CancelInvoke("GenZoombie");
        return;
    }
    void GenZoombie2()
    {
        zb2Count += 1;
        if (zb2Count <= GameManager.instance.level[PlayerPrefs.GetInt("day")].totalZb2)
        {
            GetZoomBie2().SetActive(true);
        }
        else
            CancelInvoke("GenZoombie2");
        return;
    }
    void GenZoombie3()
    {
        zb3Count += 1;
        if (zb2Count <= GameManager.instance.level[PlayerPrefs.GetInt("day")].totalZb3)
        {
            GetZoomBie3().SetActive(true);
        }
        else
            CancelInvoke("GenZoombie3");
        return;
    }
    void GenZoombie4()
    {
        zb4Count += 1;
        if (zb2Count <= GameManager.instance.level[PlayerPrefs.GetInt("day")].totalZb4)
        {
            GetZoomBie4().SetActive(true);
        }
        else
            CancelInvoke("GenZoombie4");
        return;
    }

    GameObject GetZoombie()
    {
        for (int i = 0; i < pooledZombie.Count; i++)
        {
            if (!pooledZombie[i].activeInHierarchy)
            {
                return pooledZombie[i];
            }
        }
        return null;
    }
    GameObject GetZoomBie2()
    {
        for (int i = 0; i < pooledZombie2.Count; i++)
        {
            if (!pooledZombie2[i].activeInHierarchy)
            {
                return pooledZombie2[i];
            }
        }
        return null;
    }
    GameObject GetZoomBie3()
    {
        for (int i = 0; i < pooledZombie3.Count; i++)
        {
            if (!pooledZombie3[i].activeInHierarchy)
            {
                return pooledZombie3[i];
            }
        }
        return null;
    }
    GameObject GetZoomBie4()
    {
        for (int i = 0; i < pooledZombie4.Count; i++)
        {
            if (!pooledZombie4[i].activeInHierarchy)
            {
                return pooledZombie4[i];
            }
        }
        return null;
    }

    public GameObject GetBlood()
    {
        for (int i = 0; i < pooledBlood.Count; i++)
        {
            if (!pooledBlood[i].activeInHierarchy)
            {
                return pooledBlood[i];
            }
        }
        return null;
    }
}
