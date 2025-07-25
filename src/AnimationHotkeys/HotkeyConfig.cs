using BepInEx.Configuration;

namespace AnimationHotkeys.Config;

public class HotkeyConfig(ConfigFile config)
{
  public readonly ConfigEntry<string> BackslashEmote = config.Bind("Hotkeys", "Backslash Emote", "chang_sitinit02", "The emote you want to play when pressing backslash, make sure to test it with PunkEmotes first!");
}
