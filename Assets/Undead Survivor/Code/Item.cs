using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemData data;
    public int level;
    public Weapon weapon;
    public Gear gear;

    Image icon;
    Text textlevel;

    void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1];
        icon.sprite = data.itemIcon;

        Text[] texts = GetComponentsInChildren<Text>();
        textlevel = texts[0];
        
    }

    void LateUpdate()
    {
        textlevel.text = "LV." + level;
    }

    public void OnClick()
    {
        
        switch(data.itemType)
        {
            
            case ItemData.ItemType.Melee:
            case ItemData.ItemType.Range:
                if(level == 0)
                {
                    GameObject newWeapon = new GameObject();
                    weapon = newWeapon.AddComponent<Weapon>();
                    weapon.Init(data);
                }
                else
                {
                    float nextDamage = data.baseDamage;
                    int nextCount = data.baseCount;
                    
                    nextDamage += data.baseDamage * data.damages[level];    
                    nextCount += data.counts[level];
                    
                    weapon.LevelUp(nextDamage, nextCount);
                                
                }
                level++;
                break;
            case ItemData.ItemType.Heal:
                GameManager.instance.health = GameManager.instance.maxHealth;
                break;
            case ItemData.ItemType.Shoe:
            case ItemData.ItemType.Glove:
                if (level == 0)
                {
                    
                    GameObject newGear = new GameObject();
                    gear = newGear.AddComponent<Gear>();
                    gear.Init(data);
                }
                else
                {
                    float nextRate = data.damages[level];
                    gear.LevelUp(nextRate);
                }
                level++;
                break;
        }

        
        if (level == data.damages.Length){
            GetComponent<Button>().interactable =false;
        }
    }
}
