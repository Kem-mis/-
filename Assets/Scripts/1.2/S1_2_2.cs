using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class S1_2_2 : MonoBehaviour
{
    Sequence s;
    public Bag playerBag;
    public Button left, right;
    public Button posterBtn;
    public Button cloth2Btn;

    public GameObject poster;
    public GameObject clothes, nocloth, cloth2;
    // Start is called before the first frame update
    void Start()
    {
        s = DOTween.Sequence();
        left.onClick.AddListener(l);
        right.onClick.AddListener(r);

        posterBtn.onClick.AddListener(posterOnClicked);
        cloth2Btn.onClick.AddListener(colth2OnClicked);

        if(Begin.cloth2Picked)
        {
            clothes.SetActive(false);
            nocloth.SetActive(true);
            cloth2Btn.enabled = false;
        }

        BagManager.RefreshItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void colth2OnClicked()
    {
        if(clothes.activeSelf)
        {
            cloth2Btn.enabled = false;
            StartCoroutine(showCloth());
        }
    }

    IEnumerator showCloth()
    {
        cloth2.SetActive(true);
        yield return new WaitForSeconds(1f);
        nocloth.SetActive(true);
        clothes.SetActive(false);
        cloth2.SetActive(false);
        Begin.cloth2Picked = true;
        yield return new WaitForSeconds(1f);
    }

    void posterOnClicked()
    {
        StartCoroutine(showPoster());
    }

    IEnumerator showPoster()
    {
        s.Append(poster.transform.DOScale(new Vector3(2f, 2f, 2f), 1));
        s.Join(poster.transform.DOMove(new Vector3(poster.transform.position.x, poster.transform.position.y - 3f, 0f), 1));
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(1f);
        s.Append(poster.transform.DOScale(new Vector3(1f, 1f, 1f), 1));
        s.Join(poster.transform.DOMove(new Vector3(poster.transform.position.x, poster.transform.position.y + 3f, 0f), 1));
        yield return new WaitForSeconds(1f);
    }

    void l()
    {
        SceneManager.LoadScene("1.2-1");
    }

    void r()
    {
        SceneManager.LoadScene("1.2-3");
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
