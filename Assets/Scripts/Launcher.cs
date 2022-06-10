using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;
 
 namespace Com.MyCompany.MyGame
{
    public class Launcher : MonoBehaviourPunCallbacks
    {
       
        void Start()
        {
            Connect();
        }
        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to master");
            PhotonNetwork.JoinLobby();
           
        }
       
        public void Connect()
        {
            // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
            if (PhotonNetwork.IsConnected)
            {
                // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
                

                Debug.Log("Joining Random room");

            }
            else
            {
                // #Critical, we must first and foremost connect to Photon Online Server.
                PhotonNetwork.ConnectUsingSettings();
                Debug.Log("Connecting to a new server");
               
            }

        }
        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
            Debug.Log("Connecting to lobby");
            PhotonNetwork.JoinRoom("mayank");
        }
        public override void OnJoinRoomFailed(short returnCode, string message)
       
        {
            Debug.Log("join random room failed creating a new room ");
            CreateRoom();
        }
        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel("Game");
        }
        public void CreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.CleanupCacheOnLeave = false;
            roomOptions.MaxPlayers = 2;
            PhotonNetwork.CreateRoom("mayank", roomOptions);
        }
        


    }
}