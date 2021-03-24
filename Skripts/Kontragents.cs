//список контрагентов + настройки
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//класс списка контрагентов
public class Kontragents : ReferencesToScripts
{
    public List<Klients> Kontragent = new List<Klients>();
    
    //добавляем контрагента
    public void AddNewKontragent()
    {
        Transform Pref = InstantiateAndSetParentObject(KontragentPrefab.references[0],KontragentPrefab.references[5]);
        AddKontragentMassive(Pref);
      //  StartCoroutine(routine: ScrollRect(KontragentPrefab.references[2].transform));
    }

    //добавляем экземпляр в массив
    private void AddKontragentMassive(Transform Obj)
    {
        Kontragent.Add(new Klients());
        Kontragent[Kontragent.Count - 1].ReferencesToKlientsObject = Obj.transform;
        Obj.GetChild(0).GetComponent<Text>().text = (Kontragent.Count - 1).ToString();
    }

    //устанавливаем значения адресса в массив 
    public void InitializationAdress(Transform MyTransform)
    {
        int idKlient = int.Parse(MyTransform.GetChild(0).GetComponent<Text>().text);

        Kontragent[idKlient].adress = MyTransform.GetChild(1).GetComponent<InputField>().text;
    }

    //перемещает список контрагентов вниз через 0,05 от секунды
    public IEnumerator ScrollRect(Transform obj)
    {
        yield return new WaitForSeconds(0.03f);
        obj.localPosition = new Vector2(obj.localPosition.x, obj.localPosition.y + 1000);       
    }

    
}
