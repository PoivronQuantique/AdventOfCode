using AdventOfCode.Template;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode.Jours.J7.Jour_7;

namespace AdventOfCode.Jours.J7
{
    public class Jour_7 : Jour_abs
    {
        #region Enumerables
        public enum HandValue
        {
            ToutDifferent = 1,
            Paire = 2,
            DeuxPaires = 3,
            Brelan = 4,
            FullHouse = 5,
            Carré = 6,
            Poker = 7
        }
        #endregion

        #region Propriétés
        private List<Hand> Hands { get; set; } = new List<Hand>();

        private static Dictionary<string, int> CardValues = new Dictionary<string, int>()
        {
            {"2" , 0 },
            {"3" , 1 },
            {"4" , 2 },
            {"5" , 3 },
            {"6" , 4 },
            {"7" , 5 },
            {"8" , 6 },
            {"9" , 7 },
            {"T" , 8 },
            {"J" , 9 },
            {"Q" , 10 },
            {"K" , 11 },
            {"A" , 12 }
        };
        private static Dictionary<HandValue, string> HandValues = new Dictionary<HandValue, string>()
        {
            {HandValue.ToutDifferent, "ToutDifferent"   },
            {HandValue.Paire        , "Paire"           },
            {HandValue.DeuxPaires   , "DeuxPaires"      },
            {HandValue.Brelan       , "Brelan"          },
            {HandValue.FullHouse    , "FullHouse"       },
            {HandValue.Carré        , "Carré"           },
            {HandValue.Poker        , "Poker"           }
        };
        #endregion

        #region Constructeur
        public Jour_7(bool debug = false):base(debug)
        {
            #region Input Data
            string InputData = "35229 30\r\nQ379J 837\r\n88Q8Q 841\r\nA8725 531\r\n9959J 588\r\nQ7AA2 79\r\nJ7Q5J 446\r\n44644 73\r\n222J9 43\r\n475TK 461\r\nKKA5J 251\r\n7K49A 760\r\nT333T 932\r\n5T8QK 301\r\n37973 197\r\n555K2 816\r\n42422 45\r\n3AAAA 699\r\nA77A4 530\r\nK9QQK 785\r\n67K36 694\r\n933J4 320\r\nQQ98Q 267\r\n22KK6 306\r\n2AKAK 77\r\n7775J 518\r\n3T586 952\r\n34J58 132\r\n3353T 773\r\nTT353 480\r\n5777A 459\r\n79333 280\r\n7TK8T 242\r\nK7A3Q 444\r\nKK6Q4 575\r\nT5AKA 256\r\n858TT 670\r\nA7KA8 731\r\n67676 92\r\nT966T 616\r\n9Q765 566\r\n23Q92 322\r\n356A6 957\r\n996Q9 687\r\n6398Q 578\r\n52552 107\r\nT8558 384\r\n4A69J 998\r\nTQT2Q 317\r\nK56QT 797\r\n4A2AJ 36\r\nQ777K 552\r\nAT6Q4 902\r\nJJJJJ 358\r\nK358K 563\r\nQ94QQ 113\r\nA28J8 167\r\n29224 781\r\nQT66T 135\r\n2AA26 738\r\n4K8AT 324\r\nJT728 511\r\n7JQTJ 399\r\n8K94Q 691\r\nKAA92 818\r\n8Q846 892\r\nA66TJ 368\r\n48QKT 742\r\n39K99 479\r\n73T72 868\r\nJ4K37 386\r\nJK767 405\r\n75Q4A 850\r\n35274 184\r\n72T9T 186\r\nA9Q7A 291\r\nA3JAA 263\r\n57927 766\r\n9T42Q 485\r\n6A6AK 165\r\nT2TTT 600\r\n753QA 570\r\n6K27Q 939\r\nA7A8T 659\r\n8TQJK 656\r\n4T922 115\r\n3K337 719\r\n56665 134\r\nT4A22 367\r\nQQJ5A 776\r\n89889 919\r\n54A44 751\r\n22665 103\r\nJ4QK4 88\r\n45J44 390\r\n382A7 305\r\n8JTTQ 349\r\nK6KK6 260\r\n2Q228 625\r\n39Q44 663\r\n9K96K 414\r\nA9JAA 905\r\n2A8JJ 562\r\nKT9J4 960\r\n666K6 678\r\nTA666 212\r\nTTT8A 543\r\n98J28 548\r\n6QT83 966\r\nAA58J 933\r\n77677 199\r\nJJ222 824\r\n88J68 763\r\n9J999 255\r\n66J6J 163\r\nTQ3K8 90\r\n5A6T6 565\r\n4TT4T 741\r\nTTKTJ 9\r\n755AQ 402\r\n39943 62\r\n358JJ 295\r\nQT46K 493\r\n283TT 334\r\n2222J 631\r\nTTKKT 573\r\n55AA9 857\r\n725T4 836\r\n33A23 325\r\n659Q3 293\r\nJ4747 806\r\nAJKT8 940\r\n99449 669\r\nJQ888 198\r\n66868 432\r\n57J42 437\r\n8T58A 811\r\n4KK55 595\r\nK2KKK 7\r\nKA52J 651\r\n3T6TT 93\r\nJ6398 392\r\n78564 992\r\n385KJ 602\r\nQ7Q7Q 958\r\nQ9T79 524\r\n5Q555 330\r\n2JQ2Q 619\r\n7T9K3 698\r\nJ88J8 780\r\nKKJAA 712\r\nQQ777 671\r\n26Q59 18\r\n2J585 991\r\nJ9969 647\r\nKQ3A3 586\r\nKKK44 875\r\n2TT2T 579\r\n538J8 515\r\n5T444 842\r\nQT4QQ 864\r\n55553 505\r\n7KKKQ 125\r\n47Q47 650\r\n9Q7Q9 278\r\n7769K 365\r\nQTTQQ 177\r\nQ3A99 38\r\n888J3 784\r\nKJK33 921\r\n65657 848\r\n26336 594\r\nK7777 916\r\nT573J 790\r\nQ64QQ 234\r\n66696 2\r\n36673 329\r\nQQ5QJ 820\r\n85J35 156\r\nK74K7 513\r\nA8A8J 29\r\n4TT33 829\r\nJA9TJ 574\r\n4ATTT 464\r\nT6TQ7 104\r\n452J3 297\r\nQ9A73 343\r\n267AK 427\r\nQTQ3Q 981\r\nK84J2 100\r\n4Q333 605\r\nJK355 164\r\n5465A 70\r\n66226 490\r\n44TAT 666\r\n88833 851\r\nA28AA 555\r\n23982 997\r\n22232 882\r\n787KK 81\r\nT49TJ 274\r\n55475 249\r\n88882 982\r\n74T98 170\r\n48484 56\r\nK392T 375\r\n4TT43 426\r\n65JQ4 499\r\n44339 327\r\n79T77 257\r\nT6TTA 727\r\nK9798 660\r\nQ8T54 855\r\n8J7TJ 222\r\nT7776 642\r\n94T9T 27\r\nTT3T4 298\r\n559JQ 819\r\n96T7T 4\r\nAJAJJ 89\r\n87668 644\r\n33633 47\r\n87778 695\r\n45555 488\r\n87A4K 734\r\n4JK85 463\r\n9A5AA 383\r\nAA32A 713\r\n6QTT5 339\r\nJ9A98 789\r\n3KAAK 980\r\n37525 130\r\n7J736 484\r\n22462 606\r\n9A2TA 483\r\n7T98J 84\r\nT22KT 158\r\n669J6 352\r\nA5599 271\r\nK6QJ7 696\r\n82822 935\r\nAA3J3 61\r\n43553 885\r\n7586K 839\r\nTQ58A 581\r\nK4444 924\r\n55858 928\r\nAA669 372\r\n92626 774\r\nQAQQ6 898\r\nA6AAA 307\r\nJ9797 796\r\n54A68 930\r\n6TT94 487\r\nK3Q6T 60\r\nJTK2J 286\r\n58555 31\r\n8J292 798\r\n8QQ53 310\r\nK4JA4 639\r\n6J777 64\r\nA6JQA 252\r\n6T2QA 248\r\n45A45 179\r\n54595 441\r\n7582K 973\r\n338Q7 412\r\n28288 752\r\nJJK3K 445\r\n62K2T 993\r\n44229 724\r\n59399 521\r\n53KK2 746\r\n3A9AQ 550\r\n6525A 215\r\n676A2 754\r\n7KTA6 750\r\n88889 805\r\nT9898 457\r\nJ99J9 681\r\nAA886 24\r\n522QJ 556\r\n6666J 955\r\nJ3QA7 988\r\n87777 214\r\n52J24 277\r\n994J9 183\r\n69559 598\r\n93339 396\r\n9JAA2 243\r\n56636 571\r\n54554 987\r\n86T58 48\r\n34334 259\r\n7K254 945\r\nT4T44 203\r\nAT9J3 447\r\n8668T 720\r\nT9T33 645\r\n8AAAA 80\r\nQ28J6 350\r\n2AJ49 560\r\n778TT 290\r\n355J3 341\r\nQ79T3 558\r\n92222 527\r\n22262 920\r\nJTJTT 643\r\nT23TA 95\r\nA33K3 869\r\n222J5 443\r\nQ4Q44 896\r\nK522J 308\r\nJ774J 772\r\n52952 897\r\n223J2 429\r\nTTA5T 747\r\nKA459 13\r\n2QQJQ 858\r\n92297 795\r\n8T888 627\r\nQA74T 755\r\n26494 408\r\n26665 568\r\nJ5J3J 657\r\nT4Q2T 984\r\n38223 23\r\n2TT5T 859\r\n8JJ4T 541\r\nJQ662 535\r\nT8T8T 943\r\nT6999 400\r\n25225 311\r\n66766 99\r\nKKJ9K 597\r\nT355T 722\r\n3J673 68\r\n5AAAA 679\r\n3T2K2 941\r\nQ9T99 244\r\n2929K 424\r\nJ4JKK 477\r\nQ66QA 761\r\nQ5A8J 238\r\nKTTKK 828\r\n428JT 910\r\nKKKJK 497\r\nK5KK5 433\r\nQA572 537\r\n77TJ7 601\r\n3JA7K 469\r\n86444 314\r\nQ4444 917\r\n65QQJ 508\r\nKKK37 853\r\n3388J 331\r\nJ97A2 312\r\n44J44 783\r\nJT7JA 191\r\n7QKQ7 166\r\nK444K 888\r\n83QT5 832\r\nT876T 82\r\n5J7J7 71\r\n696J8 974\r\nKQK54 918\r\nQ8868 618\r\n575AA 237\r\n6463Q 648\r\nQT5JK 906\r\n55755 737\r\nJ3T3A 674\r\n82AA7 716\r\nJQ86T 801\r\nQTQKJ 802\r\nK247Q 740\r\n39JA3 475\r\nA5967 478\r\n4644Q 815\r\nQ2963 899\r\nJJK53 58\r\nK53T7 587\r\n33377 180\r\n9299J 379\r\n775J5 706\r\nKKQQ2 972\r\nJ5656 353\r\nTTTT9 395\r\n2998K 673\r\n79269 501\r\n3AT52 303\r\n7KT77 710\r\n33539 799\r\nKJK7K 275\r\nKK999 374\r\n66829 413\r\nTA9QQ 337\r\nK4556 57\r\n4T759 745\r\nTQ7JQ 577\r\n3793A 346\r\n88779 615\r\n9888K 626\r\nJ2K2K 241\r\n75377 887\r\nJ5635 793\r\n6Q3T5 415\r\n97779 182\r\nT99TK 844\r\n444QJ 210\r\n99996 913\r\n32553 825\r\nK97T8 732\r\nJJ555 136\r\nK8456 239\r\n52J55 217\r\n59595 201\r\nJJT6T 66\r\n29JTK 211\r\n333AA 582\r\n777J9 629\r\n93653 593\r\nK5TK5 494\r\n52QQ5 458\r\n433JT 621\r\nT5T55 28\r\n79A8J 831\r\n588Q8 514\r\n5Q4T7 19\r\n72A8T 791\r\n73498 967\r\nTJJJT 35\r\n94494 770\r\n2QJ58 569\r\n64777 630\r\n9TK74 704\r\nQQ864 675\r\n6TQ54 376\r\nK55K6 335\r\n9Q8Q8 881\r\nAAA69 690\r\n999QJ 922\r\nK3A8Q 528\r\n7Q983 97\r\n62T99 876\r\nQQQQA 544\r\nK2885 821\r\n55656 360\r\nJ6AA8 382\r\n5658J 739\r\n78225 453\r\nKKQKK 72\r\n9K277 300\r\nKJ333 119\r\nJ972T 120\r\n96299 21\r\n878JJ 822\r\nJAT4J 730\r\nTT494 777\r\nTJ52A 299\r\n2J72J 884\r\nQA48K 714\r\n95Q58 240\r\nT2K65 536\r\n3923Q 532\r\nJKQQ5 91\r\n922J9 69\r\n75JA9 838\r\nA888K 845\r\nQA3QA 936\r\n8T9T8 843\r\nT762J 901\r\nJAJAQ 51\r\nT7777 705\r\n555K3 361\r\nQ222Q 944\r\nAJ77A 131\r\n99J2K 503\r\nJTJ67 733\r\n52922 83\r\nJKKKQ 44\r\nT4233 143\r\n35946 728\r\nAJAJA 911\r\n33733 50\r\n5J555 49\r\n2Q2J2 230\r\nJ277K 633\r\nJTA88 389\r\nTAAJ6 510\r\n96688 40\r\nK93K5 67\r\nTJ949 154\r\n7Q34A 417\r\nJ66JT 968\r\n9A99A 830\r\n46Q8T 596\r\nQ6646 927\r\nQQ555 846\r\n3QK2T 152\r\nJ2828 533\r\nTATKT 946\r\nKKQ92 326\r\n5JQ66 849\r\nJ557T 226\r\nA2883 452\r\n56Q2A 148\r\n48888 624\r\nA22AA 880\r\n44343 788\r\n85633 439\r\n55449 472\r\nTKATK 344\r\nT65Q8 576\r\nA555A 111\r\nJ88A8 995\r\nT6663 371\r\nAQA4Q 122\r\nAA55A 765\r\n5T5JT 20\r\n73832 247\r\n9A9T6 282\r\nKJ99K 778\r\nJ3338 914\r\nQQ5QQ 388\r\n6J464 254\r\n24A5J 827\r\nJ77J7 559\r\nQ7Q6Q 874\r\n74QKJ 261\r\nQK37K 144\r\n5649T 655\r\nTJ746 654\r\n6A269 623\r\n226K5 17\r\n32J5J 953\r\nQTT47 748\r\nKK222 150\r\nQKQJA 507\r\n6A6Q3 188\r\nKTTT8 546\r\n53T99 517\r\n33A73 871\r\n89899 767\r\nK344T 124\r\n2324Q 220\r\n7J442 206\r\n9AAAA 133\r\nQ99Q9 456\r\n22233 986\r\n92284 725\r\n6347A 701\r\n73777 990\r\nTTKTT 422\r\nTTT87 792\r\n877K8 431\r\n5A6QT 800\r\n85548 677\r\n53353 208\r\n33322 965\r\nAAJ45 866\r\n2AJAA 153\r\n4785K 949\r\nJ8J77 187\r\n9A388 779\r\nJ9QAQ 398\r\n23A36 909\r\n92Q95 702\r\nJ2467 296\r\nA32QQ 181\r\n93TJ7 721\r\n9T428 502\r\n72777 667\r\nAAAA2 227\r\nTQTAT 847\r\nKA777 264\r\nT4635 744\r\nA886Q 492\r\nTQJ3A 449\r\nJAAA6 729\r\nQJ86J 840\r\nJK777 385\r\n9922A 430\r\nQKT95 425\r\n34AKA 551\r\n5J996 377\r\n82J87 270\r\n26T59 173\r\nAKKKA 294\r\nK675Q 688\r\nK79JA 718\r\n668J8 970\r\nJ7373 520\r\nA5873 985\r\n99A79 381\r\nAA33A 620\r\nQQ93J 435\r\n23758 416\r\nQQ2QQ 672\r\n48K49 75\r\n92294 893\r\n22QQQ 467\r\n59555 612\r\nAKAAA 101\r\nA29Q6 756\r\n675K3 471\r\nQ5776 129\r\nA68T2 890\r\nQ76J7 599\r\n84QA9 229\r\nJ68AJ 194\r\n996A6 661\r\n888J8 929\r\nJA8K4 580\r\n77879 3\r\nT8J2A 266\r\nK66AK 810\r\n899J4 53\r\n6QQ66 646\r\nKK3JK 915\r\nTQQKQ 373\r\n892TQ 378\r\n777AJ 689\r\n7T898 190\r\nK4QJK 262\r\n36AK9 5\r\n78788 189\r\n8722K 978\r\n499J4 979\r\n8QQQ8 407\r\nT55J3 903\r\n672Q8 168\r\n996JJ 357\r\n555A5 622\r\n8844J 192\r\n959QK 348\r\nQQQQ6 54\r\n6Q56Q 304\r\n62TT6 567\r\nK4QQQ 246\r\n6T439 963\r\nJQ2J8 171\r\n6766J 272\r\n2T798 592\r\n4J4AA 591\r\n38TAJ 224\r\n45788 276\r\n56555 110\r\nT5T5T 354\r\n78888 106\r\n737Q6 908\r\n54454 14\r\nTTTQT 340\r\n8K8KK 610\r\n46454 786\r\n88JK2 63\r\n8Q8QJ 316\r\nKJ88A 549\r\nK6K45 209\r\n5Q95A 942\r\n7J9KK 641\r\n67767 451\r\nA2Q5J 37\r\nJJT22 176\r\n43JKA 387\r\n44T2A 409\r\n2Q222 438\r\nJT822 245\r\n577A3 526\r\n5TJT2 200\r\n38T43 856\r\nKJ444 553\r\nQTTTQ 749\r\n57477 147\r\n4T2Q8 878\r\n2A2KA 436\r\nAAAQJ 284\r\n38828 867\r\n528QK 141\r\n26TK4 692\r\n3444J 693\r\n5Q955 333\r\n3AK24 460\r\n7J52Q 185\r\n22277 542\r\nAATAT 281\r\nT57Q2 519\r\n84483 140\r\n85436 926\r\nAKAKA 283\r\nJK4K8 468\r\n6JQ6A 196\r\n34464 481\r\nJK5Q2 328\r\n423J3 609\r\n77A47 614\r\n22242 279\r\n99279 608\r\n89492 529\r\n3A333 292\r\n3T5TT 948\r\n979T9 907\r\n37322 455\r\n6QQ68 397\r\nA66JA 638\r\n93QA3 833\r\nTJ8J2 983\r\nTT5QQ 202\r\nTT888 1\r\nQKQTK 852\r\nJA556 703\r\nQT345 496\r\n88Q26 994\r\n5Q5AA 697\r\n59429 418\r\n9939T 318\r\nQ333Q 370\r\nQ3AA3 707\r\n378JQ 572\r\n2255Q 86\r\n2JA2A 509\r\nJ5K36 117\r\nQ5866 861\r\nQ94Q2 813\r\n36993 287\r\nA5574 590\r\nTQ43K 743\r\nT66AT 711\r\n4A6J5 178\r\n5K5J5 961\r\n888A3 959\r\n4777K 554\r\nT4QKK 637\r\nJTQQ6 735\r\n37735 782\r\n5J9J5 233\r\n33Q33 607\r\n9T9T9 250\r\nA6A66 683\r\nJAAAA 96\r\nJ63J7 717\r\n22K4K 870\r\nT3J6J 169\r\n8TT33 895\r\n63339 865\r\nQT3TT 42\r\n6TT48 218\r\nKAK5T 894\r\nT6922 736\r\n9AJ9A 102\r\nKKAKT 151\r\nQT79A 726\r\nKA999 442\r\n99399 315\r\n224T6 213\r\nKAKK9 410\r\n7J7KK 812\r\nKT859 155\r\n3AT26 996\r\n7A6A9 640\r\nK5368 491\r\nJQK34 78\r\n27268 289\r\n4967K 564\r\n8K848 268\r\n626JJ 652\r\nAKA6K 964\r\n4J4T4 534\r\n93939 336\r\n47876 59\r\n3J23A 207\r\n9Q999 126\r\n22432 265\r\nK7KKK 205\r\nAA399 835\r\nK77K7 112\r\n3J5K9 762\r\n36J33 223\r\nT3TAJ 947\r\nQQQA8 466\r\n3434Q 219\r\nQ4QQ5 764\r\nQQQJQ 500\r\nAJAKA 157\r\n82T96 393\r\n888KK 85\r\n3699J 474\r\nQQQKQ 680\r\nTTT7J 145\r\n6Q982 221\r\n96669 174\r\nKQ33Q 228\r\nJJJ8J 450\r\n368K8 12\r\n29QJ8 195\r\nT6TT6 561\r\n5KA22 522\r\n777TT 962\r\n92899 854\r\n799JJ 10\r\nQ3Q53 394\r\n7A745 285\r\n9Q43K 46\r\nQ33AQ 355\r\n7Q9JK 454\r\n69Q66 956\r\n7A325 950\r\n39T4J 470\r\n336QQ 715\r\nJA62A 345\r\n88883 951\r\n7J777 771\r\n63878 482\r\nKAKKK 486\r\n7TT33 504\r\nQ9AQA 976\r\nQAAJQ 98\r\n69J69 332\r\n5298Q 160\r\n27292 273\r\nT2T4T 448\r\n2J95K 428\r\n46646 11\r\n9JJ33 787\r\nQ9QQQ 216\r\nJ4455 912\r\nJ96QA 628\r\n9A49A 676\r\n64K66 547\r\nK853T 391\r\nK4J87 769\r\nJAA7K 347\r\nJ5535 931\r\n99222 886\r\n5K59K 313\r\n3333K 362\r\n66J86 434\r\n48J56 604\r\n4K39T 775\r\n4A86Q 495\r\nT99J9 139\r\n782T7 823\r\nT4494 658\r\n66986 971\r\nKKK87 25\r\n52222 269\r\n3T3TT 236\r\n5KK74 904\r\nTK2KJ 860\r\nT33KQ 969\r\n727J7 423\r\n24926 114\r\nT8965 288\r\n58K84 462\r\n43T34 175\r\nKK77K 768\r\n33663 41\r\nQ66J6 231\r\n2T222 758\r\nQ4QJ4 411\r\nQQ99Q 540\r\n9J698 403\r\nT99JT 709\r\n8QKKQ 1000\r\nAAA48 39\r\n7Q4J7 636\r\nT7787 465\r\n56TT6 225\r\nQ88TT 611\r\n6T98Q 516\r\n834TK 366\r\n3QJQQ 309\r\n3A833 15\r\nJT4Q9 323\r\n673TT 149\r\nT8JA5 338\r\n28222 476\r\nAA4A4 321\r\nT9JTT 161\r\n8573J 753\r\n6Q44J 363\r\nA4744 105\r\nT985J 440\r\n24J4T 8\r\n552K3 804\r\n8TT56 401\r\nJ7Q77 406\r\n32333 87\r\nKKKJ5 668\r\nA44A4 506\r\nQ767K 138\r\nTJTTT 632\r\nTT5TT 613\r\n6AA6A 937\r\nKK7K6 94\r\n46554 862\r\n3333J 162\r\n6T666 834\r\nKK8JK 74\r\n92J3A 33\r\n9TT2T 123\r\n964J6 938\r\nTTT99 76\r\nJQJQ8 685\r\nJT6T8 22\r\nA5Q2T 977\r\n77QJQ 6\r\n62A37 700\r\nJJ867 925\r\n3QJ39 872\r\n2AKKK 934\r\n44QQ6 873\r\n4J422 954\r\n79979 489\r\n888KJ 889\r\nQ4A85 759\r\nAAQK2 52\r\n54646 232\r\n99966 172\r\n33833 538\r\nQ23T9 351\r\n34444 380\r\nQQKK5 421\r\nTTJ22 32\r\n336A4 682\r\nQ2TQ5 525\r\nJ8K4T 809\r\n47797 523\r\nK72Q9 665\r\nJ3J33 999\r\n96A98 55\r\n98Q34 109\r\n6J646 26\r\n96946 235\r\n24Q75 253\r\n6A5Q3 404\r\nK5KK7 342\r\nJTTT5 653\r\n5KKQK 118\r\n2775Q 649\r\n8T58K 975\r\nAA5K5 356\r\n7AAAK 512\r\n4753K 369\r\n32335 900\r\nT7TT5 603\r\n64825 16\r\nT5T93 193\r\n4925J 127\r\n488A5 757\r\n39K9K 584\r\nT77KK 159\r\nK4KT5 420\r\nQ746K 65\r\nJQ6AJ 826\r\n5T664 807\r\n95995 808\r\n85838 794\r\nJ8KQ3 817\r\nJ97A4 891\r\n4QQ77 146\r\nT44A6 498\r\n556Q6 589\r\nQ6745 617\r\nTTTT3 883\r\nA64QK 723\r\nQAAQQ 684\r\n72222 116\r\nA74K3 121\r\nJK49K 583\r\n48884 708\r\nQ9979 302\r\n888T3 803\r\nK788K 635\r\n5A82T 662\r\nA383Q 557\r\nK6966 204\r\nK9999 634\r\n72774 34\r\n8TQ7K 585\r\n79954 664\r\n3Q42K 879\r\nQQQQ8 539\r\n394QQ 108\r\nQ758K 137\r\n72727 419\r\n58835 359\r\n32726 545\r\n4J4J4 142\r\nAJJA9 989\r\n589KK 686\r\n7722A 923\r\n97479 863\r\nTTTQJ 814\r\nQ66QQ 258\r\nT5TJJ 319\r\nT9A6T 473\r\n6777A 364\r\n22T2T 877\r\n7388J 128";
            //InputData = "32T3K 765\r\nT55J5 684\r\nKK677 28\r\nKTJJT 220\r\nQQQJA 483";
            #endregion

            InitInputData(InputData);
            
            foreach (string ligne in Lines)
            {
                InitialisationLigne(ligne);
            }

            Hands.Sort();

            if (Debug)
                DebugInit();
        }
        #endregion

        #region Initialisation
        /// <summary>
        /// Initialisation des données de travail pour une ligne.
        /// </summary>
        /// <param name="ligne">Données de la ligne d'entrée</param>
        private void InitialisationLigne(string ligne)
        {
            var Split = ligne.Split(' ').ToList();
            Hand Main = new Hand()
            {
                Bid = int.Parse(Split.Last())
            };
            for(int i = 0; i < Split[0].Length; i++)
            {
                Card carte = new Card()
                {
                    StrValeur = Split[0].Substring(i, 1),
                    Valeur = Jour_7.CardValues[Split[0].Substring(i, 1)]
                };
                Main.Add(carte);
            }
            Main.CalculateHandValue();
            Hands.Add(Main);
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
        /// <summary>
        /// Le process est identique au process1, avec pour seule différence la prise en compte des jokers, d'où le recalcul des valeurs des mains et le nouveau tri
        /// </summary>
        /// <returns></returns>
        private long ProcessPart2()
        {
            Hands.ForEach(h => h.CalculateHandValue(true));
            Hands.Sort();
            if (this.Debug)
                Console.WriteLine(string.Join("\r\n", Hands));
            return ProcessPart1();
        }
        private long ProcessPart1()
        {
            long nb = 0;
            for(int i = 0; i < Hands.Count; i++)
            {
                nb += (i+1) * Hands[i].Bid;
            }
            return nb;
        }
        #endregion

        #region Debug
        /// <summary>
        /// Fonction de debug de l'initialisation, par reconstruction de la matrice d'entrée et comparaison ligne à ligne
        /// </summary>
        private void DebugInit()
        {
            string debugStr = string.Join("\r\n", this.Hands.ToString());
            Console.WriteLine(debugStr);
        }
        #endregion

        #region Classes de travail
        public class Card : IComparable<Card>
        {
            public string StrValeur { get; set; }
            public int Valeur { get; set; }
            public int CompareTo(Card other)
            {
                return this.Valeur.CompareTo(other.Valeur);
            }
            public override string ToString()
            {
                return StrValeur;
            }
        }

        public class Hand : List<Card>, IComparable<Hand> 
        {
            public int Bid { get; set; }
            public HandValue HandValue { get; set; }

            public int CompareTo(Hand other)
            {
                int comp = ((int)this.HandValue).CompareTo((int)other.HandValue);
                for(int i = 0; i < 5; i++)
                {
                    if (comp == 0)
                    {
                        comp = this[i].CompareTo(other[i]);
                    }
                }
                return comp;
            }

            public void CalculateHandValue(bool WithJokers = false)
            {
                int NombreJokers = 0; 
                if(WithJokers)
                {
                    NombreJokers = this.Count(c => c.StrValeur == "J");
                    this.ForEach(c => c.Valeur = c.StrValeur.Equals("J") ? 0 : c.Valeur + 1);
                }
                var CartesParNombre = this.GroupBy(c => c.Valeur).OrderByDescending(g => g.Count()).ToList();
                if (CartesParNombre.Count == 5)
                {
                    HandValue =  Jour_7.HandValue.ToutDifferent; 
                    if(NombreJokers == 1)
                    {
                        HandValue = Jour_7.HandValue.Paire;
                    }
                }
                else if(CartesParNombre.Count == 4)
                {
                    HandValue = Jour_7.HandValue.Paire;

                    if (NombreJokers > 0)
                    {
                        HandValue = Jour_7.HandValue.Brelan;
                    }
                }
                else if (CartesParNombre[0].Count() == 2 && CartesParNombre[1].Count() == 2)
                {
                    HandValue = Jour_7.HandValue.DeuxPaires;
                    switch(NombreJokers)
                    {
                        case 1:
                            HandValue = Jour_7.HandValue.FullHouse;
                            break;
                        case 2:
                            HandValue = Jour_7.HandValue.Carré;
                            break;
                    }
                }
                else if (CartesParNombre[0].Count() == 3)
                {
                    if (CartesParNombre[1].Count() == 2)
                        HandValue = Jour_7.HandValue.FullHouse;
                    else
                        HandValue = Jour_7.HandValue.Brelan;

                    switch (NombreJokers)
                    {
                        case 1:
                            HandValue = Jour_7.HandValue.Carré;
                            break;
                        case 2:
                            HandValue = Jour_7.HandValue.Poker;
                            break;
                        case 3:
                            if(HandValue == Jour_7.HandValue.FullHouse)
                                HandValue = Jour_7.HandValue.Poker;
                            else
                                HandValue = Jour_7.HandValue.Carré;
                            break;
                    }
                }
                else if (CartesParNombre[0].Count() == 4)
                {
                    HandValue = Jour_7.HandValue.Carré;
                    if (NombreJokers > 0)
                        HandValue = Jour_7.HandValue.Poker;
                }
                else
                {
                    HandValue = Jour_7.HandValue.Poker;
                }
            }

            public override string ToString()
            {
                return string.Join("", this.Select(c=>c.ToString())) + " " + this.Bid.ToString().PadLeft(4) + "  :  " + HandValues[this.HandValue].ToString().PadRight(10) + " : " + long.Parse(string.Join("", this.Select(c=>c.Valeur.ToString().PadLeft(2, '0')))).ToString().PadLeft(10);
            }
        }
        #endregion
    }
}
