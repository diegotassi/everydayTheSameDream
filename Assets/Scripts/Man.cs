using UnityEngine;

public class Man : MonoBehaviour {

    public float speed = 2;

    public GameObject modelNaked;
    public GameObject modelDressed;
    
    Animator anim;
    Vector3 initialPosition;
    Rigidbody2D body;

    void OnEnable()
    {
        print("Man OnEnable");
        InputManager.instance.move += Move;
        InputManager.instance.action += Action;
    }

    void OnDisable()
    {
        print("Man OnDisable");
        InputManager.instance.move -= Move;
        InputManager.instance.action -= Action;
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        
        initialPosition = transform.position;
    }

    void Reset()
    {
        body.position = initialPosition;
        Dress(false);
    }

    void Update ()
    {
        anim.SetBool("moving", InputManager.instance.dir != 0);
    }

    public void Action()
    {
        var obj = GameManager.instance.currentObject;
        if (obj)
        {
            GameManager.instance.currentObject.Action();
        }
    }

    public void Move(float dir)
    {
        var movement = dir * Time.deltaTime * speed;
        body.MovePosition(new Vector2(transform.position.x + movement, transform.position.y));
        //transform.Translate(dir * Time.deltaTime * speed, 0, 0, Space.World);

        transform.localScale = new Vector3(dir, 1, 1);
    }

    public void Dress(bool dress)
    {
        modelNaked.SetActive(!dress);
        modelDressed.SetActive(dress);
    }

    public bool IsNaked()
    {
        return modelNaked.activeSelf;
    }

    public void SetXPositon(float x)
    {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
