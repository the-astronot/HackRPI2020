using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileRendering : MonoBehaviour
{

    public Sprite[] tile_sprites;
    public int[,] CityArray;
    public Coords start = new Coords(0,0);
    public Coords end = new Coords(10,10);
    public Grid roadgrid;
    public Tilemap roadmap;
    public int[,] TestMap;

    // Start is called before the first frame update
    void Start()
    {
        TestMap = GenerateCity.GetBasicMap();
        //roadmap = gameObject.GetComponentInChildren<Tilemap>();
        //CityArray = GenerateCity.GetMap(start, end);
        //Debug.Log(CityArray);
        CityArray = TestMap;
        for (int i=0; i<CityArray.GetLength(0); i++) {
            for (int j=0; j<CityArray.GetLength(1); j++) {
                RenderTile(new Coords(i,j), CityArray[i,j]);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RenderTile(Coords pos, int index) {
        Vector3Int pos3 = new Vector3Int(pos.x,pos.y,0);
        Tile tile = new Tile();
        tile.sprite = tile_sprites[index];
        roadmap.SetTile(pos3, tile);
    }
}
