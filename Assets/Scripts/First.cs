using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class First : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;

    private float time1, time2;
    private Color tmp;

    // Start is called before the first frame update
    void Start()
    {
        time1 = time2 = 0.0f;

        tmp = Text1.GetComponentInChildren<Text>().color;
        Text1.GetComponentInChildren<Text>().color = new Color(tmp.r, tmp.g, tmp.b, 0);
        tmp = Text2.GetComponentInChildren<Text>().color;
        Text2.GetComponentInChildren<Text>().color = new Color(tmp.r, tmp.g, tmp.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(time1 < 3.0f) {
            Text1.SetActive(true);
            Text2.SetActive(false);
            time1 += Time.deltaTime;
            if(time1 < 1.0f) {
                tmp = Text1.GetComponentInChildren<Text>().color;
                Text1.GetComponentInChildren<Text>().color = new Color(tmp.r, tmp.g, tmp.b, tmp.a + Time.deltaTime);
            }
            else if(time1 >= 2.5f) {
                tmp = Text1.GetComponentInChildren<Text>().color;
                Text1.GetComponentInChildren<Text>().color = new Color(tmp.r, tmp.g, tmp.b, tmp.a - Time.deltaTime * 2.0f);
            }
        }
        else if(time2 < 3.0f) {
            Text1.SetActive(false);
            Text2.SetActive(true);
            Debug.Log(time2);
            time2 += Time.deltaTime;
            if(time2 < 1.0f) {
                tmp = Text2.GetComponentInChildren<Text>().color;
                Text2.GetComponentInChildren<Text>().color = new Color(tmp.r, tmp.g, tmp.b, tmp.a + Time.deltaTime);
            }
            else if(time2 >= 2.5f) {
                tmp = Text2.GetComponentInChildren<Text>().color;
                Text2.GetComponentInChildren<Text>().color = new Color(tmp.r, tmp.g, tmp.b, tmp.a - Time.deltaTime * 2.0f);
            }
        }
        else {
            Text2.SetActive(false);
            SceneManager.LoadScene("1.0-1");
        }
    }
}
