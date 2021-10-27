using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class One1 : MonoBehaviour
{
    public GameObject cabinet1, cabinet2, hair, cabinet3, diary, faker1, faker2,anihair;
    public GameObject withDiary, withoutDiary, cindPage, cindPage2;
    public GameObject poster1, poster2;
    public Button posterBtn;
    public Button left, right;
    public Button c, hairButton, fakerButton, bustleBtn;
    public Button shelfBtn, diaryBtn, cindBtn;
    // public Button nextNoteBtn, prevNoteBtn;
    public Bag playerBag;
    public Item hair2, diary2, bustle;
    public Item shelfDiary;

    private bool shelfZooming, cindOpen, posterRead;

    //public Button tmpBtn;  // test

    public GameObject[] diaryPage = new GameObject[6];
    public GameObject[] notePage = new GameObject[5];
    public GameObject close;
    public Button closeBtn;
    private int diaryPageNum, notePageNum;
    public Button nextDiaryBtn, prevDiaryBtn;

    Sequence s;

    // Start is called before the first frame update
    void Start()
    {

        if(!Begin.go0)
        {
            //AudioManager.AudioPlay("bgm/1.0");
            Begin.go0 = true;
        }
        
        c.onClick.AddListener(c1);
        left.onClick.AddListener(l);
        right.onClick.AddListener(r);
        hairButton.onClick.AddListener(hairOnClicked);
        fakerButton.onClick.AddListener(fakerClicked);
        bustleBtn.onClick.AddListener(bustleClicked);
        shelfBtn.onClick.AddListener(shelfOnClicked);
        diaryBtn.onClick.AddListener(diaryOnClicked);
        cindBtn.onClick.AddListener(cindOnClicked);
        posterBtn.onClick.AddListener(posterOnClicked);

        nextDiaryBtn.onClick.AddListener(nextDiaryOnClicked);
        prevDiaryBtn.onClick.AddListener(prevDiaryOnClicked);

        closeBtn.onClick.AddListener(closeOnClicked);

        //tmpBtn.onClick.AddListener(goto13); // test

        bustleBtn.enabled = false;

        shelfZooming = cindOpen = posterRead = false;

        //加载场景前判断物品是否被取走过
        if(Begin.hairPicked == true) 
        {
            hair.SetActive(false);
            hairButton.enabled = false;
        }
        if(Begin.drawerOpen == true)
        {
            cabinet1.SetActive(false);
            cabinet2.SetActive(true);
        }
        if(Begin.bustleFound == true)
        {
            faker1.SetActive(false);
            faker2.SetActive(true);
        }
        if(Begin.diary2Picked) {
            withDiary.SetActive(false);
            withoutDiary.SetActive(true);
        }

        for(int i = 0; i < 6; i ++) {
            diaryPage[i].SetActive(false);
        }
        for(int i = 0; i < 5; i ++) {
            notePage[i].SetActive(false);
        }

        s = DOTween.Sequence();
        // test
        Begin.readNote = false;
        Begin.readDiary = false;
        Begin.readingDiary = false;
        Begin.readingNote = false;

        nextDiaryBtn.enabled = false;
        prevDiaryBtn.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            closePictures();
        }

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

    void posterOnClicked()
    {
        poster2.SetActive(true);
        posterRead = true;
    }

    void closePictures() {
        if(shelfZooming) {
            if(withDiary.activeSelf) {
                s.Append(withDiary.transform.DOScale(1f, 0.5f));
                s.Join(withDiary.transform.DOMove(new Vector3(withDiary.transform.position.x - 5f, withDiary.transform.position.y, 0f), 0.5f));
            }
            else {
                s.Append(withoutDiary.transform.DOScale(1f, 0.5f));
                s.Join(withoutDiary.transform.DOMove(new Vector3(withoutDiary.transform.position.x - 5f, withoutDiary.transform.position.y, 0f), 0.5f));
            }
            shelfZooming = false;
            shelfBtn.enabled = true;
            cindBtn.enabled = true;
            diaryBtn.enabled = true;
        }
        if(cindOpen) {
            s.Join(cindPage2.transform.DOScale(1f, 0.5f));
            cindPage2.SetActive(false);
            cindOpen = false;
        }
        if(posterRead)
        {
            poster2.SetActive(false);
            posterRead = false;
        }
    }

    void fakerClicked()
    {
        if(Begin.bustleFound == false) //裙撑有无被点开
        {
            if(Begin.bustlePicked == false && Begin.hairPicked == true) //裙撑还没被拿到，铁丝已经有了，制作裙撑
            {
                anihair.SetActive(true);
                StartCoroutine(anih());
                faker1.SetActive(false);
                faker2.SetActive(true);
                RemoveItem(hair2);
                Begin.bustleFound = true;
                bustleBtn.enabled = true;
            }
        }
    }

    IEnumerator anih()
    {
        s.Append(anihair.transform.DOMove(new Vector3(anihair.transform.position.x + 1f, anihair.transform.position.y - 1f, 0f), 1.5f));
        s.Join(anihair.transform.DORotate(new Vector3(0, 0, 180), 1.5f));
        s.Join(anihair.transform.DOScale(new Vector3(0, 0, 0), 1.5f));
        yield return new WaitForSeconds(1.5f);
        anihair.SetActive(false);
    }

    void bustleClicked() {
        if(Begin.bustleFound)
        {
            faker1.SetActive(true);
            faker2.SetActive(false);
            Begin.bustleFound = false;
            Begin.bustlePicked = true;
            bustleBtn.enabled = false;
        }
    }

    void hairOnClicked()
    {
        if(hair.activeSelf)
        {
            hair.SetActive(false);
            AddNewItem(hair2);
            //BagManager.UpdateItemInfo("拿到了莎士比亚的假发！");
            Begin.hairPicked = true;
            hairButton.enabled = false;
        }
    }


    void c1()
    {
        if(cabinet1.activeSelf)
        {
            cabinet1.SetActive(false);
            cabinet2.SetActive(true);
            Begin.drawerOpen = true;
        }
        else if(cabinet2.activeSelf)
        {
            if(Begin.diaryPicked == false) StartCoroutine(pickDiary());
            else
            {
                cabinet1.SetActive(true);
                cabinet2.SetActive(false);
                Begin.drawerOpen = false;          
            }
        }
    }

    IEnumerator pickDiary()
    {
        cabinet3.SetActive(true);
        diary.SetActive(true);
        yield return new WaitForSeconds(1f);
        //BagManager.UpdateItemInfo("找到了Andrew的日记本！");
        Begin.diaryPicked = true;
        s.Append(diary.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2));
        s.Join(diary.transform.DOMove(new Vector3(diary.transform.position.x, diary.transform.position.y + 1.5f, 0f), 2));
        yield return new WaitForSeconds(2f);
        s.Append(diary.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 2));
        diary.SetActive(false);
        cabinet3.SetActive(false);
        AddNewItem(diary2);
    }

    void diaryOnClicked() {
        if(withDiary.activeSelf) {
            withoutDiary.SetActive(true);
            withDiary.SetActive(false);
            Begin.diary2Picked = true;
            AddNewItem(shelfDiary);
            diaryBtn.enabled = false;
        }
    }

    void shelfOnClicked() {
        if(!shelfZooming) {
            shelfZooming = true;
            shelfBtn.enabled = false;
            cindBtn.enabled = false;
            diaryBtn.enabled = false;
            if(withDiary.activeSelf) {
                s.Append(withDiary.transform.DOMove(new Vector3(withDiary.transform.position.x + 5f, withDiary.transform.position.y, 0f), 0.5f));
                s.Join(withDiary.transform.DOScale(1.2f, 0.5f));
            }
            else {
                s.Append(withoutDiary.transform.DOMove(new Vector3(withoutDiary.transform.position.x + 5f, withoutDiary.transform.position.y, 0f), 0.5f));
                s.Join(withoutDiary.transform.DOScale(1.2f, 0.5f));
            }
        }
    }

    void cindOnClicked() {
        if(!cindOpen) {
            cindOpen = true;
            StartCoroutine(openCind());
        }
    }
    
    IEnumerator openCind() {
        cindPage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        s.Append(cindPage2.transform.DOScale(1.5f, 0.5f));
        cindPage2.SetActive(true);
        cindPage.SetActive(false);
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
        SceneManager.LoadScene("1.0-4");
    }

    void r()
    {
        //AudioManager._audioSource.Pause();
        SceneManager.LoadScene("1.0-2");
    }

    // void goto13() {
    //     SceneManager.LoadScene("1.3-1");
    // }

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
