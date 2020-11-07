using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Coords {
    public int x;
    public int y;
    public Coords(int x, int y) {
        this.x = x;
        this.y = y;
    }
}


public class GenerateCity
{

    public int[,] CityArray;
    public Coords start = new Coords(0,0);
    public Coords end = new Coords(10,10);

    public static int[,] GetMap(Coords start, Coords end) {
        Coords current = start;
        int size_x = Mathf.Abs(end.x - start.x) + 2;
        int size_y = Mathf.Abs(end.y - start.y) + 2;
        int base_x = Mathf.Min(start.x, end.x) - 1;
        int base_y = Mathf.Min(start.y, end.y) - 1;

        int[,] map = new int[size_x,size_y];

        for (int i=0; i<size_x; i++) {
            for (int j=0; j<size_y; j++) {
                map[i,j] = 0;
            }
        }


        return map;
    }

    public static int[,] GetBasicMap() {
        // 0 == 4 way intersection
        // 1 == Y travel
        // 2 == X travel
        // 3 == Grass
        int[,] BasicMap = {
            {0,2,2,2,2,0,2,2,2,2,2,0},
            {1,3,3,3,3,1,3,3,3,3,3,1},
            {1,3,3,3,3,1,3,3,3,3,3,1},
        };

        return BasicMap;
    }
}
