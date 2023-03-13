using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.U2D;
using UnityEngine.Serialization;
using UnityEngine.Scripting.APIUpdating;

public class GameManager : Singleton<GameManager>
{
    public GameObject PlayerObj;
    public GameObject EnemyObj;
    public GameObject botObj;
    public GameObject[] TeamA = new GameObject[10];
    public GameObject[] TeamB = new GameObject[10];
    private int PlayerCount;
    public GameObject[] AllPlayers = new GameObject[10];

    bool IsNewPlayer = false;
    player Player1;
    player Player2;
    player Player3;
    player Player4;
    player Player5;
    player Player6;
    player Player7;
    player Player8;
    player Player9;
    player Player10;
    player Enemy;
    bot Bot;

    private void Start()
    {
         if(LoadHCS.client == true)
        {
            NetworkManager.Singleton.StartClient();
        }
        if (LoadHCS.host == true)
        {
            NetworkManager.Singleton.StartHost();
        }
        if (LoadHCS.server == true)
        {
            NetworkManager.Singleton.StartServer();
        }



    }

    public bot GetBot() { 
        return Bot;
    }
    public Vector3 GetPlayerPos(player Player)
    {
        return Player.GetPos();
    }

    public Vector2 GetPlayerPos2(player Player)
    {
        return Player.GetPos2();
    }
    public float GetPlayerRot(player Player)
    {
        return Player.transform.rotation.eulerAngles.z;
    }

    public float GetPlayerSens(player Player)
    {
        return Player.sensitivity;
    }
    public void SetPlayerSens(float sens,player Player)
    {
        Player.sensitivity = sens;
    }
    public Vector3 GetBotPos()
    {
        return new Vector3(Bot.rb.position.x, Bot.rb.position.y, 0);
    }

    public float GetBotRot()
    {
        return Bot.transform.rotation.eulerAngles.z;
    }

    public void GetHitBot(int dmg)
    {
        Bot.GetHit(dmg);
    }

    public bool GetPlayerSlow(player Player)
    {
        return Player.GetSlowPlayer();
    }

    public Vector2 GetPlayerVel(player Player) 
    { 
    return Player.rb.velocity;
    }
    public Vector2 GetPlayerMov(player Player)
    {
        return Player.GetAxis();
    }

    public void SetActiveWeaponPlayer(GameObject Player, string ActiveWeapon)
    {
        Player.transform.Find("PlayerBody").transform.Find("CutPlayer").gameObject.SetActive(false);
        Player.transform.Find("CanvaPlayer").transform.Find("Canvas").transform.Find("ArmeCycle").transform.Find("CutCanva").gameObject.SetActive(false);
        Player.transform.Find("PlayerBody").transform.Find("VandalPlayer").gameObject.SetActive(false);
        Player.transform.Find("CanvaPlayer").transform.Find("Canvas").transform.Find("ArmeCycle").transform.Find("VandalCanva").gameObject.SetActive(false);
        switch (ActiveWeapon)
        {
            case "Vandal":
                Player.transform.Find("PlayerBody").transform.Find("VandalPlayer").gameObject.SetActive(true);
                Player.transform.Find("CanvaPlayer").transform.Find("Canvas").transform.Find("ArmeCycle").transform.Find("VandalCanva").gameObject.SetActive(true);

                break;

            case "Cut":
                Player.transform.Find("PlayerBody").transform.Find("CutPlayer").gameObject.SetActive(true);
                Player.transform.Find("CanvaPlayer").transform.Find("Canvas").transform.Find("ArmeCycle").transform.Find("CutCanva").gameObject.SetActive(true);
                break;
        }
        
    }

    public bool IsNewPlayerSpawn() { return IsNewPlayer; }

    


    private void Update()
    {
        IsNewPlayer = false;
        PlayerObj = null;
        if(PlayerObj == null) 
        { 
            PlayerObj = GameObject.Find("Player(Clone)");
            if(PlayerObj != null ) 
            {
                for (int i = 0; i < AllPlayers.Length; i++)
                {
                    if (AllPlayers[i] == null)
                    {
                        // Assign name to PlayerObj and assign it to the available slot
                        PlayerObj.name = "Player" + (i + 1);
                        AllPlayers[i] = PlayerObj;

                        GameObject ConeVisionPlayer = GameObject.Find("Player" + (i + 1)).transform.Find("PlayerBody").transform.Find("ConeVisionPlayer").gameObject;   
                        GameObject CameraPlayer = GameObject.Find("Player" + (i + 1)).transform.Find("PlayerBody").transform.Find("Camera").gameObject;
                        GameObject BodyLightPlayer = GameObject.Find("Player" + (i + 1)).transform.Find("PlayerBody").transform.Find("BodyLight").gameObject;
                        GameObject ChargeurPlayer = GameObject.Find("Player" + (i + 1)).transform.Find("CanvaPlayer").transform.Find("Canvas").transform.Find("Chargeur").gameObject;
                        if (ChargeurPlayer != null) { ChargeurPlayer.GetComponent<RectTransform>().anchoredPosition = new Vector3(-115.71f, 46, 10f); }

                        GameObject bulletPlayer = GameObject.Find("Player" + (i + 1)).transform.Find("CanvaPlayer").transform.Find("Canvas").transform.Find("bulletPlayer").gameObject;
                        if (bulletPlayer != null) { GameObject.Find("Player" + (i + 1)).transform.Find("PlayerBody").GetComponent<shooting>().Bullet = bulletPlayer.GetComponent<UnityEngine.UI.Image>(); }

                        GameObject ReloadCircle = GameObject.Find("Player" + (i + 1)).transform.Find("CanvaPlayer").transform.Find("Canvas").transform.Find("ReloadCircle").gameObject;
                        if (ReloadCircle != null) { GameObject.Find("Player" + (i + 1)).transform.Find("PlayerBody").GetComponent<shooting>().RechargementCircle = ReloadCircle.GetComponent<UnityEngine.UI.Image>(); }

                        GameObject CountBullet = GameObject.Find("Player" + (i + 1)).transform.Find("CanvaPlayer").transform.Find("Canvas").transform.Find("Chargeur").gameObject;
                        if (CountBullet != null) { GameObject.Find("Player" + (i + 1)).transform.Find("PlayerBody").GetComponent<shooting>().CountBullet = CountBullet; }

                        GameObject PlayerEar = GameObject.Find("Player" + (i + 1)).transform.Find("PlayerBody").transform.Find("PlayerEar").gameObject;
                        if (PlayerEar != null) { GameObject.Find("Player" + (i + 1)).transform.Find("CanvaPlayer").GetComponent<Panel>().audiosoiurce = PlayerEar.GetComponent<AudioSource>(); }

                        GameObject VandalPlayer = GameObject.Find("Player" + (i + 1)).transform.Find("CanvaPlayer").transform.Find("Canvas").transform.Find("ArmeCycle").transform.Find("VandalCanva").gameObject;
                        if (VandalPlayer != null) { GameObject.Find("Player" + (i + 1)).transform.Find("PlayerBody").GetComponent<CycleArme>().Vandal = VandalPlayer.GetComponent<UnityEngine.UI.Image>(); }

                        GameObject CutPlayer = GameObject.Find("Player" + (i + 1)).transform.Find("CanvaPlayer").transform.Find("Canvas").transform.Find("ArmeCycle").transform.Find("CutCanva").gameObject;
                        if (CutPlayer != null) { GameObject.Find("Player" + (i + 1)).transform.Find("PlayerBody").GetComponent<CycleArme>().Cut = CutPlayer.GetComponent<UnityEngine.UI.Image>(); }

                        
                        GameObject SliderCamDistance = GameObject.Find("Player" + (i + 1)).transform.Find("CanvaPlayer").transform.Find("Canvas").transform.Find("Options").transform.Find("SliderCamDistance").gameObject;
                        if (SliderCamDistance != null) { SliderCamDistance.GetComponent<Slider>().value = 19;  }

                        GameObject CanvasPlayer = GameObject.Find("Player" + (i + 1)).transform.Find("CanvaPlayer").gameObject;
                        if (CanvasPlayer != null) { CanvasPlayer.GetComponent<Canvas>().worldCamera = CameraPlayer.GetComponent<Camera>();
                            CanvasPlayer.GetComponent<Canvas>().sortingLayerName = "ALL BUT NOT CHAR";
                            CanvasPlayer.GetComponent<Canvas>().sortingOrder = 10;
                        }
                        
                        CameraPlayer.name = "Camera" + (i + 1);




                        if (i % 2 == 0)
                        {
                            TeamA[i] = AllPlayers[i];
                            GameObject.Find("Player" + (i + 1)).transform.Find("PlayerBody").transform.position = new Vector3(GameObject.Find("SpawnTeamA").gameObject.transform.position.x + 2 * (TeamA.Length - 1), GameObject.Find("SpawnTeamA").gameObject.transform.position.y, GameObject.Find("SpawnTeamA").gameObject.transform.position.z);
                            ConeVisionPlayer.layer = 13;
                            CameraPlayer.GetComponent<Camera>().cullingMask |= (1 << 13);
                   
                            BodyLightPlayer.layer= 13;
                            
                        }
                        else
                        {
                            TeamB[i] = AllPlayers[i];
                            GameObject.Find("Player" + (i + 1)).transform.Find("PlayerBody").transform.position = new Vector3(GameObject.Find("SpawnTeamB").gameObject.transform.position.x + 2 * (TeamB.Length - 1), GameObject.Find("SpawnTeamB").gameObject.transform.position.y, GameObject.Find("SpawnTeamB").gameObject.transform.position.z);
                            GameObject.Find("Player" + (i + 1)).transform.Find("PlayerBody").transform.rotation = new Quaternion(0,0,180,1);

                            ConeVisionPlayer.layer = 14;
                            CameraPlayer.GetComponent<Camera>().cullingMask |= (1 << 14);

                            BodyLightPlayer.layer= 14;
                            
                            
                        }
                        IsNewPlayer = true;
                        PlayerObj = null;
                        break; // Exit the loop after assigning the player object
                    }
                }
                
                PlayerCount++;
            }

            
        }

    
        /*if (botObj == null)
        { 
            botObj = GameObject.Find("Bot");
        }*/
    }
}
