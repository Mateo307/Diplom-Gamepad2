using UnityEngine;
using UnityEngine.SceneManagement;
using MySql.Data.MySqlClient;
using System;

public class LevelComplete : MonoBehaviour
{
    private MySqlConnection connection; // Переменная для соединения с БД
    private MySqlCommand command; // Переменная для выполнения запросов к БД

    public float endTime; // Время завершения уровня
    public int mistakes; // Количество ошибок
    public int hints; // Количество подсказок
    public int levelId; // Идентификатор уровня
    public float levelDifficulty; // Сложность уровня

    void Start()
    {
        // Строка подключения к БД
        string connectionString = "Server=localhost;Database=kursach2;Uid=root;Pwd=110590Slava;";

        try
        {
            connection = new MySqlConnection(connectionString);
            connection.Open(); // Открытие соединения с БД
            Debug.Log("Подключение к БД успешно");

            // Создание команды для вставки данных в таблицу "итоги_уровня"
            string insertQuery = "INSERT INTO итоги_уровня (end_time, mistakes, hints) VALUES (@endTime, @mistakes, @hints)";
            command = new MySqlCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@endTime", endTime);
            command.Parameters.AddWithValue("@mistakes", mistakes);
            command.Parameters.AddWithValue("@hints", hints);
            command.ExecuteNonQuery(); // Выполнение запроса на вставку данных

            // Создание команды для получения результата аддитивного критерия из БД
            string selectQuery = "SELECT additivecriterion FROM уровень WHERE id = @levelId";
            command = new MySqlCommand(selectQuery, connection);
            command.Parameters.AddWithValue("@levelId", levelId);
            float additiveCriterionResult = Convert.ToSingle(command.ExecuteScalar()); // Получение результата аддитивного критерия

            // Проверка результата аддитивного критерия и вывод соответствующей сцены
            if (additiveCriterionResult > 1.7)
            {
                SceneManager.LoadScene(1);
            }
            else if (additiveCriterionResult <= 1.7 && additiveCriterionResult > 1.0)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(3);
            }
        }
        catch (Exception ex)
        {
            Debug.Log("Ошибка подключения к БД: " + ex.Message);
        }
        finally
        {
            if (connection != null)
            {
                connection.Close(); // Закрытие соединения с БД
                Debug.Log("Отключение от БД");
            }
        }
    }
}