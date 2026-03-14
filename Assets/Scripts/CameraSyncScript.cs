using UnityEngine;
using Cinemachine;

public class CameraSyncScript : MonoBehaviour
{
    private Camera mainCam;
    private CinemachineBrain cinemachineBrain;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        cinemachineBrain = mainCam.GetComponent<CinemachineBrain>();

        if (cinemachineBrain == null)
        {
            Debug.LogError("CinemachineBrain component not found on the main camera.");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SyncToMainCamera();
        }
    }
    void SyncToMainCamera()
    {
        if (cinemachineBrain != null && mainCam != null)
        {
            CinemachineVirtualCamera activeVCam = cinemachineBrain.ActiveVirtualCamera as CinemachineVirtualCamera;

            if (activeVCam != null)
            {
                activeVCam.transform.position = mainCam.transform.position;
                activeVCam.transform.rotation = mainCam.transform.rotation;
                
                if (mainCam.orthographic)
                {
                    activeVCam.m_Lens.OrthographicSize = mainCam.orthographicSize;
                }
                else
                {
                    activeVCam.m_Lens.FieldOfView = mainCam.fieldOfView;
                }

                Debug.Log("Cinemachine Virtual Camera synced to Main Camera.");
            }
            else
            {
                Debug.LogWarning("No active Cinemachine Virtual Camera found to sync.");
            }
        }
    }
}
