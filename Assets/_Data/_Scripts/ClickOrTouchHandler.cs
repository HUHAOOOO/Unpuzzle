using UnityEngine;

public class ClickOrTouchHandler : MonoBehaviour
{
    void Update()
    {
        // PC
        if (Application.isEditor || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleClickOrTouch(Input.mousePosition);
            }
        }

        // Mobile
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            HandleClickOrTouch(Input.GetTouch(0).position);
        }
    }

    void HandleClickOrTouch(Vector2 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Touched or clicked: " + hit.collider.transform.parent.name,gameObject);

            // Call OnInteract()
            hit.collider.gameObject.GetComponent<IInteractable>()?.OnInteract();
        }
    }
}
