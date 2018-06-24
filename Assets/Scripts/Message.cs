using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour {

    public static Message instance;

    Text text;

	void Awake()
    {
        instance = this;
        text = GetComponent<Text>();
    }

    public void Set(string msg = null)
    {
        text.text = msg;
    }
}
