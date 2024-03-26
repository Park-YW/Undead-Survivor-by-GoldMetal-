using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("#gamecontrol")]
    public float gameTime = 0;
    public float maxGameTime = 10f;

    [Header("#playerinfo")]
    public int health;
    public int maxHealth = 100;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = {3, 5, 10, 30, 60, 100, 150, 200};

    [Header("#gameobject")]
    public Player player;
    public PoolManager pool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
        
    }

    public void GetExp()
    {
        exp++;

        if (exp==nextExp[level])
        {
            level++;
            exp=0;
        }
    }
}
