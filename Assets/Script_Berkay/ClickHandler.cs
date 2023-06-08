using UnityEngine;
using TMPro;

public class ClickHandler : MonoBehaviour
{
    public GameObject[] targetObjects;
    public TextMeshProUGUI descriptionText;
    public GameObject panelObject; // Panel objesini tutacak public GameObject

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            if (hit.collider != null)
            {
                GameObject clickedObject = hit.collider.gameObject;

                bool isTargetObject = false;
                ObjectDescription objectDescription = null;

                foreach (GameObject targetObject in targetObjects)
                {
                    if (clickedObject == targetObject)
                    {
                        isTargetObject = true;
                        objectDescription = targetObject.GetComponent<ObjectDescription>();
                        break;
                    }
                }

                if (isTargetObject)
                {
                    // Tıklanan nesne hedef nesne ise açıklamasını ekranda göster
                    if (objectDescription != null)
                    {
                        descriptionText.text = objectDescription.description;
                        panelObject.SetActive(true); // Panel objesini etkinleştir
                    }
                }
                else
                {
                    // Tıklanan nesne hedef nesne değilse "not this one" mesajını ekranda göster
                    descriptionText.text = "Not this one";
                    
                }
            }
        }
    }

    public void ClosePanel()
    {
        panelObject.SetActive(false); // Panel objesini devre dışı bırak
    }
}
