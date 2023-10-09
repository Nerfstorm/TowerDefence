using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler { // 6:40, Simple Drag Drop - CodeMonkey

    //[SerializeField] private Canvas canvas;

    RectTransform rectTransform;
    Image Image;
    Camera cam;
    Canvas canvas;
    GameObject UIwoodParent;

    NotPoor pricekeeper;

    public GameObject ObjectUI;
    public GameObject ObjectPlacement;

    Vector2 startposition;

    private void Awake() {
        rectTransform = gameObject.GetComponent(typeof(RectTransform)) as RectTransform;
        Image = gameObject.GetComponentInChildren(typeof(Image)) as Image;

        cam = Camera.main;
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        UIwoodParent = GameObject.Find("UI/Canvas/ObstaclePanel/WoodSlot");
        startposition = this.transform.position;

        pricekeeper = (NotPoor)GetComponentInParent(typeof(NotPoor));
    }

    public void OnBeginDrag(PointerEventData eventData) {
        //Debug.Log("OnBeginDrag");
        var tempColor = Image.color;
        tempColor.a = 0.7f;
        Image.color = tempColor;
    }

    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; // va trebui inmulit cu marimea canvasului, cand pui toate chestile astea intr-un data script (difera de la telefon la altul)
    }

    public void OnEndDrag(PointerEventData eventData) {

        //if (rectTransform.position.y < 1920 && rectTransform.position.y > 610) Walling();
        //Instantiate(woodwallUI, UIwoodParent.transform);
        //Destroy(this.gameObject);
        Walling();
        this.rectTransform.position = startposition;
        var tempColor = Image.color;
        tempColor.a = 1f;
        Image.color = tempColor;
    }

    public void OnPointerDown(PointerEventData eventData) {
        //Debug.Log("OnPointerdown");   // habar n-am ce voiam sa fac aici
    }

    void Walling() {
        Instantiate(ObjectPlacement, Rounding(cam.ScreenToWorldPoint(Input.mousePosition)), Quaternion.Euler(0, 0, 0));
        CoinCount.RemoveCoinS(pricekeeper.price);
    }

    Vector2 Rounding(Vector2 position) {
     
        int x = (int)position.x;
        int y = (int)position.y;

        x = x - (x+1800) % 180 + 90;
        y = y - (y+600) % 60 + 30;

        return new Vector2(x, y);
    }

}
