using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//базовый класс тут ссылки на скрипты и объекты и общие методы
public class ReferencesToScripts : MonoBehaviour
{
    protected ReferencesToElements KontragentPrefab;
    protected Kontragents kontragents;
    protected ItemList ItemListReference;
    protected CounterpartySettings CounterpartySettingsReference;

    private void Awake() 
    {
        KontragentPrefab = transform.GetComponent<ReferencesToElements>();
        kontragents = transform.GetComponent<Kontragents>();
        
        ItemListReference = transform.GetComponent<ItemList>();
        CounterpartySettingsReference = transform.GetComponent<CounterpartySettings>();
    }

    protected void DestroyGameObjects(Transform transformObjects)
    {
        //удаляем все объекты внутри каколибо панели
        foreach (Transform i in transformObjects)
        {
            Destroy(i.gameObject);
        }
    }

    protected Transform InstantiateAndSetParentObject(Transform refInstantiate, Transform SetParent)
    {
        Transform Pref;
        Pref = Instantiate(refInstantiate);
        Pref.SetParent(SetParent);
        Pref.localScale = new Vector3(1, 1, 1);//изменяем размер так как он почему то меняется при создании обьекта

        return Pref;
    }

}
