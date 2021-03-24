using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SearchKontragents : ReferencesToScripts
{
    List<Klients> KontragentSerch = new List<Klients>();    
   
    
    //системма поиска для отсеевателей контрагентов
    public void Serch()
    {
        string serchObject = KontragentPrefab.references[4].GetComponent<InputField>().text;//сылка поискавой панельи
        GameObject content = KontragentPrefab.references[5].gameObject;
        GameObject contentserch = KontragentPrefab.references[6].gameObject;

        if (serchObject == "")//если панель пуста то
        {
            content.gameObject.SetActive(true);//основной массив включаем
            contentserch.gameObject.SetActive(false);//вспомогательный выключаем
        }
        else
        {
            content.gameObject.SetActive(false);//основной выключаем
            contentserch.gameObject.SetActive(true);//вспомогательный включаем
        }

        for (int del = KontragentSerch.Count - 1; del >= 0; del--)
        {
            Destroy(KontragentSerch[del].ReferencesToKlientsObject.gameObject);
            KontragentSerch.RemoveAt(del);
        }

        if (serchObject != "")
        {
            
            for (int i = 0; i < kontragents.Kontragent.Count; i++)
            {
                if (kontragents.Kontragent[i].adress != null && kontragents.Kontragent[i].adress.ToLower().Contains(serchObject))//берем все записи,находим заглавные буквы и делаем их маленькими 
                {                                                                                 //затем находим совпадения в словосочетаниях 
                
                    bool access = true;
                    for (int x = 0; x < KontragentSerch.Count; x++)
                    {
                        if (KontragentSerch[KontragentSerch.Count - 1].adress == kontragents.Kontragent[i].adress)
                        {
                            access = false;
                        }
                    }

                    if(access)
                    {
                        Transform Pref = InstantiateAndSetParentObject(KontragentPrefab.references[0],KontragentPrefab.references[6]);

                        KontragentSerch.Add(new Klients());
                        KontragentSerch[KontragentSerch.Count - 1].ReferencesToKlientsObject = Pref;

                        KontragentSerch[KontragentSerch.Count - 1].adress = kontragents.Kontragent[i].adress;
                        Pref.GetChild(0).GetComponent<Text>().text = (KontragentSerch.Count - 1).ToString();

                        Pref.GetChild(1).GetComponent<Text>().text = KontragentSerch[KontragentSerch.Count - 1].adress;
                        
                    }
                }
            }           
        }        
    }

    //очищает поле поиска
    public void ClearSerchPanel()
    {
        KontragentPrefab.references[4].GetComponent<InputField>().text = "";
    }
}
