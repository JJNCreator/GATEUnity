using UnityEngine;
using System.IO;

public class UpdateVersionInfo
{
    public static void UpdateVersion()
    {
        var version = Resources.Load<TextAsset>("VersionInfo").text;
        var versionSplit = version.Split('.');
        var year = versionSplit[0];
        var major = versionSplit[1];
        var minor = versionSplit[2];
        var patch = versionSplit[3];
        var build = versionSplit[4].Split('p')[0];

        year = System.DateTime.Now.Year.ToString();
        int incrementBuild = int.Parse(build);
        incrementBuild++;
        build = incrementBuild.ToString();

        var newVersion = string.Format("{0}.{1}.{2}.{3}.{4}", 
            year, major, minor, patch, build);

        var writeVersion = new StreamWriter("Assets/Resources/VersionInfo.txt", false);
        writeVersion.WriteLine(string.Format("{0}", newVersion));
        writeVersion.Close();

    }
}
