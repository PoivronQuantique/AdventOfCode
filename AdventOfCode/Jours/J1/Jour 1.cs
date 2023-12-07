﻿using AdventOfCode.Template;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Jours.J1
{
    public class Jour_1 : Jour_abs
    {
        #region Enumerables
        #endregion

        #region Propriétés
        private static string NombresNum { get; set; } = "0123456789";
        private static List<string> NombresTous { get; set; } = new List<string>()
        {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
        };
        private List<Tuple<int, int>> ValeursLignes { get; set; } = new List<Tuple<int, int>>();
        #endregion

        #region Constructeur
        public Jour_1(bool debug = false):base(debug)
        {
            #region Input Data
            string InputData = "3fiveone\r\neightnineseventwo1seven\r\n9h1xcrcggtwo38\r\nnine4pvtl\r\nseven7rsbqpgxtjzsgxssix\r\ntwofivethreepqgsvrszczrthree7\r\n44qcrkvr1two\r\nzstrmphtxdvdpsnhpnq4threenbjznsb\r\nbhgxhb41eight\r\nqhstsbxsspsrfourmtvtnfhxlj699one\r\nonekvhgkeighteight6two7ninelnfzbr\r\nxsixz5six3gfqrzmpnjgskd6\r\nqfrpksmzzvfkddtfh6838\r\nmztttgnxdqt4\r\n8threesevenfourgbgteight5twonenjr\r\nbpzkn2rbbjtdtlznl\r\nglckqhjsbsznseight5dtnxnsix7\r\n2shd3ksrtmbs62vvdvhd\r\n9ninemdkkqjzjfour9mzspzjgmlhfq\r\n7twoqjbshcfxldnkc33one83\r\nzstxvfdthreeseven7mdfpgzgfourdfshplvqflfprt1\r\n9mndn31msfprm1kpk\r\ntmczplnmrsevenhmhprtllcktpr8eight9\r\n49nine29917five\r\n6qspssvm8\r\n7fourninefourcpfgpmxqjsjxmjfntwonine\r\n3nxfjmzhseven22one\r\ntzgnljxhs9nine1lvqgsix9four\r\neightthree9eightfourninexl6gsdhljppfb\r\n9g\r\n2xlcvqrxs2eightznzdghnlvcfour8xbzk\r\nxgmfqvdbsn7sixnineseven5\r\n65zsghsnfbseven9\r\n7skmb5\r\ndbvjtf294threefournine\r\n21hbtcfzbjhsbxlhd\r\n27four\r\njlrthree9four8fourhqnsevenxqlmtsmzt\r\ngjppzpvglfsvdmonercrsn4\r\n3zzxmhc\r\nldfgpzjmtcbj3jvsltltjv1eightzrdczhrzpcssrsrxbj\r\nszblqqfgxhxkk3fourvqnpzf1onesixthree\r\nvsb37three\r\n8kxdcgmpb2sevenjdvc3eight7\r\nkgrsmfghvfivemhxnfiveqzzspmgmsvvghzd1fzcrkzdfsb\r\n5mphlhx5dmcxxcpcxsrdzdninethree\r\nhmqdkgvk4twoeight\r\n2rjxxdcgtq5fivehzslfc\r\nsrqzfsvpfbnsvninetwothree6sixppsmfrtcrxxth\r\n4fourtwocdxnzkbznnrf\r\n4six419qpqfvfdpcrqvsjhgsfgrkpfmphseven\r\nhxdcttl72seven\r\nqkoneighttwoonesixeightfive2tzmrtpcthreefour\r\nbnjqlftwobvsvjqptdp1two94twonej\r\neightninetwo278prrbvmcmf\r\nseven79two\r\none9bx\r\ncfpbdmjbcd27sixfour\r\n16snbjgjzqxzplxkkclpxzdx\r\n3scbbonenine5fivethreenine\r\n21sixsix68oneninefour\r\n6ninejmtrp4fivekxgdgj\r\n6mhlddxbshqbseventhree3two6six\r\n7four8smntchbmj71oneeight6\r\nsix25four196one2\r\n2foursixftdbhbtd6\r\nfourfonekfsxdgvglvtrnrrjzmmkzxljm3\r\n3xckjzm\r\nsix9ssvkh1hdxcxmsptlxgdd8eight\r\n2eightfourone2ninezslhqhdlcp2qxv\r\n7oneclztx7xsxhrhhggfbhzdfgkdfvsqjskmdzj\r\nfouronekkxqtrkptqz8\r\nklccbbvbjsix3fivenine\r\nrjrxdxdz33nine\r\nsevenninen5\r\nnineseveneightlcfrlftwoxlsmrjxnkk7zlzpbzm\r\nrblvkfltqtbm18one7bvkzvvqrlbtf\r\ngdcbszzf6sqldx\r\ntwoninethree23sixninebnzzjgqrlfktt\r\n62ninetwo\r\nfourfour44z8\r\n6qxdvmpkq\r\nsixfivesixthree3x\r\npcqfxpvb1threefive77\r\npncgzkppqqhmzmzjmzsevenxbsggc8\r\nfivexxdvpl32rdsix2seven\r\n9blqpthpvfourfour69bprn\r\n8vxsdfbdjmldkvtkbr4three\r\nthreefive8\r\nck4p6\r\ntwo9bpeightldmrnzbt\r\n4dpd\r\none7four6rcvtvfmzmnineq3\r\n4njtvkkstgmbjptcpdpzdfive\r\n2tsl1sixgfbbpdhxgrfpt\r\n947four5four3fivenine\r\nfivelhtkgjhhzxfp3\r\n7one1three4sixmcrjlkzrj\r\n9fourxtzqsjjmxfivehttj15\r\n2lqnfrgvdninedrdj\r\n9rtxjbffmsbsqdrnjjdkb\r\ntwofour8\r\n1sixfourone\r\nnine1xzpqkfhmzkbqtzh\r\nbbh9fqrbt94onebdppqmtjlq\r\none8nnngz5\r\nvchszvlzpljt1pdv6tqsk6four\r\nsevensix9qmjkrglh\r\n5threenine7fkrtbcsevenjlxrkltp1\r\nggrsfivetwothree687two\r\njbtdsixthreexxvjbft5\r\n1four2eightseven8one3eightwogrr\r\nsix6vtltzh65\r\n7bbxlhgdbrh9sph44sbboneoneightxcn\r\nlptqrf9twofzbmbbkkmt\r\n1zhxmsevenlnsxmdcpz5one\r\n63one\r\none3ninepcnphxdzvhvmcv846\r\nnkn6eight21one\r\ns1cnkm\r\nsixone3\r\nsixbvvmreightonethreesixthree3five\r\nbvbeight5sevensixchfrkjz\r\nhkfkczqffjmndzseven7fiverklvhv9\r\nrsfccvtl9seven\r\nfourczfive5threefive5qj3\r\n9fivexskp3\r\ntsrdgzcvftbvllhvcvzzthreetzzspvvjkrfgn9\r\nbv8twotwo9nh\r\nlbksl3cpgzlxjgnrpqslbsknglctwothree\r\nnine9eightqhcdzfcp2\r\nvckdtskc79threemblqcs3sixndlxfpq8\r\n1ggkrvbpsl9ssix6one8zh\r\n679one9nzsktvfseighteightwotjm\r\nthreefive7gfzptnxbvvlzlxbteightglseightworsq\r\n843trvvsxdkfspsixonethreeone\r\nhsrqmrfvvzkczhphc8147xrrnzldnvr\r\nm6six\r\noneccnxglxone29\r\n37jvhjvvlbv223mmnrthreesl\r\nbpeight1\r\ntwocd8\r\n4sevensix8twotwohhmzr2\r\ndjpbjhrcfour5vbpkmsgnjckrkvt7\r\nsixnfrlbv8sixrqgmt4qmftxnrmx5\r\nsevenzvhhfourchckzrljhfivevjbxxh91six\r\neightckclzxbkqmkncvfdxfx84zeight1\r\n9stftdhkbs4\r\nqrpbdqzsjfj3seven21zktlblk\r\nseven87\r\nlpms5\r\npdgpscn74s4onelh8\r\n7ljbdfour1tnfive81\r\n3rjlmtdvbr\r\nlnvjkkgjc5\r\n7vxlqgxk5lkfdnsdh3\r\njlpgttbf35fourthreenine3cdfxbsdgslczvpjssm\r\neighttwoplpbcbkltwobvzccbhxndndmgxdf5\r\neightoneeight4\r\nrkfx585\r\n9fourfour\r\n7pxcnjslqgp98sixpkhvqjhjqgeightone\r\nfiveeight1fivehvqrnzxqlkrcmd\r\nsevenvgzkmhst8ninegcgzxkxr4dpdjsmone8\r\nfourgjfncfeightlptffqjhrltngg6\r\nsevenqkjdtxptzbtwo8seven8\r\n757ltrfkjzeight57\r\n1twofoursix2xcqkf\r\n7ninetjngrkq7npldprkd\r\nkqcgtnxvjv9\r\nnsvqdsqzthreeqtzzhpd6xcggbnkxfone5\r\neightzkmbhtmpxxjlfqqvmvmbvgmbtpcbpz1\r\nsix1tpvs2sixnctjmdlc\r\n695one92sevenggrsc\r\nstpr38onedftngldtx8lrsgfljrc\r\n1vbzxfive4fivetwotwo7\r\nkdsjx2\r\ndntkrpshcmqpgskcgsgvq9\r\n6pskhmkpfive1nmkcvonemdfpqdtvdl\r\nfvfndcnine7khthreehljzshdbkblgm\r\neight49rcbnkmdthreegqlgvksvxksqf7\r\n22xsix\r\ntwosevenfive72bccn8rbzkfczgssqcg\r\ntwo9hclkszjmxonetlgjfive1\r\ndgpm6nhzkkqng\r\nqrnkpxnn3lltxqxxjzxdkxhlkceight3eightthree\r\ntwo5two4one61\r\n59ninesix\r\n3nineninesevenfour\r\n9cvsx1jzrxhrxshldtbbn9\r\n65four\r\nthree738\r\ncvj2sevenxrsdqhp\r\np255hztrqj92sevenjlpzm\r\nqjsdgdjrxdsjdfx7one\r\n6fivexm1qhxbgcvkvxb\r\nfourxdnpqmjs3bqnzzphp1\r\n7nmrndvq7jnxnlsseven9twonelxb\r\nfour1sjnh5zkrrlxxj\r\nhphshrj3cztfgm23two\r\n1zgvfourninefivetwocllkr\r\n1mgqmktstwo\r\n5ndrsix5tdmfcjbgvff\r\n4onefive9918eight\r\nsevendbtcttvmcnljp3threethree1vmsggrpx\r\nfour5llnsvvcrcgd7sevenldffd\r\nnine2five9fivemfour\r\n2cpbhssgzfsrhjtq2onefmpdqfivehxvbzpfmg\r\nspglsevenrtbrkpnrq6\r\nbbfqkt5nkfrzl99gxdlzzsb\r\n6csshxkzkshsxnnineeighttwoclslvdkjkc\r\nfive9pcb2nine4two4b\r\nbrzrd5threendzpvs7ldkjxmpqqr\r\none4vdtwo\r\nfourseven5493dvldshvz\r\n1gkmnj\r\nninethree8\r\nvshbcvtvvf4eightonesix\r\n7nine485eightrmxbrd\r\ndctwofour3\r\n18ftwo\r\ntwotwo8rzdbgeightthree\r\nsevenztlzzn38nine3jtnqjsnine6\r\n14qrvcspxmr4\r\n783sixxkkhrpqjrt5ninesjflktt1\r\n73five3\r\nnrtwonetlmkldqrcjqrdn6gptzdclninethreenine\r\n8sixxqfl\r\nsndlpvjr3\r\nhx5zzlqk1571three\r\nzvl1\r\n1twotnqcmfqrnr33rrhghsdqddpmbzd\r\nnine1threevcninetwosix7m\r\nsix2onesix1xqjzczdrl3\r\n15jkhgkfzseven26\r\nfntvfkhfzsfour7onesevenfour\r\nsixone653\r\nhnvftxjthnmfive1sevendfnpkpffgj\r\nrdktwone9fourkklk9rsseven\r\n2fivefive4eight\r\nvmfour34lpjzbr517nqkthkljv\r\nhk9rqtwozr189\r\nfivefive3\r\n5one6four9twohsnjkcp3\r\none77twoeighteightfive6twonek\r\nvrxbxdgmtwo8tmglzjx\r\nlp4ckhf\r\nsrh2\r\nhsbkzggsfgeight5qhblzgsppxbdlpvhvcpgkndzkjtmpggpdx\r\nsixzvhnnzffnsevenfourpkxnvc7one\r\nfourvgv19g6xhphkdt\r\nfgvl8nine42\r\nfour97five4lfcmzchtbmtvtvbr\r\n3onesevenqtwo21jjpgtwo\r\nfour44fournine1\r\ntwozhhvcxck6\r\nskpvglmddmxlsrt3961nine\r\n8twoonetwofourtwokxrplnrvhmthree\r\n7ktxhsjdml6twofive\r\nzfdtjbrfive669bscgkpeightseven\r\nzmghddqkseight5two63three45\r\nx4one\r\n5one1pcv9kkninenine7\r\nb678two\r\nx7\r\n97foursevenbhrxdpkv1\r\nrjkfdbteight8fivejrspls231\r\nsix2skbfzvnlbvfour61seven8\r\n2mcqpccjfs5\r\n8tm\r\nkr9pmdxkzjsg69fnkrrphlxqpsqjhzbznine\r\neightcqmdq8twozbbzfkxlhsmmv7\r\nxvgflfourkhn3ninebx9fivedzsmsnf\r\ncrrsnkfmvtwosmjk7\r\n8four8796\r\nnxqhdsczcgnvq5\r\n8five5two9three4\r\n6clffour2eight3zgzjnnmfsix\r\n1drp4six2rtszhttwotwo\r\nzkmlfive7\r\n245eightnine9142\r\nsixfive1\r\nxvnbjvfivezhzfpvnsthree5bvvfive5cxjfkszprp\r\n3bbvmq\r\n13\r\n946five\r\n5twooneeightbhxfhpvjmlgtkccqgmqjnq\r\nmlq7\r\n122fivetv4\r\nfiveseven833pszfqhbt\r\n229oneninenine414\r\nknmvqkkh1cjbbjnjzrtpxdjznn9six\r\n78nslms\r\nvqrdsmtjtgfourninethreefivextgtwo5t\r\nslnrndksnb95three8vrskzqzfthree6\r\n4twofhhqdghjssjkkcjlbjthree\r\n2xsnjsfngdqpzfmltkrsk1hvhktwo52\r\nsevenxxmxmmngqmdx2lbthree\r\nfive823nine\r\ndszvsjnzn7\r\ntmvlsfive5prd\r\nsix3nine\r\nonerzskmfthree3sctlkhcqrdzc97\r\neight34kfour2cdgnnkdff\r\ndmone3three5hjndcbbonethree\r\n63five5513pdgczone\r\n6fivechs4vk\r\n3zlqsxzqdnpseight5\r\nfive6eight13eight\r\nzjknbtptmdzfour3one2seventhree\r\nsxshgxbcxs64dmtzplkqnfffkpz\r\nrml4b65htpzcrlrbn39\r\n8tlpnvnrhjb57\r\nfivetwo1five\r\n9nrrms247qcffourone\r\nn6two2sevenvtfsxhsn\r\ndxjtpsfjcssix2ninefour\r\nqfldkljtbqc4five72fourjqbkbrh\r\n3nine1\r\njflrjzjzfour3four8threefouroneeight\r\nfivefivesevenseveneight771lhpzhb\r\nnrszb3eight1tbzmmps79\r\n8kkskdtwoeight78eightvbmv\r\n4bccrqxmrvd1three\r\nnine93fourjhspbgnthree364\r\n11q\r\nthree7fourthreeftbxtmmm\r\nmznine6six1\r\nsevendzpcbqjfdk83twobgqfourmkzfzflnn1\r\ntwocvbtssm72\r\nkeightwo12\r\nfourzxcbncddhthreeqsccqgsf4crzszqdd3nvvjsix\r\njmh3ggvdp\r\n12fiveninefoureight\r\n3tvlmfpkgrdthree2phmllhczeightj9qq\r\nsevendndrnfpfzmgvfqnkp8pcjlttzfour7\r\ndvtbsjreight1fkdlffive55bxzpsrnxtbfour\r\n7threeseven\r\nqrhzdlsb4five\r\nbvdvjfqvtrtqntrrnqfpf87njtjgxzkgbcnine\r\nz927\r\none2eight\r\n7dpszhz3pfnrrtrkxjn\r\n8mfkvn\r\n258lkpqdc3five733\r\n1nine1threefour\r\nnnbfzxdmm828cdgvfive\r\nthreetwothreethreetjzskgfive4\r\nsix893sevennine82\r\n3ss48phseventwo24\r\nxgbpshxnkvcppnninepjcztcsevenqbnjcjftpxxkpqp66\r\n8mlkbpdpftwonine4\r\n5three6six1seven\r\n91onelrttnjrcqjtnrfivec\r\n322one\r\nsevenmfpxvntvkpqvpbnnbpr5seven18sixeighteightwok\r\njnthkgsrone6vnkdvkjznjnboneoneseven7\r\nfive81472\r\n2onefive\r\nnine9oneqfb7\r\ntcf2two2145eightsix\r\nvdjhlrksdhcone17three9qoneightr\r\nfiveone82228bgrr\r\n5rfxlfbbjqninethreefour\r\neight641\r\n2pjmlgrrzvv\r\nkpqsxmvhp4twohnlsone3eighttwones\r\n35sixd9eighthm89\r\n8four5onethreeqmdmttvchslfvnqrbftthree\r\nfivemmbfjmq1jlvzsix1hgkbr7bxcsc\r\neightgmjxseven5fivefiveslbfsqrjrnbhqzgr\r\nxr18oneqjgsnjfzcsix4\r\n9threefivekclcmrnsix654\r\nonelnh6sqvzxeight9\r\n6vjjpmmxxknineone79\r\ncdsfmz97twoninetqhhtsljsixseven\r\n8five6\r\nninepkp3\r\neightfour4fqtrlnzt\r\none4pttsvonexsj4\r\nfczlpseven261\r\n9six6nine5nb4fouroneightv\r\n2snzvzxkbbpcvd\r\nmvnqjkcmkhrvnsxt3hjkj2ninethreezzbbrsdone\r\nzktwonemhqnxssxftwotsd1nhfmrxpffoureight7\r\nqfhlmpxhxpthreennlk7chk7zzmlqxmtlk6\r\n7dxhzpmtwog9\r\nkfkmpmzxhn6four87rcthd\r\nbvplp656vtxxlqvmm6187\r\n811beight\r\n39586547\r\n18twok\r\npfxsfxsvkjrb9\r\n38z9trcxdbfivedmhtdrfive\r\n19bhddbmbkbg77\r\nfour522\r\n7vshvtblzonefbfcfgsfive2\r\nmgtwoneonecthreefoureight37eightjqlxf\r\neightnine67gthszx9tzxczcpone1\r\nfourfourthree2fivejrfgkb6seventwo\r\n4dnreightrv6ql3\r\ncsfgqxjdvm22jjnr9\r\n42szlhdvbdstllzldtcblgtfive7gnctbrmvmn6\r\nztwoneeightfourzzsck7seventwo\r\ntwo78\r\n1hxqtdxjqflthreesrzzdbxmfnvk89three\r\nrnprnnpbjq7fivetwoneqsh\r\nhkpjjpbl3nineone6pcszznjft8d\r\ngcbtzdtkhnbbjnftwo2four7nineseven\r\n3foureightonesixrfqrjlp\r\nqvftcskmxdvnsrzqfourfivethreenine99slncxvjrcn\r\nsix5sshpxtr88\r\n7twofour\r\nfour143\r\nvrxxmzfp8\r\nfour9tg8bfonesix59\r\nthree3onezsqdtkrceighthnstg6three\r\n7seventwonine\r\nfivetwofour9nine1two\r\ntwozfdvkjzbtwo6xrjgmfgsxv\r\n1dqfcfjcbxxgxrksixnine4\r\nrfpgseven5ninezdmbx5\r\n622\r\nnine19fivetvm\r\neightthreelpj58qjlnhr\r\n9fourjtczvxfourfivebmzds415\r\n3fivejbgzdsx\r\nfcqdbxgjf86twofour\r\nnine6oneone\r\nonefour1\r\nonestc6eight3oneseventhreeone\r\nseven2six\r\nplbgd5nmppgfpbtphsxldrllpmnprm\r\n1three14eightbvnzx83\r\nfour95kkpjsttjf8one\r\nmrkrgj5xtqvvzpmxn8nine\r\nnineskg78nbrnonelsxfxkxlrc\r\nqxnvkcx1one\r\n9ztbs2grvsixsqt94\r\nsevenjhtd7\r\nqjb78nine29\r\n3oneonegjtcppfrjs633\r\n3clhz\r\n1v398nine\r\nmqlsevenlcnblh94\r\n5fiveseven\r\n73rbhnnsixsix7ntssps9v\r\nsvjsgvdsrspmsxzkczseven11nine4\r\nonefjncqnsbsvqqm4478\r\nmfzfzjhc1zgbtt\r\nsix1sevenseventwokvbtwogvpstm\r\none56nine\r\n8sxhbpfrxfsixl9lthreehr9\r\n44nine4threethreedbbp\r\nseventhreedp66gnxvfnpzvdpqflnx2\r\ntwotwofour37cmfzvxqjp5seven\r\n1twonexlr\r\nsixtwosix6seven7g\r\n63zscqhtonebtcjfdjqc\r\nfiveklbblk4eighttwonefdf\r\nseven7one\r\nzz361tmxqdpmgseven6\r\n5onethree6cgkfkdcmnine2blhxzqxjqk5\r\nthreefour43dp\r\nhcmjsszeightthree4tsnppskn78ggl\r\n7gzqsthtmvszmjvcgseven\r\nonethree6sevenonetcxsseven\r\n3twobzbxc9onelxfkvgsnhteight\r\nhnljcxrhxhjkhmhtffjrcqmeight7kcjmhjlvmgq4\r\n5nineseven6lkxzlbf\r\n49jxmvnql8crs\r\nqgq6eighttwo5one\r\n1xclqfour8bgqsjknine\r\nmrheightwogfglthreeeight6threeeighttwodfkjgp\r\n26three6nfrxkhqlq93seven\r\n3two4gjzmvvnrhdthreekrqhbfgssjghksix\r\nsixone6sixfour7four\r\nzbsvkkmhmcone677hmjsevenrqmng\r\nmqzjpd5foursevengxmsbjhl\r\nlmrpmthreelthree19tvbnbfqggnftwo\r\nx3\r\n6zrhpdnxqpbfourltbvhlglvseven\r\n3onesixeightsevenqjjclpcndtzgnzcv9\r\nfiveeightrm6\r\ncfqonesevenszbvlkdpfourninetwo6five\r\n9lhlsbntzfourhvxfxgfjfivezcvqfshmldcmmhb\r\noneseven28pjmqkd\r\none5three284fhrbztwoseven\r\njmhj2rnf983bbzsmts2xf\r\none981eightr4\r\ntmtwo2zrjdd9five\r\n4eightsixsix\r\nq3rszpbkftqv\r\n6zndd7\r\n7sixflqjpcgrh4281\r\n89ninehbfklckdglmcgvm2\r\n712gsfgtdvthree\r\nnine5knlzninerspkdklnthree\r\ndhjmgthfiveeight79threefive\r\n87bn\r\n4eightkbppvkx9sevenzqcfrqlbxmk45\r\nfourthreekvtvdrlgjrk2four7c\r\nsix6dlmmmvfkseventwoonesix\r\n47rsjqzcqsnffourqdggnkpgsqjgprhrx2\r\nptbtpthmkeightxtzjftbff6dqzdq7\r\n48sixcfngcjngjs3bszknmgzjthree\r\nnmcdlgrrdrmrrbpfn1\r\n5q6crrhphbmqr8zdddmnseven8\r\nfxlkdnq6\r\nthreeffvsrjdbtfk6trsgmkn\r\none3fourtwofcqsgcvvg\r\neight8onexvdtthree1pzfrllrjrtktzvnrp\r\nhlnine3\r\n54three3zxbdtjrlzone\r\n5qjnpjvnzpfive2two71rphp\r\nnjseven6four\r\nbgpkmfcbl72\r\n9vmjgvhvfvd1\r\nttbmt46two\r\nmksvjgxsbdnlg8eighttwofourthreesfn\r\nmtjm6twoseven46\r\nfivefourcktdqsdlvpdq1eightwolc\r\n45twoneqs\r\nsevenplrfqrhfivejqzrnv3\r\n9nine4threetwolk6sevenk\r\n5qxpfourfqtg\r\n34cpbblldjfqpltcntpzninetwo\r\n7eightfivehczsxqhglmtpsxk8hkksbzr\r\n69two9\r\n6seven33pggfive1\r\nsevenhkhrj2\r\n4phnnpxthjn8\r\n4vnnfqdssrfive8seven8ninedfhl\r\nfrhf15three4vvlgthree\r\n4nine3\r\n57hlrhqmxxxbl\r\neightjhblpnjk786fivekrq\r\nrj9twofour\r\nlmszmtrhpthreezbdghgfour7sixtwofive\r\nninesixrlxxsskgjpqfdpzbthree5\r\nqbddmnpgskf1tpfive34\r\nfxmninejzl319twoeight4\r\ntwo7ckzsmvqfcbfourthree25\r\nxzhqltqmdfourqshqmlxpninecbrsclzftwotwo7three\r\none3zdppmxfroneighthb\r\neightsix8tmh7fivesixgbdttd3\r\npnhkxlcsh35\r\nfour45\r\n9sevenfivehxr4eightfour8\r\nrmvmqbclzr5bmsxdzxgptlhczgsh42eight\r\nbpbbvbjrptfourqpkdfqkjcrrpone1b3\r\n2six6\r\nninesixthreexshfvpb5\r\n3xhljmkxlr1clcqkmbdrmtxptgl\r\ngfkhdhgv27ktc7foursevenseven2\r\neight1eight4\r\nnine4vzdqjs8three9\r\n2lhmbfzonetwo9\r\nnlhkm83cslc5three9sevennine\r\nthhllmnnpxsbtjvnrnhq8rbvhzfrxzqqqhccqlzfggseven\r\nfour6six8kqmjzk8\r\ngcrqzmbsh7seven6\r\n8five575four9six\r\nfour615\r\n41xzlprtjncrlzbcgvbmclsqrnbdone6\r\nsdphx53c\r\nthreefblfr1seven3\r\nxqh1one\r\nqztslzlkheightsixkrpfourtwonine7one\r\nnhqdsngrf8seven7dkbkfbdgdcjvnmdbzx9\r\n7qrmrsnhvfive4klcrkkbtwo\r\nqpltxmjl3twosixrnvmlqvgrgmgninetwo\r\n43lbsbgjkng1one\r\nlzjqmlxnk452zrglhpbpvtwo\r\nfourlmcprk36mthree\r\ncssthvvxrgpks48glbxk\r\nqpmkfxk4fourbmnbfzhgn2three\r\nzxkntbdnm3fivethreesixmkgztvrfpkjgxljbm5tt\r\n1vlhrcllfjtsgmqcvhcbcr98\r\nnine6dlkvtfjfnq3hbxxm\r\neight42\r\nmnrdpvdpklgkjnrz4\r\n1seven93ninesevenjqmeighteightwoz\r\nseven8933five4seven\r\n9lldhvdqdzvdgptsmf1eight\r\n7fiveninezfourkrltflg\r\nthreeseven9\r\n7hjfzpltbjqbkx1two\r\n1twoqghxlrpmfourfivefonermntbg\r\n77eightjpgmmjst4\r\n9three8586nine6kb\r\nthree8ninetwothree2\r\n13xrhdzqsonesix43bph\r\nfoneight7\r\n29one\r\nrth7cczktksv2\r\nfrrpbtjjcdfccdl1three\r\none5six4\r\nninehszc5svnhfrqm\r\nthreezfrmbgmjzg6\r\n9eight8one8fxlkdjhql\r\nfivesmtkcsskrq7hxqbfkbqlninegnqddjrvxb\r\nzfivehhknpdm7fngjpkbvone\r\n7five8\r\nqkcxcpjzggzdxrfhlbsdbq17\r\n654mk\r\n2mqtgbmsnhq4zv48jzdchccdpzhs\r\nrpkfj1hkrztwosix4bktdfk\r\nseven9bxjmvrbb\r\n9threethreeeightppdkjzltclnq8sixnine\r\n7seven92\r\n567onefour8bsgjtrvsxkjlsc\r\n1dnbsjbdsrsscq3ninefour\r\nvbpkpgssljgtxdfivethree6\r\neightsevenrkkjszmxvxtwo9jpvzldd6\r\none7523vgpvlkd\r\nfoureightonepeight4\r\n9fiveeightone\r\nnine7one9\r\ng328dbspnkseven\r\nthreeclqhr97five\r\n8onefourffhrmfkvctt\r\n2pzftpmvzfive\r\n433tvdzmcrdl\r\nfive42ckvlkgkjxh35sixd\r\nnine6hs\r\n99cmtdzjtpxk15c2\r\ntconexjkkh9\r\nsevensix5oneeight\r\ntwotwo4ncmpzpvvdrsxkpnpfkjseven\r\nnine42\r\n7sevenxntxxdnfckbkdh7seven6eight\r\n2foursevenzvdvhmzscd8gmlxxkqxd\r\n5sevenrzntpronehfpbdcmffdscfvsqjcvnbtqzpph\r\nthreefoursix6ninegdpmtlsix\r\nlxcflpcvgctxhm1nine2\r\nseven4one9mkkznineck8ptpc\r\nseven4qtgqrcvfcfourzfdnx\r\nmd13xsdltxltqhninemjs\r\nfourtxtscncgxvp3tqthreeseven\r\n8zzvkkmzhr7sevenfive776\r\n91sgceightvgzjdkkkthree\r\nmfmvgtck5gbjstzvmfvtmr\r\nnine57one84sixmqt\r\nthreekslcvdzlhhq6dqtkp9two4\r\n2slmvrvz38\r\nfoursix6qlqvzqbdzf2\r\nmftwone3eighthhcsgfvrrj\r\n174bx2ninetwo8\r\nninetwo7mzlcjkmj\r\n37four2\r\ncjmlmtwovrvsbmeightthreethree3lkq9\r\ncscvfbgpjmonep8hmlnvrhvgsqrvcp\r\ntmqkssbt79ninerfgh88\r\nqdsxzxcseight7\r\neighteightnine8threecbcnfdtm41\r\nljpcfour1368nine\r\nhftwoneninesixxxmdtcfd8lbvqdjg\r\nkjktdqqbfourdvkjlprhkzgfivetcddgds1\r\nqjeightwohvvdbqdnbknktv8six4four53\r\n6482cbb1\r\nsixcczlxcthree35lqn51\r\nrmnmjsthreehfxsjqlpkjxmdkg7three\r\n94lhpqldseven\r\nfctfxjvnine7\r\nsqnthxzkctfk98\r\n8xpknqzfkone\r\n9threeonetwo\r\n59d8twoshphfzlk\r\n26vtseven6bsfkgxmjqnine\r\n6nslcxpglfoursevenoneseven\r\nsfvpkkvdkrfour31one8bqcrtwokhqp\r\n29vrcx5four9\r\n43two\r\neightsixpcmhlk7nhpxhmnrmponesevenpkfgxmrfnq\r\nsvfjcqdtnmcrtjdgseveneightninetwocnbrrbcgmreight9\r\n25cxhtcxvgkjlbcshxrfour7rcnkzmm\r\nonethree14gvjpp\r\nsevennxlncmqpkvlhbts1mhpfxzqf8\r\nsix6fivesix\r\n3fiveone8one6six57\r\ntqgdrncxgpxpxz33\r\nvrdxxljfeightseven63b\r\nonetwo56nineone9kkb\r\nnvpqcnrgqrrnzqsqrh4four\r\n67twobvxksevenztnhfpzkj9\r\nrxddljfhxhlbqqrllk3six\r\n8twosevenone\r\nonejxjpcnzljjdkbkmgvvrjrkgxgpqzdmpjzt4\r\nftbssc2fgtmsrjbr\r\ndjxnine1seven6sixone\r\ngrqxsevengkkgv83fhspzflvfbqjrm\r\nctsj5svksdtwostmft8twonine\r\ntwo9thpzhrcvdl4\r\none2seven2plxkgkldxcpqconecfnppseightwovz\r\nprleightwoggdqszvonefrqhh791vxxcfv\r\nnine4seven6ninepbfoursix2\r\nfourthree8threett488\r\nsix984three9r3xjnmvp\r\n261\r\ntwoonedrbbmvrm8fivejsix\r\n6onethreethreeeightxpcchknine\r\ntwo55oneone3three7five\r\nthree3threekgpsix\r\nrqvfvm9ninesixninesix7pfsxcrx\r\n4oneeightsixfive\r\n2fourthreeqjppmfjfxnzfdhlr\r\n9gctq3\r\nvtzcng2jhrhgsqhq\r\neightmmxz6ninenleight\r\nsbzllxonemjfffkhltgpshkmlrjb7oneone\r\n7fourfivefivefive3qjfdzclghxtc\r\nfourfour9hmmlhhbxfour46twomzsgpkht\r\nfiveqc45\r\n2bvseven54sixghpnhleights\r\n2qlhvfive6ffpbhftfp6\r\n4sixone1sevengqqqjbzr\r\nspq17sevenhjfkkjzdf\r\neightphqcjzdfzpttgxbsix1fvmnvqczr\r\n9hxzczdhdl8oneqkqdlseveneighteight7\r\ngllbrsevenfour4vfcgth\r\nlxdqx59mvzfjcsjl9\r\nthree2eight3seven8rzsthree3\r\ntwo8seven64\r\neight4dqqgeightseven\r\n71threejdzzk\r\n6fourgtcqnjkzjljksdqtbddpvxznvmprjtr6\r\n3fxkdgm\r\neighttwo3four6zg\r\n6rxlnjpgkkstkbzj\r\n74pcpzgndmtjgngonejfskscqfgm\r\ndfssmbbxf873rhrbxnfzcp\r\nbpqlnrtn5eightsixdschkk\r\nlcrhcxvbrqhbz1one8\r\n46mrpfrtpnzdkshjgfxnrjbtntdnfive\r\ntlgtzp86twofive\r\neightpmbdvzmdmpfivebphsv2pzxtcsrvtgnqnhvsbdf9twonehc\r\nxqkbgbseven5\r\nbheightwotwojl1one8\r\nfive7zsixgsmtvpxkkdrjtqtfjdjln\r\nponeightbrndfh97kqtpgcstvnine6\r\nsvhgqmjgfoureight7twodsmcnjh6mmncjvltp\r\n79sixfourdlprglcm\r\nfive31\r\nncnmdbvvhnpqxzkktjzbsqxb42\r\ntwoone8mfxc\r\nsixtwogxhhvcqpvzjmnltcdskdthree3nvdqeight\r\nstwone15\r\nthreethreeghzvvdkd7\r\nfivesevenr3nj\r\nfive6rmrccmczninelshone62\r\n8threet4nsrrkhg6bprcjtrpgclp\r\n3twoseven5\r\n26twopqtvsks5\r\nninemhgqvchgzgndlone938five\r\n5twoprnvvvfcbninexxfrh2\r\n6fdpxffv4\r\nninetwo5one6nqngsbqghbphngmone\r\nkvqfvnxnine9552\r\n1lmht\r\n6jvngqeightqnp925\r\none53rqlbdzfive453xp\r\n32gntcntdtcv\r\n6qxdnhpvrcd5fivenpmqb\r\nsevenninesevenfive9\r\n98svjcb1nine\r\n777ctrsnjzlfbxdzbvckr\r\n6three4onetwofour2five\r\n27hdhhbv68sevennineclpdtb\r\nmknzmjqsp5xd7vdmfkbcfpgst2\r\n39twotwo\r\nd78jjxpgrgmpbthreefivezlbvgphnsd\r\nmcxgg3one7eightrzbdqzvfnvxn\r\nncmfng86sevendqscgbmlrjnkvgqmzzfff1\r\nfivejlsdtbktwosix3\r\nnpnxr6five947\r\n2prjccpmn3hfnxpqht8nine5four\r\nhfqrqpzfkqllthttmb4kcvfgtmp\r\n2fourfour\r\n6pj9fivenmhdlsx\r\n6csv7ninesevenlzgzninesixsthrlvsst\r\n7one83\r\n7mlrfqmjq47gfgpqgkgmpq72\r\nsix5pnslzjhthfour67kcvgsix\r\nninetwothree3\r\nvb91two4two\r\neightdqmnsxlhhkz44two\r\ntrzzone6tcvrsznine7kdctnine\r\nnineninefdfnxsixnrq2ninezrn\r\nbl79eight59\r\njvjxkgjrbqdmnzk432sixmblqqmpn\r\ntwo39hthree7\r\ntdlcjpj5jhslsgfcx\r\n4two9jzdfzbbp\r\n9six7gtbk15vqzhhsbtxgmcx\r\n7vptsbpmq1\r\n59nsfbgxkvphnqvt\r\ndmffndtn9\r\ngzfnfsrdmrgtrbbsfive586xhrc\r\ncxvgfjjvbtlvkpsgsknine4jjgntjjzgfqrmlfbx4six\r\n3tszbt1six3\r\nptjjhztq9eightseven\r\nzglcldrtwo5fqhvmfivesevenxvkxl9\r\nsevenonephscj3foursix2\r\nninelgclbhv37\r\nfczvmgkzbm2jnzbgxhqmzoneqsrdj61\r\n1v8hpchzrvnzfbxninencjqdtqvgl\r\nseven6threeone\r\nfive2sixrlfqftqzgks\r\n6three1xzgnkrzl2krjtxr\r\nzgkjvnkczstwolctzzlsevenone6bglzxscglsnjm\r\n3kvxbzmpvrp\r\n75vfz2\r\nvpnh25eight\r\ncnsdklvrsix2one\r\nkvlsjffgfltbkckcznmgrr8\r\n56foursix\r\npmhgkfonehjdslqbdc4eight9\r\ntwodmmsk57nx\r\nlfjvsz6fivekfivefivesdplsixpx\r\ntwofivethreeqdgf3eightthree\r\n43sevenhnvsp\r\nthreeeightzh3threeqnncknpxgseven\r\n4vbnmhgrmtsblrhrtoneljbbnvxmtvbfzssgone\r\n5kvqfxmlkgcmlmgbfiveeight\r\n55ztqqfzvmdppdpq1three3sixtwo\r\n26bskpdjql\r\nthreehhgxmxdz1five94eight\r\n52fourzcbcfknlvlrnvhbnldq\r\nthree49four8gshbnmxlc8vphklsvfmhnfss\r\nsevend95\r\nfbkmpcone555oneightkc\r\n5qddnptqdoneonezczvnsl\r\n78ttssqjfournddr986\r\nthree4five\r\njb6\r\nht3hmrbxjsdvrsnlzvsqrj1rlcfggt5\r\n5bgxfoursevenrhtcqf2dpkvfmsmh2\r\n8rdsljbdggzseven4chgfppzmzkj\r\nhfcjpnrzsixfivefour6\r\nseveneight5hldmqltxonecbtknbeight6\r\n6ninetztvlzdmgj2xzbtk\r\nthree988twodndrqvqpq\r\n4threejkrpgtlhgg6five\r\n4kgxgmprssixseven\r\nspfpone16\r\nxcpqvrthreemrggrvghqcgbqtkknvvk5\r\n2three84bxtwo\r\ngjmv82mgnqqgnzcgcd\r\n3nine4seven\r\n9twosnine\r\nnxfmfour8bgcgdkvb\r\n8three6one\r\nbxvxksbbdn3knpdc6stfbxffjggfglc\r\nsevenmfpxjgnpb743five6\r\nseven7sm\r\n8qxbbcxjvppeightwot\r\nfivetwotwo1seven8r\r\n96eightnrbeight84\r\ngljg4fiveone\r\n8nine6sevenmllmmchzjxb\r\n3twosixdcgl\r\n6xsfmfjjnz6vstfvhndhlklrsc73kljcseven\r\nthreefour1\r\ntqtlxckrrch5jone9\r\n9qjsntszxb\r\nninetwopqfnsrxrfstwod8one\r\n6eight85\r\nfour63vgjflnctzssfstjx113\r\n1vhshftmrbseventhreetwoeight\r\n51bntvpdmxfznine5hbt\r\nfivebpcntvnklxxseven9\r\n2xq\r\nvjcbktqbxd55zhdxrhjqnr\r\nbxqndkhjg1sixvjct4\r\n2two1three\r\nkkconeight5eight9\r\ngz6two\r\ndmctnkrmone7fourdfqcfone3\r\n9oneightcb\r\nfiveqzjsvjqlsd99kpsixone\r\n8fivehfphnvtdf\r\n3six8jrrlnpj\r\n1six53hpmgsfqfourxmfmdqds\r\neight7ljkrn3cntjv\r\n7rkscrcchttwoggxktqdptwodpkcsgpbseven\r\neightthreeseven9threebdlskshg\r\n18xpklsg\r\n2sevenjlscgksv\r\nrmr3784sevenbgqfhklhl\r\ndbmtkvthree9mmqzfvmhpthreefivethreetwo\r\n566sixeightone6fiveone\r\nsixtwokf9\r\nlzgsrdmnl2xpps\r\nzlbmfmxtvhvng1eight\r\n1nine76ninegpc\r\n8onesevenxqjqrxflrb1\r\n2dhthree6sixthree\r\n4eight16\r\n2threenvllhnkqthreelhfnbp1gmkcgdf\r\n5threeeightthreeeight\r\nqjltlxkptr7threezplpxvqgrrn5\r\nftkjg8onedxjcnmrsmf6foursctg5\r\nthreenks5\r\nbtseven2dlqjqpsnhxqmvqnjx\r\n43four\r\n64thknbt3three\r\njgghlcsxl4gtwo9gfdcgxfour\r\nmvdkntknjf1stttccdntnrxhhdzgnrzznineseven\r\n2nine4nine\r\n4s6eight66616\r\nr4eightjfldjbqhcpxnhmsmzsjm\r\n3smktnsbtjm27cpkzvnjxone\r\nhvtccdslkb83xmlpktzbfournlklrqfxone\r\nseven5twosix9\r\n6dcqcfvcrbs8pxphlrrlvqlmjqfrlfoursixseven\r\nqntwofivezcpfknsvq51\r\nkdvszdf9tzkbhmthn\r\n79dcrnqfrnine\r\ndh8hrfvk2nine1fivefourseven\r\nrphmhjjnthree1threekbpbjhfk2threeggzjsz\r\nfhfive3vcflkznnpfive\r\nsp19onesixtwo5\r\neight2ninejc4fivedgffn\r\nm5ffive\r\n436\r\nkhpvrkl27twotwo\r\n7fnbzfdsqeight5fourone5one\r\neight92nine48fivecnhzhg9\r\n83mkhqxtdt\r\nfivezvmqbczkgclsxfour3eightthreethree\r\nsixsixxlmh6\r\nsixfive98\r\nfourttlpxqponetwokn8tvkmrk66\r\n1chfcvrmxbtwo4\r\nsevensix1rlcnmbhs4\r\neightftbfczpt8cgcnnck\r\nfourfivessnxfmlzzfiveseven24mfbfx\r\n49lqkxcxtjs2jdsbkmrvfninesix56\r\nfknjdjqcnm66hrktq\r\n1three24four6\r\nrpxtwone83\r\n5vnntgqnrpjh537ninebbkcs6\r\nthree5mjmzhht57\r\nsix4gfqcdbdhx96jvhktthree6\r\nsevendbssnxndrdxlbvssrt8dtrgcxxsixonehhstdr\r\n1sixfrzgtwo27pf\r\n6onevnnptcxhzgonethreetfxlsvxfmbqc\r\ngmqnpqsix7three3one5tpklvdfzkbqftkhrj\r\nrrslpzr1\r\n7ninedsvqtgntjdsqqmhgpjkqxkbpgmkxl\r\nsevenxhpjppgxqqz9nxgctwo\r\n7onefour\r\none6dsntwo\r\nghlgnsztmtsevenfour1bsctrtmp\r\nonehtzmgbpkjcninefive7bmlnvfhsreightthree\r\n2822\r\n3threerbtmxdngpq12oneeightone\r\nthreenine7z\r\n9bvxxcsnzfive98\r\ndjctwonefourlxshzxzmff313onesixkzxxhrrfour\r\nsevensevengjbfbzmvlhlseven7bgdrreight\r\nseven34p5zpmnn\r\nr27threeqzx27gspmgncgth\r\nthreeeighttwoone1jqghpbbl\r\nonefqlnr9bmsvjsb2gcl4\r\nthreeqxjjjtqx4four2mbxfive\r\n5one9qnrzfdsixone\r\nthree184eight\r\n2hcnineseven1\r\nonejgnvdndtwoqpdxbnzhkg91sevenrfgv\r\nhmgseven1fivek866\r\nseven4four1zpgc\r\ndl8three5\r\n7two2\r\nhbglb9719\r\n1zsgbsmmgprkmgssvnrbv7\r\n5sixfourrfbbvmlrjfourl\r\nthree63sixseven5\r\nseven3eightthree318five\r\n6brhdvjnz\r\nonesevenfivefour5four413\r\ntwo5689seventhree9\r\n59nczhdqzdr\r\n3vsxmbrfkljfxlkxm1x\r\n6nm6k5three47\r\n451sixxkcncfqr\r\nxsixonevns4seven3vlxpfcttwo\r\nkl6onehlrmxgbfourfour8\r\nqvfclpxqfivethreeninesixl521\r\n33hpkbonepsnfp8nine2\r\nthree41fivetzzfvmlsfive5two\r\n9two6vgvxhnfjone\r\nsix68five8pbgrvl2six\r\nsphsdpxfdtgvmmtwoone8eight\r\nz726vlhseven\r\nnine9ninesix6xmgbsgfmpgxkzgpzlxqnjsqhr\r\nfourknflljrbrq63five\r\n42onef6seven\r\n39njjvzt7threetkccstz";
            //InputData = "";   // Exemple donné pour debug
            #endregion

            InitInputData(InputData);

            foreach (string ligne in Lines)
            {
                InitialisationLigne(ligne);
            }
            if (this.Debug)
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
            int NumeroPt1 = (ligne.Where(c => NombresNum.Contains(c)).First() - '0') * 10 + (ligne.Where(c => NombresNum.Contains(c)).Last() - '0');

            int NumeroPt2 = 0;

            int IndexMin = ligne.Length;
            int IndexMax = -1;

            int valMin = 0;
            int valMax = 0;
            for(int i = 0; i < NombresTous.Count; i++) 
            {
                string s = NombresTous[i];
                int index = ligne.IndexOf(s);
                if(index >= 0 && index < IndexMin)
                {
                    IndexMin = index;
                    valMin = i % 10;
                }
                index = ligne.LastIndexOf(s) ;
                if (index >= 0 && index > IndexMax)
                {
                    IndexMax = index;
                    valMax = i % 10;
                }
            }
            NumeroPt2 = valMin * 10 + valMax;
            ValeursLignes.Add(new Tuple<int, int>(NumeroPt1, NumeroPt2));
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
            long nb = 0;
            foreach (var ligne in ValeursLignes)
            {
                nb += ligne.Item1;
            }
            return nb;
        }
        private long ProcessPart2()
        {
            long nb = 0;
            foreach (var ligne in ValeursLignes)
            {
                nb += ligne.Item2;
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
        }
        #endregion

        #region Classes de travail

        #endregion
    }
}
