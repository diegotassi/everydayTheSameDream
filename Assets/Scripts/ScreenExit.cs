using UnityEngine;

public class ScreenExit : MonoBehaviour {

    public bool right;

    void OnTriggerEnter2D(Collider2D other)
    {
        ScreenManager.instance.GoScreen(right);
    }
}
