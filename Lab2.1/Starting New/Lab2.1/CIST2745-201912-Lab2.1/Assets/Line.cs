using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CIST2745
{
	public class Line : MonoBehaviour {

		TextManager textManager;
		BoxScript boxscript;
		GridScript gridscript;
		public Material lineColor;
		// Use this for initialization
		void Start () {
			textManager = FindObjectOfType<TextManager> ();
			boxscript = FindObjectOfType<BoxScript>();
			gridscript = FindObjectOfType<GridScript>();

		}

		// Update is called once per frame
		void Update () {

		}

		public void DrawLine (Vector3 start, Vector3 end, Color color)
		{
			GameObject myLine = new GameObject ();
			myLine.AddComponent<LineRenderer> ();
			myLine.transform.position = start;
			LineRenderer lr = myLine.GetComponent<LineRenderer> ();

			lr.material = new Material (lineColor);

			lr.SetColors (color, color);
			lr.startWidth = .5f;
			lr.endWidth = .5f;
			lr.SetPosition (0, start);
			lr.SetPosition (1, end);




		}
	}
}
