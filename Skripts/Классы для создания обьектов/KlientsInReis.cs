using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//класс клиента который в рейсе
[System.Serializable]
public class KlientsInReis
{
    public Transform ReferencesToKlientsObject;//ссылка объект в контрагенте   
    public string adress;
    public string telephone;
    public string note;
}
