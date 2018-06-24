using UnityEngine;

public class Car : MonoBehaviour {

    public float speed = .3f;
    public Rigidbody2D body;
    public ObjCar objCar;
   
    Vector3 initialPosition = Vector3.zero;

    void Awake()
    {
        initialPosition = transform.position;
    }

    void OnEnable ()
    {
        if (initialPosition != Vector3.zero)
        {
            body.position = initialPosition;
        }
        GetIn();
    }

    void OnDisable()
    {
        GetOut();
    }

    public void Move(float dir)
    {
        if (dir > 0)
        {
            body.velocity = Vector2.right * speed * dir;
        }
    }

    public void GetIn()
    {
        InputManager.instance.move += Move;
        InputManager.instance.action += GetOut;

        GameManager.instance.man.gameObject.SetActive(false);
    }
	
	public void GetOut()
    {
        InputManager.instance.move -= Move;
        InputManager.instance.action -= GetOut;

        GameManager.instance.man.gameObject.SetActive(true);
        GameManager.instance.man.SetXPositon(transform.position.x);
    }
}
