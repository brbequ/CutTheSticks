using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the queensAttack function below.
    static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
    {
        // There are 8 directions to move in.
        // This array tracks moves in each of eight
        // directions
        int[] moves = { 0, 0, 0, 0, 0, 0, 0, 0 };

        // For each compass direction from the queen
        // Calculate maximum moves possible
        // with no obstacles in the way.
        // i.e. the shortest distance to the edge on each path
        moves[0] = n - r_q;                               // N
        moves[1] = n - r_q < n - c_q ? n - r_q : n - c_q; // NE
        moves[2] = n - c_q;                               // E
        moves[3] = n - c_q > r_q - 1 ? r_q - 1 : n - c_q; // SE
        moves[4] = r_q - 1;                               // S
        moves[5] = r_q - 1 > c_q - 1 ? c_q - 1 : r_q - 1; // SW
        moves[6] = c_q - 1;                               // W
        moves[7] = n - r_q > c_q - 1 ? c_q - 1 : n - r_q; // NW

        // Loop through the obstacles making adjustments;                
        for (int i = 0; i < k; i++)
        {
            int row = obstacles[i][0];
            int col = obstacles[i][1];
            int idx;

            // Same row
            if (row == r_q)
            {
                if (col < c_q)
                    idx = 6; // W
                else
                    idx = 2; // E

                moves[idx] = Math.Abs(c_q - col) - 1;
            }

            // Same col                
            if (col == c_q)
            {
                if (row < r_q)
                    idx = 4; // S
                else
                    idx = 0; // N

                moves[idx] = Math.Abs(r_q - row) - 1;
            }

            // Diagonals
            if (Math.Abs(r_q - row) == Math.Abs(c_q - col))
            {
                // Determine the direction
                if (row > r_q)
                {
                    if (col > c_q)
                        idx = 1; // NE
                    else
                        idx = 7; // NW
                }
                else
                {
                    if (col > c_q)
                        idx = 3; // SE
                    else
                        idx = 5; // sW
                }

                // Moves between the obstacle and the queen
                int count = Math.Abs(r_q - row) - 1;

                // If the distance has shortened, update the moves array
                if (count < moves[idx])
                    moves[idx] = count;

            }
        }

        return moves.Sum();
    }

    static void Main(string[] args)
    {
        int n = 100;
        int k = 100;

        int r_q = 48;
        int c_q = 81;

        int[][] obstacles = new int[][]
        {
            new int[] {54, 87},
            new int[] {64, 97},
            new int[] {42, 75},
            new int[] {32, 65},
            new int[] {42, 87},
            new int[] {32, 97},
            new int[] {54, 75},
            new int[] {64, 65},
            new int[] {48, 87},
            new int[] {48, 75},
            new int[] {54, 81},
            new int[] {42, 81},
            new int[] {45, 17},
            new int[] {14, 24},
            new int[] {35, 15},
            new int[] {95, 64},
            new int[] {63, 87},
            new int[] {25, 72},
            new int[] {71, 38},
            new int[] {96, 97},
            new int[] {16, 30},
            new int[] {60, 34},
            new int[] {31, 67},
            new int[] {26, 82},
            new int[] {20, 93},
            new int[] {81, 38},
            new int[] {51, 94},
            new int[] {75, 41},
            new int[] {79, 84},
            new int[] {79, 65},
            new int[] {76, 80},
            new int[] {52, 87},
            new int[] {81, 54},
            new int[] {89, 52},
            new int[] {20, 31},
            new int[] {10, 41},
            new int[] {32, 73},
            new int[] {83, 98},
            new int[] {87, 61},
            new int[] {82, 52},
            new int[] {80, 64},
            new int[] {82, 46},
            new int[] {49, 21},
            new int[] {73, 86},
            new int[] {37, 70},
            new int[] {43, 12},
            new int[] {94, 28},
            new int[] {10, 93},
            new int[] {52, 25},
            new int[] {50, 61},
            new int[] {52, 68},
            new int[] {52, 23},
            new int[] {60, 91},
            new int[] {79, 17},
            new int[] {93, 82},
            new int[] {12, 18},
            new int[] {75, 64},
            new int[] {69, 69},
            new int[] {94, 74},
            new int[] {61, 61},
            new int[] {46, 57},
            new int[] {67, 45},
            new int[] {96, 64},
            new int[] {83, 89},
            new int[] {58, 87},
            new int[] {76, 53},
            new int[] {79, 21},
            new int[] {94, 70},
            new int[] {16, 10},
            new int[] {50, 82},
            new int[] {92, 20},
            new int[] {40, 51},
            new int[] {49, 28},
            new int[] {51, 82},
            new int[] {35, 16},
            new int[] {15, 86},
            new int[] {78, 89},
            new int[] {41, 98},
            new int[] {70, 46},
            new int[] {79, 79},
            new int[] {24, 40},
            new int[] {91, 13},
            new int[] {59, 73},
            new int[] {35, 32},
            new int[] {40, 31},
            new int[] {14, 31},
            new int[] {71, 35},
            new int[] {96, 18},
            new int[] {27, 39},
            new int[] {28, 38},
            new int[] {41, 36},
            new int[] {31, 63},
            new int[] {52, 48},
            new int[] {81, 25},
            new int[] {49, 90},
            new int[] {32, 65},
            new int[] {25, 45},
            new int[] {63, 94},
            new int[] {89, 50},
            new int[] {43, 41}
        };

        int result = queensAttack(n, k, r_q, c_q, obstacles);

        Console.WriteLine(result);
    }
}
