using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShop : MonoBehaviour
{
    public GameObject Shop;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowingShop()
    {
        Shop.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosingShop()
    {
        Shop.SetActive(false);
        Time.timeScale = 1;
    }
}
