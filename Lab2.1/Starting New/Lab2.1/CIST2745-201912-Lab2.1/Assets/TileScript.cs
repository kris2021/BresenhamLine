using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CIST2745
{
	
	public class TileScript : MonoBehaviour {

		public Material ColorOff;
		public Material ColorOn;

		public void ColorChange(bool State)
		{
			this.gameObject.GetComponent<Renderer>().material = (State) ? ColorOn : ColorOff;
		}

		// Use this for initialization
		public void Start () {
			
		}
		
		// Update is called once per frame
		public void Update () {
			
		}
	}
}