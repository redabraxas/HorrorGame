using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject toastView;
    public Text toastText;
    public Text doButtonText;

    public void ShowToast(bool active, string text) {
        toastView.SetActive(active);
        if (text != null) {
            toastText.text = text;
        }
    }

    public void setDoButtonText(string text) {
        doButtonText.text = text;
    }
}
