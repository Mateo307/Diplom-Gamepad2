using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public class DatabaseManager : MonoBehaviour
{
    private MySqlConnection connection;
    private string connectionString;

    private void Start()
    {
        connectionString = "server=localhost;user=root;database=kursach2;password=110590Slava;";
        connection = new MySqlConnection(connectionString);
        connection.Open();
        
        // Теперь можно выполнить запросы к базе данных
    }

    private void OnDestroy()
    {
        connection.Close();
    }
}