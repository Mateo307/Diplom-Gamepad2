using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;
using UnityEngine.SceneManagement;

public class Registration : MonoBehaviour
{
    public InputField loginInput;
    public InputField passwordInput;
    public Dropdown groupDropdown;

    private string connectionString = "Server=localhost;Database=kursach2;User ID=root;Password=110590Slava;";

    public void Register()
    {
        string login = loginInput.text;
        string password = passwordInput.text;
        string group = groupDropdown.options[groupDropdown.value].text;

        int groupId = GetGroupId(group);

        if (groupId == -1)
        {
            Debug.Log("Группа не найдена!");
            return;
        }

        MySqlConnection connection = new MySqlConnection(connectionString);

        try
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO users (логин, пароль, idроли, idгруппы) VALUES (@login, @password, 1, @group_id)";
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@group_id", groupId);
            command.ExecuteNonQuery();

            Debug.Log("Пользователь успешно зарегистрирован!");
        }
        catch (MySqlException ex)
        {
            Debug.Log("Ошибка при регистрации пользователя: " + ex.Message);
        }
        finally
        {
            connection.Close();
        }
    }

    private int GetGroupId(string groupName)
    {
        MySqlConnection connection = new MySqlConnection(connectionString);

        try
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT id FROM группа WHERE Группа = @group_name";
            command.Parameters.AddWithValue("@group_name", groupName);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetInt32(0);
            }
            else
            {
                return -1;
            }
        }
        catch (MySqlException ex)
        {
            Debug.Log("Ошибка при получении id группы: " + ex.Message);
            return -1;
        }
        finally
        {
            connection.Close();
        }
    }
}