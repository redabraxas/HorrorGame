using UnityEngine;

// Hosung Cha

public class Joystick : MonoBehaviour {

    public bool touch = false;
    public float sensitivity = 0.07f;       // 스틱 민감도

    private float radius;

    private Transform stick;
    private Vector2 startPosition;

    private GameObject player;

	// Use this for initialization
	void Start () {
        // 스틱의 최대 반경.
        radius = GetComponent<RectTransform>().sizeDelta.x / 2;

        stick = transform.FindChild("Stick");
        if (stick) {
            startPosition = stick.position;
        }

        player = GameObject.Find("Player");
	}

    public void OnDrag() {
        Vector2 pos = Vector2.zero;
        if (touch) {
            pos = Input.GetTouch(0).position;
        }
        else {
            pos = Input.mousePosition;
        }

        float delta = Vector2.Distance(pos, startPosition);     // 스틱이 중심에서 멀어진 거리.

        delta = delta > radius ? radius : delta;                // 스틱이 최대 반경을 넘어가지 않게 한다.
        Vector2 dir = (pos - startPosition).normalized * delta;

        stick.position = startPosition + dir;           // 스틱 이동.

        // 캐릭터를 이동시킨다.
        player.SendMessage("setDirection", dir * sensitivity);
    }

    public void OnEndDrag() {
        stick.position = startPosition;         // 스틱 원위치.

        // 캐릭터도 정지시킨다.
        player.SendMessage("setDirection", Vector2.zero);
    }
}
