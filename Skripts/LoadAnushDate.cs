using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Text;

public class LoadAnushDate : MonoBehaviour
{
    public Transform obj;
    public Transform imageAnton;
    public string test;
    public Image img;

    public Text[] fields;

    void Start()
    {
        LoadDate();
        //imageAnton.GetComponent<Text>().text = test;
    }

    //метод загружает из файла данные, после этого передает контроль для распределения по строкам
    void LoadDate()
    {
        StreamReader load = new StreamReader("SaveBase/www.junior35.ru-10-03-2021-22-31 — Турбо.Парсер - самый удобный парсер сайтов для СП.csv", Encoding.GetEncoding(1251));
        
        while(true)
        {
            test = load.ReadLine().ToString();
            Recoding();

            if(load.Peek() == -1)break;
        }
        load.Close();
    }

    void Recoding()
    {
        
        string[] words = test.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        
        int i = 0;
        foreach (string s in words)
        {
            //Debug.Log(s);
            fields[i].text = s;
            i++;
        }
        StartCoroutine("Tart");
    }

    [Obsolete]
    private IEnumerator Tart()
    {
        WWW www = new WWW(fields[2].text);
        yield return www;
        img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
    }

   
}
