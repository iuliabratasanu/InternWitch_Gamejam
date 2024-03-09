using UnityEngine;
using UnityEngine.EventSystems;

public class PotionDragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform potionTransform;
    private CanvasGroup canvasGroup;
    private Camera mainCamera;
    public GameObject mixingPot;

    private void Start()
    {
        potionTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        mainCamera = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Disable raycasting for this object during drag
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Update potion position during drag
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mainCamera.nearClipPlane; // Set the depth to be the same as the camera's near clip plane
        potionTransform.position = mainCamera.ScreenToWorldPoint(mousePos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Re-enable raycasting when the drag ends
        canvasGroup.blocksRaycasts = true;

        // Check if the potion was dropped over the mixing pot
        if (IsOverMixingPot(eventData.position))
        {
            // Handle mixing logic (check valid combinations, etc.)
            HandleMixing();
        }
    }

    private bool IsOverMixingPot(Vector2 mousePosition)
    {
        // Convert screen point to local point in the mixing pot's RectTransform
        RectTransform mixingPotRectTransform = mixingPot.GetComponent<RectTransform>();
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            mixingPotRectTransform,
            mousePosition,
            null,
            out localPoint
        );

        // Check if the local point is within the mixing pot's boundaries
        Rect mixingPotRect = mixingPotRectTransform.rect;
        return mixingPotRect.Contains(localPoint);
    }

    private void HandleMixing()
    {
        // Implement potion mixing logic here
        // You can communicate with the PotionShopGameplay script or perform any other actions
        Debug.Log("Potion mixed!");
    }
}