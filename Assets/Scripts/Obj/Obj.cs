using UnityEngine;

public abstract class Obj : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.instance.currentObject = this;
        Message.instance.Set(name);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Message.instance.Set();
        GameManager.instance.currentObject = null;
    }

    public abstract void Action();
}
