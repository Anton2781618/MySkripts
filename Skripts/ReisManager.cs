using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//класс отвечает за работу кнопок в созданном обьекте внутри рейса
public class ReisManager : ReferencesToScripts
{
    //сдвигает кнопку "+" вправо
    public void AddNewWaterInReisObject(Transform myTransform)
    {
        myTransform.localPosition = new Vector2(myTransform.localPosition.x + 250, myTransform.localPosition.y);
    }

    //добавляет новую позицию в строчку обьекта рейс
    public void AddNewPriseType()
    {
        //int id = 1;
        //удаляем все объекты внутри вспомогательной панели
        DestroyGameObjects(KontragentPrefab.references[1].transform);

       /* for (int i = 0; i < CounterpartySettingsReference.ItemKontragentList.Count; i++)
        {
            if (id == CounterpartySettingsReference.ItemKontragentList[i].id)
            {
                Transform Pref = InstantiateAndSetParentObject(KontragentPrefab.references[9], KontragentPrefab.references[1]);
                Pref.GetChild(0).GetComponent<Text>().text = CounterpartySettingsReference.ItemKontragentList[i].nameItem;
            }
        }*/
    }

    //добавляет в UI рейса контрагента из списка контрагентов 
    public void AddNewKontragentInReis(Text textObject)
    {
        int idKontragent = int.Parse(textObject.text);

        Transform Pref = InstantiateAndSetParentObject(KontragentPrefab.references[14], KontragentPrefab.references[15]);
        
        Pref.GetChild(1).GetComponent<Text>().text = kontragents.Kontragent[idKontragent].adress;
    }

    //добавляет в массив рейса контрагента из списка контрагентов
    private void AddKontragentMassive(Transform Obj)
    {

    }
}
