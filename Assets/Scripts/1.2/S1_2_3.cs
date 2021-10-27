using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class S1_2_3 : MonoBehaviour
{
    public Bag playerBag;
    public Button left, right;
    public Button rodBtn;

    public GameObject rod;
    public Item rodItem;
    // Start is called before the first frame update
    void Start()
    {
        left.onClick.AddListener(l);
        right.onClick.AddListener(r);

        rodBtn.onClick.AddListener(rodOnClicked);

        if(Begin.rodPicked)
        {
            rod.SetActive(false);
            rodBtn.enabled = false;
        }

        BagManager.RefreshItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void rodOnClicked()
    {
        rod.SetActive(false);
        rodBtn.enabled = false;
        AddNewItem(rodItem);
        Begin.rodPicked = true;
    }

    void l()
    {
        SceneManager.LoadScene("1.2-2");
    }

    void r()
    {
        SceneManager.LoadScene("1.2-4");
    }

    public void AddNewItem(Item thisItem)
    {
        if (!playerBag.itemList.Contains(thisItem))
        {
            playerBag.itemList.Add(thisItem);
            thisItem.itemHeld = 1;
        }
        else
        {
            thisItem.itemHeld += 1;
        }

        BagManager.RefreshItem();
    }

    public void RemoveItem(Item thisItem)
    {
        if(playerBag.itemList.Contains(thisItem))
        {
            playerBag.itemList.Remove(thisItem);
        }
        BagManager.RefreshItem();
    }
}
