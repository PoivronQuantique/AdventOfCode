﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Jours
{
    public class Jour_4 : Jour_abs
    {
        #region Propriétés
        private Dictionary<int, Tuple<List<int>, List<int>>> Cards { get; set; } = new Dictionary<int, Tuple<List<int>, List<int>>>();
        private Dictionary<int, int> CardsPt2 { get; set; } = new Dictionary<int, int>();
        private Dictionary<int, long> CardsPt2Rec { get; set; } = new Dictionary<int, long>();

        #endregion

        #region Constructeur
        public Jour_4(bool debug = false):base(debug)
        {
            #region Input Data
            string InputData = "Card   1: 75 68 35 36 86 83 30 11 14 59 | 86 25 63 57 59 91 68 14 72 32 36 74 66 44 30 28 11 35 75 34 55 83 69 56 38\r\nCard   2: 49 62 66 89 53 16 59 19 58 99 | 99 29 21 59 53 66  1 77 15 92 98 23  9 49 75  4 16 12 62 89 58 82 19 60 14\r\nCard   3: 37 77  5 90 41 15 46 27 38 53 | 47 27 41 90 77 53 65 50 69 72 37 91  9 31 67 11 46 56 85 49 15 20 40  5 38\r\nCard   4: 97 24 29 70 37 95 83 78 66 19 | 24 44 21 29 39 51 78 79 66 97 19 88 89 35 83 95 84 70  6 34 62 32 37 72 80\r\nCard   5: 41 58 67 35 33 36 73 70 64 55 | 93 29 77 60 56 35 68 53  2 55  3 92 81 78  8 30 87 73 64 85 16 20 33  5 66\r\nCard   6: 25 72 59 52 79  4 17 15 69 41 | 98 84 36 15 71 67 53 34 26 48 43 90 94 89 85 81 45 29 47 75  7 82 27 19 96\r\nCard   7: 12 52 49 53 59 96 72  2 56 66 | 83 68 10 33 44 53 79 20 71 92 11 48 81 84 26 14 27 36 93 97 12 90 99 31 35\r\nCard   8: 53 46 23 30 11 20 64 81  7 18 | 58 46 97  6  8 53 75 18 33 64 23 73 11 10 20 44 86 67  4 68 30 81  7 91 15\r\nCard   9: 51 31 21 26 16 92 37 66  2 56 | 90  1 21 65 76 73 37 61 74 18 70 68 16  2 92 93 26 66 41 51 87 31 56 39 78\r\nCard  10: 97 65 81 32 36  9 35  5 60 29 | 92 80  6 29 20 30 85 11 60 10  7 62 36 70 17 43 79 72 89 34 97 32 35 77 39\r\nCard  11: 10 11 97 96 33 18 79 46 51 80 | 73 16 58 18 97 11 79 52 46 33 56 96 92 51 37  5 29  6 61 80 90 66 10 34 38\r\nCard  12: 66 26 81 28 20  1 59 11 70  9 | 81 72  5 27 26 97 78 16 94 62 47 75 43 37  1 25 44 60 51 55  7 63 87 12 93\r\nCard  13: 44 56 25 36 35 12  2 28 19 22 | 31  2 14 22 12 89 36 61 30 15 68 99  7 35 39 74 67 52 25 84 18 58 77 81 80\r\nCard  14: 69 28  5 99 31 46 84 26 66 37 | 21 15  5 69 35  2 85 44 58 90 27 94 86 50  9 97 24 84 30 18 28 99 36 37 59\r\nCard  15: 56 78 61 36 25 16 92 32 29 97 | 61  3 85 49 36 29 79 56 44 50 60 78 15 54 77 16 21 32 10 17 97  2 92  6 37\r\nCard  16: 16 43 91 36 27 19 49 70 79 68 | 40 51 26 95 10 44 90 12 88 85 86 34 94 32 41 81 66 17 87 53 83 72 18 14 45\r\nCard  17: 66 49 60 87  9 35 86 80 40 26 | 48  1 82 34 53 78 30  4 86 22 97 26 54  2 49 88 23 94 13 90 32 98 38 51 25\r\nCard  18:  7  1 88 50 42 51 60 58 21 66 | 29 53 16 52 77 99 98 54 70 97 17 96 15 91 40 87 45 72 75 11  2 32 81 26 82\r\nCard  19: 35 56 44 99 24 79 78  6 41 23 | 44 85 63 65 75 95 38  6 86 42 62 56 71 34  9 43 50 46 15 66 23 72 45 87 79\r\nCard  20: 90 42 20 45 98 86  1 13  9 25 |  8 93 14 29 23 59 61 62 85 15 72 89 21 91 92 66  4 90 31 10  5 87 79 47 11\r\nCard  21: 10 51  4 33 77 26 53 60 15 17 | 50 40 37 48 32 69 68 62 89 17  1 80 14 88  5 27 61 51 11 21 59 96 49 94 34\r\nCard  22: 12 68 81 66 61 20 28 64 62 44 | 42 23 53 48 13 88 70 50  3 80 95 25 22 99 55 30 26 78 47  9 27 73 92 56 15\r\nCard  23: 14 79 23 60 16 55 83 45 58 52 | 61 91  4 33 84  2 13 44 17 54 65 29 42 88 66 81 74 10 22 92 15 30  8 28  3\r\nCard  24: 38 11 15 57 50 47 31 98 33 96 | 34 64 52 67 49 24 63 54 51 92 29 22 41 73 17 84 12 53 32 71 28 86  2 75  8\r\nCard  25: 57 58 44 15 71 31 22 24 14 48 | 99 31 44 24 60 14 16  2 19 48 58 55 71 15 50 22 85 96 34 68 28  4 69 79 57\r\nCard  26: 44  4 24 52 21 81 69 38 32 55 | 22 52 44 62 15 55 34 79 41 81 61 21 27 43 40 51 24  4 23 69 75 31 32 38 92\r\nCard  27: 92 48 63 57 82 29 58  3 31 32 | 90 34 49 20 48 45 29 74 58 76 32  9  3 63 31 84 92 57 40 79  8 78 77 82 88\r\nCard  28: 88 63 12 31 87 27 21 40  4 26 | 19 12 14 87 66 47 85 42 86 10 56 91 29 98 97 37 21  6 30 82 34 80 23 63 89\r\nCard  29: 50 25 33 31 26 99  2 95 67 45 | 14 90  8 51 27 11 43 61 64 74 16 84 76 19 17 23 53 81 42 38 66 32 88 18 22\r\nCard  30: 80 85 86 93 12 35 79 43 95 32 | 47  7 67 93 76 16 95 86 45 23 18 70 30 32 90 12 43 79 24 80 48 10 85 60 35\r\nCard  31: 24 89 26 13 42 65 20 88 57 64 | 98  6  4 96 26 56 86 44 28 10 77 64 16 20 65 18 41 89 90 38 48 72 24 36 85\r\nCard  32:  9 81 55 58 34 49 46 71 70 15 | 45 49 92 99 17 10 85 61 28 78 94 48 88 62 80 63  1  3 95 24 69 11 82 33 50\r\nCard  33: 59 31  3 85 81 20 91 33 16 39 | 24  3 89 45 74 93 78 19 96 73 57  8 75 59 88 87 20 13 32 15 42 61 69 39 23\r\nCard  34: 11  6 74 83 98 71 26 82 97 84 | 93 66 76 82  2 89 16 98 11 80 83 20  6 26 84 32 13 21 97  3 78 74  9 71 43\r\nCard  35: 42 24 70 48  3 14 50 17 67  5 | 24 50 67 10 70 63 61 96 48  4 34 65 11 43 14 44 55 52 33 20 30 17 22  6  5\r\nCard  36: 18 11 66 31 93 88 90  8 39  7 | 13 54 16 74  8 68 93 31 90 28 41 18 66 30 55 81  7 29 88  6 39 12 11 65 47\r\nCard  37: 33 55  7 62 42 46 58 32 12 65 | 48 10 28 73 20 54 99 90 75 45 64 94 89 62 47 33 78 26 12  4 44 63 40 65 76\r\nCard  38: 95 27 45 14  7 23 73 22 36 86 | 67 53 10  6 12 46 48 16 62 61 51 85 74 80 56 20 52  5 79 92 69 41 26 13 64\r\nCard  39: 16 62 77 88 59  6 80 63 99 79 | 11  9 15  6 58 59  3 76 93 38 25 78 79 67 99 62 98  2 16 46 92 19 75 94 18\r\nCard  40: 13 64 53 78 88 10 39 47 69 81 | 63  2 55 89 60 86 65 79 24 47 11 49 62 74 30 43 54 57 83 35 90 33 45 34  3\r\nCard  41:  5 49 44 54 38 69 73 71 35 88 | 46 92 90  8 45 57 40 47 74 55 81 33 26 83 18 16 25 51 76 52 14  6 98  9 34\r\nCard  42: 46 12 17 64 79  8  4 62 37 89 | 26 99 14 51  8 66 60 80 52 79 23 44  6 89 30 55 73 36 25 92 35 15 63 62 42\r\nCard  43: 68 59  4 90 73 88 28 83 82 64 | 62 33 56 45 95 26 23 84 87 44 46 13 91 22 41 12 29 96 19 49 14 16 52  1 20\r\nCard  44: 76 13 98 40 54 14 72 71 83 55 | 86 75 68 16 62 15 79 35 23 34 39 18 99 47 42  1 29 92 70 94 37 21 90 36 65\r\nCard  45: 67 28 87 93  3 22 49 34 43 37 | 53 64 46 19 92 88 71  8 98 52 81 17 54 21 94  7 77 15 20 47 69 37 90 91 42\r\nCard  46: 24 41 12 39 95 69 16 56 30 15 | 81 98 34  4 52 48 66 57 71 72 60 51  7 11 14 65 31 73 97 68 18 67 80 90 74\r\nCard  47: 21 15 77 16 94 82 18 23 60 39 | 29 44 57 39 74 21 16 77 47  4 60 82 31  8 37 75 15 18 94 90 23 89 12 58 13\r\nCard  48: 25 90 68 93 10 60 30 80 82 67 | 82 96 61 56 83 50 63 57 25 70 86 80 93 30 34  3 79 67 68 49 53 39 90 60 10\r\nCard  49: 60 21 29 41 63 24 98 37 15 54 | 42 24 17 89 37 39  7 21 60 15 92 79 14 93 61 98 28 63 29 45 54 40 77 95 41\r\nCard  50: 43 29 50 84  5  9 73 49  1 65 | 93 35 72  8 91 19 85 89 32 75 14 16 69 57  1 49 43 73 28 71  2 84 54  3 11\r\nCard  51:  7 59 53 16  6 49 32  1 64 12 | 38  2 51 32 16 23 29 12 53 17 85 59  1 49 28 20 47  6 46 10  7 94 64 98 93\r\nCard  52: 23 80 74 19 90 37  7 15 47 21 | 41  4 24 70 83 60 11 18 69 36 25 78 85 14 75 95 64  1 56 16  9 30 96 15 90\r\nCard  53: 22 29 42 84 33 64 62 58 28 19 | 52 54 73 28 61 84 12 81 58 23 19 64 60 29 67 14 33 69 42 62 22 80 89 41  3\r\nCard  54:  6 38 14 43 88 62 56 41 91 79 | 25 43 53 80 54 41 50 82 13 88  1 59 36 42 62 92 10 66 79  6 89 14 56 47 51\r\nCard  55: 79 35 83 80  2 56 34 46 22 33 | 35 22 87 56 31 59  2 34 46 54 83 93 61 79 36 80 86 64 30 21 42 12 17  1 33\r\nCard  56: 27 60 38 62 32  6 39 94 33 88 | 86 97 56 64 93 80 71 88 34 46 60  6 41 69 11 27 53  8 33 38 94 10  2  1 91\r\nCard  57:  4  8 60 63 16 52 10 35 79 33 | 16 59 99 82  4 81  3 35 37 98  6 77 27  2 63 30 92 23 10 86 52 60 69 28 43\r\nCard  58: 46 72 21 59 38 11 53 31 13 99 | 65 63 93 40 30 94 71 86  7 56 37 55 69 22 34 61 70 74 36 10 54 43 28 23 32\r\nCard  59: 62 54 66 16 51 97 19 77 73 35 | 87 43 32 59 15 69 93  8 79  4 25 19 10 52 12 81  5 89 82 49 67 63 65  7 36\r\nCard  60: 35 66 37 64 10 90 50 57 46 32 | 51 96  4 29 53 15 47 98 25 46 79 62 22 12 13 32 44 91 18 33 75 14 17 10 16\r\nCard  61: 14 96 73 41 85  4 74  5 15 55 | 50 84 48 49 88 82 30 61 94 96 98 24 42  1 13 91 83 54 25 75 21 38 34  2 74\r\nCard  62: 15 28 75 50 60 12 67 71 22 27 | 33 90 64 57 42 82 19 87 76 97  1 24 65 27 75 47 68 84 60 83 32 62 52 40 77\r\nCard  63: 66 32 99 86 44 58 67 62 30  4 | 12 40 80 39 75 69 73 92 38 29 67 77 89 55 97  2 11 35 72 83 49  1 57 61 23\r\nCard  64: 84 57 76 95 43 81  2 59  8 63 | 72 15 92 69 79 74 95 53 75 64 50 78 25 44 20 87 88 40 91 82 65 30 96 16 31\r\nCard  65: 59 45 80 67 35  2 94 41 15 14 | 57 63 96 72 47 43 52 50 93 17 42 46 33 11 86 20 73 48  1 38 28 53 77 60 61\r\nCard  66: 30 74 44 92 36 13 84 91 96 89 | 47 40 35 13 69 89 36 14 67 30 11  3 65 24  8 74  4 41 96 84 64 26 44 92 91\r\nCard  67: 11 40 16 75 81 43 86 72 91 54 | 75 37 16 91 48 11 86 72  9 90 52 40 44 85 17 18 49 92 81 42 43 56 94 54 88\r\nCard  68: 66 67 77 21 87 96 88 81 89  9 | 63 34 58 84 89 66 57 68 81 51 88 54 87 85 99 67 77 96  9 29 17 21 75 82 30\r\nCard  69: 79 58 53  7 96 14 33 34  1 19 |  7 27 40 29 57 46 51 63 35 16 56 19 14 59 64 26 77 96 33  1 82 79 72 58 89\r\nCard  70: 97 79 38 41 77  9 99 75 17 93 | 96 39 14 54 16 83 37 51 20 38 97 19 17 87 99 74 79 77 41 93  9 25 66  3 75\r\nCard  71: 31  9 72 50 46 76 78 77  2 24 | 78 39 33 50 37 24 41  2 97 72  9 83 13 31 49 77 66 25 54 69 46 68 14 90 76\r\nCard  72: 93 71 62 79 72 30 40 28 82  4 | 30 24 83 95 19 40 78 18 28 47 71  1 21 33 62 80 79 38 72 48 82 25 93 81  4\r\nCard  73: 13 35 39 25  7 89 41 45 66 20 | 22 90 92 47 44 19 26 36 77 72 23 24 85 48 51 28 64 53 61 69  1 32 12  4 73\r\nCard  74: 52 78 40 80  8 86 94 68 87  1 | 94 62  1 51 68 36 73 40  8 15 78 58 52 80 84 82 32 74 76 87 86  7 85 72 28\r\nCard  75:  5  7 91 33 17 69 89 53 25 71 | 99 96 98  9 77 83 86  2 44 68 14 32 61 85 46 95 26 28 21 18 49 48 55 63 27\r\nCard  76: 35 19 36 47 25  8 15 85 77 95 | 64 11 25 36 72 41 63 76 45 97 65 49  1 47  8  6  4 90 30 75 23  7 50 33 86\r\nCard  77: 78 36  4 41 48 68 39 80 28 89 | 86 88 66 14 35 97 42 10 23 57 70 84 79  7 32 12 94 34 15 74 27 81  6 90 52\r\nCard  78: 91 33 48 92 13 49 60 81 45 68 | 96 33 49 85  7 82 93 60 48 45 36 81 68 34 52 92 13 46 26 91 38 41 84  8 63\r\nCard  79: 22 53 82 48 96 61 27 54 11 21 | 87  3 58 92 21 89  4 97 20 69 22  1 13 44 50  5 43 77 23 11 59 27 71 78 68\r\nCard  80:  8 21 41 33 72 37 71 66 22 83 | 79 63 17 87 74 94 47 22 66 37 16 91 65 61 68 71 67 46 97 40  3  5 21  4 33\r\nCard  81: 27 99 71 37 49 90 16 79 76 66 | 99 90 28 16 54 35 82 46 45 17  7 60 50 39 59 64 66 56 27 76 91 49 11 10 33\r\nCard  82: 42 99 30 13 94 63  3 19 89 29 | 85 51  7 68 14 92 72 12 19 31 93 13 32 78 33 20 55 81 99 77 47 41 15 91 70\r\nCard  83: 32 71 44 46 90 50 39 87 78  4 |  3  6  2 77 82 75 23 95  8  9 88 64 57 93 71 38 40 66 94 79 62 42 30 52 19\r\nCard  84: 60 89 66 34 37 57 44 80 54 25 | 41 77 47 49 96  7 18 92 51 20 83 31 56 55 46 60 45 40  6 65 97 21 42 69 82\r\nCard  85:  1  9 56  7 47  5 30 17 81 36 | 61 83 58 97 10 24  8 94 46 75 52 42 28 25 86 66 82 73 87 23 29 15 26 54 31\r\nCard  86: 87 17 81 13 21 29 70 65 39 98 | 11 38 35 66 20 23  3 81 17 19 24 77 61 55 28 94 92 30 37 42 97 27 12 76 91\r\nCard  87: 16 99 66 52 98 85 64 14 36  2 | 51 48 72 24 54 33 83 40 13 97 60 69 96 20 75 65 58  9 76 49 62 53 47 92 71\r\nCard  88:  2 14 59 25 93 10 30  9 11 80 | 96 85 27 77 84 47 43 69 70 78 58 20 65 38 55  1 34 72 67 57 68 62 83 17 86\r\nCard  89: 34 93 46 55  1 54 39 67  5 44 | 51  4 14 82 75 65 95 81  3 84 85 66 86 22 80 43 38 61 60 45 72 69 24 70 37\r\nCard  90:  2 69 96 64  1 19 47  3 17 29 | 22 86 44 41 40 70 84 21  7 43 62 88 82 83 32 28 75 42  8 76 54 98 91 85 97\r\nCard  91: 86 84 22 70 17 51 34 75 14 72 |  6 31 18  5 19 69 21 27 53  3 71 12 80 41 56  9 52 89 67 73 95 98 50 65 92\r\nCard  92: 40 13  2  4 58 85 72 19 38 66 | 67 81 11 69  7 20  5 70 12 45 16  4 52 96 56 71 48 64 94 99 26 59 97 50  8\r\nCard  93: 72 65 42 55 83 10 63 75 79  5 | 83 75  3 87 42 10 47 99 21 50 55 12 61 22 65 84 85 62 34 37 72 63  5 25 79\r\nCard  94: 15 29 78 36 80 83 62 63 88 21 | 88 83 54 72 36 21 63  6 62 25 34 71 15 29 78 95  9 86 80 87 14 51 69 17 22\r\nCard  95: 46 19 66 37  5 77 27 55 44 33 | 23  8 40 46 51 82 37 19 77 49 63 24 20 91 55 96 33 27 39  5 43 61 44 66  1\r\nCard  96: 40 71 18 81 30 97 94 43 77 85 | 89 34 92 12 31 52 43 40 71 97 77 14 10 38 85 61 56 94 62 18 54 16 81 30 50\r\nCard  97: 18 79 90 17 80 22 99 83 60 69 | 76 81 73 78 56 48 99 94 41 90  2  3 32 57 11 54 13 84 60 46 49 44 40  6 62\r\nCard  98: 80 63 44 84 32 75 24 97 91 70 | 23 28 79 55 11 48 93 32 12 86 20  4 36 77 94 65 37  3  2 95 83 26 29 63 54\r\nCard  99: 24 55 98 10 59 35 78 86 72 83 | 83 99 55 72 68 10 62 35 52 59 23 31 67 78 24 44 71 76 86 25 74 98 91 82 65\r\nCard 100: 34 14 66  5 74 76 30  4 42 35 | 30 49 10 82  7  4 62 68 72 81 14 61 85 29 60 44 69 67  5 42 93 34 54 39 13\r\nCard 101: 73 83 88 89 49 75  2 94  4 56 | 50 61 92 53 76  4 25  2 26 91 82 67 41 63 35 98 73 89 93 90 84 55 85 88 56\r\nCard 102: 49  8 64 86 30 83 33 74 19 98 | 24 97 33 92 60 20 37 21 76 66 40 65 31  8 41 98 77 86 84 54 47 72 62 30  1\r\nCard 103: 93 94 77 84 69 80 63 56 68 70 | 10 34 78 89  5 92 60 82 62 39 30 87 15 44 40 99  1 61 54 93  6 38 86 80 81\r\nCard 104: 54 84 83 27 18 12 14  4 92 75 | 54 46 64 20 15 14 37 30 34  1 68 38  8 32 41 16 17 36 12 49  9 59 61 31 67\r\nCard 105: 53 66 18 51  1 72 30 13 21 39 | 24 58 33 41 35 92 42 27 37 55 96 83 28 84 32  8 60 38 94 63 23 93 90 76 43\r\nCard 106: 18 38  5 40 47 88 75 19 98 81 | 84 12  2 38 68 23 62 48 20 60 29 36 70 16 53 56 42 58 73 86  3 45 51 92 46\r\nCard 107: 88  3 70 12 84 22 41 77 50 26 | 69 84 45 96  8 29 74 23 32 15 54 11 58 47 33  9 66 81 82 97 63 53 95 61 93\r\nCard 108: 67  6 40 22 87 80 57 41 39 33 | 30 66 44 56 84  9 80  2 65 69 10 92 63  8 32 81 90  3 60 71 40 25 24 93 72\r\nCard 109: 65 84 61 45  4 34 44 89 35 75 | 46 86 51 32 57 52 59 21 93 98 96 18 56 12 63 55  7 13 44 20  1 23 11 82 43\r\nCard 110:  3 70 67  8 59 13 93 99 52 83 |  2 68 16 39  7 77 75 64 57 47 56 30 73 62 20 82  4 31 28 81  1 19  6 76 32\r\nCard 111: 44 11 15 95 36 88 31 46 28 40 | 15 88 39  6 80 35 24 28 86 40 97 73 44 19 95 75 31 36 56 79 46 81 11 84 78\r\nCard 112: 99 27 74 32 44 63 35  4 85  1 | 12  4 44 88 70 53 16 35 77 58 10 24 38 47 80 25 32 89 27  1  9 74 45 86 94\r\nCard 113: 87  8 79 59 40 56 80 82 67 44 |  8 65 57 75 81 29 89 60 72 17 67 34 37 47 90 97 83  2 99 28 55 58 80 22 98\r\nCard 114: 78 44 69 83 34 39 58 26 87 53 | 37 84  4 34 41 81 35 49 79 85 66 31 48 58  5 96 91 43 82  8 73 77 14 27 53\r\nCard 115: 89 80 32 56 85 75 63 21 38 64 | 38 85  4 71 56 89 24 98 32 47 93 40 80 33 21 96 64 63 75 62  9 44 67 86 91\r\nCard 116: 66  5 23 29 97 58 20 48 30 80 | 10 78 29 25 66 87 43  5 76 88 99 28 48 97 26 80 20 58 86  6 23 67 21 30 79\r\nCard 117: 86 99 26  3 44 75 91 62 48 96 | 36  3 19 44  5 33 57 86 26 13 98 68 91 99 48 56 62 96 60 94 30 58  4 40 75\r\nCard 118: 46 53 84 64 52 36 43  5 51 72 | 27 40 82 65 34 31 61 88 68 45 78 36 96  8 74 58 81 90 18 98 51 77 73 25 66\r\nCard 119: 66 96 72 55 62 52 45 41 85 53 | 26 72 78 97 87 31 42 76 70 35 30 91 88 17 32 64 92 12 46 38 50 59 34 15 71\r\nCard 120: 74 13 12 21  4  9 27 79 85 84 |  9 88 55 15 51 22 94 47 59 53 93 65 92 80  1 67 10 28 98  8 18 56 81 31 14\r\nCard 121: 24 57 86 44  5 37 11 17 34 49 |  3 69 98 29 21 64 74 28 68  4 79  7 30 65 18 83 54  6 16 40 23 25 60 48 17\r\nCard 122: 98 35 60 50 21 20 18 84 76 15 |  6 81 29 14 15 68 45 75 43 33 31 54 35 34 98 27 63 49 87 18 20 19 28 84  2\r\nCard 123: 10 84 46  7 71  9 68 40 88 81 | 30 74 72 23 25 71 16 56 85 50 15 11 89 67  5  3 59 81 51 47 26 70 73 61 46\r\nCard 124: 99 76 66 81 11 42 44 17  6 21 | 17 21  4 19 96 22 39 81 44  6 74 55 66 75 99 85 79 86 73 48 24 27 45 11 92\r\nCard 125: 83 64 91 54 59 73 18 20 10 53 | 10 83 11 37 33  4 20 42 82 78 65 26 59 49 39 86  8 40 92 76 14 68 69 63 53\r\nCard 126: 89  8 18 80 24  7 94 31 93 54 | 62 75 19 89 52 31  3 36 87 35 82 80 22 25 94 97 17  8 96 59  2 10  4  1  6\r\nCard 127:  2 78 37 93 30 23 56 62 51 52 | 60 28 52 26 68 85  8 43 19 40  9 42 56 24 30 79 88 91 71 33 93 31 98 54 23\r\nCard 128: 26 55 97 30 36 66 72 73 15 98 | 86 62 53 76 13 16 99 94 25 65 90 34 81  4 56 49 69 68 29 41 46 59 52 45 82\r\nCard 129: 27  6 16 87 56  1 28 24 83 97 | 46 14 54 58 40 94 96  4 59 48 24  2 23  5 95 51  7 25 85 60 37 79 75 36 35\r\nCard 130: 24 67 17 27 66 32 36 31 77  3 | 97 49 57 96 81 89 41 18 86 82 12  6 52 16 10 65  2 60 90  9 64 13 71 22  7\r\nCard 131: 34 38 70 58 41 46 79 64 90 81 | 82 84 74 90 19 73 22 71 55 43 98 28 10 57 39 62 85 51  9  8  5 59 15 72 63\r\nCard 132: 10  9 39 95 66 14 69 44 73 89 | 37 85 32  4 58 79  7 87 55 40 92 68 27 99 13 88  6 86 98 26 41 50 94 21 91\r\nCard 133: 51 46 20 45 26 58 36 56 68 50 | 30 55 97  2 67 78 42 69 63 93 81  1 74 14 16 52 89 20 25 11 22 82 41 32 90\r\nCard 134:  3 84  4 98 57 72 35 37 75 42 | 54 26 58 42 68 57 37 35 72 92 87 90 75 11  4 81 82 51  8 71 93 63 84 98  3\r\nCard 135: 96 84 52 43 57 12 34  6  7 61 | 51 52 29 61 36 83 77 88 57 45 12 18 72  6 64 30 26 34 43  7 96 84 58 35 87\r\nCard 136: 63 52 45 17 56 44 41  7 76 68 | 94 11 14 43 47 89 74  9 82 80 81 73 67 92 16  2  8 61 50 91 40 96 97 84 10\r\nCard 137: 79 97 77 60 93 20 71 53 90 27 | 86 48 64 74 20  9 72 37 97 34 71 35 36 79 90 87 77 60 53 78 70 11  4  3 28\r\nCard 138: 54 91 30 72 11 98 34 59 17 80 | 18 57 89 72 73 70 19 98 17 80 91 75 59 83 54 11 63 60 39 30 85 40 44 69 34\r\nCard 139: 53 14 49 35 47 79 82 39 65  1 | 81  2 75 52 82 65 83 38 53 27  1 18 47 44 10 13 49 79 37 26 54 14 39 60 35\r\nCard 140: 92 20 84 44 78  4 23 22 15 38 | 92 48 56 45 23 43 38 20 24  4 25 16 32  1 15 78 26 22 63 71 44  6 13 84 11\r\nCard 141: 69  4 96 18 31 56 76 73  2 63 | 91 44 25 17 36 87 82 14 11 71 55 24 65 97 94 90  7 86 21 39 16 59 74 28  3\r\nCard 142: 36 84 27 91 33 45 29 90 68  1 | 61 36 16 22 14  5 58 47 80 68 51 86 89 85 48 38 32 45 35 44 84 98 83 28 11\r\nCard 143: 17  8 57  9 23 85 62 33 44 86 | 67 68 33 22 85 53 32 64 23 35 38 86 17 51 58 49 90 44 77  9  8 81 88 62 57\r\nCard 144: 42 36 23 74 87 46 15 57 21 89 | 82  1 68 10  8 13 98 67 46 75 52 42 79  3 28 38 84 86 34 43 41 81 93 91 74\r\nCard 145: 47 50 77 89 54 87 94  6 21  2 | 99  9 32 97 21 87 16 84 55 14 15  2 98 51 77 94 20  4 39 50 41 47 54  7 33\r\nCard 146: 52 23 65 51 72 71 28 41 62 92 | 93 55 28 37 20 31 62 67 39 41 58 74 72 13 52  3 68 71 11 23 42 90 99  1 43\r\nCard 147: 88 81 42  8 56 85 75 60 46 10 | 15  8 88 22 78 58 48 93  3 46 42 38 75  6 56 85 77 13 31 81 34 10 24 40 54\r\nCard 148: 28 81 55 69  6 61  8 80 34 74 | 25 55 64 34 43  9 32 37 28 91 13 36 93 38 49 48 52 19  2 20 68 65  6 79 14\r\nCard 149: 30 17 68 89 84 86  2 85 59 74 | 97 53 85 68 38 31 59 40 44  4 17 25  2 89 13 42  9 21 50 12 87 93 32 83 84\r\nCard 150: 98 41 62 35 80  4 37 45 48 61 | 79 53 36 34  4 92 83 80 58 81 29 39 98  3 14 73 48 71 28 32 44 12  9  1 15\r\nCard 151: 75 65 45 66 99 62 69  8 76 53 | 15 27 26 71 33 62 24 74 61 36 43 34 65 20 45  3 44  5 47 73  8 29 78 69 63\r\nCard 152: 29 91 25 33 96 59 22 56 90 85 | 15 10 45 19 50 28 96 71 46  2 32 67  8 47 30 83 20 48 57 76 77 18 81 49 25\r\nCard 153:  5 70 13 58 72 17 28 53 73 63 |  6 63 18 45 16 89 10 71 68  8 78 11 90 83 14  2 60 41 86 20 92 23 21 27 82\r\nCard 154: 38 57 44 92 97 51 53 76 22 13 | 39 50 63 58 85  5 31 43 67 32 54 69 72 62 36 45  7 33 41 64 71 81 84 21 75\r\nCard 155: 81 86 77  2 51  4 98 85 47 24 |  7 70 79 78 11 67 64 31 76 50 33 20 59 92 46 55 16 10 62 61 52 65 94 38 99\r\nCard 156: 39 69 49 46 84 62 37 28 12 80 | 35 54 20 73 21 67 72 93  8 82 33 59 61 31 13 45 77 53 74 32 40 19 83 36 47\r\nCard 157: 45 12 73 64 11 50 78 34 87 53 | 43 32 40 18 53 88  8 68 46 45 12 34 74 83 87 33 42 91 58  7 82 44 23  3  6\r\nCard 158: 91 89 80 26 37 94 66 20 51 42 | 66 89 20 91 68 30 51 26 42 63 81 28 96 94  9 88 12  5 87 59 37 80  8 31 16\r\nCard 159: 48 96 58 26 43 22  3 95 52  4 | 18 88 77 14 41 56 67 47 90 30 61 28 73 39 11 44 92 49 55 79 27 91 85 93 24\r\nCard 160: 12 40 90 73 85 25  8 94 97 95 | 35 99 25  7 97 12 90 40 95 96 73 26 69 74  8 65 94  2 85  6 38 23 55 79 52\r\nCard 161: 77 72 44 62  7 32 46 73 76 11 |  7 41 72 93 62 67 17 88 53 54 73 66 71 42 76 82 44 11 36 46 13 32 77 28 89\r\nCard 162: 69 93  2 89 35 21 39 33 84 98 | 33 84 43 94 71 49 68 39 75 61 93 25 10 47 35 27 20 89 48 21  4 69 98  6  2\r\nCard 163: 64 11 74 16 26 68 22 88 47 14 | 14  8  9 74 36 88 16 68 12 19 26 99 64 66 27 22 95 89 47 71 92 94 18 35 11\r\nCard 164: 82 69 65  9  4  8 28 91 33 88 | 92 34 65  9 82 91  8 28 88 33 61 72 46  6 11  4 20 69 16 96 36 68 81 75 30\r\nCard 165: 13 17 85  1 39 53 73 49 75 15 | 90 42  4 77 71 89  9 74 85 75 72 47 17 13 40 53  6 30 39 73 16 49 76  1 15\r\nCard 166: 62 84 15 89 14  6 61 24 63  8 | 76 61  7 72 85 24  6 42 71 11 66 55 62 70 83 51 96 23 63 18 68 16 86 15 67\r\nCard 167: 44 66 31 17 88 99 10 95 52 80 |  5 13 78 91  7 43 15 65 26 95 67 86 80 37 25 21 85 71 48 36 84 47 53 98 58\r\nCard 168: 20  5 61 79 18 42 78 15 58  4 | 41 35 79 63 20 70 69 66 94 57 84  6  2 80 49 18 78 93 27 72 50 24 86 51 55\r\nCard 169:  1 63 57 93 36  2 11 22 16 74 | 99 52 58 86 37 28 59 12 81 41 68 24 89 92 26 35 97 17 43  9 62 67  5 82 49\r\nCard 170: 89  5 18 92 64 67 83  6 30 13 | 86 92 90 89 95 20 29 64 94  6 10 80  1 67 32 58 17 15 36 93 74 83 13 14 30\r\nCard 171:  3 53 67 46 57 93 84 74 18 35 |  1 91 35 53 74 23 47 54 68 18 98 84 60 67 70 46 93 86 27 78 76  8 41 57 77\r\nCard 172: 64 51 57 83 61 50 98 44 81 80 | 48 36 98 84 30 27 92 33 93 45 77 56 68 91 10 64 99 44 37  1 32 86  7 34 85\r\nCard 173: 22 54 35 53 21 11 31 71 46 24 | 58 89 54 98 99 75 14 35 11 27 15 86 30 53 24  4 62 29 13 87 64 71 21 31 52\r\nCard 174: 69 72 51 48 79  7 76 94 52 88 | 16 68 96 28 38 26 39 83 98 49 37 99 80 22 95 29 74 41 12 78  9  4 67 62 20\r\nCard 175: 23 50 76 67 55 30 81 62 51 27 | 67 53 55 94 35  5 33 77 62 61 90 10 52 57 23  3 54 34 74 28 29 87 11 68 85\r\nCard 176:  3 77 61 47 74 70 26 81 35 37 | 63 85  1 12 71 44 77 25 67 87 15 10 69 46 98 52 90  3 21 64 16 26 36 48 75\r\nCard 177: 29 22 69 67 81 70 14 43  5 33 | 44 60 56 10 48 91  2 96 81 25 68 78 12 61 17 21 51 19 79  1 94 39 16  5 57\r\nCard 178: 72 63 36 17 26 70 38 87 94 56 | 37  5 29 93 64 97 20 24 56 17 25 12 74 71 47 51 83 98 30 55 16 18 86 15 39\r\nCard 179: 65 34 96 71  1 76 82 69 13  3 | 46 48 24 36  7 30  8 57  9 37 68 63 40 62 44 39 64  6 70 17 47 49 85 26 20\r\nCard 180: 87 70 67 33 84 51 59 36  7 31 |  2 91 25 65 66 23 62 22 29 96 34 59 54 55 52 32 16 10 13 24  5 63 18 48 97\r\nCard 181: 69  4 14 26 89 30 93 56 87 61 | 32 35 78 55 44 25 46 22 27 45  2  7 50 15 97 53 86 85 63  6 74 36  3 29 47\r\nCard 182: 66 49 41 67 17 10 19 83 90  2 | 90 93  7  5 37 60 11 42  6 16 76 98 13  8 94 45 77 32 64 82 62 52 61 81 59\r\nCard 183: 72 63 47 22 10 45 50 23  3 82 | 19  8 92 22 47 91 75 93 74 14 45 63 25 56 72 98 68  7 82 80 10 94 50  3 23\r\nCard 184: 23 84 64  4  9 16  8 81 82 27 | 23 41  4 36 33 81 42 16 27 78 40 87 29  2 64 10 44 69 84 68 80 79 26 57 11\r\nCard 185: 37 73 36 16 46 19 31 55  9 38 | 64 46 54 74 58 99 71 31 22 55 83 67 97 73 12 37 36 13 16 51 19 38  9 45 39\r\nCard 186: 12 95  3 46 39 66 11 45 93 76 | 73 21  6 91 55 45 86 74 88 66 82 14 69 29 98  9 90 54 10 50 40 34 89 77  3\r\nCard 187: 24 10 11 46  5 40 23 45 84 88 | 46 85 16  8 65 55 81 88 28  3 59 40 45 10  5 84 31 82 24  9 54 33 23 70 11\r\nCard 188:  8 58 85 60 22  1 77 86 33 99 | 60  8  1  7 15 63 92 67  5 62 87 19 99 85 66 48 43 41 86 34 73 37 81 59 58\r\nCard 189: 63 77 32 50  1 48 75 33 73 64 | 50 72 75 29  1 80 96  2 89 57 69 85 63 33 95 73  9 82 16 39 77  5 97 64 37\r\nCard 190: 79 81 74  6 23 95 29 84 62 12 | 88 71 83 64 98 69 60 34 61 50  7 21  6  2  5 82 10 36 78 32 11 86 37 85 49\r\nCard 191: 29 19 94 63 57 68  6 96  9 51 |  1 40 96 50 46 47 27  9 88 57 95 45 32 34  4 69 63 51 52 33 79 18 87 13 80\r\nCard 192:  2 37  8 67 14 76 23 29 93 17 | 25 61  7 14  9 82 21 29 62 80 65 58 39 73 33 44 27 22  8 87 51 19 37 10 17\r\nCard 193: 46 21 58 99 17 26 16  7 22 84 | 97 99 12 21 70 67 31 44 15 16 91 17 89 45 58 68 80 24 63 39 84 62 19 87 98\r\nCard 194: 36 93 81 31 35 98 57 76 14 21 | 11 14 29 30 26 62  5 55 97 81 31 65 77 61 93 36  2 24 70 75 17 35 92 57 68\r\nCard 195: 81 44 83 66  9 32 12  4 94 29 | 61 32 98 44 30 57 81 94 83 41 42 34 36 70  4 21 51 91  5 99  9 82 13 29 66\r\nCard 196: 19 41 80 11 74 58 47 15 93 81 |  1 69 85 42 65  6 29 57 63 45 19 70 88 27 31 11 48 83 58 72 33 25 32 54 15\r\nCard 197: 79 74 77 88 84 38 41 36 46 64 | 62 39 31 92 36 12 54 69 70  2 46 14 17 97 52 18 83 63 94 68 13 38  7 20 32\r\nCard 198:  8 89 96 68 22  2 73 13 25 42 | 13  9 82 28 67 75 55 31 39 77  6 23 48 15 37 33 26 30 34  2 88  1  3 35 12\r\nCard 199: 67 63 19  3 53 22 11 43 35 15 | 82 69 43 83 45 28 41 21  3 93 26 53 31 56 63  7 40 25 90 57 37 50 13 35  8\r\nCard 200: 26  8 73 24 56 37 64 67 94 65 | 50 42 91 37 98 17 72 22 24 66 53 39 95 78 65 25 80 92 18 94 89 15 71 29  7\r\nCard 201:  7 91 79 92 86 64 44 73 38 24 | 28 12  1  8 72 38 62 65 94 15 90 32 30 50  4 37 46 49 97 86 27 71 44 53 25\r\nCard 202: 65 81 61 69 10 76  3 66 44 46 | 32 84 99 30 22 54 60 67 47 33 53 91 21 35 15 45 62 43 98 63 87 95 19 93  2\r\nCard 203: 62  8 54 23 21 36 93 26 51 34 | 65 79 18 45 46 84 32 20 55  6 19 68 94 23 97 76 33 16 48 86  9 42 52 91 75\r\nCard 204: 63  8 26 49 37 10 80 48 83 19 | 60 95  9 15 30 92 78 29  2 74 16  7 81 43 75 77 41 79 18 64 97  3 28 20 45\r\nCard 205:  8 21  5 15 29  2 48 87 26 13 | 76 90 71 17 96 78 35  4 85 95 55 73 70 43 20 97 61 14 58 56 18 42  6 28 49\r\nCard 206: 41  1 34 22 18 15 16 66 43 19 | 24 74 32 28 96 38 68 35 97 84 94 61 51 91 56 16 29 52 50 92 72 67  7 44  1\r\nCard 207: 88 85 76 84 58 97 32 46 93 13 | 84  1 32 72  9 41 92 93 13 80 88 16 10 46 60 62 58  3 98 87 76  8 85 97 59\r\nCard 208: 69 54 50 57 96 53 43 30 76 17 | 95 41 33 10 96 30 92 74 57 55 50 53 63 68 84 85 54 43 19 76 98 17 39 31 69\r\nCard 209: 32 37 59 47 72 90 71 23 74  1 | 56 23 63 47  7 36 37 20 83 86 74 72 51 82 55 59 32 94 12  1 98  3 42 90  4\r\nCard 210: 98 26 32 92 69 53 59 12 45 89 | 45 32 71 35 41  6 59 16 53 78 62 72  1 92 69 12  2 76 26 34 36 22 40 89 98\r\nCard 211:  4 33 38 84 59 95 80 70 76  3 | 93 52 45 60 81 96 62  9 17 41 30 99 86 54 14 57 58 92 91 69 42  5 36 27 70\r\nCard 212: 74 82 19  3 99 10 13 15 17 90 | 77 40 99 10 54 61 58 17 51 11 57 15 94 86 90 74 44 81 14 24 26 36 43 70 37\r\nCard 213: 79 75 20 55 18  6 99 17 62 94 | 13  4 35  7 10  2 48 25 21 85 40  3 15 11 63 65 34 60 39 77 43  5 67 52 31\r\nCard 214: 24 34 58  4 98  1 87  6 54 42 | 24 29 88  4 90 65 73 17 23 57 56 39 33 11 25 76  5 99 96 37 61 13 86 38 71\r\nCard 215: 37 29 74 35 52 58 42 98 53 49 | 99 43 13 98 47 29 32  5 14 27 87 78 23 21 97 94 17 95 63 12 64 37 59 72 49\r\nCard 216:  4 54 14 92 12 21 98 25 19 70 | 72 49 65 94 93 76 33 91 10 22 69 36 37 62 40 13 28 34  5 99  6 47 56 59  1\r\nCard 217:  1 19 56 72 30 75 55 38 16 11 | 20 50 85 55 23 73 48 56 61 93 19  7 35 46  1 97 70  9 65 75 36 62 22 31 18\r\nCard 218: 38 28  1 50 10 24 13 31 69 26 | 23 25 78 87 29 19 90 15 56 17 63  9 74 89 91 75 50 21 59 51 54  4 16 82 36\r\nCard 219: 54 44 11 57 83 94 25 28 97 17 | 85 67 90 89  6 87 48 77  4  5 56 26 94 17 82 49 91 98 92 50 76 31 39 57 34\r\nCard 220: 20 72 33 25 54 39 34 56 51 27 | 67 33 87  5 71 29 97 72 21 46 41 13 98 47 38 99 64 66 95 62 26 82 89 52  2\r\nCard 221: 30 16 95 71 10 63 36  2 57 48 | 25 84 18  8 68 47 58  5  4 33 40 99 70 45 21  9 29 72 11 32 67  6 62 39 88\r\nCard 222: 60 34 77 64 92 54 58 78 33  1 | 20 85  7 17  2 66 70 84 42 29 87 44 43 12 95 15 16 41 79 35 47 75 53 46 36\r\nCard 223: 76 93 82 50 99 57 92  1 54  3 |  2  4 27  7 98 95 77 65 41 91 97 73 67 72 32 40 64 10 20 70 39 55 81 56 60";
            #endregion

            InitInputData(InputData);

            int i = 0;
            foreach (string ligne in Lines)
            {
                InitialisationLigne(i, ligne);
                i++;
            }

            if (Debug)
                DebugInit();
        }
        #endregion

        #region Initialisation
        /// <summary>
        /// Initialisation des données de travail pour une ligne.
        /// Pour chaque symbole, on crée une entrée de type <n° de ligne, n° colonne> dans PlacementSymboles
        /// Pour chaque nombre, on crée une entrée de type <nombre, n° ligne, n° colonne du premier chiffre, n° de colonne du dernier chiffre>
        /// </summary>
        /// <param name="Numero">Numéro de la ligne d'entrée</param>
        /// <param name="ligne">Données de la ligne d'entrée</param>
        private void InitialisationLigne(int Numero, string ligne)
        {
            var PremierSplit = ligne.Split('|').ToList();
            int NumeroCarte;
            List<int> NumerosGagnants = new List<int>();
            List<int> NumerosJoués = new List<int>();
            var Split1Temp = PremierSplit[0].Split(':').ToList();
            NumeroCarte = int.Parse(Split1Temp[0].Split(' ').Last());
            NumerosGagnants.AddRange(Split1Temp[1].Split(' ').Where(s=>!string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList());
            NumerosJoués.AddRange(PremierSplit[1].Split(' ').Where(s=>!string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList());


            Cards.Add(NumeroCarte, new Tuple<List<int>, List<int>>(NumerosGagnants, NumerosJoués));
        }
        #endregion

        #region Méthodes publiques
        public override long Partie1()
        {
            int NbLignes = Lines.Count;
            long TotalPart1 = 0;
            foreach (int numero in Cards.Keys)
            {
                TotalPart1 += PointsCarte(numero);
            }

            return TotalPart1;
        }

        public override long Partie2()
        {
            return ProcessPart2();
        }
        #endregion

        #region Process
        private long PointsCarte(int NumeroCarte)
        {
            List<int> NumerosGagnants = Cards[NumeroCarte].Item1;
            List<int> NumerosJoues = Cards[NumeroCarte].Item2;
            int nombreGagnants = NumerosJoues.Count(n => NumerosGagnants.Contains(n));
            CardsPt2.Add(NumeroCarte, nombreGagnants);
            if(nombreGagnants > 0)
            {
                return (long)Math.Pow(2, nombreGagnants-1);
            }
            else
            {
                return 0;
            }
        }


        private long ProcessPart2()
        {
            long nb = 0;
            foreach(int n in CardsPt2.Keys.ToList())
            {
                nb += ProcessCard(n);
            }
            return nb;
        }
        private long ProcessCard(int NumeroCarte)
        {
            if (CardsPt2Rec.TryGetValue(NumeroCarte, out long valeur))
            {
                return valeur;
            }
            else
            {
                long nb = 1;
                for (int i = 1; i <= CardsPt2[NumeroCarte]; i++)
                {
                    nb += ProcessCard(NumeroCarte + i);
                }
                CardsPt2Rec.Add(NumeroCarte, nb);
                return nb;
            }
        }
        #endregion

        #region Debug
        /// <summary>
        /// Fonction de debug de l'initialisation, par reconstruction de la matrice d'entrée et comparaison ligne à ligne
        /// </summary>
        private void DebugInit()
        {
        }
        #endregion
    }
}
