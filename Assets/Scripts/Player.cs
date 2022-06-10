using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
   
    
    void Start()
    {

        if (PhotonNetwork.IsConnected)
        {
          GameObject cube =  PhotonNetwork.Instantiate("cube", Vector3.zero, Quaternion.identity);
            


        }
    }

   
}
