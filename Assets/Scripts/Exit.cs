using UnityEngine.SceneManagement;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public int id_сцены; // id сцены, которую нужно загрузить

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) // проверяем, нажата ли клавиша "v"
        {
            SceneManager.LoadScene(id_сцены); // загружаем сцену по ее id
        }
    }
}