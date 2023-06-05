using UnityEngine;
using TMPro;

public class InventoryCollider : MonoBehaviour
{
    [SerializeField] 
    TextMeshPro inventoryText;
    
    [SerializeField] private GameObject frontPanel, firstWire, secondWire;
    private int counter = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == firstWire.name ||
            other.name == secondWire.name ||
            other.name == frontPanel.name)
        {
            counter++;
            if (counter == 3)
            {
                inventoryText.text = "Приступите к сборке";
                Debug.Log("OnTriggerEnter() вызван");
                Debug.Log("Текст успешно изменен на: " + inventoryText.text);
            }
        }
    }
}