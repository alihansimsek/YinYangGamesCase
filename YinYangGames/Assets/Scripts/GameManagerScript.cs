using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject ammoType;
    public GameObject target;
    public GameObject targetGrounds;
    public string playerID = "0";
    private ServiceManager sm;
    private int score;
    private float timePassed;
    private bool spawnAllowed = true;
    float targetGroundsWidth, targetGroundsLength;

    public int Score { get => score; set => score = value; }

    void Start()
    {
        timePassed = 0;
        Vector3 targetGroundsBounds = targetGrounds.GetComponent<MeshCollider>().bounds.size;
        targetGroundsWidth = targetGroundsBounds.x;
        targetGroundsLength = targetGroundsBounds.z;
        sm = gameObject.GetComponent<ServiceManager>();
    }
    void Update()
    {
        timePassed += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            GameObject shotObject = Instantiate(ammoType, Camera.main.transform.position, Quaternion.identity,gameObject.transform);
            shotObject.GetComponent<Rigidbody>().AddForce(ray.direction*1000);

        }
        SpawnTarget();
    }
    public void ScoreUp()
    {
        score++;
        string serviceScore = score.ToString();
        sm.increaseScore(playerID, serviceScore);
        Debug.Log("Score: " + score);
    }
    public void SpawnTarget()
    {
        if ((int)timePassed % 5 == 0 && spawnAllowed)
        {
            Instantiate(target, new Vector3(targetGrounds.transform.position.x + Random.Range(-targetGroundsWidth/2, targetGroundsWidth / 2), targetGrounds.transform.localPosition.y + 0.5f, targetGrounds.transform.position.z + Random.Range(-targetGroundsLength/2, targetGroundsLength / 2)), Quaternion.identity);
            spawnAllowed = false;
        }
        else if ((int)timePassed % 5 > 0)
        {
            spawnAllowed = true;
        }
    }
}
