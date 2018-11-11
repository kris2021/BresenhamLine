using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CIST2745
{

	public class GridScript : MonoBehaviour {

		public int Height = 0;
		public int Width = 0;
		public int Scale = 1;
		public List<int> gridList;

		//public int[,] gridBox;

		public GameObject TileMaster;

		public int MaxWidth 
		{ 
			get { return Scale * Width;} 
		}
		public int MaxHeight 
		{ 
			get { return Scale * Height;} 
		}

		// Use this for initialization
		public void Start () {
			this.Initialize();
		}
		
		// Update is called once per frame
		public void Update () {
			
		}

		private void Initialize()
		{
			// Create Tiles

			for (int x = 0; x < Width; x++) 
			{
				for (int z = 0; z < Height; z++) 
				{
					Vector3 v = new Vector3(x*Scale, 0, z*Scale);
					Quaternion q = new Quaternion(0,0,0,0);
					GameObject go = GameObject.Instantiate(TileMaster, v, q);
					go.transform.parent = this.gameObject.transform;
					go.name = "Tile_" + x.ToString () + "_" + z.ToString ();
					BoxScript ts = go.GetComponent<BoxScript>();
					//bool cOn = (((x % 2) == 0) && ((z % 2) == 0));
					//ts.ColorChange (cOn);
				}
			}

			// Set Camera
			GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
			camera.transform.position = new Vector3 (MaxWidth/2, 20f, MaxHeight/2);
		}
	}
}