using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public string rootName;
    public int bulletsAmount;
    public GameObject prefabBullet;
    List<GameObject> bullets = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateBulletList();
    }

    private void CreateBulletList()
    {
        GameObject Root = new GameObject();
        Root.name = rootName;

        if (prefabBullet == null)
        {
            print("you did not assign any prefab bullet.");
            return;
        }

        for (int i = 0; i < bulletsAmount; i++)
        {
            GameObject obj = Instantiate(prefabBullet);
            obj.transform.parent = Root.transform;
            obj.SetActive(false);
            bullets.Add(obj);
        }
    }

    public void CallBullet()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                bullets[i].transform.position = transform.position;
                bullets[i].SetActive(true);
                break;
            }
        }
    }
}
