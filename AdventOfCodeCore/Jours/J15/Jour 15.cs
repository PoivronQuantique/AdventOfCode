﻿
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode.Jours
{
    public class Jour_15 : Jour_abs
    {
        #region Enumerables
        #endregion

        #region Propriétés
        private List<HashMap> Maps {  get; set; } = new List<HashMap>();
        private List<Lens> Lentilles { get; set; } = new List<Lens>();
        private List<Box> Boxes { get; set; } = new List<Box>();
        #endregion

        #region Constructeur
        public Jour_15(bool debug = false):base(debug)
        {
            #region Input Data
            string InputData = "mlk-,nph=9,ctvm=4,fdrl-,qsh=1,kjjjd-,gkk=3,sk-,rs=4,glm-,zffjcc=2,njh-,pn=7,hrvx=1,nxvk-,dftq=3,ppb-,kgs=7,sgck-,pcsnm=9,hrvx=2,vrz-,sbbct-,zcqcms-,zcqcms-,sgck-,blz-,vn=1,pr=6,ks-,csh=2,vfjqg=6,sgck=3,hp=8,dm=1,zkdlm=6,zzx=6,mh-,xgg=5,vfhm-,zdscf-,xnjn=5,scs=7,zggx=7,mtxt-,qk-,jsq-,szq-,hdvm-,nf=1,pmc-,vqnj-,mn=3,zt-,rp=1,hnf-,xln=3,gs-,xpr-,ft=4,ksd=6,xsrz=7,pjll=1,zpdh=5,bcgd-,kg-,mjq=1,hdvm=5,hv-,dvd=9,pgjr=6,dcxz=1,xl=2,rbzmb=5,rgnsg=2,zt=4,pjll=3,szq=5,hrvx-,rht=5,cd-,zf=9,rxrl-,mh-,dh-,mj=5,xd=2,rbz-,gdmssd=3,mf=7,dxt-,xqmlx-,fdrl=6,zdscf=6,jx=7,dfbjt-,gxp-,nvq=3,nrdx=9,cb-,zbmlcj-,zbmlcj-,stph-,qbjz=8,qbjz-,gzx=1,pr-,jhn=9,phpzp-,dh-,mkj=6,hx-,xl=9,ktvtfk-,bpq-,pjll-,mp=8,cm-,dbsln-,hj=9,cnmm=1,rk=5,skj-,qk=7,qk-,ld-,bg-,msr-,tnxz=7,sr=3,fd=7,gzx=5,smd-,sk-,brgng=5,bx-,dgfj=7,sg=4,zmk-,pcsnm=3,xqmlx-,qbv-,ktvtfk-,xnd=6,dgmn-,jr-,vqnj=3,xn=5,csh-,dpnd-,rv-,dh-,fxf=5,kjjjd=3,md=3,pjll-,sc=1,zk-,kcj=7,xrg-,rxq=2,pb=6,sg-,glz=8,gzg=2,gzx=1,px=6,hnf=6,bzp-,hz-,clflq=8,htncc-,qjt=4,db-,rvp-,ld=5,zdb-,srx=2,gqfh-,sljds-,zpq=2,bxphtc-,sgck=9,mnx-,gprzp=5,zst-,zk=4,tqnb=7,dfk=2,xl=5,mqgm=7,qlh=4,zr=1,xrg-,gzg=9,fzbss-,zz=4,cb=1,bgj=6,zd=3,bt-,rt=9,lpsh=7,jtzh-,hkz=6,fdrl=1,ddg-,kf=9,snm=4,jdgj-,mkj=6,xd=3,qjt-,dftq=6,dbsln-,hcqgkm=2,gqb-,xl-,gdsr-,vz=9,zbmlcj-,kfrpnr-,qk-,lxm=1,nxcp-,gj=1,jsm=1,cds=3,dcxz-,rxrl-,pqj-,lj=4,zng=8,gp-,gjb-,phpzp-,xh-,smd-,lzl=2,rbz=7,gxp=1,lt=9,jtzh-,tfcx=8,sk-,skj-,qdq=2,bxgv=8,fmfm-,mx-,mrh-,blz-,xgg-,zpdh=1,pnz-,cr-,msr=1,xhs=1,mj=8,lc-,sv-,pjll-,ksv=7,sljds=7,smf-,nvq=2,vqnj=5,nxcp-,vsrgdj=7,hnf=5,fzbss=9,ls-,bqx=4,hkz-,knr=2,bzlz-,dsgft-,kx=1,mf-,bq=5,xdpnjg=7,gkrl=3,tzm=6,pgjr=2,pgjr-,szn=7,vmlf=2,sgck=1,nqkg=2,hz-,fph=2,glz-,kfrpnr-,mhh=7,stph-,qk=4,dgfj-,sh-,bxgv-,crx=6,kvk-,slkt-,kjjjd-,cp-,zng-,stph-,kvk=9,dfrdck-,xq=2,bk-,blz=9,pntf-,px=9,dkl=4,vvmz-,sgck-,xsj=6,rv-,plp=5,gdgjr-,pqj-,snh=6,cp-,gs=3,cmm-,mhh=1,lpsh-,qm-,qx=1,xnjn=1,jqnpx=1,szn=4,zbb-,glxf=3,szn-,sqcj=2,kx-,pt=9,plx-,xp-,ptq-,fm=4,slkt-,dfrdck-,vn=8,sml=7,fph-,ft-,lvc-,hqmcc-,qzd-,dfbjt=7,gjq=6,mzd=3,dsz-,qzd-,qv-,vs=5,gvzjn-,zpj-,tgvqks-,pff-,bgj-,zzg=7,kfrpnr-,mj-,ljdxr=7,vhxjjm=9,glz=9,lt-,njx=5,zzg-,gs=4,gjq-,gzs-,gf=3,nph-,klfd=9,gzg=8,jkc=8,gdsr=3,rx-,rv-,lz=3,dcc-,stph=9,hgszs-,bd-,xsrz=3,vt=2,dbsln=2,xglp-,hqmcc=7,xrg-,sc=9,mjdvv=2,rz-,scs=3,vsrgdj=2,dpnd=6,bqrx=3,sdrg-,tsr-,fqvmbl-,jdgj-,gprzp=8,nbb=5,qz=7,kg=8,qdq=6,cz=9,rgnsg=8,dpnd-,zf-,tgc-,bt-,snh-,zdscf=1,rz-,vc=1,cb=6,clz=7,xh=7,zt=9,gzfb=1,qmtzf-,lhncx-,qbv-,tzm=7,hdvm=4,pn=3,pp=5,dhn=3,sfn-,skm=7,kgs-,ls-,glz-,cz-,qs-,bxhm=6,cmm=4,tqnb=6,sst-,lr=9,lt=6,dfbjt-,xzvt=9,lxm-,db-,rjgk=7,zf-,zm-,zf-,vkh=7,hkz-,nvq-,cclz=9,pgf-,fdrl-,mtxt=4,bqmg=1,rgnsg-,qhns-,cnmm-,sd=4,sc=8,dfk=4,tsr-,pr-,sbbct=7,nxcp=2,ks-,jsm-,dv=3,slkt-,zcqcms-,bck=9,rk-,sk=1,xkrpbx=9,dkl-,snm-,sr-,sk=5,vqnj=6,mrh-,hrlr-,rp=8,mnx=4,xn-,pp=4,kpr-,vm=3,ls-,fj=3,nqkg-,hkz=5,htb-,sk-,vvr-,gkrl-,kc=1,djp=5,kc=7,dbsln=6,mrh-,pgjr=8,qg-,xq-,ppb-,rq=2,ggptvn-,bq-,hj-,rvp-,csz=9,bxphtc-,cg=5,nz-,hx-,xrg-,lj-,njh=5,zncxj-,ccbn=6,dz=1,dz-,jpmnhm=5,zdb=3,fmfm=4,sml-,bzp-,jpmnhm-,dfr=1,qkh=1,xhbf-,zr=2,scs=4,xqmlx-,phsl-,clflq-,zbmlcj-,gl-,rxrl-,dfrdck=5,tkz-,bz=4,cb=1,csz=1,ctvm-,qh-,gs-,mpg=3,sdm=6,bd=7,csh=4,hs=1,nk=8,np-,zm-,gjq=3,gjb-,qg=2,dftq-,pds-,hqmcc=3,sbbct=9,jrl-,rp=6,zdb-,gdmssd-,hj-,snh-,ccbn=2,xpr=3,kpr-,zpk-,njx-,dpnd-,kpr=4,dgfj=8,gzx-,khm-,dv-,rggz=8,hf=3,snh=5,vzx=9,xm-,pb=7,kjjjd=1,slkt=7,htncc=4,rkm=1,rd=8,dgx-,xrfs=2,hlddh-,jtclbl-,cf=1,lz-,lg-,sjs-,pb-,mfp=2,rkm-,nhp-,skj=3,bzlz-,mzxv-,bgj-,jrl=4,ksv-,rggz=8,szq-,gzg-,ltb=3,csh-,bpq-,lg-,jkc=5,xq=7,kjjjd=8,vqnj=6,sg-,xrfs=9,zzx-,nc=7,sd=8,nzmt=2,ls-,qdq-,gj-,pqj=3,rgn-,vhxjjm-,dh=3,fm-,hv-,qjt=2,tsdv-,fdrl=6,khbz-,jkg=4,mmdmk-,xnmkp-,zpq=2,dsz=3,xpnpvg-,nk-,dx-,sgk=1,vfn-,gzg=8,njx=5,pmc-,vs-,xpr=5,dcc-,dcc=9,kvk=9,bpq-,sg=6,jfrm-,mdrtq=5,hj=5,pc-,gprzp=3,qns=9,vrjfg-,vvr-,gdm-,xlgp=4,cmm=1,gdm-,qg-,hnc-,mh=7,mdrtq=6,dt-,tt-,qg=4,qh=7,zzx=1,mfp-,gf-,tsr=1,zpk=9,mrh=2,pq-,prq=7,rp=1,csh-,gxp-,chfhqz=6,sdrg-,smd-,spf=2,lg-,qmtzf-,bthtl-,lhncx-,ppb=8,hxts-,css-,hnf=8,xqmlx=7,xp-,hz=2,pjs=3,hqmcc-,ncq-,tqdnj-,gdsr-,qvgqk-,vtdx=9,pf=7,xsrz=2,cds-,cds=4,qlc-,fm-,vvr-,ctvm=5,gqb=9,gxd-,hkcdp-,bz-,dh-,zst=8,zmk=3,dsz-,dcmm-,ndhl=9,mtxt=8,pds-,mqgm=2,gdm=7,bsc-,hnf-,dpf-,pntf-,pcsnm-,fbj-,nxd-,vc-,ffj-,xfqlc-,qd=2,rvp=6,xtl-,jfrm=7,lz-,pmq-,ptq=1,vnz-,gj-,gl=3,qp=2,bq=3,sv-,sljds=9,xpnx=1,dx=6,kg=4,zpdh-,dhx-,hrvx=9,xlgp=5,pr-,htncc-,ps=6,pgf-,jpmnhm=7,sx-,zkdlm-,rtvv=3,hcqgkm-,zt=8,lzl=5,rxrl=8,pgf-,jr-,mkj=5,vfn-,dnzl-,klfd-,gkk=2,jhn-,xr-,xsj-,jmd=6,fxf-,pb-,qm=4,sml=6,dr=5,sh=3,dh=5,tsdv=9,zz-,glz-,qmtzf=1,zncxj=8,dfk=7,vcgf-,lhncx-,cds-,xd=9,cd-,rk-,pgjr=3,xln-,ctvm=7,plp=7,nz-,fj-,dr=2,bfxmzl=5,dhn=8,mzd-,rq-,ssf=4,htb=1,mlk-,gz=7,zcqcms=3,hgszs=6,dq-,dfk-,kvk-,pntf=4,vhxjjm=3,sdrg-,np=2,cm=3,hrvx-,chfhqz-,gdmssd-,hkcdp=1,xpnpvg-,ljdxr-,bxphtc-,xkj-,vfn=4,mqgm-,fs=9,ndhl-,vz=6,kvk-,dfk-,ff=8,cclz=9,zjhp=9,rht=9,sg=2,tfcx-,nm-,jx-,dt=4,qvgqk-,bd=8,bfxmzl=4,vm-,mmdmk=6,pgjr=5,ksv=8,vz-,vfn-,sr=7,bzlz=3,kpr-,cd-,dbsln=9,ptq-,qbjz-,ds=3,ftvktn=2,pmq-,gbg=8,vqnj=4,rvt-,tfcx=7,xkj-,zcqcms=2,vfjqg=3,bsc=2,hn-,mq-,db=2,sml=8,tqdnj-,bqx-,hv=3,ffh=5,tsr=5,pq=3,bqmg=2,sgck-,ks-,skj-,rs=1,zfn-,pq=8,qh=2,dbsln=6,prq=9,kcj-,mj-,dq=5,pnz-,brgng-,cz-,rs-,cr-,zbmlcj-,qkh-,cn=2,zfn-,xnjn=7,glm-,smf-,skm-,kvk=5,ccbn=8,bzlz-,lhncx-,lpsh-,djp-,brgng=5,xsrz=4,qx-,ls=6,mzxv=3,hgszs-,xtl=7,cpjlj-,sx-,hv-,glpx=9,gl=4,rgn=6,dvd-,xpnx-,cz=7,glpx=8,jr=6,qg=6,rsdr=8,xq-,khm-,dfk=5,qlh-,nm-,xkrpbx=6,gf-,cnmm=5,kg=9,dfr=1,dh-,sbk-,lvc=3,glz-,gj=8,mz=4,dbh=3,zglm-,cclz-,rbz-,sk=5,czg=6,qvgqk-,ffh-,dcmm=3,kf-,rggz-,nhp=4,gvzjn=8,qx-,dcmm=6,pgjr=7,nrj-,gprzp=4,hp=9,ksv-,nvq=4,mj-,dcxz=5,qx=7,tgc-,jmd-,nph=4,ktrrv=6,rlgv=9,rgn-,gzd=9,vsrgdj-,ggptvn-,cn=4,lc=9,lqrm-,fdrl=1,hp-,hkcdp-,rkm-,xvr=6,snm-,ljdxr=4,qsh=9,zpdh-,nc=4,kq=9,ftvktn-,zt-,ljdxr-,hknmt-,bsc=9,vs-,pjs=4,zz-,rt=8,kjjjd-,cd=3,kj=2,xfqlc-,qx-,njx-,fb=7,lqrm=5,lqrm-,nbb=3,mrh=6,sqcj-,hn=9,jmbl-,xdpnjg=7,vs=5,drnjm-,hrlr=2,zz=2,nxvk=4,zpj=3,fbj=1,nfh-,tgc=7,xr=4,dq-,gj-,vt=7,kg=6,kx-,gqb-,tkz=4,nhp=9,hknmt=6,nxd=6,qm=9,vvmz=3,dbs=3,vc=5,jkc=2,mpg-,gzg-,cnmm=1,ffj-,xrg-,bd-,nf-,lgc-,mzxv=7,jtzh=8,szq=2,rs-,qg=4,sv=5,xcd=7,nvq=2,qk=6,hdvm=8,cqcv=2,sg-,rd-,mjq-,glz=1,pf-,bg=4,gqb=7,lth=1,sc=8,zm-,dq=1,rlgv=2,nxvk=3,vtdx=9,kc=9,qm=3,pff-,sr-,gzx-,njx-,jfrm-,xjl-,vfjqg=4,dlz=7,zpq=6,nz-,jkg=4,khbz-,xp-,bcgd-,hh=7,gjb-,srx=2,bg=3,ks-,dhn=7,ps=7,nrj=7,hn=8,xpnx-,dv-,gj=8,cds=2,lpsh=7,hf=4,nxd-,crx=8,ltzd-,dcc-,bzlz=3,xnmkp-,zmk=9,bzp=8,chfhqz=8,xvr-,pmc=9,vfn-,mfp=4,hj-,mh-,mjdvv=3,gp=6,mgm=1,mx=4,gjb=7,ffh=4,qx=6,pntf=5,vzx=9,nvq=1,fmfm=6,ff=8,pc=5,zk-,zmk=8,knr=6,kcj-,qns-,kcj=1,zt-,rxrl=3,rbzmb=7,gjb=4,gqb=2,sst=2,vcf-,snh-,fbj=1,hh-,zpg-,ksd-,ktrrv=3,xp-,dftq=4,bzp=1,njrqz-,mlk=8,xtl-,khc=6,vcgf-,md-,jrl=7,skj-,pzqpj=3,jmbl=9,nfh-,rtvv-,dpnd-,pgf=6,mp-,xh=2,vzsr-,xd-,nhp=5,mnx-,bd=3,vfn=7,nxvk-,jkc-,dhx-,pnz=6,vtdx=4,ddg=2,sk=4,zk=8,ps=1,qkh=4,lg-,lgc=7,sgk=9,fbj=3,glm=2,qk=4,zm=2,bcgd=9,hn-,zfn-,ffh-,pff=4,ff-,mm=2,kq=2,dv=1,jsq=8,khbz-,rjj=4,jnr=4,smd-,hkcdp=3,fxf-,fbj-,gdmssd-,dgsjz=1,dd=9,fb=2,gqfh-,jkc-,vzx-,gqb-,rgnsg-,bqmg=8,mp-,cg=8,ccbn=9,bq=5,qlc=5,bqrx-,rkm-,fmm-,pcsnm-,bthtl-,qx-,phpzp-,bqx-,sst-,sgck-,jkdp=5,nrj-,ghg-,dbsln-,dfrdck=8,xpnx-,smd-,vrz=5,zzx=8,zjhp-,bd-,zpg=2,xrg-,xfqlc=8,ltzd=4,qlc-,qvgqk-,zst=5,ds-,lkdm=2,gbg-,xglp-,zncxj-,hh=7,ff-,vtdx-,tgvqks=6,xhbf-,cg-,dlz-,db-,qlh-,jkg=6,sbbct-,rt-,vtj-,rz=7,zpdh=7,rkm-,db=8,njrqz=8,qk-,zng=9,jkg-,khm=1,tsr=5,bxgv=9,mh=6,vcf-,cds-,gf=1,bxphtc=8,njh-,kz=6,jnr=4,djtk-,qm-,jkg-,qkh=2,ps-,ftvktn=6,kq=6,qmtzf-,hs-,xhbf-,jkdp=9,brgng-,xh=1,qbjz=2,vm-,sbk-,plp-,mnvbvr-,sv=3,smf-,ncq=7,jpv=8,dt-,jx-,mq-,qp=8,glpx=6,gjb-,dq-,gf=5,fmfm=3,xq-,xr-,xdpnjg-,dcmm=1,dfk=2,nrj-,sljds-,clz=4,spf=9,jrl=9,mf=2,fzbss=5,vzsr=1,hdvm=9,jsm=2,vcgf=6,skm-,xpnx-,nz-,zpdh=7,gljk-,fs-,zv-,rjgk=7,dcmm-,ktrrv=3,jrl=1,zglm=4,rbz=2,dfr-,lhncx=5,ptq=7,nrdx=7,dsz-,ff=8,cg-,xsj=4,mm-,dfbjt=8,hkcdp-,sqcj=4,cl-,xcd-,zncxj=2,rz-,nph=8,zfn-,cpjlj=7,kg=9,qsh-,xpr=5,bqrx=2,db=3,ghg-,gzs=9,bpq=4,bg=8,bfxmzl=7,gdgjr-,xkrpbx-,lg-,mf=3,nk-,xn=7,fb-,pr=1,xqmlx-,zmk-,dcmm=4,kg=6,bsc-,blz-,ksd=7,qns-,sh=8,gzs=7,zfjx-,dx=4,dgx-,bt=8,csh-,md=7,kx=9,pnz-,bxhm=4,ft-,bcgd-,xnd=2,bzp-,tfcx-,jnr-,vrz=6,qlh=1,mzxv-,xd-,rz=2,cn=6,tzm=8,xsrz-,dfr-,vvr-,rbzmb=4,ltb=2,dd=1,snm-,djfqs=9,nxcp-,zst-,jtzh=2,pntf=6,cg=2,hgszs-,pgjr-,rtvv-,gdm=2,xrfs-,ltzd=8,clz-,vcgf-,nc-,zt=2,fmfm-,spf-,zpg=2,hgszs-,rd=5,zcqcms-,zpq-,lg-,ddg-,rsdr=8,jhn=6,bxhm=9,sh-,nph-,cqcv=1,rggz=9,sk-,mx=8,dd=9,lth-,vcgf-,qmtzf=1,cnmm-,gzg-,xr-,ssf=4,fb=6,xcd=2,nrj=4,vzx-,dgx=3,klfd-,dr-,vkh-,lj=2,vc=2,pjll-,rbzmb-,kq=9,zd-,pmq=7,tgvqks-,dlz=7,pf=2,zk=4,rht=4,nz=6,sgck-,sfn-,mzxv=2,smd-,csz=2,sst-,prq-,htb-,crx=9,cd-,vnz-,dbsln=9,pnz=1,vz-,gbg-,njrqz-,ssf=9,lth=9,mrv=3,xh-,hz-,jr-,bfxmzl-,sjs=1,dbs=7,bzlz=4,rjj-,cnmm-,pb-,vvn-,sg-,djp=3,nm=5,plp=6,ljsrv-,zdb=3,cz-,skj-,sgk=2,tgc-,smf=7,xvr-,dgx-,hknmt-,fmfm=9,cp=6,zv=4,gdsr-,vjz=1,qns=3,nph=1,glz=1,hf=1,hv=9,ghg=2,tsr=4,gf=6,fmm=1,ph-,kpr=7,xh-,rtx=1,zt=4,rz-,jkc-,nph-,hdvm=8,csh-,qhns=6,zm=9,rjgk=8,tzm-,xhs-,kg-,gprzp-,cr=4,ljsrv-,njx-,pq-,qzd-,pdms=1,kpr-,zzg=1,db=6,zr-,hgszs-,cclz=9,jpmnhm=7,dbsln-,xkrpbx=3,dd=5,pds=4,njx=1,sgk-,ccbn=3,dfk=5,zjhp=6,hnc-,nhp=9,dsz=3,htncc=9,jqnpx=4,bcgd=2,ncq-,gqfh-,kc-,gmb=4,sv=7,glz-,rjj-,cr=2,htncc-,pnz-,rx-,zz-,rtx-,gxd=4,slkt=8,dcc-,zkdlm=5,xnmkp-,kcj=4,sdrg=7,gjq-,nbb=3,gzx=4,jqnpx-,ctvm-,mh=6,skj-,djfqs=2,plp-,bqrx=5,xn-,nqkg-,gkk=1,pzqpj=9,gvzjn=8,rtx-,nxvk-,gkrl=8,dbs-,msr-,scs-,qbjz=8,pmq=9,zzg=9,nxvk-,rt=9,blz=6,zpdh-,drnjm-,qbjz=7,lqrm-,ltb-,zt-,dgx=6,cz=9,csz-,lg-,sgck-,mqgm=8,tt=3,dm=7,zdscf=1,gjb-,xrg=4,nxcp=8,xqmlx=1,dfbjt=7,nk=3,qns=2,vjz-,hs=7,dfrdck-,zbmlcj-,bcgd-,bfxmzl=7,rlgv-,qx-,tqdnj=3,dq-,jx=9,cds-,ssf-,qbjz=6,qk=2,xpnx=9,xq-,zncxj=9,sr=9,djp=6,gtvvp=2,ctvm=7,cp-,szq-,lgc=2,htb-,tqdnj=2,hdvm-,mzd=3,kpr=1,smd=4,ljsrv-,nxd=2,kgs=5,pb=8,jmbl-,pgjr=5,sg=6,kjjjd=2,hrlr-,clflq=5,dnzl-,pds=1,pzqpj=4,ld=2,khm=8,gq=2,ffh-,jkg=8,qh=9,sv=7,sg-,hnf=7,fqvmbl=4,khbz=3,mq=6,dpnd-,jtclbl=7,rht=5,hkz=5,vmlf=9,gdm=1,vfhm=9,jsq-,kq-,fzbss-,zjhp=7,tsr-,gzs-,rvp=2,lmv-,lj=1,pmq-,jdgj-,dcmm-,zpg=2,rvp=4,vhxjjm-,ld-,xm-,kpr=8,zjhp-,dfbjt-,sml-,mnx-,nk=8,snh=3,gxd-,ktrrv=2,dd-,kx=4,hj=2,jkc-,nm=1,blz-,dhx-,pq=1,xjl=4,gkrl-,dgfj=6,zggx-,nz=5,qmtzf=6,xrfs=9,ffj-,glm-,zpj=5,mmdmk=7,pgjr-,dbh=2,sfn=7,spf=6,hknmt-,dfr-,klfd-,jsq-,mpg-,xlgp-,cclz=2,fmfm=3,qm=1,zzg-,xnd=5,bp-,ljdxr=1,dpnd-,xfqlc=7,bx-,khm=9,dbsln-,ncq-,lj-,gjb=9,ln-,rjgk-,vfjqg=5,szq-,cf=4,lg-,ppb=3,rj-,qns=1,sr=3,jrl=2,bz=3,qns=3,jkdp=5,xqvq-,tkz=2,zf-,zfn=4,gxp=3,vcf=8,rggz-,dcmm=4,pr=4,khm=2,qg-,xp-,mf-,qbv-,hknmt-,zpdh-,bd-,brgng-,xsj=9,fph-,sgck-,rvp-,slkt-,bgj-,nbb-,vnz-,ftvktn=2,glxf=1,nxvk=2,dv=1,vhxjjm-,qjj-,mfp=9,zpdh=8,ndhl=6,jrl-,sg=4,tqnb-,pn-,zcqcms-,lkdm=4,skj-,kx-,scv=3,nqkg=5,bx-,fbj-,vzsr=1,crx-,ccbn-,cl-,mhh-,hh=1,fzbss-,gdm=3,jtzh-,gxp-,hs=9,vvn-,zcqcms-,zjhp-,bqx=3,gbg=8,lz-,ls-,xfqlc-,rgnsg=3,xr-,gprzp=7,sv=9,gjq-,hkcdp-,sqcj-,lc-,zcqcms-,sv=5,clflq=3,mmdmk=8,dgsjz=1,kvk=4,khm-,rp-,ps=7,gqb-,xdpnjg-,dgfj-,plx-,pzqpj=2,mm=5,crx=2,ps=9,pt-,gf=7,kjjjd=3,rx-,vnz-,bx=8,xr=8,rk-,zffjcc-,hdrc=7,drnjm-,smf=2,rtx=1,lkdm-,bk=1,rxq-,mq-,gxd-,hcqgkm-,vqnj=5,fdrl=5,xr-,kgs-,zpj=3,vcgf=7,glpx-,ctvm-,bxhm=6,jmd=1,knr=1,hnc-,pcsnm-,qz-,vvr-,gzs-,zd=6,vfq-,dz-,qbv-,zkdlm=5,bck=2,lz=5,nf=9,jmd-,xglp=8,cclz=8,rp-,drnjm-,gqb-,gzg=9,gljk=2,gzfb=5,sr-,zk-,ljdxr=1,xnjn=4,nfh=4,xtl=9,kg-,xn-,cclz=2,sst-,zkdlm=6,fdrl-,bxgv-,sljds=6,ljdxr-,dpnd-,dpf=9,khbz=3,pjs=2,fd=7,nxvk-,njx-,ftvktn-,xnd-,pds-,mhr=2,vz=1,pnz=6,gzx-,jkdp-,xqmlx-,rz-,xkrpbx=4,kg=8,jmd-,mfp-,lq-,pr=4,dlz-,ltzd=4,bq-,dhn=3,vcgf=7,bcgd-,smd-,xqmlx=5,nz-,dz-,scv-,jqnpx-,hv=4,gtvvp-,zst=7,fmfm-,rkm-,vqnj-,rkm=1,nrj-,gp=6,mpg-,gxp=8,zpk=6,zst-,kq-,mj=5,qv=3,cds-,cdgz-,ds=6,sdrg-,djfqs=5,hs=9,cds=7,xgg-,kc-,kjjjd=8,mz-,jfrm=8,gljk=6,szq=5,jrl-,rjj-,xnd-,cl=3,vqnj-,rjj-,dgfj-,skm-,kf=4,qz=3,qmtzf=2,jmd=4,mf=8,khc-,bck-,ks-,rht=1,djtk-,qdq=8,vn=4,xfqlc-,rkm-,gkrl-,zm-,hkz=2,xdpnjg-,vrz=8,nc-,np-,msr-,hkcdp=2,pmc=8,vsrgdj-,scs-,zcqcms=9,zzx-,pf=1,nhp-,pc-,dcc-,gdm=2,xl-,rq=1,lpsh-,jqnpx-,fs-,fmm=6,crx-,nzmt-,dgfj-,blz-,zffjcc-,mgm=2,xhs=6,vrz-,vc-,rp-,pmq-,dkl-,sh=2,ps-,gqfh=2,xglp-,gvzjn-,bxhm-,vn=9,lpsh=9,sd=2,fb-,xn=6,zmk=9,xnd=9,xrg=7,qz-,xvr=4,gdgjr-,kf=1,lmv=6,jsm-,pmq=9,sc-,fs=4,dz-,dftq-,bzg=1,ltzd-,kr=8,bpq=9,sv=9,hcqgkm=5,ddg=9,glpx-,gzx=2,bqrx=1,xsj-,nzmt=7,dhx=4,jmbl-,ktrrv-,tgc=9,vm-,vcf-,ksv=4,bthtl=2,rgnsg=6,ljdxr=6,cl-,pjll=8,mj-,bthtl=9,sh-,jrl-,snh-,xdpnjg-,qns=6,pnz-,lgc-,lj=6,hs-,mj=6,xgg-,ksd=2,xnd=7,glz-,zbb-,mp=8,dt=9,bzp=3,xhs=5,pn-,xnjn=7,rvp=2,lt-,vjz-,mnx=2,bzp-,lxm-,rxq=1,qm-,mhh-,dsgft=8,cpjlj=9,mpg=1,kpr=8,csz-,hkcdp=5,skj-,gqfh=9,qs=2,fb-,kz=3,zmk=1,jkg=1,qm=2,mn=7,zzx-,gxp-,sqcj=3,hnf-,zncxj=5,nk=2,vnz-,qg-,zfn=1,pq=4,nrdx=1,tqnb-,ksv-,qmtzf=1,nf=8,pqj=4,mnvbvr=6,vnz-,sml=3,rj-,ktrrv-,kpr=2,hjc-,dcc=2,xln-,bzp-,xpnx-,qjnxvl=1,fm-,nzmt-,nqkg=4,jpv=7,gp-,vfhm=7,lvc=2,rxrl=8,zfn-,zt-,mzd=1,gzfb=4,lr=7,htncc-,drnjm-,kjjjd-,nxvk=1,dxt-,vtj=6,skj-,vvn-,lj=8,vmlf=1,ls-,xglp=8,xtl-,glz=4,xh=7,sbk=5,tgvqks-,rt=7,dbs=8,njh=7,rxrl=1,hkcdp-,gp=3,pqj-,zpk=8,mzxv-,dfbjt-,zpg=3,gbg=8,rvp=1,dt=9,kfrpnr-,sk-,kc-,dftq=8,rsdr=6,bqx-,khbz-,cmm-,gfdxhm=3,px=5,tnxz-,gdsr-,bcgd=7,qns=7,jbljv-,bp=2,vkh=5,vfn-,ds-,cnmm=2,md-,bsc=1,jkc=2,dv=8,mf-,pgjr-,rxq-,kpr=5,dfk-,lt=3,dfrdck=5,kj=4,cdgz=2,scv-,mjq=1,gzs=6,mm=8,jpv-,kfrpnr-,pzqpj=2,xrfs-,pcsnm-,dt-,gkrl-,xkj-,ddg=3,xr=4,gljk=4,jnr=5,mm=8,zfjx=5,xrg-,sv-,sk-,sdm-,lmv=5,rkm=8,lt=8,zdscf=9,qsh-,qvgqk=4,fph-,bg=2,knr-,fbj=3,mx=3,ppb-,crx=1,mm=5,pgf=1,jnr=1,djp=9,ggptvn=2,bzlz-,zpk-,lth-,cr-,ps-,pjs=7,ppb-,rgnsg=5,kz-,qdq-,rz=1,db-,vm-,gq-,gzg=8,mhh=9,zggx=6,bzp=2,scs-,khm-,rjgk-,nf=1,sgk=5,dd=7,hj-,lmv-,sx=8,tfcx-,fph=6,dlz=2,gbg=3,zd=6,hj-,sdm=4,glxf=8,lr=4,ljsrv=5,hxts-,mrv=7,sc=6,dt=2,bg-,qkh=9,nzmt=8,ln=1,xhbf-,bk-,cmm=9,xnmkp-,lhncx-,njh=3,kz-,jnr=9,gs-,vfhm=2,sgk-,hcqgkm-,gfdxhm-,md=4,djtk-,gq=3,nxd-,rtx-,dt-,phpzp-,ksv-,bk=2,dbs=9,pr=2,hx-,kx=7,fqvmbl=9,nrj=5,sml-,hkz=2,ks=6,szn=2,rht-,vrjfg-,lth-,pntf=6,pnz-,xfqlc=3,bck=9,hdvm-,ccbn-,xfqlc=1,vvmz=2,bxgv=9,rxq=6,snh-,khbz-,dbsln=8,zglm=5,zm-,np-,xdlr-,sfn-,qmtzf-,dhx=7,pgf=7,vcf-,nf=6,ktvtfk=4,mjdvv=4,xtl=5,tfcx=3,jkc=1,pn-,zk-,zggx-,ld=2,khm-,xglp=5,ncq-,jkg-,pcsnm=9,spf-,kj-,dgsjz=9,blz-,cdgz-,bp=4,vvn=2,pzqpj-,vkh-,scv=4,kx-,zdscf=2,ccbn-,sx-,jtclbl=5,gqb=9,dcxz=9,bxhm=6,slkt-,qjt=7,msr=4,kc-,pc=9,jsq=6,pb=7,hrlr-,np-,ff=2,rj=3,vsrgdj-,zr-,bx-,lqrm=5,kx-,sc=5,mqgm=4,xlgp-,fj=2,rbzmb-,cds=1,zr=2,kgs-,njx-,jdgj-,jbljv-,hkz=9,bk-,cqcv=3,xp-,xrfs-,tgc=3,chfhqz-,nph=2,xtl=5,vvn-,fs-,xnmkp-,xlgp-,plp-,spf-,dsgft=8,vnz=2,zkdlm-,hh-,hn=6,rbz-,sdm-,lt-,qp=6,mdrtq-,zggx-,np=7,sk=9,kj=2,qlc=4,hcqgkm-,cclz-,jkg=4,tsdv=5,sbk-,ft=8,khc-,xqmlx=9,stph=5,xkj-,lmv=3,bxphtc-,mzd-,nk-,xfqlc=5,glxf=4,xglp-,cqcv=1,sdrg=4,rtvv-,rht-,sx=1,lg-,pgf-,htb-,bcgd=7,gkk=5,qbv-,tgc=6,lmv=4,qjt=7,rd=1,mjq=4,gqb=1,gprzp-,qns=5,dhx-,hrlr=3,mkj=5,pt-,hkcdp=3,qlh-,lzl=6,sr-,vfq=7,vvn=8,dpf=9,ktrrv=9,glz=2,zr-,rtx=3,qjt=5,lg=5,lg=4,xkj-,mqgm=7,tt=1,dz-,drnjm-,hxts-,mp=2,hs-,pgjr-,dq=9,ff=6,vzx=7,vcf-,mmdmk=1,ssf=5,sml=6,vhxjjm=4,sfn=1,mmdmk-,mzd-,zbb=9,fs-,xjl-,jsq=7,zm=3,bxhm-,qjj-,brgng=9,dfr=7,jkc=5,hjc-,csz-,rht-,cz-,dfrdck-,zm=9,fmm=5,xpr-,ppb-,dgfj=9,bthtl-,dh-,dvd-,snh=5,dq-,qx-,xpnx=5,mfp=1,db-,szn=1,ks=6,zv=7,clflq=6,zfjx=9,xglp=9,np=2,qjt-,ncq-,ddg-,dcc=1,pmc-,pzqpj-,rkm=8,lxm-,xm=1,mx=1,gp-,xm=1,nxd=6,rvp=7,dpf-,zpq-,ln=4,pjs-,mq-,zm-,gp=4,dvd-,rk=6,skj-,lzl=6,sgk-,bsc-,pgjr-,hkcdp-,pb=7,bck=4,scs=7,djtk=6,zv=7,nz-,gl=1,nqkg=1,lgc=8,klfd=2,jfrm=9,mgm-,tnxz-,qlc-,hh-,dhn-,plx=6,hx=9,xtl-,md=4,qdq=1,qmtzf-,zpj=4,qjt-,jtzh=8,mpg-,zdscf=8,gzg=9,zk-,rgnsg=2,tqnb-,hh-,nbb-,cpjlj=1,ljsrv-,vrz-,qjj=8,bq-,rht=6,fmm-,pc-,hrvx-,dx-,xhbf=1,jmbl=8,zpdh=1,ltb=1,vc=6,zzx=2,lpsh=6,lhncx=6,hh=4,hcqgkm=6,pgf-,plp-,czg=2,sjs-,xkrpbx-,qh=9,zfn-,mdrtq-,njh-,bsc-,ksd-,sv-,pt=4,ps=6,gkk=3,hnc=2,cl=1,ph=5,jr-,dh-,blz=7,vcgf-,mnx-,gp=7,qm-,pq-,rggz=1,kz-,xlgp-,clz-,bk-,mn-,kz-,tfcx-,zdb=9,dm=4,px=6,dgsjz-,vmlf=5,lc-,sv=1,sh-,bck=1,pt-,vvn=9,skm-,vjz-,dfbjt=7,plx-,rxq=5,slkt-,gj-,gqb=8,lc=8,nxvk-,qjj-,mmdmk=1,khc-,cdgz-,ff=3,jx=8,dfrdck=5,hn=5,zr=8,vfhm-,qjt-,pgjr=6,vsrgdj=8,ltb-,gq-,dnzl=7,qp=8,pq=3,lkdm=5,jhn=9,zfjx-,qk-,zpdh-,gdsr=4,ff-,sml=8,vzx-,xn=5,vs-,jfrm-,vtj-,dfbjt-,qns=5,mnvbvr-,tj=4,bxgv-,bxhm-,fxf-,qdpm=3,jfrm=3,cg-,rx=6,gjb=5,ssf=2,zggx=9,khc-,gmb-,xln-,zzx=2,nrj=2,css=2,khm-,jsq-,lqrm=8,mp-,rvp=2,gdm=8,rtx-,pmc-,xgg-,vfhm-,nrdx=6,dd-,fdrl-,nqkg-,kg=9,htb-,zk=2,khc-,bp-,zncxj=4,pq=1,xlgp=5,cg=1,sh=5,ljsrv-,mqgm=9,bt=6,plp-,mn-,dgfj=2,rv=8,zr-,rv=5,xq-,mgm-,njrqz-,gtvvp-,zd=7,klfd=7,klfd-,gvzjn=2,zffjcc=6,xsj-,stph=4,cr=9,qz=7,nk-,ltzd-,pff=2,xsj=1,dt-,lth-,mp-,dcmm-,kj-,nhp=4,tfcx-,snm=5,smf=9,jmd-,lq-,sv-,gdmssd=7,dgx-,kfrpnr=3,gzx-,zd-,pqj-,xfqlc-,bt-,gf=4,sg-,vzx=3,qkh=6,tgc-,rt-,mnvbvr-,qns=3,bck=6,czg-,rp-,tgvqks-,ktvtfk=8,bzp=3,kfrpnr-,zfn=6,djp-,pjs=6,vhxjjm=3,bz-,pds=3,bgj-,gz=2,fxf=6,htb=2,pjs=4,rt=1,cl-,jkdp-,xzvt=6,zt-,pnz-,vzx-,kx-,pmc-,rbz-,rht=6,zt-,pq=1,dvd-,khm=1,zbb-,nzmt=2,qzd-,lq-,xkj=3,dgmn=6,dftq-,gkk=8,bzlz=7,jmd=8,nrj=2,pmc=8,fzbss=4,msr=9,qjnxvl=5,bxphtc=7,pmq=1,mdrtq=9,nzmt=9,kvk-,zz=7,tsr-,plx-,cdgz-,dnzl-,lt=3,vfjqg-,tj-,ssf=6,dfk-,bsc-,mm=6,xq=5,hjc-,stph-,jmd=8,zfjx=3,sgk-,fm=9,xfqlc-,sh-,ph=2,vrjfg=2,brgng=3,njrqz-,bk=4,jdgj=1,zst=8,qlh=8,rtvv-,qlh=2,qsh=7,njrqz=8,sk=6,dcxz=5,dgsjz-,xr-,mtxt=2,vsrgdj-,qzd=3,bxphtc-,tj-,kcj=9,jbljv-,hgszs=2,mhr-,kf=9,zpq=3,tj-,dr-,xdlr=5,jx=5,sk=7,zbmlcj-,tqnb-,qzd-,htncc-,xsj-,bq-,pt-,jmd=2,jx=2,plp=9,bqrx=2,qdq=8,rbzmb-,clz=6,nfh=5,lt=3,mm=7,pt-,vmlf=6,pn=9,lmv=4,sgck-,xn-,jhn-,sgck-,bthtl=5,pjll=9,rtx-,ctvm-,lg=7,fb-,rk-,zk-,nf=1,szq-,crx=9,lq=3,ltzd-,dfk-,sdm=3,css=5,np=3,zfjx-,dbs=8,vjz=1,plp-,pf-,mtxt-,bxphtc-,fj=2,vqnj-,xkj=6,dz-,mp=3,rkm=4,gfdxhm-,ps=1,zncxj=7,fmfm=8,smd=3,fb-,gljk-,ljdxr-,zf=3,dnzl=7,xl=4,fbj=3,gdsr=7,mnvbvr=4,qbjz-,vfq=3,zk=1,rd-,vkh=4,dpf=3,bpq=9,skm-,qp-,dcxz=6,zv-,lqrm=1,gjb-,zm-,vzsr-,pmq-,pff=1,sh-,nzmt-,gl-,hxts-,hgszs-,zpq=8,rlgv=6,mp=1,xcd=6,rbz=8,bq-,rbzmb=9,ssf=4,xd-,vn-,xrg-,pc-,ppb-,qlh-,hv=4,ls=8,rs-,bp-,zjhp=4,rtx=3,ljdxr-,hj=5,fqvmbl-,xnmkp-,zdb=5,zkdlm-,vhxjjm-,kf=1,zfn-,kpr-,xn-,nrdx-,rd-,hgszs=9,prq-,clz=6,dkl-,xr-,glpx-,zbmlcj-,qmtzf-,xh=2,cm=9,fb-,bq-,rs-,lz-,mn-,ndhl-,md=4,jbljv-,xn-,kcj=8,zpg=9,nf-,jhn-,bk-,djtk-,zdscf=2,kq-,md=7,hkz-,gvzjn-,khbz-,gdsr-,xpr-,drnjm-,clz=2,dm-,srx-,dgmn=3,lpsh-,zzx=5,pf=8,ftvktn-,cz=2,zfn=1,dhn-,gzx=6,fbj=6,qmtzf-,gxp=9,ph=1,vfhm-,bqx-,gq-,kpr=8,xrfs=6,xqmlx=1,srx=3,ptq-,dpnd-,vvmz=7,qkh-,ltb=4,nvq=4,ft=7,vrz-,srx-,gjq=4,rht=5,khbz=4,pf=2,vtdx=9,mq-,rk=7,vrz=7,zr=3,cz-,rxrl-,dvd-,mgm-,zmk=7,vvr=6,lj-,sljds-,scs-,zr=4,ps=7,lvc-,rq=3,rxrl-,xsrz-,lhncx=4,jnr=7,lq=4,jnr-,skm=7,bq=7,qsh=2,gjq=4,sh=4,kj-,bxphtc=5,rvp-,bxhm=7,vcgf-,zbmlcj-,dd=3,ddg-,bsc=1,zng-,gkk=4,nzmt=4,dfk=3,jkc-,jx-,sst-,vcgf-,gf=1,vfn-,dgx-,dfbjt-,glm=1,pntf=4,jpmnhm-,jfrm=9,cdgz=3,rkm-,lr=1,vs-,zt=4,dh-,bpq=7,vzsr=3,mtxt-,djtk-,ltb=7,kc-,qv=9,dq=4,tt-,nxcp=4,glm=3,tzm-,xh=2,vfq=5,lj-,rht-,zf-,hlddh-,dd=7,css-,sd=7,jkg-,gdsr=7,ksv=1,dcmm-,jtclbl=1,rs-,qjnxvl-,vrz-,xcrx-,zd=7,snm=6,mf-,ddg=5,jtzh=3,vhxjjm=2,kvk-,hj=6,qbjz=6,pds=4,gl=1,scs-,dbsln=4,mp-,zfn=7,fbj=9,dfrdck-,jkg-,khm=4,pgf=2,lvc=1,dz-,fbj-,djp=3,lkdm=1,gprzp-,dnzl=2,zglm-,rbz-,skj=5,sdm=1,qjnxvl=9,dz-,gdsr=4,dfbjt-,bqmg=5,xqvq-,mf-,cz-,dcxz-,dx=3,bqrx-,dhx=7,msr=7,mzd-,tgc=1,vfhm-,sjs-,pr-,skj=2,nxvk-,ncq-,rsdr-,sk-,ph-,xl-,bqx-,nqkg=9,ln-,ln=6,bthtl-,kvk-,bgj=7,sd-,mkj-,cf=2,bcgd=5,xhs=3,dgsjz=6,bgj-,pq-,pzqpj-,zbmlcj=5,dxt-,gprzp-,sbbct=7,zcqcms-,tsdv=3,fdrl=3,vfhm=6,sqcj-,zjhp-,dpf=9,tsr=4,zbmlcj=2,sh-,cb-,htb-,cnmm=8,qhns=3,rvt=9,vm=4,jkc-,fb-,dm=2,cl-,gp=8,nrdx=9,pc=8,qd=1,zbmlcj-,rsdr=9,bk=8,xvr=5,mf-,ff=5,htncc-,qjt-,hlddh-,ljdxr-,xfqlc-,ddg-,msr-,zpdh=7,ltb=2,sgck=7,bpq-,lpsh=8,cds-,vqnj-,np=2,lt=5,zk-,dhn-,njh-,lg=3,hh=5,qx-,kx=2,zkdlm=3,ld=4,dfrdck-,tt-,zffjcc=4,xvr-,sbk-,qx-,pr=7,vfq-,jrl=1,dxt-,pds=9,bgj-,pqj=3,nf=4,gzfb-,tt=2,sdm-,tkz-,bzg=5,cp=8,bcgd-,tgc-,zdscf=6,qkh-,nxvk=6,pnz=1,srx-,hjc=5,zzx=3,db-,nbb=3,ncq=9,glpx=6,bsc=7,vkh-,gkk=2,zf=9,glz-,cr=9,bk-,xcd=8,dsgft=6,rp=4,zv=6,ncq=6,mqgm=3,zpq-,cpjlj-,glz-,zggx-,xdpnjg=2,zdscf=6,tsdv=9,xnd-,clz-,sml-,lg=2,sg=7,gs=8,zbb=6,hnf=9,pr-,zr-,gxd-,gs-,bqmg=2,kgs-,mrv=5,gzx=2,cnmm=2,mhr=6,hrlr-,zm=1,xr-,mjdvv-,ssf=3,mm-,sbk-,hknmt=6,nzmt=2,prq-,xkj-,bt=8,bqx=5,dbh-,ghg-,vnz=1,ltzd-,ks-,zng=4,dsgft=5,jfrm-,pgf-,zdb-,nvq=3,htb=8,rgnsg=3,rp=2,zr=8,clz=6,sd-,bzp-,sgck=8,xfqlc=7,qmtzf-,gz=9,hknmt=1,pff=4,gzfb-,srx-,bz=2,qbv-,qh-,dbsln-,zzg=7,lhncx-,xnjn=5,glpx-,mh-,sjs-,xfqlc=7,bq=8,kr-,fph=9,vqnj=8,ftvktn-,cqcv=3,mmdmk=7,fxf-,khc=4,cpjlj=2,qx=6,xp=1,rgnsg-,xkrpbx-,sfn-,zpq-,gf=5,pntf=2,hjc=9,mkj=4,qvgqk-,hx-,vc-,hj=4,fj=8,mhh=9,sgk=6,mrv=7,nvq-,zdscf=3,gzfb=7,xrfs-,sfn=7,pf=7,djfqs=9,ffh-,rk-,ghg=2,mtxt=1,bcgd=7,fxf=9,qm=6,gvzjn=5,tqnb-,njrqz=6,mfp=3,gbg=5,bg-,ltb=8,sg-,gdsr=7,dh=4,cm=2,hrvx-,qd=5,tgvqks=5,gzs-,gz=2,gdm=6,dr-,pdms=9,sljds-,xvr=9,ccbn-,gf=4,jqnpx-,nxvk=4,ftvktn=4,dvd=5,pf-,mrv-,vkh=7,nc-,clflq-,dcc-,dpf-,zpq=7,xpr=3,ctvm-,csz=2,dgmn=3,scv=1,xnd=2,css=9,rjgk-,tgc=2,pjll-,kfrpnr=1,pr-,vfjqg-,zzx-,dxt-,mkj=7,hn=4,pmc-,jkc-,vrjfg-,mm=2,mx=3,lhncx=4,knr=5,gj=8,gxp-,djtk=9,sst-,kz-,hrlr=4,hdrc-,xvr-,mqgm=9,gdgjr=4,prq-,ssf=4,pt-,lt=2,glm=5,np=3,hdrc-,vnz-,tqnb-,djp=8,bp-,lc=2,bg-,lq-,xm-,xdlr-,ffj=5,rtvv-,bfxmzl=7,dhx-,gz=6,cg=4,dpf-,zbb=8,dd-,ksv=7,ppb=7,xfqlc=2,dfbjt-,skj-,cqcv-,rk=7,qs-,phsl-,zt=1,jpv=9,xpnpvg=4,xnd=6,dgfj-,xh-,hkz-,qlc-,xglp=7,tnxz=1,jsq-,tsr-,jbljv=5,zpq=6,tzm-,mdrtq=3,dkl-,slkt=1,pds=7,lz=1,rxrl=2,vnz-,xqmlx-,nbb=8,lgc=9,djtk=5,blz=7,lqrm-,csz-,dgx=4,vrjfg-,kj-,dpf=4,cp=7,mhh-,pn-,zr=8,vzsr-,bthtl=5,cp=6,rjgk=4,bfxmzl-,chfhqz-,rbzmb=4,hn=4,qjt=6,gvzjn=4,mhr=2,rlgv=8,mpg-,ph-,cds=9,tj-,xpnx-,dbs=2,rs=7,vzx-,xd-,sml=3,jrl=8,fbj=5,xm-,db-,zffjcc=8,nm-,bgj-,szn-,lc=6,lpsh-,nxcp-,ljdxr=6,dfrdck=9,zbb-,pff=6,gdgjr-,ndhl-,mdrtq=2,dftq-,xsj=6,lt-,kfrpnr-,xkj=5,zst=1,rt-,ltb-,gmb=6,zcqcms=2,pcsnm=4,vzx=2,bk=8,chfhqz-,hrvx=1,vtj-,tzm=9,sbk=6,dgfj=9,dfr=1,gp=7,zpk-,bqmg=1,vfhm=5,mfp-,cr-,mzd=3,hknmt-,dsz=7,hrvx=2,kz=5,fdrl-,pdms-,rjgk=4,zdb=5,pzqpj-,zpg-,rvt-,cqcv-,gxp=6,mmdmk-,rxrl-,gs-,nf=7,lg=5,tsdv-,bck-,sv=3,rgnsg=1,fmfm-,nrj=9,mzd=2,jbljv=5,hrlr-,xcrx-,mzd=5,mjdvv-,sqcj=9,lth-,njh=4,kq-,mhr-,xsj-,xtl=2,gfdxhm-,qm-,tgvqks=8,rtx-,dfk-,lqrm-,tgc=4,xq=7,bxhm=1,skm-,nhp-,dr-,bgj-,lg-,gzd=7,bz-,gkrl-,hjc=3,kz-,hlddh=6,kpr-,clflq=1,gj=4,rq=3,zpj=1,dq=1,scv=5,djfqs-,pntf-,zk-,mnx=7,xdpnjg-,gzg-,sg-,sg=5,vzsr=9,dbs-,vkh=7,bx=9,xrg=2,jmbl-,mjdvv-,dftq-,dh-,ds-,qvgqk-,zm-,kgs=2,gkk=7,nfh=3,xp=2,mtxt-,cf=1,nhp-,xgg=5,hknmt-,vsrgdj-,tj=4,xgg=5,hlddh=7,fdrl-,bthtl-,jsq-,vn-,sk=7,jkdp=7,jsm=2,cm=7,ls=5,xpnx=3,zpj-,qv=4,rv-,xm-,bxhm=6,mlk-,dvd=3,bd-,njh-,dh-,mhh=1,xzvt-,scs=5,xr=9,rt-,mnvbvr=4,sml=7,cdgz=5,vt=7,zzg=5,vkh=5,pn-,xr-,lxm-,dnzl-,tj-,plp-,gfdxhm-,rq-,qhns=6,kjjjd=8,tkz=4,mp=4,mn=5,zfn=2,ppb-,fd-,pgf=2,gdmssd-,zpg=8,nxvk=4,dq=2,dlz-,qs=1,smd=7,gq-,snm-,njx-,rq=7,qsh=9,qjj-,gf-,khc-,nxcp=3,hjc-,bqmg-,rq=1,qlh-,kvk-,bcgd=9,zmk-,csz=2,gjq=2,gxp-,gqb-,xgg-,tgc-,zzg-,qx=1,zdb-,lmv-,xnmkp=4,rs-,bzg=9,mhr=4,dt-,sdrg=4,mtxt=7,mfp=8,phsl-,spf-";
            //InputData = "rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7";   // Exemple donné pour debug
            #endregion

            InitInputData(InputData);

            foreach (string ligne in Lines)
            {
                InitialisationLigne(ligne);
            }

            for(int i = 0; i < 256; i++)
            {
                Boxes.Add(new Box() { Index = i });
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
            var Split = ligne.Split(',').ToList();
            foreach(var split in Split)
            {
                this.Maps.Add(new HashMap(split));
                Lens lens = new Lens(split);
                Lentilles.Add(lens);
            }
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
            return Maps.Sum(m=>(long)Encode(m.Input));
        }
        private long ProcessPart2()
        {
            foreach(Lens lens in Lentilles)
            {
                if(lens.Dioptrie.HasValue)
                {
                    Lens l = Boxes[lens.Hash].Lentilles.FirstOrDefault(le => le.Label.Equals(lens.Label));
                    if (l != null)
                    {
                        l.Dioptrie = lens.Dioptrie;
                    }
                    else
                    {
                        Boxes[lens.Hash].Lentilles.Add(lens);
                    }
                }
                else
                {
                    Boxes[lens.Hash].Lentilles.RemoveAll(le => le.Label.Equals(lens.Label));
                }
            }

            return Boxes.Sum(b => (b.FocusingPower));
        }

        public static char Encode(string input)
        {
            char current = '\0';
            foreach (char c in input)
            {
                current += c;
                current = (char)((current * 17) % 256);
            }
            return current;
        }
        #endregion

        #region Debug
        private void DebugInit()
        {
        }
        #endregion

        #region Classes de travail
        public class HashMap
        {
            public string Input { get; private set; }

            public HashMap(string input)
            {
                Input = input.ToString();
            }
        }
        public class Lens
        {
            public string Label { get; set; }
            public long? Dioptrie { get; set; } = null;
            public char Hash { get; private set; }
            private Lens() { }
            public Lens(string input)
            {
                if(input.Contains('='))
                {
                    var Split = input.Split('=').ToList();
                    Label = Split[0];
                    Dioptrie = int.Parse(Split[1]);
                }
                else
                {
                    var Split = input.Split('-').ToList();
                    Label = Split[0];
                }
                Hash = Encode(Label);
            }
        }
        public class Box
        {
            public int Index { get; set; }
            public List<Lens> Lentilles { get; private set; } = new List<Lens>();
            public long FocusingPower
            {
                get
                {
                    return Lentilles.Select((l, i) => (Index+1) * l.Dioptrie.Value * (i + 1)).Sum();
                }
            }
        }
        #endregion
    }
}
