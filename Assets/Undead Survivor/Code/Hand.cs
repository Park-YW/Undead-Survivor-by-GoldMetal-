using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool isLeft;
    public SpriteRenderer spriter;

    SpriteRenderer player;

    Vector3 rightPos = new Vector3(0.35f, -0.15f, 0);
    Vector3 rightPosReverse = new Vector3(-0.15f, -0.15f, 0);
    Quaternion leftRot = Quaternion.Euler(0, 0, -35);
    Quaternion leftRotInverse = Quaternion.Euler(0, 0, -135);
    void Awake()
    {
        player = GetComponentsInParent<SpriteRenderer>()[1];
    }

    void LateUpdate()
    {
        bool isRevesre = player.flipX;
        if(isLeft)
        {
            transform.localRotation = isRevesre ? leftRotInverse : leftRot;
            spriter.flipY = isRevesre;
            spriter.sortingOrder = isRevesre ? 4 : 6;
        }
        else{
            transform.localPosition = isRevesre ? rightPosReverse : rightPos;
            spriter.flipX = isRevesre;
            spriter.sortingOrder = isRevesre ? 6 : 4;
        }

    }
}
