using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CarsAhead : MonoBehaviour {

    public float totalDistance = 8;
    public Vector2 stepDistance = new Vector2(1, 2);
    public Vector2 stepTime = new Vector2(1, 2);

    Rigidbody2D body2d;
    Vector3 initialPosition;
    
    void Awake ()
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
        float currentDistance = 0;

        do
        {
            yield return new WaitForSeconds(Random.Range(stepTime.x, stepTime.y));

            float distance = Random.Range(stepDistance.x, stepDistance.y);
            body2d.DOMoveX(body2d.position.x + distance, distance).SetEase(Ease.InOutQuad).WaitForCompletion();
            currentDistance += distance;
        }
        while (currentDistance < totalDistance);
    }
}

