using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll2 : MonoBehaviour
{
    [SerializeField] private RawImage pic;
    [SerializeField] private float x,y;
    void Update()
    {
        if(MainGame.instance.GameStart)
        {
            x=MainGame.instance.currentspeed/100f;
            pic.uvRect = new Rect(pic.uvRect.position + new Vector2(x,y) * Time.deltaTime,pic.uvRect.size);
        }
    }
}
