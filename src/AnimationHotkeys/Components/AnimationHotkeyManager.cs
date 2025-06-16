using UnityEngine;

namespace AnimationHotkeys;

public class AnimationHotkeyManager : MonoBehaviour
{
  public void Awake()
  {
    AnimationHotkeysPlugin.Log.LogInfo("AnimationHotKeyManager is active");
  }

  public void Update()
  {
    if (Input.GetKeyDown(KeyCode.Backslash))
    {
      AnimationHotkeysPlugin.Log.LogInfo("Backslash down");
      HotkeyQueen.SendEmoteChatMessage(AnimationHotkeysPlugin.HKConfig.BackslashEmote.Value);
    }
  }
}
