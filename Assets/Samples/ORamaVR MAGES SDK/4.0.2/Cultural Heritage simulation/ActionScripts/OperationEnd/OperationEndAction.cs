using MAGES.sceneGraphSpace;
using UnityEngine;
using System;
using MAGES.OperationAnalytics;
using MAGES.UIManagement;
using MAGES.Utilities;

public class OperationEndAction : MonoBehaviour, IAction
{

    #region Action Variables
    private GameObject exit;
    #endregion

    #region IAction Variables
    private string AName;
    private GameObject acNode;
    public string ActionName
    {
        get { return AName; }
        set { AName = value; }
    }
    public GameObject ActionNode
    {
        get { return acNode; }
        set { acNode = value; }
    }
    #endregion

    #region IAction Functions
    public void Initialize()
    {
        InterfaceManagement.Get.InterfaceRaycastActivation(true);

        exit = PrefabImporter.SpawnActionPrefab("OperationEnd/OperationExit");

        if (ORamaVR.RecorderVR.RecordingWriter.Instance.isRecording)
            ORamaVR.RecorderVR.RecordingWriter.Instance.EndRecording(true);
        else
            GameObject.Find("OperationExit(Clone)/InterfaceContent/RecordingUpload").SetActive(false);

        // Call OperationFinished to export Analytics
        AnalyticsMain.OperationFinished();
    } 

    public void InitializeHolograms()
    {
    }

    public void Perform()
    {
        DestroyUtilities.RemoteDestroy(exit);
    }

    public void Undo()
    {
        DestroyUtilities.RemoteDestroy(exit);
        InterfaceManagement.Get.InterfaceRaycastActivation(false);
    }

    public void SetNextModule(Action action)
    {
        // Empty
    }

    public void DifficultyRestrictions()
    {
        // Empty
    }

    public void DestroyAction()
    {
        throw new NotImplementedException();
    }
    #endregion

}
