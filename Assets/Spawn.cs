using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float timecount=0f,spawnTime=3f,bettime;
    public GameObject cactus;
    void Start()
    {
        bettime = Random.Range(MainGame.instance.spawntimemax,MainGame.instance.spawntimemin);
    }
    void Update()
    {
        if(MainGame.instance.GameStart)
        {
            timecount+=Time.deltaTime;
            if(timecount> spawnTime)
            {
                Spawning();
                spawnTime += timecount + bettime;
            }
        }
    }
    void Spawning()
    {
        Instantiate(cactus,transform.position,transform.rotation);
    }
}
