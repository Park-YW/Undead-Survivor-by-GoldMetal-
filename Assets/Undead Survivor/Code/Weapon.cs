using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefebId;
    public float damage;
    public int count;
    public float speed;

    void Start()
    {
        Init();
    }


    void Update()
    {
        switch(id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
            break;
            default:
            break;
        }

        //test
        if (Input.GetButtonDown("Jump"))
        {
            LevelUp(20, 20);
        }
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count = count;
        if (id == 0)
        {
            Positioning();
        }
    }

    public void Init()
    {
        switch(id)
        {
            case 0:
                speed = -150;
                Positioning();
            break;
            default:
            break;
        }
    }

    void Positioning()
    {
        for (int index = 0; index < count; ++index)
        {
            Transform bullet;
            if (index < transform.childCount)
            {
                bullet = transform.GetChild(index);
            }
            else{
                bullet = GameManager.instance.pool.Get(prefebId).transform;
                bullet.parent = transform;
            }
            
            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Bullet>().Init(damage, -1); //-1은 무한관통

        }
    }
}
