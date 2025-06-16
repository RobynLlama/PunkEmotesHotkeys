using System.Linq;

namespace AnimationHotkeys;

public static class HotkeyQueen
{
  public static void SendEmoteChatMessage(string emoteName)
  {
    if (GetLocalPlayerObject() is not Player localPlayer)
    {
      AnimationHotkeysPlugin.Log.LogInfo($"Local player doesn't exist right now");
      return;
    }

    AnimationHotkeysPlugin.Log.LogInfo($"Sending this chat message `/em {emoteName.ToLower()}`");
    localPlayer.gameObject.GetComponent<ChatBehaviour>().Send_ChatMessage($"/em {emoteName.ToLower()}");
  }

  internal static Player? GetLocalPlayerObject()
  {
    if (AtlyssNetworkManager._current is null)
      return null;

    return AtlyssNetworkManager._current._connectedPlayers.Where(player => player.isLocalPlayer).FirstOrDefault();
  }
}

/*
using PunkEmotes;
using UnityEngine;

namespace AnimationHotkeys;

public static class HotkeyTest
{
  public static Plugin.PunkEmotesManager? localManager = null;

  public static void RunAnimationFromPunkEmotes(string anim, string? otherThing = null)
  {
    if (localManager == null)
    {
      AnimationHotkeysPlugin.Log.LogWarning("Trying to run an animation with a null animator! Don't do that, silly..");
      return;
    }

    if (GetAnimation(anim, otherThing) is not AnimationClip animClip)
    {
      AnimationHotkeysPlugin.Log.LogWarning($"Unable to play animation {anim} from category {otherThing}");
      return;
    }

    AnimationHotkeysPlugin.Log.LogInfo($"Found animation {animClip.name}, sending to PunkEmotes");
AnimationHotkeysPlugin.Log.LogInfo($"Sending this to PunkEmotes:\n  Animation: {anim}\n Category: {otherThing}");
    localManager.PlayAnimationClip("ALL", localManager, anim.ToLower());
  }

  public static AnimationClip? GetAnimation(string clip, string? whatever = null) =>
    PunkEmotes.Plugin.AnimationConstructor.AnimationLibrary.Instance.GetAnimation(clip, whatever);
}
*/
