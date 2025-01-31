using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public class UpdateVersionInfoBeforeBuild : IPreprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }
    public void OnPreprocessBuild(BuildReport report)
    {
        UpdateVersionInfo.UpdateVersion();
    }
}
