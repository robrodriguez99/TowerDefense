using UnityEngine;

public class TurretBullet : Bullet {

	private Transform _target;

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

        Travel();

    }

    new public void Travel() => Move(_target.position - transform.position);

    new public void Move(Vector3 direction)
    {
        direction.Normalize();

        // Rotate towards the target
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);

        // Move towards the target
        transform.Translate(direction * MovementSpeed * Time.deltaTime, Space.World);

    }

}
