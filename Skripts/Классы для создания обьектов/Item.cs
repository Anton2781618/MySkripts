using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//класс номенклатура
[System.Serializable]
public class Item
{
    public Transform ReferencesToItemObject;//ссылка объект в контрагенте   
    public string nameItem;
    public string buyPrise;

}