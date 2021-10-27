using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    public GameObject page1;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(onClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClicked()
    {
        Debug.Log("item clicked");
        // 记事本
        if(slotItem.itemName == "diary" && !Begin.readingDiary){
            // Debug.Log("diary clicked");
            // page1.SetActive(true);
            Begin.readNote = true;
        }

        // 红色羽毛
        // if(slotItem.itemName == "Red") {
        //     Begin.useRed = true;
        // }

        // 蓝色果实
        if(slotItem.itemName == "blueItem") {
            Begin.useBlue = true;
        }

        // 黄色煤渣
        if(slotItem.itemName == "yellowItem") {
            Begin.useYellow = true;
        }

        // 日记
        if(slotItem.itemName == "shelfDiary" && !Begin.readingNote) {   // pb: 不记得叫啥了，看一眼
            Begin.readDiary = true;
        }
    }
}
