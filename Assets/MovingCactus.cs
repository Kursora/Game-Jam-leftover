using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCactus : MonoBehaviour
{
    [SerializeField]private Sprite[] cactusskin;
    void Awake()
    {
        int i=Random.Range(0,2);
        gameObject.GetComponent<SpriteRenderer>().sprite=cactusskin[i];
    }
    void Update()
    {
        transform.Translate(new Vector3(-0.05f*(MainGame.instance.currentspeed/0.4f),0f,0f));   
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
