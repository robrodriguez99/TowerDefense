using UnityEngine;

public class TurretBullet : MonoBehaviour, IBullet {

	private Transform _target;

	public GameObject impactEffect;

    public float Lifetime => throw new System.NotImplementedException();

	public float MovementSpeed => _movementSpeed;

    public float RotationSpeed => throw new System.NotImplementedException();

    [SerializeField] private float _movementSpeed = 100f;

    public void Seek (Transform target)
	{
		_target = target;
	}

	void Update () {

		if (_target == null)
		{
			Destroy(gameObject);
			return;
		}

        Move(_target.position - transform.position);

    }

	void HitTarget ()
	{
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectIns, 2f);
		Destroy(this.gameObject);
	}

    public void Travel()
    {
        throw new System.NotImplementedException();
    }

    public void OnTriggerEnter(Collider collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<Actor>().lifeController;
        damageable?.TakeDamage(10);
		HitTarget();
    }

    public void Move(Vector3 direction)
    {
        direction.Normalize();

        // Rotate towards the target
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);

        // Move towards the target
        transform.Translate(direction * _movementSpeed * Time.deltaTime, Space.World);

    }

    public void Rotation(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
}
