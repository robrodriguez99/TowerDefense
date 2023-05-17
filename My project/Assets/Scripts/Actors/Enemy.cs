using UnityEngine;

public class Enemy : LifeController
{
  public float speed = 10f;
  
  private Transform target;
  private int wavepointIndex = 0;

    void Start()
    {
        //this.gameObject.AddComponent<Rigidbody>();
       // this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.gameObject.AddComponent<BoxCollider>();
        this.gameObject.GetComponent<BoxCollider>().size = Vector3.one * 4;

        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.LookAt(target);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

}
