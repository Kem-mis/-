using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class S1_2_6 : MonoBehaviour
{
    Sequence s;
    public Bag playerBag;
    public Button back;
    public Button sculpBtn;
    public Button bettyBtn;
    public Button downBtn;
    public Button hang1Btn, hang2Btn;
    public GameObject light1,light2;
    public GameObject betty1;
    public GameObject image;
    public GameObject m1, m2, m3, m4;
    public GameObject aniha;
    public Item sculpItem, hammer;
    // Start is called before the first frame update
    void Start()
    {
        s = DOTween.Sequence();
        back.onClick.AddListener(b);
        sculpBtn.onClick.AddListener(sculpOnClicked);
        downBtn.onClick.AddListener(mOnClicked);
        hang1Btn.onClick.AddListener(hang1OnClicked);
        hang2Btn.onClick.AddListener(hang2OnClicked);

        if(Begin.sculpPicked)
        {
            image.SetActive(false);
            m1.SetActive(true);
            sculpBtn.enabled = false;
        }
        if(Begin.machineClicked)
        {
            m1.SetActive(false);
            m4.SetActive(true);
            betty1.SetActive(true);
            downBtn.enabled = false;
            back.enabled = false;
        }
        if(Begin.hang1Clicked)
        {
            light1.SetActive(true);
            hang1Btn.enabled = false;
        }
        if(Begin.hang2Clicked)
        {
            // hang2.SetActive(false);
            // hang22.SetActive(true);
            light2.SetActive(true);
            hang2Btn.enabled = false;
        }
        // if(Begin.hang1Clicked && Begin.hang2Clicked)
        // {
        //     betty1.SetActive(true);
        //     //betty2.SetActive(true);
        //     //grey.SetActive(true);
        // }

        BagManager.RefreshItem();
    }

    void hang1OnClicked()
    {
        // hang1.SetActive(false);
        // hang11.SetActive(true);
        light1.SetActive(true);
        hang1Btn.enabled = false;
        Begin.hang1Clicked = true;
        // if(Begin.hang2Clicked)
        // {
        //     betty1.SetActive(true);
        //     //betty2.SetActive(true);
        //     //grey.SetActive(true);
        // }
    }

    void hang2OnClicked()
    {
        // hang2.SetActive(false);
        // hang22.SetActive(true);
        light2.SetActive(true);
        hang2Btn.enabled = false;
        Begin.hang2Clicked = true;
        // if(Begin.hang1Clicked)
        // {
        //     betty1.SetActive(true);
        //     //betty2.SetActive(true);
        //     //grey.SetActive(true);
        // }
    }

    void mOnClicked()
    {
        if(Begin.sculpPicked && Begin.hang1Clicked && Begin.hang2Clicked)
        {
            StartCoroutine(machine());
            back.enabled = false;
        }
    }

    IEnumerator machine()
    {
        downBtn.enabled = false;
        Begin.machineClicked = true;  
        RemoveItem(sculpItem);     
        m1.SetActive(false);
        m2.SetActive(true);
        betty1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        m2.SetActive(false);
        m3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        m3.SetActive(false);
        m4.SetActive(true);
        yield return new WaitForSeconds(0.5f);
    }

    void sculpOnClicked()
    {
        if(playerBag.itemList.Contains(hammer))
        {
            Begin.sculpPicked = true;
            image.SetActive(false);
            aniha.SetActive(true);
            StartCoroutine(ania());
            m1.SetActive(true);
            sculpBtn.enabled = false;
            AddNewItem(sculpItem);
        }
    }

    IEnumerator ania()
    {
        s.Append(aniha.transform.DOMove(new Vector3(aniha.transform.position.x + 1f, aniha.transform.position.y, 0f), 0.5f));
        s.Join(aniha.transform.DORotate(new Vector3(0, 0, 180), 0.5f));
        yield return new WaitForSeconds(0.5f);
        s.Append(aniha.transform.DORotate(new Vector3(0, 0, 60), 0.5f));
        yield return new WaitForSeconds(0.25f);
        aniha.SetActive(false);
    }

        void b()
    {
        SceneManager.LoadScene("1.2-5");
    }

    // Update is called once per frame
    void Update()
    {
        
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
