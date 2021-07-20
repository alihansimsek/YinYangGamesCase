using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private GameManagerScript gameManager;
    private float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponentInParent<GameManagerScript>();
        timePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime; 
        if (timePassed > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target") {
            gameManager.ScoreUp();
            Destroy(collision.gameObject);
        }
    }
}
