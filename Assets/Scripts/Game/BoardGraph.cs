using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoardGraph
{
    public static int[] GetAdjacentNodes(string node)
    {
        int n = int.Parse(node);
        int[] r;
        switch (n)
        {
            case 0:
                r = new int[2];
                r[0] = 1;
                r[1] = 2;
                return r;
            case 1:
                r = new int[4];
                r[0] = 0;
                r[1] = 2;
                r[2] = 3;
                r[3] = 4;
                return r;
            case 2:
                r = new int[4];
                r[0] = 0;
                r[1] = 1;
                r[2] = 4;
                r[3] = 5;
                return r;
            case 3:
                r = new int[4];
                r[0] = 1;
                r[1] = 4;
                r[2] = 6;
                r[3] = 7;
                return r;
            case 4:
                r = new int[6];
                r[0] = 1;
                r[1] = 2;
                r[2] = 3;
                r[3] = 5;
                r[4] = 7;
                r[5] = 8;
                return r;
            case 5:
                r = new int[4];
                r[0] = 2;
                r[1] = 4;
                r[2] = 8;
                r[3] = 9;
                return r;
            case 6:
                r = new int[3];
                r[0] = 3;
                r[1] = 7;
                r[2] = 10;
                return r;
            case 7:
                r = new int[6];
                r[0] = 3;
                r[1] = 4;
                r[2] = 6;
                r[3] = 8;
                r[4] = 10;
                r[5] = 11;
                return r;
            case 8:
                r = new int[6];
                r[0] = 4;
                r[1] = 5;
                r[2] = 7;
                r[3] = 9;
                r[4] = 11;
                r[5] = 12;
                return r;
            case 9:
                r = new int[3];
                r[0] = 5;
                r[1] = 8;
                r[2] = 12;
                return r;
            case 10:
                r = new int[4];
                r[0] = 6;
                r[1] = 7;
                r[2] = 11;
                r[3] = 13;
                return r;
            case 11:
                r = new int[6];
                r[0] = 7;
                r[1] = 8;
                r[2] = 10;
                r[3] = 12;
                r[4] = 13;
                r[5] = 14;
                return r;
            case 12:
                r = new int[4];
                r[0] = 8;
                r[1] = 9;
                r[2] = 11;
                r[3] = 14;
                return r;
            case 13:
                r = new int[4];
                r[0] = 10;
                r[1] = 11;
                r[2] = 14;
                r[3] = 15;
                return r;
            case 14:
                r = new int[4];
                r[0] = 11;
                r[1] = 12;
                r[2] = 13;
                r[3] = 15;
                return r;
            default:
                r = new int[2];
                r[0] = 13;
                r[1] = 14;
                return r;
        }
    }

    public static int[] GetAdjacentNodes(int node)
    {
        int[] r;
        switch(node)
        {
            case 0:
                r = new int[2];
                r[0] = 1;
                r[1] = 2;
                return r;
            case 1:
                r = new int[4];
                r[0] = 0;
                r[1] = 2;
                r[2] = 3;
                r[3] = 4;
                return r;
            case 2:
                r = new int[4];
                r[0] = 0;
                r[1] = 1;
                r[2] = 4;
                r[3] = 5;
                return r;
            case 3:
                r = new int[4];
                r[0] = 1;
                r[1] = 4;
                r[2] = 6;
                r[3] = 7;
                return r;
            case 4:
                r = new int[6];
                r[0] = 1;
                r[1] = 2;
                r[2] = 3;
                r[3] = 5;
                r[4] = 7;
                r[5] = 8;
                return r;
            case 5:
                r = new int[4];
                r[0] = 2;
                r[1] = 4;
                r[2] = 8;
                r[3] = 9;
                return r;
            case 6:
                r = new int[3];
                r[0] = 3;
                r[1] = 7;
                r[2] = 10;
                return r;
            case 7:
                r = new int[6];
                r[0] = 3;
                r[1] = 4;
                r[2] = 6;
                r[3] = 8;
                r[4] = 10;
                r[5] = 11;
                return r;
            case 8:
                r = new int[6];
                r[0] = 4;
                r[1] = 5;
                r[2] = 7;
                r[3] = 9;
                r[4] = 11;
                r[5] = 12;
                return r;
            case 9:
                r = new int[3];
                r[0] = 5;
                r[1] = 8;
                r[2] = 12;
                return r;
            case 10:
                r = new int[4];
                r[0] = 6;
                r[1] = 7;
                r[2] = 11;
                r[3] = 13;
                return r;
            case 11:
                r = new int[6];
                r[0] = 7;
                r[1] = 8;
                r[2] = 10;
                r[3] = 12;
                r[4] = 13;
                r[5] = 14;
                return r;
            case 12:
                r = new int[4];
                r[0] = 8;
                r[1] = 9;
                r[2] = 11;
                r[3] = 14;
                return r;
            case 13:
                r = new int[4];
                r[0] = 10;
                r[1] = 11;
                r[2] = 14;
                r[3] = 15;
                return r;
            case 14:
                r = new int[4];
                r[0] = 11;
                r[1] = 12;
                r[2] = 13;
                r[3] = 15;
                return r;
            default:
                r = new int[2];
                r[0] = 13;
                r[1] = 14;
                return r;
        }
    }
}
