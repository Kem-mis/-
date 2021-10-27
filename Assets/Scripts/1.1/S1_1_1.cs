using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class S1_1_1 : MonoBehaviour
{
    Sequence s;
    public Bag playerBag;
    public Button left, right;
    public Button posterBtn;
    public Button holeBtn;
    public Button doorBtn;
    public Button lightBtn;
    public Button diadoorBut;

    public GameObject image;
    public GameObject poster;
    public GameObject key;
    public GameObject hole;
    public GameObject shadow, forkFloat;
    public GameObject lightOn1, lightOn2;
    public GameObject hair;
    public GameObject bookshelf1, bookshelf2;
    public GameObject puzzle1;

    public Item diary, perfume, diary2, puzzleItem;

    private bool showingHole, showingPoster;
    private bool isLight;

    //aka
    public GameObject[] diaryPage = new GameObject[6];
    public GameObject[] notePage = new GameObject[5];
    public GameObject close;
    public Button closeBtn;
    private int diaryPageNum, notePageNum;
    public Button nextDiaryBtn, prevDiaryBtn;

    // Start is called before the first frame update
    void Start()
    {
        s = DOTween.Sequence();
        left.onClick.AddListener(l);
        right.onClick.AddListener(r);
        posterBtn.onClick.AddListener(posterOnClicked);
        holeBtn.onClick.AddListener(holeOnClicked);
        doorBtn.onClick.AddListener(doorOnClicked);
        lightBtn.onClick.AddListener(lightOnClicked);

        showingHole = false;
        showingPoster = false;
        isLight = false;

        //aka
        nextDiaryBtn.onClick.AddListener(nextDiaryOnClicked);
        prevDiaryBtn.onClick.AddListener(prevDiaryOnClicked);
        closeBtn.onClick.AddListener(closeOnClicked);
        Begin.readNote = false;
        Begin.readDiary = false;
        Begin.readingDiary = false;
        Begin.readingNote = false;
        nextDiaryBtn.enabled = false;
        prevDiaryBtn.enabled = false;

        if(!Begin.go1)
        {
            BagManager.PropClear();
            //todo 香水，Andrew记事本和雷欧妮日记要留着
            if(Begin.diaryPicked)     AddNewItem(diary);
            if(Begin.perfumePicked) AddNewItem(perfume);
            if(Begin.diary2Picked)    AddNewItem(diary2);
            Begin.go1 = true;
        }
        if(Begin.diary2Picked) {
            bookshelf1.SetActive(false);
            bookshelf2.SetActive(true);
        }
        if(Begin.wireFixed)
        {
            lightOn1.SetActive(true);
            lightOn2.SetActive(true);
            image.SetActive(true);
        }
        if(Begin.puzzle1Picked)
        {
            lightBtn.enabled = false;
            forkFloat.SetActive(true);
            shadow.SetActive(true);
        }

        BagManager.RefreshItem();

        if(Begin.puzzle1Picked && Begin.puzzle2Picked && Begin.wireFixed && Begin.puzzle4Picked)
        {
            StartCoroutine(showkey());
        }
    }

    IEnumerator showkey()
    {
        key.SetActive(true);
        s.Append(key.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1));
        yield return new WaitForSeconds(1f);
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            closePictures();
        }
        if (Begin.puzzle1Picked && Begin.puzzle2Picked && Begin.wireFixed && Begin.puzzle4Picked)
        {
            Destroy(diadoorBut.gameObject);
        }

        //aka
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

    void closePictures() {
        if(showingPoster) {
            s.Append(poster.transform.DOScale(new Vector3(1f, 1f, 1f), 1));
            s.Join(poster.transform.DOMove(new Vector3(poster.transform.position.x - 5f, poster.transform.position.y, 0f), 1));
            showingPoster = false;
        }
        else if(showingHole) {
            s.Append(hole.transform.DOScale(new Vector3(1f, 1f, 1f), 1));
            s.Join(hole.transform.DOMove(new Vector3(hole.transform.position.x - 5f, hole.transform.position.y - 5f, 0f), 1));
            hole.SetActive(false);
            showingHole = false;
        }
    }

    //aka
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

    void doorOnClicked()
    {
        // todo 判断是否有钥匙
        // 这里为了测试先设定能直接转场
        if(Begin.puzzle1Picked && Begin.puzzle2Picked && Begin.wireFixed && Begin.puzzle4Picked)
        {
            SceneManager.LoadScene("1.1-5");
        }
    }

    void holeOnClicked()
    {
        if(!showingHole) {
            holeBtn.enabled = false;
            showingHole = true;
            // Debug.Log("hole clicked");
            //todo 拼图收集完全后的情况另写
            hole.SetActive(true);
            s.Append(hole.transform.DOScale(new Vector3(5f, 5f, 5f), 1));
            s.Join(hole.transform.DOMove(new Vector3(hole.transform.position.x + 5f, hole.transform.position.y + 5f, 0f), 1));
        }
    }

    void posterOnClicked()
    {
        if(!showingPoster) {
            showingPoster = true;
            s.Append(poster.transform.DOScale(new Vector3(3f, 3f, 3f), 1));
            s.Join(poster.transform.DOMove(new Vector3(poster.transform.position.x + 5f, poster.transform.position.y, 0f), 1));
            posterBtn.enabled = false;
        }
    }

    void lightOnClicked() {
        if(Begin.forkPicked && lightOn1.activeSelf)
        {
            forkFloat.SetActive(true);
            shadow.SetActive(true);
            lightBtn.enabled = false;
            StartCoroutine(p1());
        }
    }

    IEnumerator p1()
    {
        puzzle1.SetActive(true);
        s.Append(puzzle1.transform.DOScale(new Vector3(5f, 5f, 5f), 1));
        s.Join(puzzle1.transform.DOMove(new Vector3(puzzle1.transform.position.x + 5f, puzzle1.transform.position.y + 3f, 0f), 1));
        yield return new WaitForSeconds(1f);
        puzzle1.SetActive(false);
        AddNewItem(puzzleItem);
        Begin.puzzle1Picked = true;
        yield return new WaitForSeconds(0.5f);
        if(Begin.puzzle1Picked && Begin.puzzle2Picked && Begin.wireFixed && Begin.puzzle4Picked)
        {
            StartCoroutine(showkey());
        }
    }
    
    void l()
    {
        SceneManager.LoadScene("1.1-4");
    }

    void r()
    {
        SceneManager.LoadScene("1.1-2");
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
