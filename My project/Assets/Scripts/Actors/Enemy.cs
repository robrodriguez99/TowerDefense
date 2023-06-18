using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Actor, IStateful
{  
    private Transform _target;
    private int _wavepointIndex = 0;
    private int _damage = 10;
    Transform[] path;
    private float _movementSpeed;


    protected override void Start()
    {   
        base.Start();
        path = Random.Range(0f, 1f) > 0.5f ? Waypoints.mainPathPoints : Waypoints.altPathPoints;
        _target = path[0];
        _movementSpeed = _actorStats.MovementSpeed;
    }

    void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _movementSpeed * Time.deltaTime, Space.World);
        transform.LookAt(_target);

        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (_wavepointIndex >= path.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        _wavepointIndex++;
        _target = path[_wavepointIndex];
    }

    public IEnumerator SlowDown()
    {
        Debug.Log("Slowing Down");
        _movementSpeed = _actorStats.MovementSpeed * 0.5f;
        yield return new WaitForSeconds(3f); //wait 3 seconds
        _movementSpeed = _actorStats.MovementSpeed;
    }


    private void OnCollisionEnter(Collision collision)
    {

        GameObject objectCollided = collision.gameObject;
        if(objectCollided.tag == "Finish")
        {
            EventManager.instance.ActionEnemySuccess(_damage);
            Destroy(this.gameObject);
        }

        if (objectCollided.tag == "Player")
        {
            IDamageable damageable = objectCollided.GetComponent<IDamageable>();
            if (damageable != null)
            {
                new CmdApplyDamage(damageable, 10).Execute();
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        GameObject objectCollided = collision.gameObject;
        if (objectCollided.tag == "Finish")
        {
            EventManager.instance.ActionEnemySuccess(_damage);
            Destroy(this.gameObject);
        }

        if (objectCollided.tag == "Player")
        {
            IDamageable damageable = objectCollided.GetComponent<IDamageable>();
            if (damageable != null)
            {
                new CmdApplyDamage(damageable, 10).Execute();
            }
        }
    }

    public void TakeStatusEffect(string Status)
    {
        Debug.Log(Status);
        if(Status == "Ice")
        {
            StartCoroutine(SlowDown());

        }
    }
}

