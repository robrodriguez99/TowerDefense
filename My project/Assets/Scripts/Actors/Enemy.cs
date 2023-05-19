using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Actor
{  
    private Transform _target;
    private int _wavepointIndex = 0;
    private int _damage = 10;

    protected override void Start()
    {   
        base.Start();
        _target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _actorStats.MovementSpeed * Time.deltaTime, Space.World);
        transform.LookAt(_target);

        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (_wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        _wavepointIndex++;
        _target = Waypoints.points[_wavepointIndex];
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject objectCollided = collision.gameObject;
        if(objectCollided.tag == "Finish")
        {
            EventManager.instance.ActionEnemySuccess(_damage);
            Destroy(this.gameObject);
        }

        if(objectCollided.tag == "Player")
        {
            IDamageable damageable = objectCollided.GetComponent<IDamageable>();
            if (damageable != null)
            {
                new CmdApplyDamage(damageable, 10).Execute();
            }
        }
    }

}
