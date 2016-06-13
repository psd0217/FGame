using UnityEngine;
using System.Collections;
[AddComponentMenu("Xesos/UI/XS UIState")]
public class XSUIState : MonoBehaviour {

    public GameObject enableActive;
    protected bool init = false;
	// Use this for initialization
	void Start () {

        init = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnEnable()
    {
        if (enableActive != null && init == false )
            SetActive(enableActive.name);
    }

    void OnDisable()
    {
        init = false;
    }


    public void Reset()
    {
          for (int i = 0; i < this.gameObject.transform.childCount; ++i)
          {
              Transform t = this.gameObject.transform.GetChild(i);
              if (t == null) continue;

              if (t.gameObject.activeSelf == true)
                  t.gameObject.SetActive(false);
          }
    }


    public GameObject SetActive(string name)
    {
        GameObject go = null;
        for (int i = 0; i < this.gameObject.transform.childCount; ++i)
        {
            Transform t = this.gameObject.transform.GetChild(i);
            if (t == null) continue;

            if (t.gameObject.name.Equals(name) == true)
            {
                t.gameObject.SetActive(true);
                go = t.gameObject;
            }
            else
            {
                   t.gameObject.SetActive(false);
            }
        }

        init = true;

        return go;
    }

    public GameObject GetActive()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; ++i)
        {
            Transform t = this.gameObject.transform.GetChild(i);
            if (t.gameObject.activeInHierarchy == true)
                return t.gameObject;
         
        }
        return null;
    }

	public GameObject GetActiveSelf()
	{
		for (int i = 0; i < this.gameObject.transform.childCount; ++i)
		{
			Transform t = this.gameObject.transform.GetChild(i);
			if (t.gameObject.activeSelf == true)
				return t.gameObject;
			
		}
		return null;
	}

}
