using Cysharp.Threading.Tasks;
using UnityEngine;

public class ToggleDarkness : MonoBehaviour
{

    private void OnEnable()
    {
        EventDelegates.onGameOver += ResetFog;
    }
    private void OnDisable()
    {
        EventDelegates.onGameOver -= ResetFog;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private async UniTask ToggleFog(bool on)
    {
        if(on)
        {
            while(RenderSettings.fogDensity < 0.08f)
            {
                RenderSettings.fogDensity += 0.001f;
                await UniTask.Yield();
            }
        }
        else
        {
            while(RenderSettings.fogDensity > 0f)
            {
                RenderSettings.fogDensity -= 0.001f;
                await UniTask.Yield();
            }
        }
    }
    private void ResetFog()
    {
        RenderSettings.fogDensity = 1f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ToggleFog(true).Forget();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ToggleFog(false).Forget();
        }
    }
}
