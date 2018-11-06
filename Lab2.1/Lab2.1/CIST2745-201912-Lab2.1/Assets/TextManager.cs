using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace CIST2745
{
	public class TextManager : MonoBehaviour 
	{
		public Text X1;
		public Text Y1;
		public Text X2;
		public Text Y2;
		public Button finishedButton;
		public bool buttonPressed = false;

		//Transforms
		public Vector3 startPoint;
		public Vector3 endPoint;

		public int x1, y1, x2, y2;
		public float rise = 0f;
		public float run = 0f;
		public float slope = 0f;

		public int xDiff = 0;
		public int yDiff = 0;

		public BoxScript boxscript;
		public GridScript gridScript;
		public Line line;

		// Use this for initialization
		public void Start () {
			gridScript = FindObjectOfType<GridScript> ();
			line = FindObjectOfType<Line> ();
			boxscript = FindObjectOfType<BoxScript> ();

		}
		
		// Update is called once per frame
		public void Update () {

			//This is just a debugging piece of code to see
			//if the data is actually right.
			if (Input.GetKeyDown (KeyCode.B))
			{
				Debug.Log (X1.text);
			}
		}

		public void buttonPress()
		{
			
			x1 = int.Parse (X1.text.ToString ());
			y1 = int.Parse (Y1.text.ToString ());
			x2 = int.Parse (X2.text.ToString ());
			y2 = int.Parse (Y2.text.ToString ());


			//startPoint = new Vector3 (0f, 10f, 0f);
			//endPoint = new Vector3 (100f, 10f, 100f);
			startPoint = GameObject.Find ("Tile_" + x1.ToString () + "_" + y1.ToString()).transform.position;
			endPoint = GameObject.Find("Tile_" + x2.ToString() + "_" + y2.ToString()).transform.position;
			startPoint.y += 1;
			endPoint.y += 1;
			if (line != null)
			{
				line.DestroyLine ();
			}
			line.DrawLine(startPoint, endPoint, Color.black);

			calcSlope ();
		}

		public void calcSlope()
		{
			
			rise = y2 - y1;	//delta x
			run = x2 - x1; //delta y
			slope = rise / run; //obviously the slope

			Debug.Log ("Rise: " + rise);
			Debug.Log ("Run: " + run);
			Debug.Log ("Slope: " + slope);

			GameObject go = GameObject.Find ("Tile_" + x1.ToString () + "_" + y1.ToString ());
			go.GetComponent<Renderer> ().material = boxscript.ColorOn;
			GameObject.Find("Tile_" + x2.ToString () + "_" + y2.ToString()).GetComponent<Renderer> ().material = boxscript.ColorOn;

			/*
			#region fail(FIX THIS)
			for (int index = 0; index < x2; index++)
			{
				GameObject.Find("Tile_" + (x1 + rise + index).ToString () + "_" + (y1 + run + index).ToString()).GetComponent<Renderer> ().material = boxscript.ColorOn;
			}

			for (int index = 0; index < y2; index++)
			{
				//GameObject.Find("Tile_" + (x1).ToString () + "_" + (y1).ToString()).GetComponent<Renderer> ().material = boxscript.ColorOn;
			}

			#endregion //fail
			*/
		}


	}
}