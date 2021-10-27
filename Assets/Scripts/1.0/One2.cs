using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using DG.Tweening;

public class One2 : MonoBehaviour
{
    Sequence s;
    public Bag playerBag;
    public Button left, right;

    public GameObject dress;
    public GameObject withDress, withoutDress;
    public GameObject fireplace, fBurning, fBurned;
    public GameObject light, nolight;
    public GameObject shoe1, shoes;
    public GameObject design;
    public GameObject plant, plantCut1, plantCut2, plantCut3;
    public GameObject aniaxe,anilight,aniwood;
    public GameObject shoe2, dust;

    public Item dressItem;
    public Item lightItem;
    public Item shoeItem;
    public Item plantItem;

    public Button dressBtn;
    public Button lightBtn;
    public Button shoe1Btn;
    public Button plantBtn;
    public Button dialogplantbutton;


    public Button paintBtn;
    private bool paintClicked;
    public Button fireplaceBtn;
    public Button shoe2Btn;
    
    public GameObject[] diaryPage = new GameObject[6];
    public GameObject[] notePage = new GameObject[5];
    public GameObject close;
    private Button closeBtn;
    private int diaryPageNum, notePageNum;
    public Button nextDiaryBtn, prevDiaryBtn;


    //private int cnt;

    // Start is called before the first frame update
    void Start()
    {
        closeBtn = close.GetComponent<Button>();
        close.SetActive(false);
        closeBtn.enabled = false;
        closeBtn.onClick.AddListener(closeOnClicked);

        //AudioManager._audioSource.UnPause();
        s = DOTween.Sequence();
        left.onClick.AddListener(l);
        right.onClick.AddListener(r);

        dressBtn.onClick.AddListener(dressOnClicked);
        lightBtn.onClick.AddListener(lightOnClicked);
        shoe1Btn.onClick.AddListener(shoe1OnClicked);
        plantBtn.onClick.AddListener(plantOnClicked);

        paintBtn.onClick.AddListener(paintOnClicked);
        paintClicked = false;

        fireplaceBtn.onClick.AddListener(fireOnClicked);
        shoe2Btn.onClick.AddListener(shoe2OnClicked);

        if(Begin.dressPicked)
        {
            withDress.SetActive(false);
            dress.SetActive(false);
            withoutDress.SetActive(true);
            dressBtn.enabled = false;
        }
        if(Begin.lightPicked)
        {
            light.SetActive(false);
            lightBtn.enabled = false;
        }
        if(Begin.shoe1Picked)
        {
            shoe1.SetActive(false);
            shoe1Btn.enabled = false;
        }
        if(Begin.axePicked)
        {
            Destroy(dialogplantbutton.gameObject);
        }
        if(Begin.fireplaceBurned) {
            fBurned.SetActive(true);
            fBurning.SetActive(false);
            fireplace.SetActive(false);
            fireplaceBtn.enabled = false;
            dust.SetActive(true);
            if(Begin.shoe2Picked)
            {
                shoe2Btn.enabled = false;
            }
            else
            {
                shoe2.SetActive(true);
            }
        }
        if(Begin.woodPicked) {
            plant.SetActive(false);
            plantCut2.SetActive(true);
            plantBtn.enabled = false;
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
        //cnt = 0;
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

    void closePictures() {
        if(paintClicked) {
            s.Append(design.transform.DOScale(new Vector3(1f, 1f, 1f), 1));
            s.Join(design.transform.DOMove(new Vector3(design.transform.position.x, design.transform.position.y + 3f, 0f), 1));
            paintClicked = false;
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
        SceneManager.LoadScene("1.0-1");
    }

    void r()
    {
        SceneManager.LoadScene("1.0-3");
    }

    void shoe2OnClicked()
    {
        Begin.shoe2Picked = true;
        shoe2.SetActive(false);
        shoe2Btn.enabled = false;
    }

    void dressOnClicked() {
        if(withDress.activeSelf)
        {
            dressBtn.enabled = false;
            StartCoroutine(showDress());
        }
    }

    IEnumerator showDress() {
        dress.SetActive(true);
        withoutDress.SetActive(true);
        withDress.SetActive(false);
        s.Append(dress.transform.DOMove(new Vector3(dress.transform.position.x + 3f, dress.transform.position.y, 0f), 1));
        yield return new WaitForSeconds(2f);
        dress.SetActive(false);
        Begin.dressPicked = true;
        yield return new WaitForSeconds(1f);
    }

    void lightOnClicked() {
        if(light.activeSelf) {
            light.SetActive(false);
            AddNewItem(lightItem);
            Begin.lightPicked = true;
            lightBtn.enabled = false;
        }
    }

    void shoe1OnClicked() {
        if(shoe1.activeSelf) {
            shoe1.SetActive(false);
            Begin.shoe1Picked = true;
            shoe1Btn.enabled = false;
        }
    }

    void paintOnClicked() {
        if(!paintClicked) {
            paintClicked = true;
            paintBtn.enabled = false;
            s.Append(design.transform.DOMove(new Vector3(design.transform.position.x, design.transform.position.y - 3f, 0f), 1));
            s.Join(design.transform.DOScale(new Vector3(2f, 2f, 2f), 1));
        }
    }

    void plantOnClicked() {
        if(Begin.axePicked) {
            aniaxe.SetActive(true);
            StartCoroutine(ania());
            Begin.woodPicked = true;
            plantBtn.enabled = false;
        }
    }

    IEnumerator ania()
    {
        s.Append(aniaxe.transform.DOMove(new Vector3(aniaxe.transform.position.x + 1f, aniaxe.transform.position.y, 0f), 0.5f));
        s.Join(aniaxe.transform.DORotate(new Vector3(0, 0 , 180), 0.5f));
        yield return new WaitForSeconds(0.5f);
        s.Append(aniaxe.transform.DORotate(new Vector3(0, 0, 60), 0.5f));
        yield return new WaitForSeconds(0.25f);
        plant.SetActive(false);
        plantCut2.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        aniaxe.SetActive(false);
        AddNewItem(plantItem);
    }

    void fireOnClicked() {
        if(!Begin.fireplaceBurned && Begin.woodPicked) {
            Begin.fireplaceBurned = true;
            fireplaceBtn.enabled = false;
            RemoveItem(plantItem);
            RemoveItem(lightItem);
            aniwood.SetActive(true);
            anilight.SetActive(true);
            StartCoroutine(aniligh());
            StartCoroutine(aniwoo());
            StartCoroutine(burn());
        }

    }

    IEnumerator aniligh()
    {
        s.Append(anilight.transform.DOMove(new Vector3(anilight.transform.position.x - 1f, anilight.transform.position.y + 0.5f, 0f), 1.5f));
        s.Join(anilight.transform.DORotate(new Vector3(0, 0, 60), 1.5f));
        yield return new WaitForSeconds(1.5f);
        anilight.SetActive(false);
    }

    IEnumerator aniwoo()
    {
        s.Append(aniwood.transform.DOMove(new Vector3(aniwood.transform.position.x + 1f, aniwood.transform.position.y + 0.5f, 0f), 1.5f));
        s.Join(aniwood.transform.DORotate(new Vector3(0, 0, -60), 1.5f));
        yield return new WaitForSeconds(1.5f);
        aniwood.SetActive(false);
    }
    IEnumerator burn() {
        Color tmp = fBurning.GetComponentInChildren<Image>().color;
        fBurning.GetComponentInChildren<Image>().color = new Color(tmp.r, tmp.g, tmp.b, 0);
        fBurning.SetActive(true);
        for(int i = 1; i <= 100; i ++) {
            fBurning.GetComponentInChildren<Image>().color = new Color(tmp.r, tmp.g, tmp.b, i * 1.0f / 100);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(2f);
        for(int i = 1; i <= 50; i ++) {
            fBurning.GetComponentInChildren<Image>().color = new Color(tmp.r, tmp.g, tmp.b, 1 - i * 2.0f / 100);
            yield return new WaitForSeconds(0.01f);
        }
        fireplace.SetActive(false);
        fBurned.SetActive(true);
        fBurning.SetActive(false);
        shoe2.SetActive(true);
        dust.SetActive(true);
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
