using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScr : MonoBehaviour
{
    public Slider forshow;
    public string upgrade;
    public Text moneyTag;
    void Update()
    {
        forshow.value=0.125f*PlayerPrefs.GetInt(upgrade,0);
        moneyTag.text=""+100*(2*(PlayerPrefs.GetInt(upgrade,0)+1))+"$";
    }
    public void Clicked()
    {
        if(MainGame.instance.money>=(100*(2*(PlayerPrefs.GetInt(upgrade,0)+1))) && PlayerPrefs.GetInt(upgrade,0)<8)
        {
            int lol=PlayerPrefs.GetInt(upgrade,0);
            MainGame.instance.money-=100*(2*(PlayerPrefs.GetInt(upgrade,0)+1));
            PlayerPrefs.SetInt(upgrade,lol+1);
            PlayerPrefs.SetInt("Money",MainGame.instance.money);
            PlayerPrefs.Save();
        }
    }
}
