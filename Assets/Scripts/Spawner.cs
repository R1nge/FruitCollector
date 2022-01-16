using System.Collections;
using UnityEngine;
public class Spawner : MonoBehaviour
{
	[SerializeField] private Collectable[] objectsToSpawn;
	[SerializeField] private float spawnInterval;
	[SerializeField] private int targetSpawnAmount;
	private Camera _camera;
	private int _spawnedAmount;

	private void Awake ()
	{
		_camera = FindObjectOfType<Camera>();
	}

	private void Start ()
	{
		StartCoroutine(Spawn_c());
	}

	private IEnumerator Spawn_c ()
	{
		while (enabled)
		{
			_spawnedAmount = FindObjectsOfType<Collectable>().Length;
			if (_spawnedAmount < targetSpawnAmount)
			{
				Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)],
					_camera.ViewportToWorldPoint(
						new Vector3(
							Random.Range(0f, 1f),
							Random.Range(0f, 1f)) + new Vector3(0, 0, 10)),
					Quaternion.identity);
			}

			yield return new WaitForSeconds(spawnInterval);
		}
	}
}
