using UnityEngine;
using System.Collections;

public class GameManager :MonoBehaviour {

    public string DO_SEARCH = "조사/행동";
    public string DO_OK = "확인";
    private bool isCancelable = false;

    public Player player;
    public UIManager uiManager;
    public DoorLock doorLock;

    public void ClickDoButton() {
        if (isCancelable) {
            uiManager.ShowToast(false, null);
            isCancelable = false;
            uiManager.setDoButtonText(DO_SEARCH);
            return;
        }

        // Background 레이어를 제외한 것을 탐색.
        RaycastHit2D hit = Physics2D.Raycast(player.getPosition(), player.getDirection(), 2, 9);
        if (hit.collider != null) {
            Do(hit.collider);
        }
    }

    public void ClickInventoryButton() {
        uiManager.ShowInventory();
    }

    public void ClickSettingButton() {
        // TODO(danhee):
    }

    private void Do(Collider2D collider) {
        switch (collider.name) {
            case "book":
                uiManager.ShowToast(true, "무언가 적혀있다. ...탈출하고 싶다...");
                uiManager.setDoButtonText(DO_OK);
                isCancelable = true;

                collider.GetComponent<GetItemObject>().GetItem();
                break;
            case "bed":
                uiManager.ShowToast(true, "내가 누워있던 침대. 많이 낡았다. 여기저기 헤져있다.");
                uiManager.setDoButtonText(DO_OK);
                isCancelable = true;

                collider.GetComponent<GetItemObject>().GetItem();
                break;
            case "door1":
            case "door2":
                doorLock.OpenDoorLockPopUp();
                isCancelable = false;
                break;
        }
    }
}
