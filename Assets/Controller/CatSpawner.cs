using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class CatSpawner : MonoBehaviour {
    [Header("Attributes")]
    [SerializeField] float _spawnPerSecond = 10;
    [SerializeField] float _projectionStrength = 5f;
    [SerializeField] float _upInfluence = 3f;
    
    [Header("References")]
    [SerializeField] PlayerController _playerController;
    [SerializeField] Rigidbody _catPrefab;
    [SerializeField] Transform _spawnPoint;
    Timer _timer;

    void Start() {
        _timer = new Timer(1f / _spawnPerSecond);
        
        _playerController.SpawnCatAction.started += SpawnCatStarted;
        _playerController.SpawnCatAction.canceled += SpawnCatCanceled;
    }

    void OnDisable() {
        _playerController.SpawnCatAction.started -= SpawnCatStarted;
        _playerController.SpawnCatAction.canceled -= SpawnCatCanceled;
    }

    void SpawnCatStarted(InputAction.CallbackContext ctx) {
        _timer.OnTimerTick += SpawnCat;
        _timer.Start();
    }

    void SpawnCatCanceled(InputAction.CallbackContext ctx) {
        _timer.OnTimerTick += SpawnCat;
        _timer.Stop();
    }

    void SpawnCat() {
        var cat = Instantiate(_catPrefab, _spawnPoint.position, Quaternion.identity);
        var dir = Random.insideUnitSphere;
        cat.AddForce(dir * _projectionStrength, ForceMode.Impulse);
        cat.AddTorque(Random.insideUnitSphere * 100f, ForceMode.Impulse);
    }

    void Update() => _timer.Update(Time.deltaTime);
}
