using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheelchair : MonoBehaviour
{
    //[SerializeField]
    public Rigidbody2D rb;
    void Update()
    {
        if(MainGame.instance.GameStart)
        {
            StartCoroutine(initiate());
        }
        if(Mathf.Round(rb.position.y) == -2)
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * 50, ForceMode2D.Impulse);
            }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag== "Dead")
        {
            MainGame.instance.GameOver();
        }
    }
    IEnumerator initiate()
    {
        while(transform.position.x<-6.5f)
        {
            transform.Translate(new Vector3(0.1f,0f,0f));
            yield return new WaitForSeconds(0.5f);
        }
    }
}
