using UnityEngine;

public class Spitwad : MonoBehaviour
{
	public Vector3 Direction { get; set; }
	[SerializeField] private int damage = 4;
	[SerializeField] private float range = 20f;
	[SerializeField] private float speed = 50f;

	private Vector3 spawnPosition;

	void Start()
	{
		spawnPosition = transform.position;
		GetComponent<Rigidbody>().AddForce(Direction * speed);
	}

	void Update()
	{
		if (Vector3.Distance(spawnPosition, transform.position) >= range)
		{
			Stop();
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Enemy")
		{
			collision.transform.GetComponent<IEnemy>().TakeDamage(damage);
		}
		Stop();
	}

	private void Stop()
	{
		Destroy(gameObject);
	}
}
