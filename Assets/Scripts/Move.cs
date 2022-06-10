using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class Move : MonoBehaviour
{ 
    PhotonView photonView;
    public float Speed;
    float h;
    float v;
    int[] values = {1,2};
    

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        
        if (photonView.IsMine)
        {
            GetComponent<MeshRenderer>().material.color = Color.green;

        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            h = Input.GetAxis("Horizontal");
            transform.position += Vector3.right * (Speed * Time.deltaTime) * h;
            v = Input.GetAxis("Vertical");
            transform.position += Vector3.forward * (Speed * Time.deltaTime) * v;
            if(Input.GetKeyDown(KeyCode.G))
            {
                photonView.RPC("RpcWithObjectArray", RpcTarget.AllViaServer, values as object);
                PhotonNetwork.Instantiate("Car", transform.position, Quaternion.identity);
            }
        }
    }
    /*public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);

        }
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();
        }
    }*/
    
   

    [PunRPC]
    void RpcWithObjectArray(int[] array)
    {
        //Color col = (Color)color;
        //this.GetComponent<MeshRenderer>().material.color = col;
        foreach(int items in array)
        {
            Debug.Log(items);
        }
    }
}
