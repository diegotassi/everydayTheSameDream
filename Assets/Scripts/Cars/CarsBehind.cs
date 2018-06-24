using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CarsBehind : MonoBehaviour
{
    public Vector2 stepDistance = new Vector2(1, 2);
    public Vector2 stepTime = new Vector2(1, 2);

    Rigidbody2D body2d;
    Vector3 initialPosition;
    bool canMove = true;

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
        initialPosition = body2d.transform.position;
    }

    void OnEnable()
    {
        body2d.position = initialPosition;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(stepTime.x, stepTime.y));

            if (canMove)
            {
                float distance = Random.Range(stepDistance.x, stepDistance.y);
                body2d.DOMoveX(body2d.position.x + distance, distance).SetEase(Ease.InOutQuad).WaitForCompletion();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        body2d.DOKill();
        canMove = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        canMove = true;
    }

}

