using UnityEngine;

public class TurretBullet : MonoBehaviour, IBullet, IMovable {

	private Transform target;

	public GameObject impactEffect;

    public float Lifetime => throw new System.NotImplementedException();

	public float MovementSpeed => _movementSpeed;
	[SerializeField] private float _movementSpeed = 100f;

    public void Seek (Transform _target)
	{
		target = _target;
	}

	void Update () {

		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

        
            // Calculate direction towards the target
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            // Rotate towards the target
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);

            // Move towards the target
            transform.Translate(direction * _movementSpeed * Time.deltaTime, Space.World);
        
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

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        damageable?.TakeDamage(30);
		HitTarget();
    }

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * _movementSpeed * Time.deltaTime);
    }
}
