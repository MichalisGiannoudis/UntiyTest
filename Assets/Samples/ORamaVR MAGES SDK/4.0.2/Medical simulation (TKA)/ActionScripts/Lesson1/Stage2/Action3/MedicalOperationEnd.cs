using MAGES.sceneGraphSpace;
using UnityEngine;
using System;
using MAGES.OperationAnalytics;
using MAGES.UIManagement;
using MAGES.Utilities;

public class MedicalOperationEnd : MonoBehaviour, IAction
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
    private int altPath = -1;
    public int AlternativePath
    {
        get { return altPath; }
        set { this.altPath = value; }
    }
    #endregion

    #region IAction Functions
    public void Initialize()
    {
        InterfaceManagement.Get.InterfaceRaycastActivation(true);


        exit = PrefabImporter.SpawnActionPrefab("Lesson1/Stage2/Action3/OperationExitMedical");
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
        DestroyUtilities.RemoteDestroy(GameObject.Find("FemoralGuideFinal(Clone)"));
        DestroyUtilities.RemoteDestroy(GameObject.Find("CuttingBlockFinal(Clone)"));

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
