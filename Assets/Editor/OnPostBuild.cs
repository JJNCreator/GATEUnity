using System.IO;
using System.Runtime.InteropServices;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using Debug = UnityEngine.Debug;
using System.Diagnostics;

public class OnPostBuild : IPostprocessBuildWithReport
{
    public int callbackOrder {  get { return 0; } }
    public void OnPostprocessBuild(BuildReport report)
    {
        var outputPath = report.summary.outputPath;
        var directory = Path.GetDirectoryName(outputPath);
        Debug.Log("Build output path: " + outputPath);
        Debug.Log(string.Format("Build output path: {0}", outputPath));
        if(Directory.Exists(directory))
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start("explorer.exe", $"/n, /e, \"{directory}\"");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", directory);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", directory);
            }
        }
        else
        {
            Debug.LogError(string.Format("{0} could not be found. ", directory));
        }
    }
}
