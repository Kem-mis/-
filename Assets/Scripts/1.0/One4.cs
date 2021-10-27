using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class One4 : MonoBehaviour
{
    Sequence s;
    public Bag playerBag;
    public Button left, right;
    public Button hatBtn;
    public Button mirrorBtn;
    public GameObject hat, hatBlue, anilip;
    public GameObject person, mirror1, mirror2;
    public Button diahatBtn;

    public Item lipstickItem;

    
    public GameObject[] diaryPage = new GameObject[6];
    public GameObject[] notePage = new GameObject[5];
    public GameObject close;
    private Button closeBtn;
    private int diaryPageNum, notePageNum;
    public Button nextDiaryBtn, prevDiaryBtn;

    // Start is called before the first frame update
    void Start()
    {
        closeBtn = close.GetComponent<Button>();
        close.SetActive(false);
        closeBtn.enabled = false;
        closeBtn.onClick.AddListener(closeOnClicked);

        s = DOTween.Sequence();
        left.onClick.AddListener(l);
        right.onClick.AddListener(r);
        hatBtn.onClick.AddListener(hatOnClicked);
        mirrorBtn.onClick.AddListener(mirrorOnClicked);

        if (Begin.lipstickPicked)
        {
            Destroy(diahatBtn.gameObject);
        }

        if (Begin.hatPainted)
        {
            hat.SetActive(false);
            hatBlue.SetActive(true);
            hatBtn.enabled = false;
        }
        if(Begin.hatPicked) {
            hatBlue.SetActive(false);
        }
        if(Begin.hatPicked && Begin.dressPicked && Begin.shoe1Picked && Begin.shoe2Picked 
           && Begin.perfumePicked && Begin.diaryPicked && Begin.diary2Picked)
        {
            StartCoroutine(mirrorChange());
        }

        nextDiaryBtn.onClick.AddListener(nextDiaryOnClicked);
        prevDiaryBtn.onClick.AddListener(prevDiaryOnClicked);

        for(int i = 0; i < 6; i ++) {
            diaryPage[i].SetActive(false);
        }
        for(int i = 0; i < 5; i ++) {
            notePage[i].SetActive(false);
        }

        Begin.readNote = false;
        Begin.readDiary = false;
        Begin.readingDiary = false;
        Begin.readingNote = false;

        nextDiaryBtn.enabled = false;
        prevDiaryBtn.enabled = false;
        
        if(Begin.hatPicked && Begin.dressPicked && Begin.shoe1Picked && Begin.shoe2Picked 
           && Begin.perfumePicked && Begin.diaryPicked && Begin.diary2Picked)
        {
            StartCoroutine(mirrorChange());
        }
    }

    IEnumerator mirrorChange()
    {
        person.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        mirror1.SetActive(false);
        mirror2.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        mirror1.SetActive(true);
        mirror2.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        mirror1.SetActive(false);
        mirror2.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        mirror1.SetActive(true);
        mirror2.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        mirror1.SetActive(false);
        mirror2.SetActive(true);
        yield return new WaitForSeconds(0.2f);
    }

    IEnumerator anilipstick()
    {
        s.Append(anilip.transform.DORotate(new Vector3(0, 0, -20), 0.3f));
        yield return new WaitForSeconds(0.3f);
        s.Append(anilip.transform.DOMove(new Vector3(anilip.transform.position.x + 0.3f, anilip.transform.position.y - 0.3f, 0f), 0.2f));
        yield return new WaitForSeconds(0.2f);
        s.Append(anilip.transform.DOMove(new Vector3(anilip.transform.position.x - 0.3f, anilip.transform.position.y - 0.3f, 0f), 0.2f));
        yield return new WaitForSeconds(0.2f);
        s.Append(anilip.transform.DOMove(new Vector3(anilip.transform.position.x + 0.3f, anilip.transform.position.y - 0.3f, 0f), 0.2f));
        yield return new WaitForSeconds(0.2f);
        anilip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Begin.readNote == true) {
            Begin.readNote = false;
            Begin.readingNote = true;
            notePage[0].SetActive(true);
            notePageNum = 0;
            nextDiaryBtn.enabled = true;
            prevDiaryBtn.enabled = false;
            close.SetActive(true);
            closeBtn.enabled = true;
        }

        if(Begin.readDiary == true) {
            Begin.readingDiary = true;
            Begin.readDiary = false;
            diaryPage[0].SetActive(true);
            diaryPageNum = 0;
            nextDiaryBtn.enabled = true;
            prevDiaryBtn.enabled = false;
            close.SetActive(true);
            closeBtn.enabled = true;
        }
    }

    void nextDiaryOnClicked() {
        if(Begin.readingDiary && diaryPageNum < 5) {
            diaryPageNum ++;
            diaryPage[diaryPageNum].SetActive(true);
            diaryPage[diaryPageNum - 1].SetActive(false);
            if(diaryPageNum == 5) {
                nextDiaryBtn.enabled = false;
            }
            else if(diaryPageNum == 1) {
                prevDiaryBtn.enabled = true;
            }
        }
        else if(Begin.readingNote && notePageNum < 4) {
            notePageNum ++;
            notePage[notePageNum].SetActive(true);
            notePage[notePageNum - 1].SetActive(false);
            if(notePageNum == 4) {
                nextDiaryBtn.enabled = false;
            }
            else if(notePageNum == 1) {
                prevDiaryBtn.enabled = true;
            }
        }
    }

    void prevDiaryOnClicked() {
        if(Begin.readingDiary && diaryPageNum > 0) {
            diaryPageNum --;
            diaryPage[diaryPageNum].SetActive(true);
            diaryPage[diaryPageNum + 1].SetActive(false);
            if(diaryPageNum == 0) {
                prevDiaryBtn.enabled = false;
            }
            else if(diaryPageNum == 4) {
                nextDiaryBtn.enabled = true;
            }
        }
        else if(Begin.readingNote && notePageNum > 0) {
            notePageNum --;
            notePage[notePageNum].SetActive(true);
            notePage[notePageNum + 1].SetActive(false);
            if(notePageNum == 0) {
                prevDiaryBtn.enabled = false;
            }
            else if(notePageNum == 3) {
                nextDiaryBtn.enabled = true;
            }
        }
    }


    void mirrorOnClicked()
    {
        if(Begin.hatPicked && Begin.dressPicked && Begin.shoe1Picked && Begin.shoe2Picked 
           && Begin.perfumePicked && Begin.diaryPicked && Begin.diary2Picked)
        {
            SceneManager.LoadScene("1.1-1");
        }
    }

    void hatOnClicked()
    {
        if (hat.activeSelf && Begin.lipstickPicked)
        {
            hat.SetActive(false);
            hatBlue.SetActive(true);
            Begin.hatPainted = true;
            anilip.SetActive(true);
            StartCoroutine(anilipstick());
            RemoveItem(lipstickItem);
        }
        else if(hatBlue.activeSelf) {
            Debug.Log("bluehat");
            hatBlue.SetActive(false);
            hatBtn.enabled = false;
            Begin.hatPicked = true;
        }
        if(Begin.hatPicked && Begin.dressPicked && Begin.shoe1Picked && Begin.shoe2Picked 
           && Begin.perfumePicked && Begin.diaryPicked && Begin.diary2Picked)
        {
            StartCoroutine(mirrorChange());
        }
    }
    
    void closeOnClicked() {
        if(Begin.readingDiary) {
            diaryPage[diaryPageNum].SetActive(false);
            Begin.readingDiary = false;
        }
        else if(Begin.readingNote) {
            notePage[notePageNum].SetActive(false);
            Begin.readingNote = false;
        }
        close.SetActive(false);
        closeBtn.enabled = false;
        prevDiaryBtn.enabled = false;
        nextDiaryBtn.enabled = false;
    }

    void l()
    {
        SceneManager.LoadScene("1.0-3");
    }

    void r()
    {
        SceneManager.LoadScene("1.0-1");
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
