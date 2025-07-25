using System;
using AnimationHotkeys.Config;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using UnityEngine;

namespace AnimationHotkeys;

[BepInPlugin(LCMPluginInfo.PLUGIN_GUID, LCMPluginInfo.PLUGIN_NAME, LCMPluginInfo.PLUGIN_VERSION)]
public class AnimationHotkeysPlugin : BaseUnityPlugin
{
  internal static ManualLogSource Log = null!;
  internal static HotkeyConfig HKConfig = null!;

  private void Awake()
  {
    //forward our logger
    Log = Logger;
    //forward our config file
    HKConfig = new(Config);

    // Log our awake here so we can see it in LogOutput.txt file
    Log.LogInfo($"Plugin {LCMPluginInfo.PLUGIN_NAME} version {LCMPluginInfo.PLUGIN_VERSION} is loaded!");

    try
    {
      var manager = new GameObject("AnimationHotkeyManager", [typeof(AnimationHotkeyManager)]);
      DontDestroyOnLoad(manager);
    }
    catch (Exception ex)
    {
      Log.LogError($"Unable to setup manager instance!\n{ex}\n");
    }


    if (HKConfig.BackslashEmote.Value.Equals("sitinit02"))
    {
      Log.LogWarning("Animation names have changed, rewriting your config to use the correct animation for sitinit02");
      HKConfig.BackslashEmote.Value = "chang_sitinit02";
      Config.Save();
    }
  }

}
