using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks
{
    #region Private Serializable Fields

    [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;
    bool isConnecting;

    #endregion


    #region Private Fields
    //[Tooltip("The Ui Panel to let the user enter name, connect and play")]
    //[SerializeField]
    //private GameObject controlPanel;
    //[Tooltip("The UI Label to inform the user that the connection is in progress")]
    //[SerializeField]
    //private GameObject progressLabel;

    string gameVersion = "1";


    #endregion


    #region MonoBehaviour CallBacks


    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    void Start()
    {
        //progressLabel.SetActive(false);
        //controlPanel.SetActive(true);
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Z))
        {
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                isConnecting = PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
            }

        }
        if (Input.GetKey(KeyCode.X))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
    #endregion


    #region Public Methods


    public void Connect()
    {
        //progressLabel.SetActive(true);
        //controlPanel.SetActive(false);
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            isConnecting = PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }


    #endregion

    #region MonoBehaviourPunCallbacks Callbacks


    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
            isConnecting = false;
            Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
        }
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        //progressLabel.SetActive(false);
        //controlPanel.SetActive(true);
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("We load the 'Taiki' ");

            PhotonNetwork.LoadLevel("Taiki");
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            Debug.Log("We load the 'ButtleScene' ");

            PhotonNetwork.LoadLevel("ButtleScene");
        }
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
    }

    #endregion
}
