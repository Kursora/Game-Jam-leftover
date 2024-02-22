using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGame : MonoBehaviour
{
    [SerializeField]private GameObject Title,notice,dist,velo,GameOverob;
    public Button playbutton;
    public static MainGame instance;
    public bool GameStart= false;
    public float maxspeed,minspeed,currentspeed,speedboost,dista=0f,targetboost=1f,distcop=1000f,copvelo=25f,remain=0f;
    public float spawntimemax=1.5f, spawntimemin=2.5f;
    public int money;
    void Awake()
    {
        instance=this;
        Application.targetFrameRate=60;
        //default setting
        maxspeed=0.8f;
        minspeed=0.4f;
        currentspeed=0.4f;
        speedboost=0.05f;
        //apply item from shop
        if(!PlayerPrefs.HasKey("PlayerFirst"))
        {
            PlayerPrefs.SetInt("BW",0);
            PlayerPrefs.SetInt("Gloves",0);
            PlayerPrefs.SetInt("ED",0);
            PlayerPrefs.SetInt("EC",0);
            PlayerPrefs.SetInt("HW",0);
            PlayerPrefs.SetInt("DS",0);
            PlayerPrefs.SetInt("Money",0);
            PlayerPrefs.SetInt("PlayerFirst",1);
            PlayerPrefs.Save();
        }
        maxspeed=0.8f;
        minspeed=0.4f;
        currentspeed=0.4f;
        speedboost=0.05f;
        money=PlayerPrefs.GetInt("Money",0);
        distcop=1000+(250*PlayerPrefs.GetInt("DS",0));
        maxspeed=1*PlayerPrefs.GetInt("BW",0);
    }
    void Update()
    {
        if(GameStart)
        {
            dista+=currentspeed*Time.deltaTime;
            remain+=copvelo*Time.deltaTime;
            dist.GetComponent<Text>().text="Distance:"+ dista.ToString("0.00")+"m\nDistance from cop:"+(dista+distcop-remain).ToString("0.00")+"m";
            velo.GetComponent<Text>().text="Velocity:"+ currentspeed.ToString("0.00")+"m/s";
            
        }
        if(currentspeed<minspeed)
            currentspeed=minspeed;
        if(Input.GetKeyDown(KeyCode.UpArrow) && currentspeed<=(maxspeed-speedboost))
        {
            currentspeed+=speedboost*(PlayerPrefs.GetInt("Gloves",0)+1);
        }
        else
        {
            if(currentspeed>minspeed)
                currentspeed-=(speedboost*Time.deltaTime*2);
        }
        if(distcop+dista<=remain)
        {
            GameOver();
            remain=0f;
        }
    }
    public void CallStart()
    {
            Title.SetActive(false);
            StartCoroutine(getready());
    }
    public void GameOver()
    {
        GameStart=false;
        GameOverob.SetActive(true);
        money+=(int)Mathf.Round(dista);
        PlayerPrefs.SetInt("Money",money);
        PlayerPrefs.Save();
    }
    IEnumerator getready()
    {
        for(float i=3;i>0;i-=Time.deltaTime)
        {
            notice.GetComponent<Text>().text="Get ready!  " +i.ToString("#");
            yield return null;
        }
        GameStart=true;
        notice.gameObject.SetActive(false);
        dist.SetActive(true);
        velo.SetActive(true);
    }
}
