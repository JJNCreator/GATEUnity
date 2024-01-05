using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPoint;
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

        var cameraTarget = spawnPlayer.transform.Find("CameraTarget");
        spawnPlayer.GetComponent<PlayerController>().camera = Camera.main.transform;
        playerCamera.GetComponent<CinemachineVirtualCamera>().Follow = cameraTarget;
        playerCamera.GetComponent<PlayerCamera>().cameraTarget = cameraTarget;
    }
}
