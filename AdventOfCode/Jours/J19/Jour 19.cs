namespace AdventOfCode.Jours
{
    public class Jour_19 : Jour_abs
    {
        #region Enumerables
        #endregion

        #region Helpers
        #endregion

        #region Propriétés
        private Workflows WFPlan { get; set; }
        private List<Part> Parts { get; set; } = new List<Part>();
        #endregion

        #region Constructeur
        public Jour_19(bool debug = false):base(debug)
        {
            #region Input Data
            string InputData = "bcj{s>2236:A,s<1879:A,x<3217:R,R}\r\ndx{s>2913:fjr,m>3556:A,a>845:A,qmf}\r\nllc{m<375:A,A}\r\nsk{s>1852:A,s>1779:A,A}\r\nkkb{a<3232:R,x>2370:A,R}\r\nqpz{s>2002:R,s<1970:A,A}\r\nxh{m<1123:hxp,hbs}\r\nhvs{x>833:A,a>3047:A,m<2545:A,A}\r\nbn{m<884:R,m<1819:A,x<191:R,A}\r\nmg{m>3212:tbn,a>2969:bvv,m<2894:hn,dv}\r\nzxl{m>1434:zm,kpk}\r\nndg{m<2376:A,m>2763:A,A}\r\nrzf{x<493:A,A}\r\nbvj{s>2051:kpv,a<430:jsq,rz}\r\nknm{m<972:R,R}\r\njds{s<2286:R,x<544:A,a>2810:A,A}\r\nrdg{m>1477:bzn,m<1233:srv,tlm}\r\njg{x>938:cz,a<1498:rnn,nvj}\r\nzx{s>418:rgl,x>3567:R,jxd}\r\nzg{m<471:A,a<2572:rzf,s>2871:A,R}\r\njcs{s<2971:R,s>3598:A,x<3099:R,R}\r\nrk{s<3628:jg,bgx}\r\ndj{s<2872:R,x>871:llc,A}\r\ntsk{m>2811:R,a<2339:R,R}\r\njv{m>760:fkk,s<2822:rzk,mr}\r\nhhd{m>1117:A,A}\r\nghz{a>1392:dvd,hhd}\r\ndn{x>968:A,s<1630:R,R}\r\nnts{a>80:A,a>64:A,R}\r\nxn{m<573:R,a<3414:R,R}\r\nqc{m>1686:dvp,bm}\r\nmlh{m>692:A,x<2902:A,A}\r\nxfk{m>2842:R,R}\r\nvrh{a>2782:R,R}\r\ndcf{s<3052:A,m<2489:R,s<3448:A,A}\r\ntv{x>2354:tp,s>2429:R,ppm}\r\ngt{m>2262:A,s>3008:R,A}\r\nbs{a>2819:mhl,pgx}\r\ndg{x<1711:A,a>205:R,m<2496:R,R}\r\nstf{m<3718:dx,pdf}\r\nvkq{x<145:R,x<246:R,m>3266:R,A}\r\nsf{m<2735:R,a>3531:R,a<3366:A,A}\r\nmzl{s<2358:R,a>469:A,vlt}\r\nptv{a>2905:R,m>421:A,x>2378:R,A}\r\nqxc{a>2506:R,x>298:pc,s>433:R,vkq}\r\nkp{a<1201:R,R}\r\ngdl{a>3699:cnx,R}\r\nhm{s>2407:A,A}\r\ncv{m>3491:A,a>765:A,A}\r\nhxp{a<2799:xvm,x<2281:xn,x>2576:R,A}\r\ncnh{m>3228:A,A}\r\nkzg{s<3590:lq,s>3742:rg,s>3685:knv,rk}\r\nrsf{m>2247:R,A}\r\nfh{a<752:A,R}\r\npc{m<3219:A,a<1070:R,A}\r\nzzc{m<1537:rh,x<1332:ks,s>3714:fdp,A}\r\ncjx{m<688:R,m>715:A,m>698:A,R}\r\ncm{m<1054:R,m<1358:db,m<1665:A,A}\r\nbl{m>3228:R,A}\r\ngxc{x<2677:A,s<3681:R,x<3281:R,A}\r\nvn{x<1211:R,a<866:R,A}\r\nmmk{x<3204:tcm,mvt}\r\nscv{m<2127:R,m<2757:R,R}\r\nzdx{x>3953:R,A}\r\nnc{m>685:A,A}\r\nhsx{m>642:R,A}\r\nffs{x<3434:jr,s<1059:hph,vrf}\r\nnnt{s<3682:A,A}\r\nncp{m>3832:zq,a<166:fqr,s>2611:R,R}\r\nnr{x>764:R,A}\r\ncnn{m>1004:R,s<3558:A,a<3149:R,R}\r\nqpk{x>2793:lcq,cjg}\r\nbvv{s<2215:R,R}\r\ndzv{m<1595:R,a>2746:A,A}\r\nhlp{m<2717:R,a<112:R,m>2886:A,A}\r\nhbs{m>1397:kkb,s>634:qz,a<2922:csb,A}\r\nrtg{x<744:R,m<3368:A,x<837:R,A}\r\nsng{m<309:dq,x<247:hsx,vmx}\r\ngtz{x<350:R,A}\r\nbkr{x<2489:jnd,x>3246:R,R}\r\nqt{s>162:A,s>148:A,A}\r\nkt{m<306:A,A}\r\nxq{s>2980:A,R}\r\nnhp{s<2481:R,s<2699:A,s>2972:R,A}\r\nzmd{m<3111:R,A}\r\nrnr{a>2648:md,R}\r\nlmh{s<608:A,R}\r\nkkq{x<3443:A,x>3701:A,s<1947:R,R}\r\nsmz{a>1213:ghz,nz}\r\npnj{a>2358:gs,s<291:R,A}\r\nzm{m<1811:rl,a<2644:lnl,s>2150:gp,hg}\r\nxzq{x>1152:R,bdc}\r\nrxm{a>1500:A,A}\r\nctt{x<910:knm,mqh}\r\njf{x>2683:vhq,x<2214:lvg,R}\r\nhs{s>736:R,x<2835:R,m<2848:A,A}\r\ngp{x<708:mrc,x<1063:R,s<2409:khf,A}\r\nmps{a>639:cdk,m<2016:tz,a<353:hp,cr}\r\ntl{x>2394:R,s>3188:A,A}\r\nhqx{a>649:A,m>2661:R,R}\r\nhbj{a<175:R,A}\r\nrs{s<3100:R,A}\r\npnn{a<2669:mm,m>2861:R,a<3361:jpb,A}\r\npbk{m>2755:R,a<824:hqx,m>2677:A,R}\r\nzvq{s>1300:R,a<3508:A,s<1200:A,R}\r\nhgj{s<3821:A,x>2702:A,x<2287:R,R}\r\njx{m>1376:A,x>482:R,x>233:pbx,vl}\r\npjg{a>2436:mg,pf}\r\ndt{s<3582:rm,m<3084:lbl,pp}\r\nqm{m>1296:jf,m>1258:mt,m>1232:jlq,dh}\r\nfkk{m>930:qpg,s<3192:glq,a<2845:R,xs}\r\nzv{x<3000:R,R}\r\ntg{a<2422:gnz,a>3105:zvc,m>1030:jn,lc}\r\ncsb{a>2364:R,A}\r\nzjf{x<2175:R,R}\r\nst{m>1699:zxn,xh}\r\nxv{s<328:R,m<2127:R,R}\r\nbpb{x<2814:gdl,s<2502:cnq,s>3484:rv,hqq}\r\nxj{a<2653:A,x>354:A,A}\r\ntmf{a<1461:lmh,s<883:A,s<1238:cnh,R}\r\ncl{s>1307:R,m<903:R,x<3644:R,R}\r\nlc{m>585:jv,a>2877:gfm,m>204:jzv,lrn}\r\nxz{s<3512:R,R}\r\ngqv{m>488:A,psx}\r\nfl{a<1470:gdr,x<596:zk,a>2901:fmd,ftn}\r\nflj{a<3243:pj,A}\r\nnsg{m>1345:R,s>3301:R,A}\r\nmhl{m<1146:A,x>3138:vzh,s<2495:R,R}\r\npkl{x>2127:R,a>2366:A,a>2111:R,A}\r\nhff{m>3698:kzf,x<3696:R,R}\r\nnzp{m<577:R,x<2373:A,R}\r\nnkv{s<486:A,x>892:A,R}\r\ndh{s>2784:pxn,m<1220:A,m>1225:shx,ng}\r\nvg{s<1279:R,A}\r\nqjl{s>744:A,R}\r\nbc{x<809:R,a<802:R,s>63:A,R}\r\nnt{a<500:R,a<991:R,x>599:A,A}\r\ngk{s>241:R,x<2909:chl,A}\r\nmh{a>337:A,R}\r\nhhr{s>2512:R,kkq}\r\nrz{m<2800:sk,hgm}\r\npf{s>2109:R,s<1938:R,qpz}\r\ncc{m<2623:hz,R}\r\nbkb{x<3020:R,A}\r\nkhf{s<2247:A,a>3124:R,A}\r\nrxx{s>3423:R,A}\r\nlx{x>2862:A,A}\r\nlm{x<1348:R,A}\r\ncj{m<2624:R,x>659:A,qg}\r\nflq{x<354:A,m<2208:R,A}\r\nmgq{a<378:R,R}\r\nlb{a<1478:zhb,a>3026:A,x>506:xd,ns}\r\nnh{m<1325:R,R}\r\nnj{x<3388:rsf,R}\r\nmvt{a<2971:A,a>3368:A,R}\r\nzrq{s<1068:A,A}\r\nql{s>3450:A,s<3309:A,a>349:R,A}\r\ntz{x<3055:zrq,x>3527:R,m<1145:A,A}\r\nch{s>836:rc,s>515:cmq,gk}\r\ncbv{x<3456:zv,s<2710:A,m>2476:lhn,cgc}\r\nnb{s>487:A,R}\r\nzp{x<3382:A,m<2400:A,A}\r\nnl{s>3261:A,s>3183:R,R}\r\nhdr{x<326:R,m<2396:R,x<353:A,A}\r\nmn{s<3015:mp,a>2917:pm,qb}\r\njr{m>1751:hj,mmk}\r\nfsk{s>1189:R,m>702:R,R}\r\nxcs{m>2025:A,x>730:R,x>465:R,A}\r\ngdc{s<3676:R,s<3680:A,A}\r\nxr{x>2595:A,m<1556:R,a<3672:A,R}\r\nvlt{a<442:A,a>454:A,a<446:A,R}\r\nhxk{x>1265:A,A}\r\nqpg{x<2888:A,x>3295:A,x>3035:R,R}\r\nmjf{s>262:R,s>234:R,a>3542:R,R}\r\nznm{a>1618:A,x<978:R,A}\r\nfq{a<2186:A,s>2212:A,A}\r\nvs{m>377:A,a>2650:R,R}\r\nmdg{a>884:hff,bb}\r\nvq{m<672:hv,m<1059:R,m>1160:A,R}\r\ngx{s>2825:R,A}\r\nxvm{x>2321:A,s<584:A,x<1857:A,A}\r\nqq{m>2815:lk,s>1660:hdr,a>3218:flq,A}\r\nnv{s>652:qf,qxc}\r\ncbm{a>3614:qx,R}\r\nls{s>1539:lb,vlc}\r\nvh{m>2816:kp,x<330:pk,A}\r\ntbn{m>3616:R,s<2147:R,A}\r\nzhq{a>2701:R,a>2558:R,A}\r\nsq{s>2909:R,m>3304:A,R}\r\ngkf{x<2381:gt,x>3292:R,A}\r\nnf{m>2231:R,R}\r\nghj{x<742:zg,x>1124:nnh,a>2016:gqv,dj}\r\nppm{a>2662:R,x<2007:R,R}\r\nhkz{x<2578:mc,vxs}\r\nqg{x<265:A,m>3099:A,A}\r\ncs{x>1082:hxk,x>785:zkx,rsb}\r\njp{x<3156:A,R}\r\nmf{x>159:bd,lmv}\r\nks{m<2850:R,x>1209:R,x>1073:R,A}\r\nxbh{m<384:R,m<526:R,m<559:R,A}\r\nmql{x>2491:R,qdc}\r\nlmv{s<1357:A,A}\r\nzlq{m<1608:R,x>2032:R,a<3614:R,R}\r\nbk{x<705:qzn,x>749:nr,A}\r\nbr{m<624:R,R}\r\ngcc{a<2067:gm,m<1260:vq,xtl}\r\nnx{a>826:R,m>2770:A,m<2368:A,A}\r\nmj{m<2250:R,a<949:A,R}\r\npd{s<794:R,m<984:A,x<2919:A,R}\r\nbj{a<1930:A,m>550:A,m>289:A,R}\r\nzvc{s<2813:csr,hdl}\r\nsj{x>2759:A,m<646:A,R}\r\nbp{m>1610:R,x>187:R,a>2927:A,A}\r\nxlx{s>2967:R,s<2367:xlz,m>3457:vm,R}\r\nrrs{m<1350:pdv,x<225:bz,xx}\r\nmrc{s<2376:A,A}\r\nhhm{a>1620:xlx,s<2703:jd,ltl}\r\nqhh{x>642:nsg,A}\r\nnkd{m>1644:A,a>2714:R,m<1500:A,R}\r\njn{m>1371:tcl,m>1205:qm,bs}\r\ngfm{s<2728:mql,a<2978:lpf,m>344:jp,bkb}\r\nbq{s<2699:R,m>375:R,R}\r\nfjr{s<3616:A,s<3760:A,x<2454:R,R}\r\nlrn{m>80:zvn,m<46:tv,a<2618:tcv,cb}\r\npm{s<3627:A,cnz}\r\nlh{a<47:R,x<1977:nts,x<2160:A,A}\r\nlq{m>2133:hh,a<1957:qhh,s>3390:fcj,ss}\r\nns{a>2112:A,x>443:R,s>1637:A,R}\r\nmqh{m<899:A,x<925:R,x<932:R,R}\r\nmnf{x<1236:R,m<722:A,m>834:A,lsq}\r\nlns{m>540:R,R}\r\nqb{m>3068:A,s<3630:R,rp}\r\nzgc{s>157:A,a<2880:A,A}\r\nbg{s>1424:A,A}\r\nfp{m<3748:R,x>3563:R,A}\r\njsq{x>1832:bcx,m<3125:A,R}\r\nzt{s>1211:R,s>1135:R,A}\r\nfhn{s>3568:A,x>3191:A,R}\r\ncvq{m>3218:xq,x>2582:A,s>2448:A,A}\r\nqmf{x>2322:A,m>3467:R,s<2223:R,R}\r\nmqm{a>2259:A,scv}\r\nsn{m>1037:R,qkn}\r\ncx{s>244:A,x>1311:R,R}\r\nzpd{s<1427:A,a>1779:R,R}\r\nrr{s>1826:cdz,x<568:ttl,pvs}\r\ncdm{a>1936:hpt,x<1270:fqb,a>1251:A,cx}\r\ngb{x>2017:tsk,x>1851:R,x<1684:znz,R}\r\nkb{a<1075:A,s>2851:A,R}\r\nrnn{m>1645:R,R}\r\nfqb{a>1129:R,R}\r\nnvq{s<1550:mf,a>1970:pnn,kx}\r\ncjg{a<500:A,A}\r\ntpz{x<3638:R,A}\r\nzs{x>226:A,a>1279:R,x<81:A,R}\r\nshh{x<2023:R,a>1077:A,m<3110:A,R}\r\nfdp{a>1468:R,s<3727:A,x>1434:R,R}\r\nxs{a>2935:R,A}\r\nphd{a>115:th,lh}\r\ndb{a<2563:A,s>1398:R,A}\r\nttl{s<1004:zqx,m<1653:xl,cjr}\r\nfmd{a>3387:R,A}\r\nqzn{m>375:R,a>2109:A,s>283:R,R}\r\nhph{a>2754:rsv,x>3782:mqm,zx}\r\npvs{m>1842:xg,x>1013:tdb,mqg}\r\nhd{x>1320:qjl,x<1187:rnr,mnf}\r\nhl{m>1458:R,m<1389:A,A}\r\nzk{a>2689:dqv,A}\r\njms{x>965:R,A}\r\nlfd{s>2581:dzv,nkd}\r\nvdb{a<2202:zxt,a<2294:A,R}\r\nqp{s>1511:rnj,sng}\r\npj{a<2909:A,R}\r\nrsb{x>641:R,a<2354:A,s<1177:jc,A}\r\nczb{m>3141:R,R}\r\ndns{m<3457:A,A}\r\nfr{m>1065:A,m>422:A,R}\r\nqn{x<920:R,x>1286:A,m>1176:R,R}\r\nhjb{s<3744:R,x<3145:R,R}\r\nlz{s<1214:jmm,x>1334:kj,A}\r\nqz{x<2297:A,R}\r\nmt{m>1278:R,R}\r\nhx{m<329:R,A}\r\nsp{m<745:R,qn}\r\nlcf{x>2723:A,A}\r\nqdc{x<2021:A,x>2232:R,R}\r\nzxn{a>3213:gn,a<2726:gb,tq}\r\ncsr{x>2568:cp,m<773:nsr,m>1236:sgk,sn}\r\nvc{m<3005:R,m<3610:ps,R}\r\ncgk{x>1258:R,x<1110:A,x<1196:A,R}\r\ncgc{a>1921:R,A}\r\nvrf{a<3069:vd,m<2619:hq,nlv}\r\nvl{a>1308:R,a<664:R,a<1067:R,A}\r\nfn{s<3270:kb,A}\r\nxb{a>590:vn,m<2224:rxj,R}\r\nng{a<2765:A,x<2511:R,a>2927:R,A}\r\nzrf{s>322:A,s<196:R,a>2973:mjf,A}\r\nrc{m<1118:R,x<3069:A,s>1241:zpd,A}\r\nmcc{x>748:A,A}\r\nqlc{a>2547:R,x>3107:A,s<2267:A,R}\r\nbcx{x<1953:R,s>1831:A,A}\r\nhpl{x<369:R,m<3331:A,m>3701:R,A}\r\ndmt{s<1024:R,a<1521:A,A}\r\nnsj{m<2783:rvg,a<1980:hhm,ld}\r\nlk{m<3591:R,x<331:A,a>3320:R,R}\r\nbh{s>2643:dvz,a>2702:A,A}\r\ntx{s<156:R,a<1799:mj,s>253:fzm,hvs}\r\nxvg{s<2714:A,s<3147:A,A}\r\nhh{s<3409:nl,m<3233:A,a<2422:xz,R}\r\ngts{a>1286:hhr,gbr}\r\nckf{s<2414:pjg,x>994:ffj,cmt}\r\nmx{a<981:R,a>1003:A,s>2182:R,R}\r\nglq{a>2825:R,a>2592:R,R}\r\nld{m>3369:bkr,s<2719:thc,zbn}\r\ngnz{a<970:hkz,a>1669:gcc,x>3079:gts,smz}\r\npsl{s<1643:dxb,m<2010:tg,a<1346:pqn,tk}\r\ntf{s>2822:sq,m>3143:R,rd}\r\nvz{m<3712:mnd,s>134:qt,a>1799:kn,bc}\r\nqss{m<3104:qv,x>2681:A,x>2001:A,R}\r\nfcj{s<3503:R,s<3532:A,x>696:cnn,kc}\r\nvlc{s>1302:A,m>3084:dns,hc}\r\nbd{m<3160:R,a>1409:A,A}\r\nbps{x>1384:fcs,cdm}\r\ncb{s<2615:R,s<3448:tn,a>2723:nnt,A}\r\nlsq{s>809:R,R}\r\ngrr{a>3271:bpb,mn}\r\nhqq{x>3438:xfk,R}\r\nrd{x>267:R,x<90:A,R}\r\nfqr{x>2550:R,x>2122:A,R}\r\nrzk{a>2747:sj,s<2106:mlh,x<2830:cjx,sfk}\r\njkg{m>2606:pbk,a<1058:qd,a<1219:gkf,bbs}\r\nflz{x>2125:A,a>2097:R,m>2163:A,A}\r\nzqp{a<1151:R,a<1198:R,s>3041:A,A}\r\ndvz{x>782:R,a>2898:R,R}\r\ndqv{s<408:R,x<578:R,R}\r\njd{m>3201:R,s<2207:trx,s<2489:A,rxm}\r\nhgm{s>1788:R,x<1769:A,x<1995:A,R}\r\nvqr{s>788:hx,x>1312:R,A}\r\nthc{s>2155:zmd,R}\r\ndvp{a>2498:R,m<2002:nhh,A}\r\nft{m<507:A,s<3387:jnr,m>533:A,A}\r\ntr{x<3220:vs,m>439:jb,A}\r\nmqg{s>766:ksh,x>775:pdr,x<643:fl,kxv}\r\nmhv{a>372:R,R}\r\nlfh{s>111:A,a<2061:A,kjq}\r\nkjq{a>3318:R,m<3194:R,a>2864:A,R}\r\nznz{a<2358:A,m<3219:R,R}\r\ndr{m>2049:A,A}\r\nsjl{x>3661:R,A}\r\nxl{m>895:rrs,qp}\r\ngm{a<1886:jcs,m>1004:R,s<2632:jsc,lx}\r\nshx{m>1229:A,R}\r\ntp{m<17:R,s<2612:R,R}\r\nqrx{x>3692:A,x>3463:A,R}\r\npgx{s<2943:A,a<2592:R,rxx}\r\ncmq{s>728:pd,R}\r\ncnz{m>3336:A,a<3109:A,s>3758:A,A}\r\nzlj{s<2298:zp,m>2495:vdx,m>2315:R,A}\r\nvr{a<39:A,s<588:R,R}\r\nntf{x<3136:R,s<3561:A,a>158:A,R}\r\nmp{m<2748:A,A}\r\nxx{a>2166:spr,x<415:vg,x>508:hl,fh}\r\nlbl{s<3777:gxc,a>409:A,m>2712:mh,R}\r\ntcm{x<2977:R,m>847:A,R}\r\nfcs{s>272:A,a>1567:zgc,A}\r\nnsh{a<3221:A,x>521:R,R}\r\nkr{m<1648:R,A}\r\nsrv{s>922:cgk,sc}\r\npxn{m>1223:A,s<3294:R,R}\r\nlvg{a<2737:R,A}\r\nmd{m<757:A,a<3484:R,x>1079:A,R}\r\nchv{s>2853:dt,x>3123:mz,x>2140:vv,bvj}\r\njlq{m>1247:xvg,R}\r\nmc{m<1264:A,ptm}\r\nvhq{m<1335:R,x<3245:A,a>2829:A,R}\r\nhpt{m<3161:A,a>2904:A,A}\r\ndtf{a<3472:R,s<2342:R,R}\r\ntrx{s>1998:R,s<1829:A,A}\r\nvdx{s>2511:A,s>2428:A,m<2752:A,R}\r\nvd{s<1390:A,x<3751:R,x<3880:R,zdx}\r\nptm{m<1617:A,x>1926:A,x<1694:A,R}\r\nvf{x<686:A,A}\r\ndl{m>2226:A,R}\r\nmm{x>136:A,a<2364:R,A}\r\nbgx{s<3665:R,a>1589:spq,gdc}\r\nsg{m>3237:A,x>3478:R,A}\r\ndq{m>135:A,R}\r\nhp{a>164:A,a<60:vr,m>3056:A,df}\r\nrm{s>3161:vxc,s<3056:fgg,rs}\r\nbx{m<2349:nth,a<87:R,hlp}\r\ncdz{s>3074:kzg,m>2365:ckf,s<2573:zxl,sqj}\r\nksh{x<811:fsk,x<921:cm,znm}\r\nkx{s<1706:A,x>175:R,R}\r\ntzj{a<2609:vh,s>1501:qq,flj}\r\nxc{x<1363:A,A}\r\njzv{x<2484:bq,s<2883:tr,m>431:ft,jls}\r\ngs{m>1412:A,x>709:R,A}\r\npk{a<1730:A,x<308:R,x<319:R,R}\r\nkpv{m>3321:R,a<457:A,R}\r\njcl{a>2730:R,m<880:R,R}\r\nkl{a<965:A,x<287:R,m<3351:A,R}\r\ntqc{s<518:R,a<3082:A,A}\r\ngh{m>2373:gnj,nj}\r\nrv{x<3370:hjb,sf}\r\nbz{x<119:R,m<1550:A,a<2149:R,bp}\r\ngtr{s<3309:R,x>3634:A,A}\r\nqkn{a>3568:A,s>2419:A,A}\r\nqd{x<2634:R,m<2382:mlr,a>847:R,A}\r\nlhn{x>3722:A,A}\r\nhc{s>1187:A,a>2167:R,m>2591:R,A}\r\nxd{m>2456:R,a>2280:R,R}\r\nbb{s<2972:gf,m<3645:cv,m<3848:fp,qrx}\r\nzqx{m>2541:nv,hr}\r\nnq{x>601:R,s<2677:kl,s<2917:gx,gtz}\r\nlpf{a>2914:ppv,m<299:tl,a<2900:R,ptv}\r\nkc{a<3291:A,x>339:A,A}\r\nzvn{a>2638:R,s<3043:kzr,zfh}\r\ntrl{m>1081:R,nzp}\r\nzq{a<182:A,A}\r\nnhh{m<1864:A,x>941:A,A}\r\nllz{a>1108:R,R}\r\nknv{a>2354:cj,x>996:zzc,s<3723:dr,jx}\r\nzz{s>453:A,A}\r\nbm{x<874:R,R}\r\nth{s<2637:qsv,x>2052:A,s>3374:ndg,dg}\r\njc{x<596:A,x<616:A,a<3401:A,A}\r\njnd{s<2807:A,s<3453:A,A}\r\nxt{m<2915:jkg,m<3333:xbx,x>3162:mdg,stf}\r\nhz{x<1195:A,m>2319:R,R}\r\nmlr{s<2819:A,R}\r\njcb{s<3169:xr,a<3594:lcf,s>3337:A,R}\r\ndvd{x>2266:R,s<2456:R,R}\r\ncz{x<1213:R,R}\r\njls{x<3307:A,s>3588:zhq,gtr}\r\nqcv{m<2944:tx,s>212:fc,m>3494:vz,lfh}\r\nrsv{a<3428:R,m>2118:zbh,km}\r\ncp{s>2204:R,a>3681:A,A}\r\nkpk{s>2298:hm,s<2124:sp,x<580:rn,nc}\r\njsc{m>577:A,x>2348:A,x<1894:A,R}\r\ngdr{m<1018:nt,a>862:nb,a<521:A,R}\r\ncq{a>1679:jh,x>2455:kg,tmf}\r\nkm{a>3750:A,x>3811:R,A}\r\nxlz{m<3339:A,A}\r\njpb{s<1718:A,A}\r\ndv{a>2641:A,s>2037:R,s<1920:R,R}\r\njmm{s>691:R,x>1219:R,a<384:R,A}\r\nqsv{m<2465:R,m<2782:A,A}\r\nrg{a>1394:pt,x>724:xb,cg}\r\ngf{a>678:R,R}\r\ntcv{s>2592:A,qlc}\r\nhq{m>1644:zvq,a<3426:A,a>3644:cl,R}\r\ntn{s>3020:R,a<2786:A,R}\r\nrj{m<1057:A,A}\r\npdr{a<1445:dp,x<882:zrf,x<940:ctt,rmq}\r\ncdk{s<782:A,m>2281:A,x>3070:R,R}\r\npdv{s>1360:xj,a<2197:zt,R}\r\nhxf{s<2049:R,x>2247:A,A}\r\nkzf{a>1176:A,m>3860:A,A}\r\ngxn{a>3573:A,A}\r\nzbn{x>2791:R,pkl}\r\nkzr{x<2744:A,x>3573:A,x>3114:R,A}\r\npqn{a>543:xt,a<287:td,chv}\r\nbbs{m<2371:R,dcf}\r\nkxv{m<800:bk,pnj}\r\ncg{x>392:R,m<2342:A,R}\r\njh{s<596:R,A}\r\nlnl{m>2064:dl,A}\r\nvxs{x<3363:A,s>3117:ql,nhp}\r\ngnj{m<2761:ntf,a>158:fhn,A}\r\nlkq{x<1201:R,m>380:A,A}\r\npt{x>1005:rkp,m>1814:A,R}\r\nvzh{a<2967:A,s<2919:R,s>3436:A,R}\r\nxg{s>800:cs,s>433:lf,x<1166:qcv,bps}\r\ndxb{a<2010:zvs,x<2857:st,ffs}\r\nqf{a>2114:hpl,czb}\r\nkn{a<3038:A,x>858:A,m<3875:A,A}\r\ncr{m>3287:R,mqs}\r\nhv{a>2238:A,a>2148:A,A}\r\nvv{a<436:mhv,x<2586:lkt,qpk}\r\nhzk{x<2136:A,s<3490:A,m<723:A,A}\r\nzxt{s>978:A,R}\r\nkz{a>147:zlj,bx}\r\ntd{m>3001:gst,x<2376:phd,s>2885:gh,kz}\r\nvm{s>2601:A,x<2583:A,A}\r\nhr{x>273:fr,tvh}\r\nzvs{a<1335:mps,m>2218:cq,ch}\r\nhg{s<1954:lkl,m<2144:xcs,s>2053:nsh,nf}\r\ncjr{x<294:nvq,x>385:ls,tzj}\r\nqx{m<562:A,A}\r\nrnj{s>1717:lns,ggg}\r\nhj{m<2990:R,m<3504:A,x>3229:A,R}\r\ntlm{a>2460:glg,A}\r\nps{s<2694:A,m<3245:R,s<2889:A,R}\r\ngst{m<3558:cvq,m<3745:zgn,ncp}\r\nlkt{x<2308:A,A}\r\nzhb{a>913:A,x>487:R,a<500:R,R}\r\nlf{x<903:qbv,s<581:cc,a<2449:nx,xzq}\r\nggt{m<186:vj,vqr}\r\nnz{m>951:llz,s>2939:R,a>1082:A,R}\r\nrp{m>2675:R,m>2261:A,A}\r\nfzm{x<899:A,R}\r\nnnh{s>2847:bj,m>604:dzq,A}\r\nrqk{a<829:lz,a<1378:kt,a>1776:vdb,sbv}\r\nzfh{s>3658:R,A}\r\nrb{m>2433:zjf,flz}\r\nftn{a<1998:xvb,s>326:R,a>2510:jcl,R}\r\nrkp{a>2607:R,a<1968:R,m<1342:R,A}\r\nmz{a<422:sg,mzl}\r\nbzn{s>789:A,A}\r\nvxc{s<3419:A,s<3525:A,m<3238:R,R}\r\nmqs{s<966:A,A}\r\nph{x>2317:A,x>2178:R,A}\r\njnr{m>555:R,A}\r\ncnx{a>3858:A,R}\r\nsfk{m>670:R,x>3344:R,x<3118:R,R}\r\ntvh{a<1646:kr,x>130:bn,tqc}\r\npp{a<429:mgq,m<3566:hgj,s<3784:A,R}\r\nrxj{s<3911:A,a<208:A,R}\r\nxtl{s<2570:R,R}\r\nrgl{a>2317:A,m>2066:A,a>2210:A,R}\r\nsc{x<1261:A,m>1138:R,a>1644:A,A}\r\nhdl{s>3524:trl,m<1251:cbm,jcb}\r\nsgk{m>1740:gxn,m>1449:zlq,m<1371:A,A}\r\nsqj{m<1009:ghj,qc}\r\nrvg{x>2751:cbv,rb}\r\nfc{x>896:A,s>351:R,a<1524:vf,rtg}\r\nnlv{x>3765:A,a<3662:bg,tpz}\r\nbdc{a>3423:R,R}\r\njxd{m>2430:A,R}\r\nffj{x<1225:vc,lm}\r\nrmq{a>2410:zz,a>1947:A,m<1209:jms,A}\r\nglg{m<1371:A,x>1253:A,a>3301:A,R}\r\npdf{s<2488:hxf,A}\r\ncmt{a<1811:nq,x>499:bh,tf}\r\nnsr{x<1949:dtf,m>301:ph,R}\r\nzkx{s<1453:bl,a<2646:R,m>2900:dn,R}\r\nsbv{m<281:dmt,x<1338:lkq,x>1412:R,xc}\r\nrn{a>2044:R,m<785:zl,s<2211:R,zs}\r\nfgg{m<2752:R,R}\r\ntq{m>2968:A,s>982:R,xv}\r\nvmx{x>401:A,a>2267:A,m<613:R,R}\r\ncnq{s<2153:A,A}\r\nin{x<1523:rr,psl}\r\nxdd{a>1076:R,a>1021:A,m<3092:bcj,mx}\r\nchl{x<2084:R,A}\r\nxbx{s>2576:fn,a<924:qss,x<2785:shh,xdd}\r\nzbh{m<3192:R,a>3731:A,x<3623:R,R}\r\nvj{s<875:R,a<3350:R,x<1196:R,A}\r\nqv{x>2691:R,x<1966:R,A}\r\nltl{a>1494:R,a<1423:A,A}\r\ndp{m<745:R,m<1280:nkv,x>869:R,R}\r\nggg{s<1607:R,m<462:R,R}\r\nkj{m<173:R,a<461:R,A}\r\nrh{x<1307:A,x<1428:A,R}\r\nmr{x>2820:A,m<651:br,hzk}\r\nlcq{s>2053:A,m>3275:R,R}\r\ngbr{s<2435:nh,a<1081:rj,x<3440:zqp,A}\r\nkqh{m>1705:vrh,A}\r\nqbv{x>790:pr,A}\r\nzl{s>2209:R,A}\r\nzgn{x<2405:hbj,x<3371:R,R}\r\nnvj{m>2048:A,R}\r\nkg{x<3110:hs,sjl}\r\ntcl{x<2652:lfd,kqh}\r\nppv{a<2945:A,m>359:R,a<2956:R,A}\r\njb{s<2174:A,x<3596:A,x<3834:R,R}\r\ngn{x>2033:A,m>2665:A,x<1766:R,R}\r\ntdb{m>983:rdg,m>512:hd,a<2442:rqk,ggt}\r\nspq{a>2917:A,m<1999:A,m>3160:A,A}\r\nrl{m<1608:fq,a>1384:jds,R}\r\nss{m>1255:R,m>614:A,a>3013:mcc,xbh}\r\nhn{a>2659:A,s>2109:R,R}\r\ndzq{s>2673:A,A}\r\npsx{x<921:R,A}\r\nmnd{s>91:A,R}\r\npr{x<863:R,x<882:A,s<676:R,A}\r\nnth{a>63:R,A}\r\ntk{a>2726:grr,nsj}\r\nspr{m>1479:R,a>2918:R,m<1424:A,A}\r\nxvb{s<257:A,m<824:A,R}\r\nlkl{a>3513:R,A}\r\ndf{m>2377:A,x<2393:R,s<794:A,A}\r\npbx{s>3731:R,R}\r\n\r\n{x=1272,m=2035,a=996,s=123}\r\n{x=2086,m=1523,a=691,s=1133}\r\n{x=3600,m=584,a=2515,s=1052}\r\n{x=1134,m=814,a=716,s=2044}\r\n{x=860,m=1827,a=209,s=1021}\r\n{x=556,m=10,a=412,s=1032}\r\n{x=231,m=214,a=2241,s=1183}\r\n{x=1315,m=38,a=609,s=146}\r\n{x=547,m=1780,a=1113,s=239}\r\n{x=393,m=1938,a=1698,s=328}\r\n{x=1562,m=115,a=332,s=2578}\r\n{x=362,m=618,a=1811,s=669}\r\n{x=966,m=696,a=276,s=424}\r\n{x=715,m=494,a=331,s=1018}\r\n{x=2710,m=2991,a=225,s=1624}\r\n{x=1586,m=702,a=2640,s=89}\r\n{x=787,m=255,a=2756,s=1590}\r\n{x=1210,m=255,a=552,s=1485}\r\n{x=388,m=73,a=2372,s=2598}\r\n{x=1509,m=573,a=82,s=1234}\r\n{x=158,m=71,a=140,s=1848}\r\n{x=983,m=1792,a=276,s=1443}\r\n{x=6,m=379,a=175,s=1552}\r\n{x=1448,m=1318,a=782,s=45}\r\n{x=2606,m=59,a=1588,s=1865}\r\n{x=902,m=481,a=865,s=353}\r\n{x=821,m=300,a=739,s=991}\r\n{x=222,m=692,a=517,s=749}\r\n{x=212,m=2987,a=2187,s=3844}\r\n{x=1625,m=722,a=625,s=436}\r\n{x=186,m=204,a=696,s=36}\r\n{x=87,m=52,a=2210,s=470}\r\n{x=478,m=74,a=916,s=1358}\r\n{x=350,m=2133,a=540,s=10}\r\n{x=353,m=530,a=8,s=119}\r\n{x=113,m=1219,a=1199,s=114}\r\n{x=239,m=1330,a=1289,s=310}\r\n{x=160,m=541,a=740,s=2207}\r\n{x=710,m=1572,a=153,s=534}\r\n{x=156,m=1332,a=359,s=968}\r\n{x=729,m=816,a=548,s=436}\r\n{x=384,m=558,a=3056,s=531}\r\n{x=669,m=2493,a=65,s=93}\r\n{x=2481,m=746,a=33,s=471}\r\n{x=1759,m=3183,a=90,s=526}\r\n{x=414,m=656,a=2653,s=1630}\r\n{x=227,m=595,a=501,s=2012}\r\n{x=1,m=1857,a=130,s=3385}\r\n{x=1307,m=2,a=919,s=1625}\r\n{x=853,m=604,a=2382,s=1724}\r\n{x=2676,m=2318,a=661,s=1102}\r\n{x=2213,m=240,a=3516,s=710}\r\n{x=1118,m=21,a=3454,s=612}\r\n{x=1858,m=168,a=139,s=1036}\r\n{x=2570,m=3636,a=2081,s=401}\r\n{x=149,m=458,a=1164,s=677}\r\n{x=605,m=2263,a=97,s=16}\r\n{x=15,m=1979,a=1705,s=1590}\r\n{x=33,m=457,a=1175,s=2729}\r\n{x=436,m=605,a=535,s=1493}\r\n{x=34,m=407,a=833,s=798}\r\n{x=272,m=846,a=68,s=2495}\r\n{x=2624,m=52,a=595,s=2574}\r\n{x=574,m=400,a=647,s=48}\r\n{x=73,m=210,a=622,s=888}\r\n{x=1154,m=834,a=557,s=1052}\r\n{x=1844,m=15,a=3539,s=2831}\r\n{x=2112,m=1220,a=13,s=566}\r\n{x=44,m=823,a=900,s=536}\r\n{x=730,m=992,a=382,s=582}\r\n{x=425,m=258,a=137,s=181}\r\n{x=1294,m=85,a=224,s=464}\r\n{x=522,m=750,a=43,s=333}\r\n{x=337,m=1638,a=1607,s=2945}\r\n{x=1305,m=357,a=1190,s=2724}\r\n{x=560,m=1424,a=2355,s=1419}\r\n{x=1616,m=55,a=1777,s=3425}\r\n{x=592,m=1115,a=83,s=130}\r\n{x=324,m=942,a=137,s=1428}\r\n{x=1121,m=515,a=360,s=288}\r\n{x=619,m=1863,a=303,s=667}\r\n{x=484,m=3574,a=107,s=788}\r\n{x=70,m=188,a=418,s=225}\r\n{x=1075,m=376,a=547,s=2803}\r\n{x=1092,m=551,a=1967,s=695}\r\n{x=1145,m=2432,a=536,s=226}\r\n{x=1474,m=1,a=867,s=536}\r\n{x=2738,m=2397,a=813,s=951}\r\n{x=1049,m=4,a=1708,s=2179}\r\n{x=2349,m=2657,a=808,s=360}\r\n{x=333,m=1660,a=120,s=1620}\r\n{x=3882,m=1902,a=755,s=1499}\r\n{x=1519,m=418,a=139,s=276}\r\n{x=12,m=2213,a=1387,s=188}\r\n{x=62,m=433,a=3247,s=3477}\r\n{x=260,m=1923,a=745,s=1092}\r\n{x=1898,m=2523,a=745,s=161}\r\n{x=1763,m=60,a=2245,s=1874}\r\n{x=837,m=1963,a=839,s=413}\r\n{x=676,m=963,a=490,s=54}\r\n{x=2289,m=1275,a=276,s=454}\r\n{x=21,m=96,a=335,s=13}\r\n{x=939,m=2479,a=481,s=9}\r\n{x=1772,m=2981,a=2166,s=2140}\r\n{x=730,m=1868,a=12,s=457}\r\n{x=283,m=1126,a=1981,s=1394}\r\n{x=1347,m=614,a=1068,s=72}\r\n{x=401,m=2943,a=1885,s=1961}\r\n{x=271,m=1366,a=207,s=53}\r\n{x=610,m=265,a=1082,s=1623}\r\n{x=997,m=2395,a=1047,s=491}\r\n{x=3726,m=503,a=1199,s=1153}\r\n{x=791,m=1157,a=1729,s=835}\r\n{x=226,m=425,a=652,s=1027}\r\n{x=1,m=310,a=2110,s=3072}\r\n{x=523,m=2198,a=162,s=3226}\r\n{x=1715,m=392,a=397,s=498}\r\n{x=419,m=2116,a=164,s=247}\r\n{x=2053,m=2607,a=245,s=775}\r\n{x=418,m=1715,a=1257,s=971}\r\n{x=2664,m=882,a=2507,s=1349}\r\n{x=2078,m=2249,a=407,s=280}\r\n{x=408,m=203,a=75,s=1220}\r\n{x=731,m=736,a=2364,s=773}\r\n{x=562,m=3377,a=897,s=24}\r\n{x=14,m=1776,a=3167,s=52}\r\n{x=3935,m=1832,a=426,s=3331}\r\n{x=1000,m=1388,a=1508,s=2292}\r\n{x=1691,m=44,a=64,s=93}\r\n{x=594,m=726,a=550,s=46}\r\n{x=69,m=687,a=411,s=1148}\r\n{x=971,m=165,a=293,s=2299}\r\n{x=1020,m=43,a=1162,s=199}\r\n{x=677,m=1372,a=3491,s=1956}\r\n{x=439,m=199,a=2173,s=112}\r\n{x=202,m=822,a=218,s=1717}\r\n{x=373,m=161,a=747,s=3432}\r\n{x=437,m=3602,a=179,s=2357}\r\n{x=712,m=1317,a=435,s=43}\r\n{x=1318,m=625,a=2002,s=1045}\r\n{x=383,m=1388,a=143,s=1333}\r\n{x=1781,m=1425,a=418,s=2396}\r\n{x=1098,m=1127,a=402,s=27}\r\n{x=571,m=179,a=2963,s=225}\r\n{x=497,m=890,a=252,s=769}\r\n{x=1402,m=72,a=328,s=1212}\r\n{x=2100,m=897,a=2356,s=1697}\r\n{x=133,m=736,a=1568,s=606}\r\n{x=1533,m=221,a=424,s=940}\r\n{x=1214,m=1653,a=9,s=3649}\r\n{x=517,m=887,a=230,s=365}\r\n{x=1317,m=70,a=154,s=1313}\r\n{x=1329,m=1887,a=2397,s=534}\r\n{x=1852,m=2036,a=2139,s=1044}\r\n{x=1161,m=1753,a=420,s=1347}\r\n{x=1352,m=1692,a=698,s=167}\r\n{x=2330,m=377,a=4,s=58}\r\n{x=1058,m=856,a=2887,s=1043}\r\n{x=600,m=551,a=1006,s=2464}\r\n{x=1409,m=546,a=1519,s=39}\r\n{x=774,m=572,a=406,s=484}\r\n{x=505,m=158,a=99,s=63}\r\n{x=808,m=1004,a=418,s=31}\r\n{x=376,m=2473,a=1902,s=2710}\r\n{x=283,m=94,a=965,s=1332}\r\n{x=667,m=370,a=1609,s=94}\r\n{x=198,m=210,a=300,s=1041}\r\n{x=2537,m=1582,a=720,s=108}\r\n{x=279,m=3454,a=3498,s=836}\r\n{x=311,m=736,a=2123,s=109}\r\n{x=857,m=2026,a=275,s=2750}\r\n{x=1832,m=384,a=2192,s=18}\r\n{x=1092,m=630,a=1233,s=250}\r\n{x=478,m=582,a=773,s=2205}\r\n{x=1368,m=2047,a=2413,s=1450}\r\n{x=532,m=128,a=354,s=1570}\r\n{x=1142,m=594,a=295,s=142}\r\n{x=789,m=504,a=1704,s=1362}\r\n{x=2582,m=1879,a=749,s=336}\r\n{x=514,m=155,a=198,s=1052}\r\n{x=293,m=253,a=1478,s=1068}\r\n{x=1014,m=414,a=599,s=643}\r\n{x=3048,m=162,a=266,s=986}\r\n{x=1223,m=1933,a=733,s=141}\r\n{x=193,m=70,a=1008,s=250}\r\n{x=1005,m=967,a=517,s=334}\r\n{x=93,m=670,a=175,s=1231}\r\n{x=842,m=1451,a=1193,s=62}\r\n{x=107,m=2605,a=761,s=1931}\r\n{x=1118,m=1756,a=1255,s=3175}\r\n{x=202,m=538,a=2878,s=1348}\r\n{x=67,m=1373,a=65,s=1153}\r\n{x=111,m=227,a=1750,s=584}\r\n{x=428,m=869,a=912,s=153}\r\n{x=3254,m=2700,a=144,s=2609}\r\n{x=3211,m=858,a=177,s=423}\r\n{x=199,m=1808,a=326,s=2681}\r\n{x=2325,m=888,a=1135,s=170}\r\n{x=117,m=699,a=281,s=1858}\r\n{x=1144,m=2008,a=3108,s=645}";
            //InputData = "px{a<2006:qkq,m>2090:A,rfg}\r\npv{ a > 1716:R,A}\r\nlnx{ m > 1548:A,A}\r\nrfg{ s < 537:gd,x > 2440:R,A}\r\nqs{ s > 3448:A,lnx}\r\nqkq{ x < 1416:A,crn}\r\ncrn{ x > 2662:A,R}\r\nin{ s < 1351:px,qqz}\r\nqqz{ s > 2770:qs,m < 1801:hdj,R}\r\ngd{ a > 3333:R,R}\r\nhdj{ m > 838:A,pv}\r\n\r\n{ x = 787,m = 2655,a = 1222,s = 2876}\r\n{ x = 1679,m = 44,a = 2067,s = 496}\r\n{ x = 2036,m = 264,a = 79,s = 2244}\r\n{ x = 2461,m=1339,a=466,s=291}\r\n{ x = 2127,m = 1623,a = 2188,s = 1013}".Replace(" ", "");   // Exemple donné pour debug
            #endregion

            #region Initialisation
            var Parties = InputData.Split("\r\n\r\n").ToList();
            InitInputData(Parties[0]);
            WFPlan = new Workflows(Lines);
            Lines.Clear();
            InitInputData(Parties[1]);
            foreach(string s in Lines)
            {
                Parts.Add(new Part(s));
            }
            Lines.Clear();
            #endregion

            if (this.Debug)
                DebugInit();
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
            foreach(Part p in Parts)
            {
                nb += WFPlan.GetRatingNumber(p);
            }
            return nb;
        }
        private long ProcessPart2()
        {
            return WFPlan.GetNumberValids(new PartRange());
        }
        #endregion

        #region Debug
        private void DebugInit()
        {
        }
        #endregion

        #region Classes de travail
        private class Part
        {
            public long X { get;private set; }
            public long M { get;private set; }
            public long A { get;private set; }
            public long S { get;private set; }
            public long RatingNumber 
            { 
                get
                {
                    return X + M + A + S;
                } 
            }
            public Part(string description)
            {
                var Splits = description.Replace("{", "").Replace("}", "").Split(',').ToList();
                var valeurs = Splits.Select(s => long.Parse(s.Split('=').Last())).ToList();
                X = valeurs[0];
                M = valeurs[1];
                A = valeurs[2];
                S = valeurs[3];
            }
        }

        private class PartRange
        {
            public long XMin { get; set; } = 1;
            public long XMax { get; set; } = 4000;
            public long MMin { get; set; } = 1;
            public long MMax { get; set; } = 4000;
            public long AMin { get; set; } = 1;
            public long AMax { get; set; } = 4000;
            public long SMin { get; set; } = 1;
            public long SMax { get; set; } = 4000;
            public long X { get { return XMax < XMin ? 0 : XMax - XMin + 1; } }
            public long M { get { return MMax < MMin ? 0 : MMax - MMin + 1; } }
            public long A { get { return AMax < AMin ? 0 : AMax - AMin + 1; } }
            public long S { get { return SMax < SMin ? 0 : SMax - SMin + 1; } }
            public long NombreAcceptes
            {
                get
                {
                    return X * M * A * S;
                }
            }
        }
        private class Workflows : Dictionary<string, Workflow>
        {
            public Workflows(List<string> inputData)
            {
                foreach(string s in inputData)
                {
                    Workflow wf = new Workflow(s);
                    this.Add(wf.Name, wf);
                }
            }
            private bool isAccepted(Part part)
            {
                string Destination = "in";
                do
                {
                    Workflow current = this[Destination];
                    Destination = current.GetDestination(part);
                } while (!Destination.Equals("A") && !Destination.Equals("R"));

                return Destination.Equals("A");
            }
            public long GetRatingNumber(Part part)
            {
                if(this.isAccepted(part))
                {
                    return part.RatingNumber;
                }
                return 0;
            }

            public long GetNumberValids(PartRange partRange)
            {
                List<(PartRange, string)> Resultats = new List<(PartRange, string)>() 
                {
                    (partRange, "in") 
                };

                // Tant qu'il reste des intervalles non aboutis
                while(Resultats.Exists(r=>!r.Item2.Equals("A") && !r.Item2.Equals("R")))
                {
                    var Liste = Resultats.Where(r => !r.Item2.Equals("A") && !r.Item2.Equals("R")).ToList();
                    Resultats.RemoveAll(r => !r.Item2.Equals("A") && !r.Item2.Equals("R"));

                    // On fragmente les intervalles non-aboutis en descendant d'un niveau supplémentaire
                    foreach(var it in Liste.GroupBy(it=>it.Item2).ToList())
                    {
                        Resultats.AddRange(this[it.Key].GetValidRanges(it.Select(i => i.Item1).ToList()));
                    }
                }

                // On compte le nombre de valeurs incluses dans les intervalles
                return Resultats.Sum(r => r.Item2 == "A" ? r.Item1.NombreAcceptes : 0);
            }
        }
        private class Workflow
        {
            public string Name { get; private set; } = string.Empty;
            public string Description { get; private set; } = string.Empty;
            public List<Condition> Conditions { get; private set; } = new List<Condition>();
            private Workflow() { }
            public Workflow(string inputData)
            {
                var Split = inputData.Split('{').ToList();
                this.Name = Split[0];
                this.Description = Split[1].Replace("}", "");
                var ConditionsString = Description.Split(',').ToList();
                foreach(var c in ConditionsString)
                {
                    Conditions.Add(new Condition(c));
                }
            }

            public string GetDestination(Part part)
            {
                int i = 0;
                string? d = null;
                do
                {
                    var c = Conditions[i];
                    d = c.GetDestination(part);
                    i++;
                } while (d == null && i < Conditions.Count);
                if (d == null)
                    d = "";
                return d;
            }
            public List<(PartRange, string)> GetValidRanges (List<PartRange> ranges)
            {
                List<(PartRange, string)> Destinations = new List<(PartRange, string)>();
                foreach(var range in ranges)
                {
                    PartRange? Current = range;
                    foreach (var c in Conditions)
                    {
                        if(Current != null)
                        {
                            string Dest = c.AdaptPartRange(Current, out PartRange valid, out Current);
                            if (valid.NombreAcceptes > 0)
                            {
                                Destinations.Add((valid, Dest));
                            }
                        }
                    }
                }
                Destinations.RemoveAll(d => d.Item2 == "R");
                return Destinations;
            }
        }
        private class Condition
        {
            public char? terme { get; private set; } = null;
            public char? Operation { get; private set; } = null;
            public long? comparatif { get; set; } = null;
            public string Destination { get; set;} = string.Empty;
            public Condition (string input)
            {
                if(!input.Contains(':'))
                {
                    Destination = input;
                }
                else
                {
                    var Split = input.Split(':').ToList();
                    Destination = Split.Last();
                    terme = Split.First()[0];
                    Operation = Split.First()[1];
                    comparatif = long.Parse(Split.First().Substring(2));
                }
            }
            public string AdaptPartRange(PartRange range, out PartRange Valid, out PartRange? Invalid)
            {
                Valid = new PartRange()
                {
                    XMin = range.XMin,
                    XMax = range.XMax,
                    MMin = range.MMin,
                    MMax = range.MMax,
                    AMin = range.AMin,
                    AMax = range.AMax,
                    SMin = range.SMin,
                    SMax = range.SMax
                };
                Invalid = new PartRange()
                {
                    XMin = range.XMin,
                    XMax = range.XMax,
                    MMin = range.MMin,
                    MMax = range.MMax,
                    AMin = range.AMin,
                    AMax = range.AMax,
                    SMin = range.SMin,
                    SMax = range.SMax
                };

                if (Operation.HasValue && terme.HasValue && comparatif.HasValue)
                {
                    if (Operation.Value == '<')
                    {
                        switch (terme.Value)
                        {
                            case 'x':
                                Valid.XMax = comparatif.Value - 1;
                                Invalid.XMin = comparatif.Value;
                                break;
                            case 'm':
                                Valid.MMax = comparatif.Value - 1;
                                Invalid.MMin = comparatif.Value;
                                break;
                            case 'a':
                                Valid.AMax = comparatif.Value - 1;
                                Invalid.AMin = comparatif.Value;
                                break;
                            case 's':
                                Valid.SMax = comparatif.Value - 1;
                                Invalid.SMin = comparatif.Value;
                                break;
                        }
                    }
                    else
                    {
                        switch (terme.Value)
                        {
                            case 'x':
                                Valid.XMin = comparatif.Value + 1;
                                Invalid.XMax = comparatif.Value;
                                break;
                            case 'm':
                                Valid.MMin = comparatif.Value + 1;
                                Invalid.MMax = comparatif.Value;
                                break;
                            case 'a':
                                Valid.AMin = comparatif.Value + 1;
                                Invalid.AMax = comparatif.Value;
                                break;
                            case 's':
                                Valid.SMin = comparatif.Value + 1;
                                Invalid.SMax = comparatif.Value;
                                break;
                        }
                    }
                }
                else
                {
                    Invalid = null;
                }
                return Destination;
            }
            public string? GetDestination(Part part)
            {
                if(Operation.HasValue && terme.HasValue)
                {
                    long Valeur = 0;
                    switch(terme.Value)
                    {
                        case 'x':
                            Valeur = part.X;
                            break;
                        case 'm':
                            Valeur = part.M;
                            break;
                        case 'a':
                            Valeur = part.A;
                            break;
                        case 's':
                            Valeur = part.S;
                            break;
                    }
                    if(Operation.Value == '<')
                    {
                        if(Valeur < this.comparatif)
                        {
                            return Destination;
                        }
                        return null;
                    }
                    else
                    {
                        if (Valeur > this.comparatif)
                        {
                            return Destination;
                        }
                        return null;
                    }
                }
                else
                {
                    return Destination;
                }
            }
        }
        #endregion
    }
}
