using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S0 : MonoBehaviour
{
    public AudioSource music;
    public AudioClip musicClip;
    public GameObject title, title2, titleBg, spark;

    private float time, sparkTime;
    private bool fade;
    private Color tmp;

    private void Awake()
    {
        music = gameObject.AddComponent<AudioSource>();
        music.loop = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        music.clip = musicClip;
        music.Play();
        time = sparkTime = 0.0f;
        fade = true;

        tmp = title.GetComponentInChildren<Image>().color;
        title.GetComponentInChildren<Image>().color = new Color(tmp.r, tmp.g, tmp.b, 0);
        tmp = title2.GetComponentInChildren<Image>().color;
        title2.GetComponentInChildren<Image>().color = new Color(tmp.r, tmp.g, tmp.b, 0);
        tmp = titleBg.GetComponentInChildren<Image>().color;
        titleBg.GetComponentInChildren<Image>().color = new Color(tmp.r, tmp.g, tmp.b, 0);
        tmp = spark.GetComponentInChildren<Image>().color;
        spark.GetComponentInChildren<Image>().color = new Color(tmp.r, tmp.g, tmp.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time < 3.0f) {
            tmp = title.GetComponentInChildren<Image>().color;
            title.GetComponentInChildren<Image>().color = new Color(tmp.r, tmp.g, tmp.b, tmp.a + Time.deltaTime / 3.0f);
            tmp = title2.GetComponentInChildren<Image>().color;
            title2.GetComponentInChildren<Image>().color = new Color(tmp.r, tmp.g, tmp.b, tmp.a + Time.deltaTime / 3.0f);
            tmp = titleBg.GetComponentInChildren<Image>().color;
            titleBg.GetComponentInChildren<Image>().color = new Color(tmp.r, tmp.g, tmp.b, tmp.a + Time.deltaTime / 3.0f);
            tmp = spark.GetComponentInChildren<Image>().color;
            spark.GetComponentInChildren<Image>().color = new Color(tmp.r, tmp.g, tmp.b, tmp.a + Time.deltaTime / 3.0f);
        }
        else {
            sparkTime += Time.deltaTime;
            if(sparkTime > 1.5f) {
                sparkTime = 0.0f;
                fade = !fade;
            }
            if(fade) {
                tmp = spark.GetComponentInChildren<Image>().color;
                spark.GetComponentInChildren<Image>().color = new Color(tmp.r, tmp.g, tmp.b, tmp.a - 0.7f * Time.deltaTime / 3.0f);
            }
            else {
                tmp = spark.GetComponentInChildren<Image>().color;
                spark.GetComponentInChildren<Image>().color = new Color(tmp.r, tmp.g, tmp.b, tmp.a + 0.7f * Time.deltaTime / 3.0f);
            }
        }
    }
}
