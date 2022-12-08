using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    public void OpenChannelYoutube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UC9bAZ23ofknYSDHcd-shKjQ");
    }
    public void OpenChannelDiscord()
    {
        Application.OpenURL("https://discord.gg/C4fBwWZFF6");
    }
    public void OpenChannelTwitter()
    {
        Application.OpenURL("https://twitter.com/zewaffelman");
    }
}