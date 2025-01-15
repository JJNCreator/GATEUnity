using Cinemachine;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform[] _enemySpawnPoints;
    public TaskDataSO[] taskItems;
    public WaypointGroup[] waypointGroups;
    public PlayerController player;
    public GameObject playerCamera;
    public Slider playerHealthBar;
    [SerializeField] private GameObject _minimapCamera;
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
        spawnPlayer.GetComponent<PlayerController>().playerCamera = playerCamera.transform;
        spawnPlayer.GetComponent<Health>().healthBarSlider = playerHealthBar;
        playerCamera.GetComponent<PlayerCamera>().target = cameraTarget;
        _minimapCamera.transform.SetParent(spawnPlayer.transform, false);
        _minimapCamera.transform.position = new Vector3(0f, 0f, 0f);
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
            spawnEnemy.GetComponent<EnemyController>().waypoints = GetWaypointGroup(i).waypointChildren;
            spawnEnemy.GetComponent<TaskHolder>().taskData = taskItems[i];
        }
    }
    public WaypointGroup GetWaypointGroup(int groupID)
    {
        return waypointGroups.First(group => group.groupID == groupID);
    }
    public void SpawnPlayerRagdoll()
    {
        var ragdoll = Instantiate(Resources.Load<GameObject>("PlayerRagdoll"),
            player.transform.position,
            player.transform.rotation);
    }
    public async UniTaskVoid SpawnEnemyRagdoll(Transform enemyPosition, int timeBeforeDestruction)
    {
        var ragdoll = Instantiate(Resources.Load<GameObject>("EnemyRagdoll"),
            enemyPosition.position,
            enemyPosition.rotation);

        await UniTask.Delay(timeBeforeDestruction);

        Destroy(ragdoll);
    }
}
