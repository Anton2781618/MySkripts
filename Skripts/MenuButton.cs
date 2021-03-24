using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
//using System.Runtime.InteropServices;
//using Excel = Microsoft.Office.Interop.Excel;

//класс отвечает за создание меню выбора! Какую панель открыть. например номенклатура или рейсы
public class MenuButton : ReferencesToScripts
{
    public Transform[] menuArray;
    public Transform[] menuArrayObjects;

    
    public void ChoiceMenu(Text ChoiseText)
    {
        
        menuArray[int.Parse(ChoiseText.name)].gameObject.SetActive(true);
    }

    public void ChoiceMenuButton()
    {
        DestroyGameObjects(KontragentPrefab.references[1].transform);

        for (int i = 0; i < menuArrayObjects.Length; i++)
        {
            InstantiateAndSetParentObject(menuArrayObjects[i],KontragentPrefab.references[1]);
        }
    }

    private void OnExe() 
    {
        
    }
}
