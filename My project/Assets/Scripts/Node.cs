using UnityEngine;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Vector3 positionOffset;

	private GameObject _turret;

	private Renderer _rend;
	private Color _startColor;

	void Start ()
	{
		_rend = GetComponent<Renderer>();
		_startColor = _rend.material.color;
    }

    public bool BuildTurret(int type)
    {
		Debug.Log(type);
		if (_turret != null)
		{
			Debug.Log("Can't build there! - TODO: Display on screen.");
			return false;
		}
		GameObject turretToBuild;

		if (type == 0) turretToBuild = BuildManager.instance.IceTurretToBuild;
		else turretToBuild = BuildManager.instance.StandartTurretToBuild;
        _turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
		return true;
    }


	void OnMouseEnter ()
	{
		_rend.material.color = hoverColor;
	}

	void OnMouseExit ()
	{
		_rend.material.color = _startColor;
    }

}
