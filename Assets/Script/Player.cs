using UnityEngine;
using System.Collections;

public class Player :MonoBehaviour {

    public float speed = 3;

    protected Animator animator;
    private Vector2 vector;

    // NOTE: 컴퓨터에서 테스트 하기 위해 방향키로 조작하기 위해서는 false, 모바일에서 터치패드 이용 가능하게 하려면 true.
    public bool useTouchPad = false;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (!useTouchPad && animator) {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            bool walking = true;
            if (h > 0) {
                vector = new Vector2(1, 0);
            } else if (h < 0) {
                vector = new Vector2(-1, 0);
            } else if (v > 0) {
                vector = new Vector2(0, 1);
            } else if (v < 0) {
                vector = new Vector2(0, -1);
            } else {
                walking = false;
            }
            updatePlayer(vector, walking);
        }
    }

    public Vector2 getDirection() {
        return vector;
    }

    public Vector3 getPosition() {
        return transform.position;
    }

    public void updatePlayer(Vector2 vector, bool walking) {
        this.vector = vector;
        if (walking) {
            transform.Translate(vector * Time.deltaTime * speed);
        }
        animator.SetFloat("DirectionX", vector.x);
        animator.SetFloat("DirectionY", vector.y);
        animator.SetBool("Walking", walking);
    }
}
