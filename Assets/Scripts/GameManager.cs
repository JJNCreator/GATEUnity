using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform[] _enemySpawnPoints;
    public PlayerController player;
    public GameObject playerCamera;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindFirstObjectByType<GameManager>();
            return _instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnPlayer()
    {
        var spawnPlayer = Instantiate(Resources.Load<GameObject>("PlayerController"), 
            _playerSpawnPoint.transform.position, 
            _playerSpawnPoint.transform.rotation);

        player = spawnPlayer.GetComponent<PlayerController>();
        var cameraTarget = spawnPlayer.transform.Find("CameraTarget");
        spawnPlayer.GetComponent<PlayerController>().camera = Camera.main.transform;
        playerCamera.GetComponent<CinemachineVirtualCamera>().Follow = cameraTarget;
        playerCamera.GetComponent<PlayerCamera>().cameraTarget = cameraTarget;
    }
    private void SpawnEnemies()
    {
        for (int i = 0; i < _enemySpawnPoints.Length; i++)
        {
            var spawnPoint = _enemySpawnPoints[i];
            var spawnEnemy = Instantiate(Resources.Load<GameObject>("EnemyController"),
                spawnPoint.position,
                spawnPoint.rotation);
            spawnEnemy.GetComponent<EnemyController>().target = player.transform;
        }
    }
}
