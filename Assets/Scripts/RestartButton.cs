using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RestartButton : MonoBehaviour
{
    public void Restart()
    {
        DebugCommand();
    }

    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
    }
#endif
    }

    public static void DebugCommand()
    {
        GameManager.changeColor = 1f;

        PlayerScript.currentHealth = 400;

        GameManager.playerdied = false;
        PlayerLose.playerLose = false;

        GameManager.playerdied = false;
        PlayerLose.playerLose = false;

        GameManager.playerLocation = true;
        PlayerScript.map1 = false;
        PortalScript.portalChecker = true;
        PortalScript.portal2Checker = true;
        GameManager.isReady2 = true;
        PortalScript.portal3Checker = true;
        PlayerMoveScript.player.position = new Vector2(769f, -3f);


        BossEvent.finishBoss = false;
        FindforPlayer.isBoss = false;
    }

}
