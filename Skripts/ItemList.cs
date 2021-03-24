using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



//класс для создания списка номенклатуры
public class ItemList : ReferencesToScripts
{
    public List<Item> ListItems = new List<Item>();
    
    public void AddNewItemObject()
    {
        Transform Pref = InstantiateAndSetParentObject(KontragentPrefab.references[8],KontragentPrefab.references[7]);
        AddNewItemList(Pref);
    }

    private void AddNewItemList(Transform Obj)
    {
        ListItems.Add(new Item());
        ListItems[ListItems.Count - 1].ReferencesToItemObject = Obj.transform;
        Obj.GetChild(0).GetComponent<Text>().text = (ListItems.Count - 1).ToString();
    }

    public void AddNewPriseType()
    {
        //удаляем все объекты внутри вспомогательной панели
        DestroyGameObjects(KontragentPrefab.references[1].transform);

        foreach (var i in ItemListReference.ListItems)
        {
            Transform Pref = InstantiateAndSetParentObject(KontragentPrefab.references[9],KontragentPrefab.references[1]);
            Pref.GetChild(0).GetComponent<Text>().text = i.nameItem;
        }
    }

    //устанавливаем имя и закупочную цену в список номенклатуры
    public void InstalTheNameAndPriseItem(Transform ParentObject)
    {
        int id = int.Parse(ParentObject.GetChild(0).GetComponent<Text>().text);

        ListItems[id].nameItem = ParentObject.GetChild(1).GetComponent<InputField>().text;
        ListItems[id].buyPrise = ParentObject.GetChild(2).GetComponent<InputField>().text;
    }
}
