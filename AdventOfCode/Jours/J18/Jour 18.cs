using System.Drawing;

namespace AdventOfCode.Jours
{
    public class Jour_18 : Jour_abs
    {
        #region Enumerables
        private enum Direction
        {
            Haut = 'U',
            Bas = 'D',
            Gauche = 'L',
            Droite = 'R'
        }
        #endregion

        #region Helpers
        private static Dictionary<Direction, (int, int)> OperationCoordonnees { get; set; } = new Dictionary<Direction, (int, int)>()
        {
            {Direction.Haut, (0, -1) },
            {Direction.Bas, (0, 1) },
            {Direction.Gauche, (-1, 0) },
            {Direction.Droite, (1, 0) }
        };
        private static Dictionary<Direction, Direction> GetInterne { get; set; } = new Dictionary<Direction, Direction>()
        {
            {Direction.Haut,    Direction.Droite },
            {Direction.Bas,     Direction.Gauche },
            {Direction.Gauche,  Direction.Haut },
            {Direction.Droite,  Direction.Bas}
        };
        private static Dictionary<char, Direction> Indication { get; set; } = new Dictionary<char, Direction>()
        {
            { '0', Direction.Droite },
            { '1', Direction.Bas },
            { '2', Direction.Gauche },
            { '3', Direction.Haut },
        };
        #endregion

        #region Propriétés
        private Surface? Terrain { get; set; }
        private Surface? Terrain2 { get; set; }
        #endregion

        #region Constructeur
        public Jour_18(bool debug = false):base(debug)
        {
            #region Input Data
            string InputData = "R 9 (#521d52)\r\nU 5 (#11e893)\r\nR 4 (#079312)\r\nU 4 (#5458e3)\r\nR 7 (#233422)\r\nU 3 (#664171)\r\nL 3 (#475012)\r\nU 6 (#312e21)\r\nR 6 (#024a22)\r\nU 3 (#335f61)\r\nL 6 (#699da2)\r\nU 4 (#3d7d41)\r\nL 6 (#699da0)\r\nU 7 (#125e51)\r\nL 3 (#1861e2)\r\nD 7 (#09f8e1)\r\nL 4 (#70eb32)\r\nD 10 (#31c8a3)\r\nR 4 (#0685e2)\r\nD 3 (#247e93)\r\nL 8 (#260972)\r\nU 7 (#36eca3)\r\nL 8 (#40b8d2)\r\nU 5 (#312e23)\r\nL 7 (#3c4242)\r\nU 8 (#50c7a3)\r\nR 6 (#21b062)\r\nU 7 (#443963)\r\nL 6 (#0f6920)\r\nU 5 (#2e1d73)\r\nL 3 (#6f8330)\r\nD 3 (#1a4943)\r\nL 5 (#5cebe2)\r\nD 12 (#27c9f3)\r\nR 5 (#220072)\r\nD 3 (#5adb73)\r\nL 6 (#317f72)\r\nD 2 (#053831)\r\nL 7 (#0c0802)\r\nU 5 (#124b51)\r\nL 5 (#198d90)\r\nD 11 (#46f3b1)\r\nL 5 (#198d92)\r\nD 2 (#5424f1)\r\nL 3 (#1232f2)\r\nU 4 (#408801)\r\nL 6 (#18cc52)\r\nU 4 (#3a6ed1)\r\nR 6 (#38c312)\r\nU 5 (#299193)\r\nL 3 (#2c9e72)\r\nU 3 (#5c2593)\r\nR 3 (#2cf822)\r\nU 5 (#33d851)\r\nR 4 (#1b0740)\r\nU 2 (#109221)\r\nR 9 (#1b0742)\r\nU 4 (#414cb1)\r\nL 7 (#0838d2)\r\nU 5 (#1ea173)\r\nL 2 (#3fcef2)\r\nU 7 (#3502f3)\r\nL 3 (#6d0672)\r\nU 3 (#0ea733)\r\nL 4 (#2c94c2)\r\nU 12 (#4ec103)\r\nL 4 (#041640)\r\nD 3 (#4bae23)\r\nL 3 (#4ff660)\r\nD 9 (#4bae21)\r\nL 4 (#458e90)\r\nD 7 (#202933)\r\nL 3 (#3fcef0)\r\nD 6 (#4b45b3)\r\nR 7 (#710a62)\r\nD 4 (#111783)\r\nR 4 (#264f12)\r\nD 4 (#19e183)\r\nL 5 (#361fa2)\r\nD 7 (#19e181)\r\nL 6 (#27a082)\r\nD 6 (#188573)\r\nL 7 (#187f60)\r\nU 8 (#343903)\r\nL 4 (#4719a0)\r\nU 4 (#1abc03)\r\nL 4 (#0e8d22)\r\nU 8 (#31faf3)\r\nL 3 (#7a8270)\r\nD 12 (#21cf23)\r\nL 4 (#7a8272)\r\nD 12 (#2cc503)\r\nR 4 (#0e8d20)\r\nD 5 (#0623c3)\r\nL 9 (#42cc80)\r\nU 3 (#320273)\r\nL 2 (#372482)\r\nU 5 (#11b943)\r\nL 7 (#10cb12)\r\nU 10 (#11b941)\r\nL 2 (#41f692)\r\nU 5 (#20ece3)\r\nL 5 (#13b450)\r\nU 6 (#367f33)\r\nL 3 (#2a3b50)\r\nD 9 (#1c7473)\r\nL 4 (#461d20)\r\nD 9 (#52f3a1)\r\nR 4 (#0bc750)\r\nD 5 (#208061)\r\nL 6 (#34c310)\r\nD 2 (#058993)\r\nL 5 (#0a5680)\r\nD 6 (#0a6a63)\r\nL 10 (#1056f0)\r\nD 2 (#47eba3)\r\nL 5 (#1056f2)\r\nD 3 (#3bd443)\r\nL 7 (#20ad20)\r\nD 9 (#05bb21)\r\nL 2 (#1efac0)\r\nD 7 (#770991)\r\nL 7 (#429760)\r\nD 11 (#16ef21)\r\nL 2 (#365170)\r\nU 11 (#208063)\r\nL 8 (#77b350)\r\nU 6 (#4828a3)\r\nL 5 (#023210)\r\nU 5 (#23f413)\r\nL 3 (#45da92)\r\nU 4 (#3712a3)\r\nR 6 (#45da90)\r\nD 5 (#4805f3)\r\nR 3 (#1d94d0)\r\nU 5 (#135023)\r\nR 5 (#12ee60)\r\nU 7 (#1ed111)\r\nL 4 (#1b3730)\r\nU 11 (#6b41c1)\r\nL 5 (#3ecd30)\r\nD 11 (#27e453)\r\nL 5 (#0e45d2)\r\nU 3 (#35a2b3)\r\nL 3 (#0e45d0)\r\nD 6 (#2c8bd3)\r\nL 3 (#510880)\r\nD 8 (#5860e3)\r\nL 5 (#318662)\r\nU 5 (#755013)\r\nL 3 (#318660)\r\nU 8 (#6ac523)\r\nL 3 (#233450)\r\nU 3 (#6aa731)\r\nL 4 (#498890)\r\nU 11 (#6aa733)\r\nR 2 (#46f1c0)\r\nU 10 (#41ea11)\r\nR 8 (#22c9f2)\r\nU 6 (#3198b1)\r\nR 6 (#7541d0)\r\nU 7 (#28ad81)\r\nR 6 (#7541d2)\r\nD 5 (#295961)\r\nR 9 (#22c9f0)\r\nU 5 (#396ab1)\r\nR 4 (#32ead0)\r\nU 8 (#4cd1e1)\r\nR 7 (#372ca0)\r\nU 5 (#192443)\r\nL 7 (#0df120)\r\nU 9 (#3417c3)\r\nL 5 (#2818d0)\r\nU 4 (#421ca1)\r\nR 6 (#444470)\r\nU 5 (#421ca3)\r\nL 9 (#147140)\r\nU 5 (#2c7e73)\r\nR 9 (#2c5cf0)\r\nU 3 (#6b8981)\r\nR 6 (#216860)\r\nU 6 (#37e4d1)\r\nR 4 (#10dd20)\r\nU 8 (#0f9fe1)\r\nR 3 (#596772)\r\nU 3 (#52ae11)\r\nR 7 (#596770)\r\nU 5 (#1cee91)\r\nR 4 (#3b6fc0)\r\nU 7 (#1dcb51)\r\nL 3 (#2360d0)\r\nU 4 (#643831)\r\nL 12 (#4537b0)\r\nU 4 (#180df1)\r\nR 9 (#31cd00)\r\nU 7 (#23f461)\r\nR 6 (#609520)\r\nU 7 (#10d611)\r\nR 3 (#2b2910)\r\nD 12 (#150921)\r\nR 5 (#45e700)\r\nD 5 (#4e7701)\r\nR 5 (#1eaa20)\r\nU 7 (#43e531)\r\nR 9 (#0f10f0)\r\nU 3 (#29c2d1)\r\nR 8 (#6ca0d0)\r\nU 10 (#28c611)\r\nR 3 (#19ef80)\r\nD 5 (#4d5381)\r\nR 9 (#30dd00)\r\nD 2 (#4c2151)\r\nR 4 (#480fe0)\r\nD 5 (#4bdcd1)\r\nR 4 (#4cc442)\r\nD 2 (#1122d1)\r\nR 3 (#08cce2)\r\nD 6 (#5309a1)\r\nR 4 (#1118f0)\r\nD 3 (#1e9b31)\r\nR 4 (#447830)\r\nD 10 (#0b6561)\r\nR 4 (#246dd0)\r\nD 7 (#5ca761)\r\nR 5 (#356150)\r\nD 4 (#09fb01)\r\nR 6 (#3786e2)\r\nD 7 (#5f9be1)\r\nR 7 (#42ca92)\r\nU 5 (#019611)\r\nR 8 (#1005b2)\r\nU 3 (#21ae81)\r\nR 6 (#173bf2)\r\nU 4 (#49b611)\r\nR 3 (#2022c0)\r\nU 6 (#33a5e1)\r\nR 8 (#3040d0)\r\nU 9 (#34b873)\r\nL 3 (#4a8800)\r\nU 2 (#34b871)\r\nL 5 (#06a780)\r\nU 5 (#08d321)\r\nL 4 (#4c2b40)\r\nU 6 (#696b43)\r\nL 4 (#1ca7c0)\r\nD 9 (#454c43)\r\nL 2 (#1f13f0)\r\nD 2 (#078593)\r\nL 7 (#1135a0)\r\nU 9 (#0641a3)\r\nR 3 (#0bf850)\r\nU 10 (#6b57e3)\r\nR 3 (#2d9de2)\r\nU 4 (#5f4661)\r\nR 7 (#33d1f2)\r\nU 6 (#5f4663)\r\nR 5 (#5a9aa2)\r\nU 6 (#4fc703)\r\nR 2 (#4f6cf0)\r\nU 2 (#0b8203)\r\nR 11 (#3efc40)\r\nU 5 (#0b8201)\r\nR 12 (#2da140)\r\nU 7 (#20f823)\r\nR 2 (#380710)\r\nU 6 (#339af3)\r\nR 3 (#514cf0)\r\nD 11 (#087ee3)\r\nR 7 (#4ad610)\r\nU 11 (#0e30f1)\r\nR 7 (#1235d2)\r\nU 9 (#60a251)\r\nL 6 (#3c6422)\r\nU 5 (#60a253)\r\nL 8 (#33f7d2)\r\nD 6 (#35e7b1)\r\nL 6 (#511ed2)\r\nU 6 (#087321)\r\nL 5 (#2e2a40)\r\nU 6 (#38d611)\r\nR 7 (#233f70)\r\nU 4 (#143ab1)\r\nL 10 (#05c470)\r\nU 4 (#007f61)\r\nL 5 (#189c70)\r\nU 4 (#633781)\r\nR 6 (#568f40)\r\nU 4 (#258a01)\r\nR 4 (#0d56c0)\r\nD 4 (#4866e1)\r\nR 5 (#4b3420)\r\nU 3 (#060511)\r\nR 5 (#100980)\r\nD 10 (#636631)\r\nR 2 (#230f20)\r\nD 3 (#1720b1)\r\nR 4 (#160300)\r\nD 2 (#3075f3)\r\nR 4 (#773320)\r\nU 2 (#370a93)\r\nR 3 (#6201c0)\r\nU 11 (#130763)\r\nR 8 (#24c420)\r\nD 9 (#130761)\r\nR 4 (#4767f0)\r\nD 4 (#49bd53)\r\nR 5 (#183ae2)\r\nD 6 (#36b133)\r\nL 5 (#6b61f2)\r\nD 7 (#36b131)\r\nL 4 (#2a6482)\r\nD 7 (#4570b3)\r\nR 6 (#202c82)\r\nD 4 (#30c3c3)\r\nR 7 (#2fc410)\r\nD 8 (#11c203)\r\nL 8 (#320302)\r\nD 6 (#1b7b81)\r\nL 3 (#3abe32)\r\nD 5 (#1b7b83)\r\nR 6 (#3a3602)\r\nU 4 (#05b423)\r\nR 4 (#598dc0)\r\nD 4 (#65c873)\r\nR 3 (#289290)\r\nD 4 (#188db3)\r\nL 13 (#2d4af0)\r\nD 5 (#6ee023)\r\nR 5 (#3397f0)\r\nD 3 (#0da5b1)\r\nR 4 (#1609e0)\r\nD 4 (#41bb51)\r\nR 6 (#1609e2)\r\nD 6 (#380cd1)\r\nL 6 (#258f60)\r\nD 5 (#216c73)\r\nR 2 (#064860)\r\nD 6 (#207401)\r\nR 9 (#32e360)\r\nU 3 (#6788e1)\r\nR 3 (#47de70)\r\nD 6 (#74c7a1)\r\nR 4 (#3b9830)\r\nD 6 (#05b631)\r\nL 4 (#5ab730)\r\nD 3 (#24c2a1)\r\nR 7 (#090620)\r\nU 3 (#3e5ff1)\r\nR 10 (#090622)\r\nU 7 (#608001)\r\nL 10 (#150b40)\r\nU 5 (#1720b3)\r\nR 6 (#44c360)\r\nU 8 (#2da851)\r\nR 6 (#1d1a12)\r\nU 2 (#21ae41)\r\nR 2 (#1f8822)\r\nU 10 (#2d6d01)\r\nL 3 (#4d4f22)\r\nU 3 (#2d6d03)\r\nL 12 (#2c7712)\r\nU 5 (#21ae43)\r\nL 9 (#20c892)\r\nU 7 (#673681)\r\nR 9 (#0c0af0)\r\nU 3 (#2a40e1)\r\nR 4 (#28f0f0)\r\nU 6 (#5e5341)\r\nL 5 (#297c60)\r\nU 5 (#42a051)\r\nL 9 (#005880)\r\nU 6 (#538613)\r\nR 6 (#61c700)\r\nU 5 (#4d6d83)\r\nR 8 (#0182a0)\r\nU 10 (#2a40e3)\r\nR 5 (#151690)\r\nU 3 (#4d7ec1)\r\nR 3 (#69ded0)\r\nU 7 (#0b8c11)\r\nR 4 (#13bee0)\r\nU 2 (#322da1)\r\nR 5 (#5c33e0)\r\nU 4 (#3a9c31)\r\nR 9 (#0736e0)\r\nD 4 (#1b39f1)\r\nR 5 (#74b5d0)\r\nU 8 (#1b39f3)\r\nR 6 (#02c790)\r\nU 10 (#3a9c33)\r\nR 8 (#40c600)\r\nD 3 (#29d881)\r\nR 4 (#161380)\r\nD 11 (#1c3d61)\r\nL 4 (#6504e0)\r\nD 3 (#2b9b31)\r\nR 6 (#1027c0)\r\nD 5 (#07c691)\r\nR 5 (#311262)\r\nD 4 (#469be1)\r\nL 6 (#0a5bd2)\r\nD 6 (#2f4b21)\r\nL 6 (#322842)\r\nU 6 (#10e413)\r\nL 5 (#2a9462)\r\nD 7 (#10e411)\r\nL 3 (#2f7a02)\r\nD 6 (#235971)\r\nR 4 (#448cf0)\r\nD 6 (#5bc301)\r\nR 7 (#210c00)\r\nU 6 (#5bc303)\r\nR 5 (#2b19f0)\r\nD 3 (#356581)\r\nR 4 (#05df90)\r\nD 7 (#266a01)\r\nL 11 (#276a82)\r\nD 5 (#5db6f1)\r\nR 11 (#4fbb22)\r\nD 8 (#0025a1)\r\nR 6 (#69d482)\r\nU 7 (#409023)\r\nR 8 (#505ec2)\r\nU 2 (#1d4c73)\r\nR 6 (#1c0e12)\r\nD 7 (#495463)\r\nR 4 (#534350)\r\nD 9 (#2a6303)\r\nL 10 (#3d5a02)\r\nD 4 (#507ae3)\r\nR 10 (#3d5a00)\r\nD 7 (#2d06a3)\r\nR 7 (#534352)\r\nD 3 (#03d713)\r\nR 8 (#3c33d2)\r\nD 7 (#5bfcf1)\r\nR 3 (#08c0b0)\r\nD 2 (#3008b1)\r\nR 8 (#08c0b2)\r\nD 4 (#737891)\r\nR 10 (#05e2d2)\r\nD 3 (#19a591)\r\nR 2 (#7106d0)\r\nD 4 (#332231)\r\nR 11 (#1d8ae2)\r\nU 3 (#315711)\r\nL 8 (#1d8ae0)\r\nU 4 (#60da61)\r\nL 2 (#5792c2)\r\nU 7 (#2095a1)\r\nL 7 (#197412)\r\nU 3 (#446241)\r\nL 6 (#501ba2)\r\nU 3 (#2b8793)\r\nL 3 (#2608a2)\r\nU 3 (#3a64c3)\r\nL 7 (#3d0f52)\r\nU 7 (#32efc3)\r\nL 4 (#447680)\r\nU 8 (#02e313)\r\nL 8 (#300890)\r\nU 8 (#4e0d13)\r\nR 5 (#0ec4c2)\r\nU 5 (#3a07f3)\r\nR 7 (#65ba52)\r\nU 5 (#201cf3)\r\nR 4 (#240b72)\r\nD 2 (#1bb531)\r\nR 6 (#612f22)\r\nD 5 (#4c28c1)\r\nL 4 (#22aaa2)\r\nD 8 (#3d7bc1)\r\nR 4 (#23b082)\r\nD 3 (#379b31)\r\nR 6 (#05e9e2)\r\nU 6 (#50a231)\r\nR 6 (#579442)\r\nU 3 (#50a233)\r\nL 6 (#1f1e42)\r\nU 7 (#379b33)\r\nR 4 (#1c99e2)\r\nU 2 (#20b9a1)\r\nR 7 (#3930c2)\r\nD 10 (#20b9a3)\r\nR 6 (#2827d2)\r\nU 7 (#2ee6f3)\r\nR 8 (#0c2ce2)\r\nU 3 (#43d703)\r\nR 3 (#34aec2)\r\nD 6 (#67c623)\r\nR 7 (#547012)\r\nD 12 (#032bf3)\r\nR 6 (#15b572)\r\nU 6 (#6af211)\r\nR 5 (#1ab422)\r\nD 6 (#476e93)\r\nR 9 (#137720)\r\nD 3 (#4279f3)\r\nR 4 (#1b0340)\r\nD 5 (#0e8663)\r\nL 8 (#74b070)\r\nD 5 (#0e8661)\r\nL 7 (#1de0e0)\r\nU 5 (#40a043)\r\nL 11 (#157592)\r\nD 2 (#2cbc01)\r\nL 6 (#1b5c72)\r\nD 3 (#04f753)\r\nR 4 (#615d92)\r\nD 5 (#04f751)\r\nR 13 (#16ea52)\r\nD 6 (#2cbc03)\r\nR 2 (#0f35b2)\r\nD 4 (#25a423)\r\nR 6 (#08bc22)\r\nD 6 (#603e43)\r\nR 7 (#4a5c22)\r\nD 10 (#507d21)\r\nR 7 (#6ba9b2)\r\nD 5 (#339b41)\r\nR 6 (#3603a2)\r\nD 5 (#416521)\r\nR 7 (#70c302)\r\nD 4 (#429121)\r\nL 4 (#477db2)\r\nD 5 (#117f11)\r\nR 10 (#249022)\r\nU 7 (#657d71)\r\nR 4 (#15b612)\r\nU 5 (#19b8e1)\r\nL 5 (#0d01e0)\r\nU 8 (#16b691)\r\nL 3 (#0d8a40)\r\nU 7 (#3022e1)\r\nR 8 (#55e320)\r\nU 10 (#0889d1)\r\nR 3 (#2e9000)\r\nU 6 (#49e261)\r\nR 4 (#0cbee0)\r\nU 4 (#1aa031)\r\nR 11 (#5fadc0)\r\nU 3 (#482851)\r\nR 2 (#22d1c2)\r\nU 4 (#2963b1)\r\nR 5 (#4681b2)\r\nU 7 (#47e8f1)\r\nL 6 (#1e3ff2)\r\nU 6 (#32f5f1)\r\nR 6 (#2fae52)\r\nU 3 (#7558d3)\r\nR 7 (#32c562)\r\nU 4 (#2ee9c3)\r\nR 6 (#2164d2)\r\nU 6 (#19cf81)\r\nR 4 (#6fbd62)\r\nD 3 (#35b691)\r\nR 9 (#3b0f00)\r\nD 5 (#1fe071)\r\nR 5 (#3cee10)\r\nD 5 (#3f7791)\r\nR 8 (#534340)\r\nD 4 (#3fb661)\r\nR 10 (#37c480)\r\nD 5 (#3fb663)\r\nR 2 (#6e47a0)\r\nD 11 (#033cc1)\r\nR 5 (#1f6410)\r\nD 6 (#0c70c1)\r\nL 7 (#0dd340)\r\nD 7 (#741ab1)\r\nL 5 (#0dd342)\r\nD 2 (#1a4621)\r\nL 7 (#315b10)\r\nD 6 (#36fbf1)\r\nL 8 (#58de52)\r\nD 8 (#42e691)\r\nL 3 (#58de50)\r\nD 3 (#08a3a1)\r\nR 6 (#357dd2)\r\nD 11 (#3d3941)\r\nR 5 (#455972)\r\nD 4 (#349ef1)\r\nR 8 (#07fd62)\r\nD 9 (#411051)\r\nR 6 (#582752)\r\nU 5 (#4ea411)\r\nR 3 (#1877c2)\r\nU 6 (#43e381)\r\nL 5 (#1877c0)\r\nU 5 (#26f251)\r\nR 5 (#34c742)\r\nU 10 (#50def3)\r\nR 3 (#0dab82)\r\nD 3 (#452e53)\r\nR 6 (#0dab80)\r\nD 4 (#236ca3)\r\nR 2 (#31ad52)\r\nD 3 (#5aab63)\r\nL 5 (#323322)\r\nD 10 (#1b03e3)\r\nR 5 (#4e67f2)\r\nD 6 (#092371)\r\nR 7 (#59a6c2)\r\nD 9 (#246113)\r\nR 4 (#262360)\r\nD 10 (#2143d3)\r\nL 8 (#3b1ce0)\r\nD 6 (#4de153)\r\nL 3 (#614042)\r\nD 8 (#346a63)\r\nL 8 (#32eec2)\r\nD 2 (#0a2f53)\r\nL 6 (#59ea12)\r\nD 2 (#3a25b1)\r\nL 6 (#42f560)\r\nD 8 (#6754a1)\r\nL 9 (#42f562)\r\nD 3 (#30a591)\r\nR 7 (#3f48b2)\r\nD 4 (#1d40b1)\r\nR 5 (#25e7c0)\r\nD 6 (#3e3901)\r\nR 8 (#25e7c2)\r\nU 10 (#545bd1)\r\nR 6 (#2855e2)\r\nD 11 (#161fa3)\r\nR 2 (#205752)\r\nD 5 (#0d60b3)\r\nL 3 (#1c5862)\r\nD 4 (#1e2c13)\r\nL 3 (#6292f2)\r\nD 7 (#253ac3)\r\nL 12 (#248f32)\r\nU 7 (#169ac3)\r\nL 7 (#018cf2)\r\nU 4 (#676241)\r\nL 3 (#043c52)\r\nD 11 (#161fa1)\r\nL 7 (#213b42)\r\nD 4 (#6d64e3)\r\nL 3 (#17acb0)\r\nD 6 (#212c53)\r\nL 4 (#674250)\r\nU 7 (#1551b3)\r\nL 12 (#7844a0)\r\nD 4 (#102593)\r\nL 2 (#70e432)\r\nD 3 (#3aa293)\r\nL 12 (#0ae382)\r\nD 6 (#277373)\r\nL 3 (#0e6692)\r\nU 6 (#5dd281)\r\nL 9 (#3f08d2)\r\nU 5 (#5dd283)\r\nL 2 (#2dfc92)\r\nU 3 (#3b1ad3)\r\nR 8 (#4b6390)\r\nU 10 (#422803)\r\nR 5 (#052de0)\r\nU 11 (#2f4123)\r\nL 6 (#59f040)\r\nU 3 (#4a9083)\r\nL 7 (#5b2a40)\r\nU 8 (#47b583)\r\nL 3 (#1a0f80)\r\nU 7 (#11d443)\r\nL 12 (#27b3c0)\r\nD 7 (#3cc073)\r\nL 6 (#63f0f0)\r\nD 3 (#2cca23)\r\nL 2 (#33cdb0)\r\nD 6 (#698a91)\r\nL 6 (#192830)\r\nD 4 (#588053)\r\nL 4 (#1946b0)\r\nD 6 (#5bf323)\r\nL 9 (#446402)\r\nD 7 (#1c7983)\r\nL 3 (#204152)\r\nD 8 (#0d93d3)\r\nL 5 (#3924d2)\r\nD 4 (#252e03)\r\nL 7 (#010c80)\r\nD 7 (#237943)\r\nL 9 (#010c82)\r\nD 4 (#33cf23)\r\nL 2 (#232b42)\r\nD 5 (#0a8cd1)\r\nR 4 (#627662)\r\nD 5 (#45a161)\r\nL 4 (#124a32)\r\nD 6 (#1d8e01)\r\nL 5 (#74c090)\r\nU 7 (#34ec01)\r\nL 5 (#36d532)\r\nU 4 (#03db81)\r\nR 5 (#6f5072)\r\nU 8 (#120e73)\r\nL 3 (#126e52)\r\nU 3 (#402c63)\r\nL 5 (#66ec72)\r\nU 7 (#1d1b63)\r\nL 3 (#3126f2)\r\nU 5 (#50e573)\r\nL 8 (#06c0e2)\r\nU 5 (#3833d3)\r\nL 3 (#13e8f2)\r\nU 6 (#59d571)\r\nL 4 (#478512)\r\nD 10 (#59d573)\r\nL 5 (#3ec962)\r\nU 10 (#255c03)\r\nL 5 (#08a472)\r\nU 6 (#5d8fd1)\r\nL 4 (#14c112)\r\nU 7 (#5f4443)\r\nL 4 (#293aa0)\r\nU 7 (#1aed53)\r\nL 2 (#311680)\r\nU 3 (#63fcc3)\r\nL 12 (#12d6a2)\r\nU 5 (#46b3c3)\r\nL 10 (#12d6a0)\r\nU 3 (#26d8f3)\r\nL 10 (#672d90)\r\nU 9 (#1f2ab3)\r\nR 8 (#517c62)\r\nU 10 (#68a6e3)\r\nL 8 (#2a9692)\r\nU 5 (#68a6e1)\r\nL 5 (#456bc2)\r\nD 4 (#142573)\r\nL 9 (#0a4712)\r\nD 7 (#0897f3)\r\nR 9 (#63e272)\r\nD 3 (#593dc3)\r\nL 4 (#63e270)\r\nD 10 (#415d53)\r\nL 6 (#459d72)\r\nD 5 (#1fbed3)\r\nL 8 (#49c7c2)\r\nD 4 (#09f433)\r\nL 2 (#742322)\r\nD 10 (#02b5c3)\r\nL 9 (#071b42)\r\nD 5 (#524e93)\r\nL 3 (#15a932)\r\nD 3 (#016c73)\r\nL 7 (#361b70)\r\nD 9 (#22a6a1)\r\nL 3 (#2f8ee0)\r\nD 7 (#22a6a3)\r\nL 2 (#2b3d40)\r\nD 4 (#4df853)\r\nL 7 (#45ff02)\r\nD 6 (#26fe93)\r\nL 10 (#5a0862)\r\nD 7 (#2d1e83)\r\nL 5 (#06e520)\r\nD 6 (#2410d3)\r\nL 9 (#1b49e0)\r\nD 2 (#46d233)\r\nL 7 (#32b7f0)\r\nD 8 (#67f703)\r\nL 5 (#296ba0)\r\nU 7 (#67f701)\r\nL 7 (#367c00)\r\nU 5 (#46d231)\r\nR 7 (#359260)\r\nU 3 (#2e68b3)\r\nL 4 (#450ba0)\r\nU 2 (#2f88f3)\r\nL 8 (#3ca9e2)\r\nD 7 (#1631d3)\r\nL 6 (#770e30)\r\nD 10 (#47c983)\r\nL 5 (#770e32)\r\nU 5 (#260fc3)\r\nL 12 (#3ca9e0)\r\nU 6 (#1ee513)\r\nR 12 (#75c272)\r\nU 3 (#0aadf3)\r\nL 2 (#0272a2)\r\nU 7 (#4ebd23)";
            //InputData = "R 6 (#70c710)\r\nD 5 (#0dc571)\r\nL 2 (#5713f0)\r\nD 2 (#d2c081)\r\nR 2 (#59c680)\r\nD 2 (#411b91)\r\nL 5 (#8ceee2)\r\nU 2 (#caa173)\r\nL 1 (#1b58a2)\r\nU 2 (#caa171)\r\nR 2 (#7807d2)\r\nU 3 (#a77fa3)\r\nL 2 (#015232)\r\nU 2 (#7a21e3)";   // Exemple donné pour debug
            #endregion

            InitInputData(InputData);

            Initialisation();

            if (this.Debug)
                DebugInit();
        }
        #endregion

        #region Initialisation
        /// <summary>
        /// Initialisation des données de travail pour une ligne.
        /// </summary>
        /// <param name="ligne">Données de la ligne d'entrée</param>
        private void Initialisation()
        {
            Terrain = new Surface(Lines, false);
            Terrain2 = new Surface(Lines, true);
        }
        #endregion

        #region Méthodes publiques
        public override long Partie1()
        {
            return ProcessPart1();
        }

        public override long Partie2()
        {
            return ProcessPart2();
        }
        #endregion

        #region Process
        private long ProcessPart1()
        {
            if(Terrain != null)
            {
                return Terrain.AireTotale();
            }
            return 0;
        }
        private long ProcessPart2()
        {
            if(Terrain2 != null)
                return Terrain2.AireTotale();
            return 0;
        }
        #endregion

        #region Debug
        private void DebugInit()
        {
        }
        #endregion

        #region Classes de travail
        private class TrenchPlan
        {
            public Direction Dir { get; private set; }
            public long Steps { get; private set; }
            public Color Color { get; private set; }
            public TrenchPlan(Direction dir, long steps, Color color)
            {
                Dir = dir;
                Steps = steps;
                Color = color;
            }
        }
        private class Bound
        {
            public long XD { get; private set; }
            public long XA { get; private set; }
            public long YD { get; private set; }
            public long YA { get; private set; }
            public bool isVertical { get { return XD == XA; } }
            public bool isHorizontal { get { return YD == YA; } }
            public Direction Direction { get; private set; }
            public Bound(long xD, long xA, long yD, long yA, Direction dir)
            {
                XD = xD;
                XA = xA;
                YD = yD;
                YA = yA;
                Direction = dir;
            }
            public bool isVerticalBetween(long Y1, long Y2)
            {
                if (!isVertical)
                    return false;
                long Ypm = Math.Min(Y1, Y2);
                long YpM = Math.Max(Y1, Y2);
                long Ym = Math.Min(YD, YA);
                long YM = Math.Max(YD, YA);
                return YM >= YpM && Ym <= Ypm;
            }
        }
        private class Surface : List<Bound>
        {
            private Queue<TrenchPlan> DigPlan = new Queue<TrenchPlan>();

            private bool ExistsHorizontal(long Y, long X1, long X2, out Bound? HorizontalBound)
            {
                HorizontalBound = this.FirstOrDefault(b => b.YD == Y && b.isHorizontal && ((X1 == b.XD && X2 == b.XA) || (X2 == b.XD && X1 == b.XA)));
                return !(HorizontalBound == null);
            }
            public Surface (List<string> inputData, bool Part2)
            {
                long X = 0;
                long Y = 0;
                foreach (string s in inputData)
                {
                    var Split = s.Split(' ').ToList();
                    if(Part2)
                    {
                        TrenchPlan Instruction = new TrenchPlan(Jour_18.Indication[Split[2][7]], Convert.ToInt64(Split[2].Substring(2, 5).ToUpper(), 16), System.Drawing.ColorTranslator.FromHtml(Split[2].Substring(1, Split[2].Length - 2)));
                        DigPlan.Enqueue(Instruction);
                    }
                    else
                    {

                        TrenchPlan Instruction = new TrenchPlan((Direction)Split[0][0], int.Parse(Split[1]), System.Drawing.ColorTranslator.FromHtml(Split[2].Substring(1, Split[2].Length - 2)));
                        DigPlan.Enqueue(Instruction);
                    }

                }

                while (DigPlan.TryDequeue(out TrenchPlan? Instruction))
                {
                    var operation = Jour_18.OperationCoordonnees[Instruction.Dir];
                    long DeltaX = operation.Item1 * Instruction.Steps;
                    long DeltaY = operation.Item2 * Instruction.Steps;
                    this.Add(new Bound(X, X + DeltaX, Y, Y + DeltaY, Instruction.Dir));
                    X += DeltaX;
                    Y += DeltaY;
                }
            }

            public long NombreInterieurLigne(long Y)
            {
                // On récupère les "bords" coupant la ligne en cours
                var Xs = this.Where(b => b.isVerticalBetween(Y, Y)).OrderBy(b => b.XD).ToList();

                int nbVertical = 0;
                long nb = 0;
                List<long> verticaux = new List<long>();

                for(int i = 0; i < Xs.Count; i++)
                {
                    if(i < Xs.Count - 1)
                    {
                        if (ExistsHorizontal(Y, Xs[i].XD, Xs[i + 1].XD, out Bound? Hbound))
                        {
                            // Si les axes à gauche et à droite de la ligne horizontale sont dans la même direction, alors c'est coupant, sinon on affleure juste
                            if (Xs[i].Direction == Xs[i+1].Direction)
                            {
                                nbVertical++;
                                if(nbVertical % 2 == 0)
                                {
                                    verticaux.Add(Math.Max(Xs[i + 1].XD, Math.Max(Hbound.XD, Hbound.XA)));
                                }
                                else
                                {
                                    verticaux.Add(Math.Min(Xs[i].XD, Math.Min(Hbound.XD, Hbound.XA)));
                                }
                            }
                            else
                            {
                                if (nbVertical % 2 == 0)
                                {
                                    verticaux.Add(Math.Min(Math.Min(Hbound.XD, Hbound.XA), Xs[i].XD));
                                    verticaux.Add(Math.Max(Math.Max(Hbound.XD, Hbound.XA), Xs[i + 1].XD));
                                    nbVertical += 2;
                                }
                            }
                            i++;
                        }
                        else
                        {
                            verticaux.Add(Xs[i].XD);
                            nbVertical ++;
                        }
                    }
                    else
                    {
                        verticaux.Add(Xs[i].XD);
                        nbVertical++;
                    }
                }
                
                for (int i = 0; i < verticaux.Count; i+=2)
                {
                    nb += verticaux[i + 1] - verticaux[i] + 1;
                }
                return nb;
            }

            public long AireTotale()
            {
                // On découpe le terrain horizontalement, une tranche = toutes les lignes uniformes
                List<long> Ys = this.Select(b => b.YD).Distinct().OrderBy(y=>y).ToList();
                List<(long, long)> zonesV = new List<(long, long)>();
                long nb = 0;

                // Pour ne pas compter deux fois les enchevêtrements, on crée des tranches exclusives à chaque ligne de changement de forme
                for(int i = 0; i < Ys.Count-1; i++)
                {
                    zonesV.Add((Ys[i], Ys[i]));
                    if(Ys[i] + 1 < Ys[i + 1])
                        zonesV.Add((Ys[i] + 1, Ys[i + 1] - 1));
                    zonesV.Add((Ys[i+1], Ys[i+1]));
                }
                zonesV.RemoveAll(z => z.Item1 > z.Item2);
                zonesV = zonesV.Distinct().ToList();

                // Pour chaque tranche, on calcule l'aire totale couverte par la forme
                foreach(var z in zonesV)
                {
                    nb += NombreInterieurLigne(z.Item1) * (Math.Abs(z.Item2 - z.Item1) + 1);
                }
                return nb;
            }
        }
        
        #endregion
    }
}
