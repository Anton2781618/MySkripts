using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//класс карточки клиента
public class CounterpartySettings : ReferencesToScripts
{
    public List<Dictionary<string, string>> ItemKontragentListDictionary = new List<Dictionary<string, string>>();
    private int id;
    private string adress;

    //метод заполяет карточку клиента по id
    public void InitId(Transform idKontragent)
    {
        id = int.Parse(idKontragent.GetChild(0).GetComponent<Text>().text);
        adress = kontragents.Kontragent[id].adress;
        Transform objkontragent = kontragents.Kontragent[id].ReferencesToKlientsObject;

        KontragentPrefab.references[3].GetChild(0).GetComponent<InputField>().text = kontragents.Kontragent[id].adress;
        KontragentPrefab.references[3].GetChild(1).GetComponent<InputField>().text = kontragents.Kontragent[id].telephone;
        KontragentPrefab.references[3].GetChild(4).GetComponent<InputField>().text = kontragents.Kontragent[id].note;

        DestroyGameObjects(KontragentPrefab.references[10].transform);

        if(CheckItemKontragentListDictionaryIdMatches())
        {
            foreach (var item in ItemKontragentListDictionary[id].Keys)
            {
                Transform Pref = InstantiateAndSetParentObject(KontragentPrefab.references[11], KontragentPrefab.references[10]);

                Pref.GetChild(0).GetComponent<Text>().text = id.ToString();
                Pref.GetChild(1).GetComponent<Text>().text = item;
                Pref.GetChild(2).GetComponent<InputField>().text = ItemKontragentListDictionary[id][item].ToString();
            }
        }
    }

    //передает данные в массив и вставляет данные в UI
    public void PassDataToArray(Transform Obj)
    {
        kontragents.Kontragent[id].adress = Obj.GetChild(0).GetComponent<InputField>().text;
        kontragents.Kontragent[id].telephone = Obj.GetChild(1).GetComponent<InputField>().text;
        kontragents.Kontragent[id].note = Obj.GetChild(4).GetComponent<InputField>().text;

        Transform objkontragent = kontragents.Kontragent[id].ReferencesToKlientsObject;
        objkontragent.GetChild(1).GetComponent<Text>().text = kontragents.Kontragent[id].adress;
    }

    //удаление клиента
    public void DeletKlient()
    {
        Destroy(kontragents.Kontragent[id].ReferencesToKlientsObject.gameObject);
        kontragents.Kontragent.RemoveAt(id);

        RenumberOllKlients();
    }

    //удаление типа цен
    public void DeletPries(Text textObject)
    {
        string key = textObject.GetComponent<Text>().text;        

        if (CheckItemKontragentListDictionaryIdMatches())
        {
            var item = ItemKontragentListDictionary[id];
            item.Remove(key);
        }
        
        Destroy( textObject.transform.parent.gameObject);
    }

    //перенумеровывает все UI как в листе Kontragent
    private void RenumberOllKlients()
    {
        for (int i = 0; i < kontragents.Kontragent.Count; i++)
        {
            kontragents.Kontragent[i].ReferencesToKlientsObject.GetChild(0).GetComponent<Text>().text = i.ToString();
        }

    }

    //метод сначала проверяет список словарей на наличие одинаковых экземпляров, затем создает экземпляр с ключем и значением
    public void AddItemKontragentObject(Text textObject)
    {
        string key = textObject.GetComponent<Text>().text;

        CheckItemKontragentListDictionaryExempl();
        if(!CheckItemKontragentListDictionaryKey(key))return;

        Transform Pref = InstantiateAndSetParentObject(KontragentPrefab.references[11],KontragentPrefab.references[10]);

        Pref.GetChild(0).GetComponent<Text>().text = id.ToString();
        Pref.GetChild(1).GetComponent<Text>().text = textObject.GetComponent<Text>().text;

        ItemKontragentListDictionary[ItemKontragentListDictionary.Count - 1].Add(key, "");
    }

    //устанавливает данные о ценах в карточке контрагента при изменении
    public void InstalretailPriseToKontragentItem(Transform ItemObject)
    {
        string itemKey = ItemObject.GetChild(1).GetComponent<Text>().text;
        string itemValue = ItemObject.GetChild(2).GetComponent<InputField>().text;

        if(CheckItemKontragentListDictionaryIdMatches())
        {
            ItemKontragentListDictionary[id][itemKey] = itemValue;
        }
    }

    //проверка на наличие позиции в длине номенклатуре карточки клиента
    private void CheckItemKontragentListDictionaryExempl()
    {
        if(ItemKontragentListDictionary.Count - 1 < id)
        {
            ItemKontragentListDictionary.Add(new Dictionary<string, string>());
        }
    }

    //проверка на наличие ключа в номенклатуре карточки клиента
    private bool CheckItemKontragentListDictionaryKey(string textObject)
    {
        foreach (var item in ItemKontragentListDictionary)
        {
            if (!item.ContainsKey(textObject))
            {                
                return true;
            }
        }
        return false;
    }

    //проверка на совпадения id cо списком словарей
    private bool CheckItemKontragentListDictionaryIdMatches()
    {
        for (int i = 0; i < ItemKontragentListDictionary.Count; i++)
        {
            if (i == id)
            {
                return true;
            }
        }
        return false;
    }

}
