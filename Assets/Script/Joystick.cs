using UnityEngine;

// Hosung Cha

public class Joystick : MonoBehaviour {

    public bool touch = false;

    private float radius;

    private Transform stick;
    private Vector2 startPosition;

    private Player player;

	// Use this for initialization
	void Start () {
        // 스틱의 최대 반경.
        radius = GetComponent<RectTransform>().sizeDelta.x / 2;

        stick = transform.FindChild("Stick");
        if (stick) {
            startPosition = stick.position;
        }

        player = GameObject.Find("Player").GetComponent<Player>();
	}

    public void OnDrag() {
        Vector2 pos = Vector2.zero;
        if (touch) {
            pos = Input.GetTouch(0).position;
        }
        else {
            pos = Input.mousePosition;
        }

        Vector2 dir = (pos - startPosition).normalized;         // 스틱의 방향벡터.
        float delta = Vector2.Distance(pos, startPosition);     // 스틱이 중심에서 멀어진 거리.

        delta = delta > radius ? radius : delta;                // 스틱이 최대 반경을 넘어가지 않게 한다.
        stick.position = startPosition + dir * delta;           // 스틱 이동.

        // 캐릭터를 이동시킨다.
    }

    public void OnEndDrag() {
        stick.position = startPosition;         // 스틱 원위치.
        
        // 캐릭터도 정지시킨다.
    }
}
