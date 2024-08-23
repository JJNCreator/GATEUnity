using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;

public class BuildScript
{
    private const string BUILD_FOLDER_WINDOWS64_DEV = "Builds/Win64/Development/GATEUnity.exe";
    private const string BUILD_FOLDER_WINDOWS64_RELEASE = "Builds/Win64/Release/GATEUnity.exe";
    private const string BUILD_FOLDER_MACOS_DEV = "Builds/macOS/Development/GATEUnity";
    private const string BUILD_FOLDER_MACOS_RELEASE = "Builds/macOS/Release/GATEUnity";
    private const string BUILD_FOLDER_LINUX_DEV = "Builds/Linux/Development/GATEUnity";
    private const string BUILD_FOLDER_LINUX_RELEASE = "Builds/Linux/Release/GATEUnity";

    [MenuItem("Build/Windows/Development")]
    public static void BuildWindows64Development()
    {
        var options = new BuildPlayerOptions();
        options.target = BuildTarget.StandaloneWindows64;
        options.scenes = GetSceneNames();
        options.locationPathName = BUILD_FOLDER_WINDOWS64_DEV;
        options.options = BuildOptions.Development;

        var report = BuildPipeline.BuildPlayer(options);
    }
    [MenuItem("Build/Windows/Release")]
    public static void BuildWindows64Release()
    {
        var options = new BuildPlayerOptions();
        options.target = BuildTarget.StandaloneWindows64;
        options.scenes = GetSceneNames();
        options.locationPathName = BUILD_FOLDER_WINDOWS64_RELEASE;
        options.options = BuildOptions.None;

        var report = BuildPipeline.BuildPlayer(options);
    }
    [MenuItem("Build/macOS/Development")]
    public static void BuildMacOSDevelopment()
    {
        var options = new BuildPlayerOptions();
        options.target = BuildTarget.StandaloneOSX;
        options.scenes = GetSceneNames();
        options.locationPathName = BUILD_FOLDER_MACOS_DEV;
        options.options = BuildOptions.Development;

        var report = BuildPipeline.BuildPlayer(options);
    }
    [MenuItem("Build/macOS/Release")]
    public static void BuildMacOSRelease()
    {
        var options = new BuildPlayerOptions();
        options.target = BuildTarget.StandaloneOSX;
        options.scenes = GetSceneNames();
        options.locationPathName = BUILD_FOLDER_MACOS_RELEASE;
        options.options = BuildOptions.None;

        var report = BuildPipeline.BuildPlayer(options);
    }
    [MenuItem("Build/Linux/Development")]
    public static void BuildLinuxDevelopment()
    {
        var options = new BuildPlayerOptions();
        options.target = BuildTarget.StandaloneLinux64;
        options.scenes = GetSceneNames();
        options.locationPathName = BUILD_FOLDER_LINUX_DEV;
        options.options = BuildOptions.Development;

        var report = BuildPipeline.BuildPlayer(options);
    }
    [MenuItem("Build/Linux/Release")]
    public static void BuildLinuxRelease()
    {
        var options = new BuildPlayerOptions();
        options.target = BuildTarget.StandaloneLinux64;
        options.scenes = GetSceneNames();
        options.locationPathName = BUILD_FOLDER_LINUX_RELEASE;
        options.options = BuildOptions.None;

        var report = BuildPipeline.BuildPlayer(options);
    }
    private static string[] GetSceneNames()
    {
        var sceneNamesList = new List<string>();
        foreach(var scene in EditorBuildSettings.scenes)
        {
            sceneNamesList.Add(scene.path);
        }
        return sceneNamesList.ToArray();
    }
}
