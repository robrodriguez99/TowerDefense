using UnityEngine;

[RequireComponent(typeof(IceTurret))]

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	public GameObject StandartTurretToBuild => _standardTurretToBuild;
    private GameObject _standardTurretToBuild;
    public GameObject IceTurretToBuild => _iceTurretToBuild;
    private GameObject _iceTurretToBuild;
    public GameObject standardTurretPrefab;
	public GameObject iceTurretPrefab;

    void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
    }


    void Start ()
	{
        _standardTurretToBuild = standardTurretPrefab;
		_iceTurretToBuild = iceTurretPrefab;
    }
}
