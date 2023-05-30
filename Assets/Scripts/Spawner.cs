using Collectables;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Collectable[] objectsToSpawn;
    [SerializeField] private int targetSpawnAmount;
    private Camera _camera;
    private int _spawnedAmount;
    private IObjectResolver _objectResolver;
    
    [Inject]
    private void Construct(IObjectResolver objectResolver)
    {
        _objectResolver = objectResolver;
    }

    private void Awake() => _camera = FindObjectOfType<Camera>();

    private void Start()
    {
        for (int i = 0; i < targetSpawnAmount; i++)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        var instance = _objectResolver.Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)],
            _camera.ViewportToWorldPoint(
                new Vector3(
                    Random.Range(0f, 1f),
                    Random.Range(0f, 1f)) + new Vector3(0, 0, 10)),
            Quaternion.identity);
        instance.OnPickedUpEvent += OnPickedUp;
    }

    private void OnPickedUp(Collectable collectable)
    {
        Spawn();
        collectable.OnPickedUpEvent -= OnPickedUp;
    }
}