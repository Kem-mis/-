using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S1_3_5 : MonoBehaviour
{
    public Button basementBtn;

    // Start is called before the first frame update
    void Start()
    {
        basementBtn.onClick.AddListener(basement);

        BagManager.RefreshItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void basement() {
        SceneManager.LoadScene("1.3-6");
    }
}
