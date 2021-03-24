using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//интерфейсы вынуждаем переопределить методы
interface IAddNewItem 
{
    //договор по созданию экземпляра массива
    void AddNewMassiveItem();

    //договор по созданию UI
    void AddNewUIObject();
}
