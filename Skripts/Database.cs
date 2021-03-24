using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System.IO;
using MySql.Data.MySqlClient;

public struct Date
{
    public string Name;
}

//AlTER TABLE water_price ADD id_req int     //добавляет колонку в таблицу
//AlTER TABLE Cliemt ADD note VARCHAR(100)   //добавляет колонку в таблицу
//CREATE TABLE water_price                   //создает таблицу
//(
//    id int auto_increment primary key
//);
public class Database : MonoBehaviour
{
     
    private string jsonURL = "https://drive.google.com/uc?export=download&id=1QoANk9fIISBluUChQRNq08ZNnQ6Ur__u";

    public string host;
    public string dateBase;
    public string userName;
    public string password;

    private void Start() 
    {
        // StartCoroutine(Send());
        //StartCoroutine(GetData(jsonURL));
        //DeleteItemInDate(1);
        //SelectOllItemsInDate();
        ExecuteARequest("select * from Cliemt left join water_price on id_user = id_request");
    }

    //получить данные локально
    void loadJsonLocalFile()
    {
        //Date item;
        //item = JsonUtility.FromJson<Date>(File.ReadAllText(Application.streamingAssetsPath + "/data.json"));
        //Debug.Log(item.Name);

        //File.WriteAllText(Application.streamingAssetsPath + "/data.json", JsonUtility.ToJson(item));
    }

    [System.Obsolete]
    private IEnumerator GetData(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.Send();

        if(request.isError)
        {
            Debug.Log("ошибка " + request.error);
        }
        else
        {
            Debug.Log("Вошли");
            Date date = JsonUtility.FromJson<Date>(request.downloadHandler.text);
           
            
            //request.SetRequestHeader("Name", "da");
            

            //Debug.Log(date.Name);
        }
        request.Dispose();
    }

    //отправить запрос на сервер и получить данные файла 
    [System.Obsolete]
    private IEnumerator Send()
    {
        WWWForm form = new WWWForm();
        form.AddField("Welcom", "Дороу");
        WWW www = new WWW("https://drive.google.com/file/d/18hJGDmpPlpVxQcG4ggxdthylJDbTWu0O/view?usp=sharing",form);
        yield return www;

        if(www.error != null)
        {
            Debug.Log("ошибка доступа " + www.error);
            yield break;
        }
        Debug.Log("сервер ответил " + www.text);
        
    }

    

    public void SelectOllItemsInDate()
    {
        ExecuteARequest("SELECT * FROM Cliemt;");
    }

    public void SelectIdItemInDate(int idItem)
    {
        ExecuteARequest($"SELECT adress FROM Cliemt WHERE id_user = '{idItem}';");
    }

    public void InsertNewItemInDate(string adress)
    {
        ExecuteARequest($"INSERT INTO Cliemt VALUES (null, '{adress}');");
    }

    //вопрос?!!!! нужно ли дикрементировать id? если надо то как? лопатить всю таблицу и апдейтом переписывать? или как то иначе делается?
    public void DeleteItemInDate(int idItem)
    {
        ExecuteARequest($"DELETE FROM Cliemt WHERE id_user = '{idItem}' ");
    }

    public void UpdateItemInDate(int idItem, string UpdateAdress)
    {
        ExecuteARequest($"UPDATE Cliemt SET adress = '{UpdateAdress}' WHERE id_user = '{idItem}' ");
    }

    private void ExecuteARequest(string request)
    {
        string connectionString = "Server=" + host + ";" + "Database=" + dateBase + ";" + "Uid=" + userName + ";" + "Pwd=" + password + ";charset=utf8;";

        //обьект БД 
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {

            //метод открытия БД        
            connection.Open();

            //проверка на открытие БД 
            if (!connection.Ping()) { Debug.Log("ошибка"); return; }
            
            //комманда соединения и запроса
            var command = new MySqlCommand { Connection = connection, CommandText = request };

            //переменная для получения результата
            var result = command.ExecuteReader();
            
            //бежим по всей БД и выводим данные в консоль
            while (result.Read())
            {
                var tempName = result.GetString("adress");
                var tempId = result.GetString("id_user");

                //Debug.Log(tempId + " " + tempName);
                
                Debug.Log(result.GetValue(5));
            }

            //метод закрытия БД
            //connection.Close();
        }
    }
}
