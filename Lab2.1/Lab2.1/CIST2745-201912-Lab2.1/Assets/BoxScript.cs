using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CIST2745
{

	public class BoxScript : MonoBehaviour {

		public Material ColorOff;
		public Material ColorOn;
		public Line line;
		public bool test = false;
		public TextManager textManager;

		public void ColorChange(bool State)
		{
			this.gameObject.GetComponent<Renderer>().material = (State) ? ColorOn : ColorOff;
		}

		// Use this for initialization
		public void Start () {
			line = FindObjectOfType<Line> ();
			textManager = FindObjectOfType<TextManager> ();
		}

		// Update is called once per frame
		public void Update () {
			if (Input.GetKeyDown (KeyCode.B))
			{
				plotLine(textManager.x1, textManager.y1, textManager.x2, textManager.y2);
			}
		}

		private void Clear()
		{
			int Height = 1;
			int Width = 1;
			BoxScript ts = null;
			GameObject go = null;

			for (int x = 0; x < Width; x++) 
			{
				for (int z = 0; z < Height; z++) 
				{
					go = this.gameObject.transform.Find("Tile_" + x.ToString () + "_" + z.ToString ()).gameObject;
					ts = go.GetComponent<BoxScript>();
					bool cOn = (((x % 2) == 0) && ((z % 2) == 0));
					ts.ColorChange (false);
				}
			}
		}


		public void plotLine(int x0, int y0, int x1, int y1)
		{
			Clear ();
			if (Mathf.Abs(y1 - y0) < Mathf.Abs(x1 - x0))
			if (x0 > x1)
				plotLineLow(x1, y1, x0, y0);
			else
				plotLineLow(x0, y0, x1, y1);
			else
				if (y0 > y1)
					plotLineHigh(x1, y1, x0, y0);
				else
					plotLineHigh(x0, y0, x1, y1);
		}

		public void plotLineHigh(int x0,int y0, int x1, int y1)
		{
			int dx = x1 - x0;
			int dy = y1 - y0;
			int xi = 1;
			if (dx < 0)
			{
				xi = -1;
				dx = -dx;
			}
			int D = 2*dx - dy;
			int x = x0;

			for (int y = y0; y<= y1;y++)
			{
				plot(x,y);
				if (D > 0)
				{
					x = x + xi;
					D = D - 2*dy;
				}
				D = D + 2*dx;
			}


		}

		public void plotLineLow(int x0,int y0, int x1,int y1)
		{
			int dx = x1 - x0;
			int dy = y1 - y0;
			int yi = 1;
			if (dy < 0)
			{
				yi = -1;
				dy = -dy;
			}
			int D = 2*dy - dx;
			int y = y0;

			for (int x = x0; x<= x1;x++)
			{
				plot(x,y);
				if (D > 0)
				{
					y = y + yi;
					D = D - 2*dx;
				}
				D = D + 2*dy;
			}
		}

		public void plot(int x, int y)
		{
			GameObject go = this.gameObject.transform.Find("Tile_" + x.ToString () + "_" + y.ToString ()).gameObject;
			BoxScript ts = go.GetComponent<BoxScript>();

			//GridScript.gridlist[x][y].GetComponent<Renderer>().material = GridScript.gridlist[x][y].GetComponent<BoxScript>().ColorOn;
			ts.ColorChange (true);
		}



	}
}