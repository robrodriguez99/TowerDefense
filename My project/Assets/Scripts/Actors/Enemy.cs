using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Actor
{
  public float speed = 10f;
  
    private Transform target;
    private int wavepointIndex = 0;
    private int _damage = 10;

    protected override void Start()
    {   
        base.Start();
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            Debug.Log("AAAAAAAAAAAAAAA");
            EventManager.instance.ActionEnemySuccess(_damage);
            Destroy(this.gameObject);
        }
    }

}
