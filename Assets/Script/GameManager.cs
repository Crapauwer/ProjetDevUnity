using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject PlayerObj;
    public GameObject botObj;

    player player;
    bot bot;

    private void Start()
    {
        player = PlayerObj.GetComponent<player>();
        bot = botObj.GetComponent<bot>();
        Debug.Log(player);

    }

    public bot GetBot() { 
        return bot;
    }
    public Vector3 GetPlayerPos()
    {
        return player.GetPos();
    }

    public Vector2 GetPlayerPos2()
    {
        return player.GetPos2();
    }
    public float GetPlayerRot()
    {
        return player.transform.rotation.eulerAngles.z;
    }

    public float GetPlayerSens()
    {
        return player.sensitivity;
    }
    public void SetPlayerSens(float sens)
    {
        player.sensitivity = sens;
    }
    public Vector3 GetBotPos()
    {
        return new Vector3(bot.rb.position.x, bot.rb.position.y, 0);
    }

    public float GetBotRot()
    {
        return bot.transform.rotation.eulerAngles.z;
    }

    public void GetHitBot(int dmg)
    {
        bot.GetHit(dmg);
    }

    public bool GetPlayerSlow()
    {
        return player.GetSlowPlayer();
    }

    public Vector2 GetPlayerVel() 
    { 
    return player.rb.velocity;
    }
    public Vector2 GetPlayerMov()
    {
        return player.GetAxis();
    }




}
