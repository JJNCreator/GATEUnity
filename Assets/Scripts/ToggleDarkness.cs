using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ToggleDarkness : MonoBehaviour
{
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
        //RenderSettings.fogDensity = (on) ? 0.08f : 0f;
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
