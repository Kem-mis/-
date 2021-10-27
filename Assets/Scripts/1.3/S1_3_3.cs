using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class S1_3_3 : MonoBehaviour
{
    public Bag playerBag;
    public Button left, right;

    public GameObject sword;
    public GameObject scissors;
    public GameObject whiteCurtain, greenCurtain;
    public GameObject flatGlass, zoomGlass;
    public GameObject needle;
    public GameObject close;
    public GameObject greenCloth;
    
    public GameObject blueGlass, yellowGlass;

    public Item blueItem, yellowItem;

    public Button swordBtn;
    public Button scissorsBtn;
    public Button flatGlassBtn, zoomglassBtn;
    public Button needleBtn;
    public Button curtainBtn;
    public Button greenClothBtn;
    public Button diadoorBtn;
    private Button closeBtn;

    public Item swordItem;
    public Item scissorsItem;
    public Item needleItem;
    public Item blueGlassItem, yellowGlassItem;

    private bool showGlass;
    
    // Start is called before the first frame update
    void Start()
    {
        closeBtn = close.GetComponent<Button>();
        close.SetActive(false);
        closeBtn.enabled = false;

        left.onClick.AddListener(l);
        right.onClick.AddListener(r);

        swordBtn.onClick.AddListener(swordOnClick);
        scissorsBtn.onClick.AddListener(scissorsOnClick);
        needleBtn.onClick.AddListener(needleOnClick);
        flatGlassBtn.onClick.AddListener(flatGlassOnClick);
        curtainBtn.onClick.AddListener(curtainOnClick);
        greenClothBtn.onClick.AddListener(greenClothOnClick);
        // zoomglassBtn.onClick.AddListener(zoomGlassOnClick);

        closeBtn.onClick.AddListener(closeOnClick);

        showGlass = false;
        curtainBtn.enabled = false;

        if(Begin.swordPicked) {
            sword.SetActive(false);
            swordBtn.enabled = false;
        }
        if(Begin.scissors13Picked) {
            scissors.SetActive(false);
            scissorsBtn.enabled = false;
        }
        if(Begin.needlePicked) {
            needle.SetActive(false);
            needleBtn.enabled = false;
        }
        if(Begin.curtainCut) {
            whiteCurtain.SetActive(false);
            greenCurtain.SetActive(false);
        }
        if(Begin.greenClothGet && !Begin.greenClothPicked) {
            greenCloth.SetActive(true);
        }
        blueGlass.SetActive(false);
        yellowGlass.SetActive(false);
        //RedGlass.SetActive(false);

        Begin.useBlue = Begin.useYellow = false;

        BagManager.RefreshItem();
    }

    // Update is called once per frame
    void Update()
    {
        if(zoomGlass.activeSelf && Begin.useBlue) {
            Begin.useBlue = false;
            blueGlass.SetActive(true);
        }
        // if(zoomGlass.activeSelf && Begin.useRed) {
        //     Begin.useRed = false;
        //     RedGlass.SetActive(true);
        // }
        if(zoomGlass.activeSelf && Begin.useYellow) {
            Begin.useYellow = false;
            yellowGlass.SetActive(true);
        }
        if(!greenCurtain.activeSelf && blueGlass.activeSelf && yellowGlass.activeSelf) {
            greenCurtain.SetActive(true);
            whiteCurtain.SetActive(false);
        }
        if (Begin.greenClothPicked)
        {
            Destroy(diadoorBtn.gameObject);
        }
        }

    void swordOnClick() {
        if(sword.activeSelf) {
            sword.SetActive(false);
            swordBtn.enabled = false;
            AddNewItem(swordItem);
            Begin.swordPicked = true;
        }
    }

    void scissorsOnClick() {
        if(scissors.activeSelf) {
            scissors.SetActive(false);
            scissorsBtn.enabled = false;
            AddNewItem(scissorsItem);
            Begin.scissors13Picked = true;
        }
    }
    
    void needleOnClick() {
        if(needle.activeSelf) {
            needle.SetActive(false);
            needleBtn.enabled = false;
            AddNewItem(needleItem);
            Begin.needlePicked = true;

            curtainBtn.enabled = true;
        }
    }

    void flatGlassOnClick() {
        if(greenCloth.activeSelf) {
            greenCloth.SetActive(false);
            Begin.greenClothPicked = true;
        }
        else if(!showGlass) {
            showGlass = true;
            flatGlass.SetActive(false);
            zoomGlass.SetActive(true);
            zoomglassBtn.enabled = true;
            close.SetActive(true);
            closeBtn.enabled = true;
        }
    }

    void curtainOnClick() {
        if(greenCurtain.activeSelf) {
            greenCurtain.SetActive(false);
            whiteCurtain.SetActive(false);
            greenCloth.SetActive(true);
            Begin.curtainCut = true;
        }
    }

    void greenClothOnClick() {
        if(greenCloth.activeSelf) {
            greenCloth.SetActive(false);
            Begin.greenClothPicked = true;
        }
    }

    void closeOnClick() {
        if(showGlass) {
            showGlass = false;
            flatGlass.SetActive(true);
            zoomGlass.SetActive(false);
            yellowGlass.SetActive(false);
            blueGlass.SetActive(false);
            zoomglassBtn.enabled = false;
            close.SetActive(false);
            closeBtn.enabled = false;
        }
    }

    void l()
    {
        SceneManager.LoadScene("1.3-2");
    }

    void r()
    {
        SceneManager.LoadScene("1.3-4");
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
