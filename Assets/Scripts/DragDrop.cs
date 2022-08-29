using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{


    [SerializeField] private Canvas canvas;
    [SerializeField] private Camera camera;
    private GameObject player;
    SlotManager slotManager;

    private CanvasGroup canvasGroup;
    
    void Awake()
    {

        player = GameObject.Find("Player");
        canvasGroup = GetComponent<CanvasGroup>();
        slotManager = player.GetComponent<SlotManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");


        canvasGroup.blocksRaycasts = false;



    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        gameObject.transform.position = (Vector2) Camera.main.ScreenToWorldPoint(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;


    }

    public void OnPointerDown(PointerEventData eventData)
    {

        Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData)
    {

        Debug.Log("OnDrop");
    }
}
