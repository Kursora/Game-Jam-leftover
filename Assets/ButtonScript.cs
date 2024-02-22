using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject shop;
    public Text money;
    public void OpenShop()
    {
        shop.SetActive(true);
        money.text="Money: "+MainGame.instance.money+"$";
    }
    public void CloseShop()
    {
        shop.SetActive(false);
    }
    public void Playgame()
    {
        MainGame.instance.CallStart();
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
