namespace AdventOfCode.Jours
{
    public class Jour_8 : Jour_abs
    {
        #region Enumerables
        public enum Instruction
        {
            Gauche = 0,
            Droite = 1
        }
        #endregion

        #region Propriétés
        private List<Instruction> Instructions { get; set; } = new List<Instruction>();
        private Network Reseau { get; set; } = null;
        #endregion

        #region Constructeur
        public Jour_8(bool debug = false):base(debug)
        {
            #region Input Data
            string InputData = "LRRRLRRLLRRLRRLRRLRRLRLLRLRLLRRLRLRRRLRRLRRLLRLRLRLRRRLRRRLLRLRRRLLRRRLRLLRRRLLRRLRLRLRRRLLRRLRRRLLRRLRLRRRLLRRRLRRLRLRRRLLRRLRRRLRRLLRRLRRLRRRLRRRLRRRLRRLRRRLLRLRLRLRRRLRRLRRRLRRLRLRRLRLRRRLRRRLRRLRRRLLRRRLLRRLRLRRRLRLRLRRRLRLRLRLRRLRLRRLRRLLRRRLRLLRRLRRRLRRRLLRRLRLLLLRRLRRRR\r\n\r\nPGQ = (QRB, MJB)\r\nJQC = (MNM, TLQ)\r\nHNP = (NKD, PJT)\r\nMDM = (SPC, RJP)\r\nQMZ = (BFS, TVG)\r\nFHJ = (MRQ, BRJ)\r\nQBT = (HTH, JXN)\r\nMQN = (NLQ, JQN)\r\nJTR = (TRS, TTN)\r\nBXC = (JMQ, BMN)\r\nJGD = (NBS, MDV)\r\nSML = (NCX, TRX)\r\nBDB = (SVH, RSP)\r\nRLQ = (PML, GKR)\r\nLKS = (NDR, CGG)\r\nSQB = (KPB, TQR)\r\nJFS = (BTX, LSK)\r\nBMJ = (BXC, SBP)\r\nKDX = (MCQ, GQP)\r\nXKR = (FKN, VBR)\r\nBPX = (XTV, GQH)\r\nSQH = (JGK, CGK)\r\nXRJ = (PQD, SBL)\r\nQXF = (TDH, XXN)\r\nBJS = (SCQ, LPD)\r\nNMV = (STS, PSG)\r\nGXB = (MSV, LNQ)\r\nFQX = (LKV, CTL)\r\nTJQ = (FHS, CXJ)\r\nPLP = (HKG, JKB)\r\nMFL = (RRP, CMB)\r\nNLF = (CCF, FST)\r\nMXA = (GKS, LTM)\r\nKJG = (GFJ, GFJ)\r\nVXC = (QCQ, JTH)\r\nQCD = (CVB, CHH)\r\nRFR = (KGH, VBF)\r\nJMC = (XTF, SQH)\r\nRPQ = (CSH, MFJ)\r\nTNK = (GSD, KFZ)\r\nHXM = (JXP, JLD)\r\nTGJ = (SML, KDL)\r\nXDS = (MFJ, CSH)\r\nPQX = (NNL, MXR)\r\nKFD = (LPN, PXQ)\r\nSJX = (GCP, BJS)\r\nBHH = (XMV, MFP)\r\nGPV = (VGQ, HDV)\r\nVJS = (JPS, QRL)\r\nMGH = (HSH, BGV)\r\nCNN = (XQB, RLQ)\r\nFKN = (JHR, VMV)\r\nHFR = (BJV, BQT)\r\nHHB = (JSH, XKS)\r\nGHL = (NJJ, HXB)\r\nMXN = (PQD, SBL)\r\nDLM = (TMG, TNK)\r\nRJS = (MCC, NHS)\r\nJHP = (RXT, RDD)\r\nRHQ = (DKG, VHJ)\r\nHRN = (QXF, JBH)\r\nGPD = (LTL, JSV)\r\nQFP = (DDQ, MFL)\r\nTSD = (TGD, LCS)\r\nKKS = (TVG, BFS)\r\nBLG = (TCN, DXP)\r\nHFS = (XFH, SKH)\r\nPPP = (QCD, QDV)\r\nTQM = (QCQ, JTH)\r\nBTX = (QGG, GLJ)\r\nHXG = (BPT, JBJ)\r\nFSC = (QKJ, JFB)\r\nMLB = (LVH, DSF)\r\nHHK = (VCT, GHL)\r\nQGF = (BPX, SVF)\r\nQVP = (GJP, BHB)\r\nPHC = (FQV, RNQ)\r\nXFS = (MDV, NBS)\r\nMVN = (VTR, FQX)\r\nXVT = (LHF, RTX)\r\nFQT = (VDV, HNV)\r\nJJX = (KDP, KHD)\r\nLTD = (FTJ, FTJ)\r\nPXL = (NBL, LGC)\r\nGKS = (XGX, HTQ)\r\nCDQ = (XGL, GFN)\r\nMBP = (KCR, VGV)\r\nHKT = (JLD, JXP)\r\nVJT = (DVX, KVF)\r\nBFR = (RGC, DDG)\r\nVVJ = (XGL, GFN)\r\nCJQ = (RXT, RDD)\r\nSHZ = (HLF, HHX)\r\nVQA = (TVG, BFS)\r\nNFJ = (DCQ, FSC)\r\nKHP = (KHB, LFG)\r\nBMN = (PKB, XHH)\r\nSVF = (GQH, XTV)\r\nNQN = (XBB, DSP)\r\nNBS = (XXD, GPD)\r\nBJD = (SVF, BPX)\r\nXGH = (MLR, HFS)\r\nVQT = (HKK, BMJ)\r\nJSM = (SKX, FHJ)\r\nSBP = (JMQ, BMN)\r\nSCQ = (FMP, SPS)\r\nXMS = (DKC, HQS)\r\nCCC = (MPP, GPV)\r\nVBJ = (KHB, LFG)\r\nCVB = (LTN, JGJ)\r\nNHV = (FVX, PMR)\r\nNFX = (LLB, DXD)\r\nPTN = (HHT, GCF)\r\nXCV = (VBR, FKN)\r\nPJT = (DBB, VRJ)\r\nVHJ = (JNT, QJT)\r\nCSH = (QHM, KTK)\r\nNQL = (XVQ, QVP)\r\nDNV = (TSD, SLF)\r\nNFT = (QDB, GPH)\r\nMPQ = (TNB, PTN)\r\nTQR = (VJH, NRX)\r\nQCS = (CLJ, VGS)\r\nRGK = (PGQ, ZZZ)\r\nSKX = (MRQ, BRJ)\r\nMKG = (TSR, HTF)\r\nJMQ = (PKB, XHH)\r\nRNK = (JBP, QQN)\r\nRNH = (JKQ, VBP)\r\nTJN = (FRQ, MVN)\r\nJFB = (XQF, FLF)\r\nBRJ = (NBR, RSD)\r\nKVH = (DMX, JDC)\r\nDXP = (CXN, BCH)\r\nKVF = (JGQ, KJK)\r\nJKB = (XHL, DBM)\r\nGRF = (TGJ, GFF)\r\nDPR = (TBV, GJV)\r\nCRF = (RJJ, VDG)\r\nFQG = (HRJ, NQF)\r\nHDV = (SJX, MMF)\r\nSLF = (LCS, TGD)\r\nCGL = (NDF, VPV)\r\nGQK = (JTQ, PSM)\r\nPKB = (LSP, VMB)\r\nHCK = (TSD, SLF)\r\nMPG = (CQN, DTK)\r\nHLF = (KFK, NNK)\r\nXXN = (RHQ, SSC)\r\nNKD = (VRJ, DBB)\r\nNVQ = (NDF, VPV)\r\nZZZ = (MJB, QRB)\r\nFQV = (STP, LMG)\r\nKQC = (RGC, DDG)\r\nLNJ = (XCV, XKR)\r\nJSV = (VNM, CVM)\r\nXLQ = (XGP, LFQ)\r\nDLC = (RBB, GVS)\r\nSCS = (BJP, CJR)\r\nRRP = (KJG, KJG)\r\nKRX = (FCB, CXP)\r\nBQT = (QPJ, DCP)\r\nMGF = (LNJ, JRK)\r\nCCM = (VJN, JMD)\r\nXQF = (KCH, HXH)\r\nRGC = (SRS, QVB)\r\nJTH = (KJH, MKG)\r\nMQS = (RSV, VQQ)\r\nDFN = (CGL, NVQ)\r\nDXD = (XMS, BQP)\r\nNRX = (RNV, SFC)\r\nGDP = (BJJ, MBP)\r\nFQF = (NRV, FHT)\r\nSGK = (CLJ, VGS)\r\nSGR = (PJT, NKD)\r\nTTN = (XLP, HFM)\r\nLHP = (GPP, BHH)\r\nNNK = (JQT, PLP)\r\nDKM = (NDC, BDM)\r\nVNM = (JJV, GVP)\r\nFCB = (HRN, TJP)\r\nLJQ = (QGF, BJD)\r\nMCC = (HJN, KLK)\r\nKXP = (HJC, VSC)\r\nVDX = (DMS, VVM)\r\nQDB = (SPT, JRP)\r\nCBA = (PQX, PMM)\r\nGKR = (LTD, GBP)\r\nKHV = (QCP, VQT)\r\nLMM = (GDP, TFD)\r\nVXK = (PXV, QDC)\r\nQMH = (HCK, DNV)\r\nGPC = (BGV, HSH)\r\nHXH = (HRP, FXD)\r\nTFR = (QDV, QCD)\r\nRJJ = (RTP, XFK)\r\nTCB = (DMS, VVM)\r\nHRP = (KXP, HCG)\r\nDDQ = (RRP, RRP)\r\nXXD = (LTL, JSV)\r\nCTL = (TXP, MLB)\r\nSFH = (HDP, HHK)\r\nQCF = (TTN, TRS)\r\nSNJ = (TVF, CNN)\r\nDRM = (DCL, DSM)\r\nVVN = (TFR, PPP)\r\nKDB = (BJP, CJR)\r\nVJN = (TCG, NMV)\r\nVQH = (PDF, NVG)\r\nXTS = (TQM, VXC)\r\nTLM = (JQN, NLQ)\r\nNVP = (FRQ, MVN)\r\nMNK = (CXP, FCB)\r\nDCQ = (JFB, QKJ)\r\nHXB = (RJS, SPD)\r\nNJT = (SRL, HCD)\r\nLPT = (TFD, GDP)\r\nLCT = (RFK, FNR)\r\nNXD = (KKS, KKS)\r\nVGS = (KGX, XLQ)\r\nFHT = (SVP, XVF)\r\nQND = (HHK, HDP)\r\nBJP = (TJN, NVP)\r\nRVK = (DFK, QGP)\r\nRQN = (BHM, CKP)\r\nGJP = (VQS, RFR)\r\nRBT = (JBP, JBP)\r\nDMP = (DSP, XBB)\r\nGPP = (MFP, XMV)\r\nJTQ = (XGH, SNR)\r\nFTJ = (TDB, TDB)\r\nXHL = (QMC, HGT)\r\nGMC = (LKN, GHN)\r\nRBB = (JDJ, BTB)\r\nHFM = (KMG, QBP)\r\nCPQ = (BLH, DPR)\r\nCXD = (SMQ, GSP)\r\nFSM = (BLK, LQH)\r\nBPT = (DLL, QBT)\r\nCKP = (XJX, SDJ)\r\nFTK = (QMH, FSG)\r\nTLQ = (DFP, QDQ)\r\nMFJ = (QHM, KTK)\r\nJGK = (GDN, HBF)\r\nGNK = (VFB, GRF)\r\nTCN = (CXN, BCH)\r\nQPB = (FMF, CCM)\r\nCHM = (PXV, QDC)\r\nKCV = (XXR, XXR)\r\nHQS = (MGH, GPC)\r\nRDK = (MFF, DFN)\r\nSPT = (LKS, KCJ)\r\nNMS = (LQH, BLK)\r\nKGN = (VQT, QCP)\r\nVBC = (RBT, RNK)\r\nSBL = (FDH, VVN)\r\nCJR = (NVP, TJN)\r\nDBD = (SHB, FFS)\r\nSRS = (NQN, DMP)\r\nDSS = (QJD, PHC)\r\nQQN = (NXD, DVJ)\r\nRNQ = (STP, LMG)\r\nLMJ = (RTX, LHF)\r\nMQG = (GTV, XPP)\r\nJBP = (NXD, NXD)\r\nTCT = (MGR, MPG)\r\nKCH = (FXD, HRP)\r\nXHZ = (LTM, GKS)\r\nJTK = (NFX, FGB)\r\nPSG = (NHK, VBC)\r\nLCM = (GFJ, FXZ)\r\nGVS = (BTB, JDJ)\r\nCCF = (LPV, JVD)\r\nJLD = (HGH, VJT)\r\nDKC = (MGH, GPC)\r\nDBM = (HGT, QMC)\r\nGKJ = (HKT, HXM)\r\nKTK = (LJQ, RHK)\r\nCFT = (VXK, CHM)\r\nPVP = (MQN, TLM)\r\nSLT = (NBL, LGC)\r\nLGX = (LNQ, MSV)\r\nDKG = (JNT, QJT)\r\nQHM = (LJQ, RHK)\r\nDFP = (KMF, BCF)\r\nMFF = (NVQ, CGL)\r\nTGD = (JQC, LCJ)\r\nKXK = (CQD, BRB)\r\nKCJ = (CGG, NDR)\r\nRHK = (BJD, QGF)\r\nMXR = (DKP, HCP)\r\nXPP = (PVB, NHV)\r\nTMG = (GSD, GSD)\r\nMDV = (XXD, GPD)\r\nRSV = (VDX, TCB)\r\nHCG = (VSC, HJC)\r\nNBJ = (SLH, TCT)\r\nNBL = (CXV, HHN)\r\nKTF = (GBR, MLN)\r\nLMT = (HQJ, NFT)\r\nSGS = (FSG, QMH)\r\nNTN = (NFJ, XBH)\r\nNXR = (XXR, XHZ)\r\nPXV = (SGK, QCS)\r\nLMG = (XHG, PVP)\r\nHTH = (MDM, DNL)\r\nKNF = (XRJ, MXN)\r\nTNB = (GCF, HHT)\r\nNDR = (PXL, SLT)\r\nNRV = (XVF, SVP)\r\nPVF = (PSM, JTQ)\r\nMGV = (VXC, TQM)\r\nQFD = (BHH, GPP)\r\nDKP = (NQR, HQL)\r\nMSV = (SQB, JJD)\r\nVSC = (MPV, NJT)\r\nBHV = (VRQ, HFR)\r\nPGB = (DDQ, MFL)\r\nVCT = (NJJ, HXB)\r\nHNV = (QMG, PDJ)\r\nSKH = (TDP, HPM)\r\nHSH = (SRN, RQL)\r\nPML = (LTD, GBP)\r\nCJP = (SDT, SSQ)\r\nSDJ = (NLF, HRD)\r\nBCK = (CQV, MBS)\r\nNLQ = (DFX, RKQ)\r\nJQT = (HKG, JKB)\r\nJDJ = (SBK, XLL)\r\nVQS = (KGH, VBF)\r\nDCP = (PPR, MBV)\r\nJGQ = (QBH, GSK)\r\nFFS = (HHB, PFH)\r\nQVB = (DMP, NQN)\r\nQCP = (BMJ, HKK)\r\nMPV = (SRL, HCD)\r\nNCX = (MGF, VFL)\r\nJJV = (FNH, KFF)\r\nSSC = (DKG, VHJ)\r\nXNN = (MBS, CQV)\r\nPSM = (XGH, SNR)\r\nXLP = (KMG, QBP)\r\nLCJ = (TLQ, MNM)\r\nBNP = (CHM, VXK)\r\nGXF = (XVQ, QVP)\r\nRSD = (MTN, TMQ)\r\nCCR = (KRX, MNK)\r\nBGV = (RQL, SRN)\r\nHJC = (NJT, MPV)\r\nSXR = (HPK, TMF)\r\nDTK = (JGL, MLX)\r\nSDG = (QCH, TLP)\r\nMSK = (PNN, TTS)\r\nSPC = (FQG, MJN)\r\nVPV = (CGR, TTF)\r\nXJG = (QFX, BLG)\r\nTSX = (TXB, DFS)\r\nQMG = (KFD, VJJ)\r\nNDF = (CGR, TTF)\r\nLVH = (FJX, FNX)\r\nMLS = (VJS, BSJ)\r\nVSG = (DFS, TXB)\r\nRFK = (CNB, CNB)\r\nXVQ = (BHB, GJP)\r\nCJG = (SXR, CDV)\r\nSHL = (LRH, GKJ)\r\nQJT = (NVF, PVG)\r\nNHS = (KLK, HJN)\r\nJXN = (DNL, MDM)\r\nBLK = (CRF, DKS)\r\nDFS = (TPX, MQS)\r\nLPN = (RGB, NBJ)\r\nDSP = (TPF, JMC)\r\nLRR = (NDC, BDM)\r\nGSP = (GVJ, LMT)\r\nBNK = (MPP, GPV)\r\nLTN = (LRR, DKM)\r\nPPR = (JHV, MLS)\r\nCGR = (MMQ, TQQ)\r\nJFK = (KRX, MNK)\r\nMMF = (GCP, BJS)\r\nPDJ = (VJJ, KFD)\r\nJBH = (TDH, XXN)\r\nSSR = (KDX, TDV)\r\nTFD = (BJJ, MBP)\r\nSHB = (PFH, HHB)\r\nGCF = (XVP, CJP)\r\nQPJ = (MBV, PPR)\r\nDFX = (KGN, KHV)\r\nXTF = (CGK, JGK)\r\nXLL = (CJG, VHH)\r\nLKT = (NVG, PDF)\r\nVGQ = (MMF, SJX)\r\nTLP = (JTK, SCT)\r\nQDQ = (KMF, BCF)\r\nRNV = (XLM, MQG)\r\nSDT = (KJT, LFX)\r\nXQB = (PML, GKR)\r\nFHS = (TPP, KNF)\r\nQJD = (FQV, RNQ)\r\nSBK = (CJG, VHH)\r\nMMQ = (XDS, RPQ)\r\nGCQ = (VDV, HNV)\r\nBKQ = (KDP, KHD)\r\nJHV = (BSJ, VJS)\r\nGFF = (KDL, SML)\r\nJDC = (PMH, SBR)\r\nFMF = (JMD, VJN)\r\nJQN = (RKQ, DFX)\r\nPVB = (PMR, FVX)\r\nHGH = (KVF, DVX)\r\nBHB = (RFR, VQS)\r\nSPD = (MCC, NHS)\r\nJXP = (HGH, VJT)\r\nGVP = (FNH, KFF)\r\nVJH = (RNV, SFC)\r\nGHN = (VQH, LKT)\r\nHHT = (XVP, CJP)\r\nFGB = (DXD, LLB)\r\nHVL = (BDB, VJQ)\r\nDMX = (PMH, SBR)\r\nNVG = (JGD, XFS)\r\nVDG = (RTP, XFK)\r\nCXV = (TBC, HVL)\r\nRDD = (GXF, NQL)\r\nCDV = (TMF, HPK)\r\nRSP = (KVH, XVV)\r\nFNH = (LKH, JLL)\r\nMTN = (LFD, MSK)\r\nTPX = (RSV, VQQ)\r\nDSM = (RXB, SHZ)\r\nMGC = (SKX, FHJ)\r\nPQD = (FDH, VVN)\r\nXJX = (NLF, HRD)\r\nFVX = (XJG, LHJ)\r\nXXR = (GKS, LTM)\r\nHHN = (TBC, HVL)\r\nXTV = (FTK, SGS)\r\nTPP = (MXN, XRJ)\r\nJKQ = (SXP, KTF)\r\nLFX = (MGV, XTS)\r\nLFD = (PNN, TTS)\r\nXLM = (XPP, GTV)\r\nJRP = (LKS, KCJ)\r\nSCT = (FGB, NFX)\r\nBRB = (RDX, SSR)\r\nBPQ = (QND, SFH)\r\nGJV = (NMS, FSM)\r\nMRQ = (NBR, RSD)\r\nBQP = (HQS, DKC)\r\nVFB = (TGJ, GFF)\r\nKFZ = (PMM, PQX)\r\nNNL = (DKP, HCP)\r\nRSK = (CFQ, QSN)\r\nCVM = (GVP, JJV)\r\nTBV = (NMS, FSM)\r\nFCG = (MXX, LCT)\r\nLSP = (DBD, FTS)\r\nDVX = (JGQ, KJK)\r\nJHR = (RMJ, HQV)\r\nTQQ = (RPQ, XDS)\r\nCXN = (PSB, PSB)\r\nJRK = (XCV, XKR)\r\nLLB = (BQP, XMS)\r\nKJK = (QBH, GSK)\r\nKFK = (JQT, PLP)\r\nGDN = (JFS, TXD)\r\nTXB = (TPX, MQS)\r\nBJV = (DCP, QPJ)\r\nHKK = (BXC, SBP)\r\nFST = (JVD, LPV)\r\nPSP = (TNP, FQF)\r\nQCQ = (KJH, MKG)\r\nTDB = (PGQ, PGQ)\r\nHCP = (NQR, HQL)\r\nXBH = (DCQ, FSC)\r\nSNR = (MLR, HFS)\r\nJSL = (DFK, QGP)\r\nPFH = (XKS, JSH)\r\nXFH = (TDP, HPM)\r\nDSF = (FNX, FJX)\r\nHPK = (SNJ, KXT)\r\nSPS = (JJX, BKQ)\r\nKXT = (TVF, CNN)\r\nHDP = (VCT, GHL)\r\nVGV = (THX, VBG)\r\nKHB = (DSS, QFF)\r\nJNT = (PVG, NVF)\r\nQBH = (BVN, BVN)\r\nLNQ = (SQB, JJD)\r\nLQH = (CRF, DKS)\r\nFMP = (BKQ, JJX)\r\nHQJ = (QDB, GPH)\r\nJJD = (KPB, TQR)\r\nMFP = (BNK, CCC)\r\nLSK = (GLJ, QGG)\r\nGSK = (BVN, BCX)\r\nMPP = (HDV, VGQ)\r\nCMB = (KJG, LCM)\r\nJGJ = (DKM, LRR)\r\nVFK = (GQK, PVF)\r\nGVJ = (NFT, HQJ)\r\nRXB = (HHX, HLF)\r\nPDF = (JGD, XFS)\r\nRCD = (VVR, QVG)\r\nVRQ = (BJV, BQT)\r\nCLJ = (XLQ, KGX)\r\nPPK = (XBH, NFJ)\r\nHRJ = (QVV, GNK)\r\nNDC = (TCF, DXQ)\r\nDMC = (VBP, JKQ)\r\nNJJ = (RJS, SPD)\r\nJBB = (RDK, FNL)\r\nQMC = (PSP, BKN)\r\nGBR = (GXS, HXG)\r\nHGT = (PSP, BKN)\r\nLPD = (FMP, SPS)\r\nNHK = (RBT, RNK)\r\nNVF = (LMM, LPT)\r\nHRD = (CCF, FST)\r\nMNM = (QDQ, DFP)\r\nHQV = (NML, RSN)\r\nMLX = (LMJ, XVT)\r\nKGH = (FCG, SCK)\r\nLHJ = (BLG, QFX)\r\nHQL = (DMC, RNH)\r\nLGC = (HHN, CXV)\r\nMBS = (TJQ, LVN)\r\nLRJ = (PVF, GQK)\r\nPXQ = (RGB, NBJ)\r\nTSR = (NTN, PPK)\r\nVMV = (RMJ, HQV)\r\nDCL = (RXB, RXB)\r\nHHX = (NNK, KFK)\r\nXPV = (SFH, QND)\r\nXGL = (SXG, DLC)\r\nLRH = (HKT, HXM)\r\nJBA = (HPC, JBB)\r\nKHD = (CJQ, JHP)\r\nLVN = (FHS, CXJ)\r\nGLJ = (LHP, QFD)\r\nKLK = (VVJ, CDQ)\r\nSRN = (KHQ, MPQ)\r\nTTS = (GMC, PKT)\r\nVJJ = (LPN, PXQ)\r\nJCG = (VVR, QVG)\r\nJLL = (RCD, JCG)\r\nBLH = (GJV, TBV)\r\nGQP = (FQT, GCQ)\r\nFDH = (PPP, TFR)\r\nHJN = (CDQ, VVJ)\r\nFLF = (HXH, KCH)\r\nSBR = (KDB, SCS)\r\nRSN = (FKX, BHV)\r\nSVP = (CXD, NCP)\r\nTJP = (QXF, JBH)\r\nJGL = (XVT, LMJ)\r\nPMR = (XJG, LHJ)\r\nPNN = (PKT, GMC)\r\nKJT = (MGV, XTS)\r\nMJN = (HRJ, NQF)\r\nTNP = (FHT, NRV)\r\nLFQ = (BCK, XNN)\r\nFXD = (KXP, HCG)\r\nJRL = (BNP, CFT)\r\nVMB = (FTS, DBD)\r\nQCH = (JTK, SCT)\r\nBJJ = (KCR, VGV)\r\nAAA = (QRB, MJB)\r\nJPS = (KQC, BFR)\r\nVHH = (SXR, CDV)\r\nTXD = (LSK, BTX)\r\nXGX = (TNT, JRL)\r\nVBP = (SXP, KTF)\r\nMJB = (VBJ, KHP)\r\nDVJ = (KKS, QMZ)\r\nCQV = (LVN, TJQ)\r\nGSD = (PQX, PMM)\r\nPKT = (GHN, LKN)\r\nFNR = (CNB, DLM)\r\nGQH = (SGS, FTK)\r\nXGP = (XNN, BCK)\r\nTTF = (TQQ, MMQ)\r\nTXP = (DSF, LVH)\r\nJVD = (PGB, QFP)\r\nGCP = (LPD, SCQ)\r\nFNL = (DFN, MFF)\r\nPTC = (LRH, GKJ)\r\nPSB = (DCL, DCL)\r\nKMF = (VFK, LRJ)\r\nVNN = (TDB, RGK)\r\nDMS = (CSR, RQN)\r\nCNB = (TMG, TMG)\r\nSMQ = (LMT, GVJ)\r\nVBG = (PTC, SHL)\r\nVMQ = (QCH, TLP)\r\nFTS = (SHB, FFS)\r\nBCX = (KCV, NXR)\r\nCSR = (BHM, CKP)\r\nTCF = (CPQ, QVH)\r\nPHN = (KXK, MPL)\r\nMXX = (RFK, FNR)\r\nMQH = (FMF, CCM)\r\nSSQ = (KJT, LFX)\r\nBVN = (KCV, KCV)\r\nLFG = (DSS, QFF)\r\nQFX = (TCN, DXP)\r\nXFK = (CCR, JFK)\r\nDDG = (SRS, QVB)\r\nTVF = (RLQ, XQB)\r\nTNT = (CFT, BNP)\r\nGFN = (DLC, SXG)\r\nBCH = (PSB, DRM)\r\nXKS = (BPQ, XPV)\r\nSFC = (XLM, MQG)\r\nLHV = (KXK, MPL)\r\nNQR = (DMC, RNH)\r\nRTP = (CCR, JFK)\r\nVFL = (LNJ, JRK)\r\nDKS = (VDG, RJJ)\r\nVVM = (CSR, RQN)\r\nMCQ = (GCQ, FQT)\r\nCXJ = (KNF, TPP)\r\nDFK = (HML, RSK)\r\nQDV = (CHH, CVB)\r\nTVG = (JSM, MGC)\r\nXBB = (TPF, JMC)\r\nPMM = (MXR, NNL)\r\nCGK = (HBF, GDN)\r\nLKV = (MLB, TXP)\r\nHCD = (VSG, TSX)\r\nXMV = (BNK, CCC)\r\nTMQ = (MSK, LFD)\r\nJMD = (TCG, NMV)\r\nHPM = (VMQ, SDG)\r\nLKN = (LKT, VQH)\r\nTMF = (KXT, SNJ)\r\nBKN = (TNP, FQF)\r\nLCS = (LCJ, JQC)\r\nQRB = (VBJ, KHP)\r\nQSN = (MQH, QPB)\r\nXHG = (MQN, TLM)\r\nJBJ = (DLL, QBT)\r\nSLH = (MPG, MGR)\r\nQVG = (QCF, JTR)\r\nJSH = (BPQ, XPV)\r\nTDV = (MCQ, GQP)\r\nVVR = (JTR, QCF)\r\nNBR = (MTN, TMQ)\r\nQGP = (RSK, HML)\r\nGXS = (BPT, JBJ)\r\nPMH = (SCS, KDB)\r\nGBP = (FTJ, VNN)\r\nBHM = (SDJ, XJX)\r\nRTX = (GXB, LGX)\r\nMLR = (XFH, SKH)\r\nGFJ = (HPC, JBB)\r\nDBB = (JSL, RVK)\r\nCXP = (TJP, HRN)\r\nSCK = (MXX, LCT)\r\nVBF = (FCG, SCK)\r\nTDP = (VMQ, SDG)\r\nGTV = (NHV, PVB)\r\nRXT = (NQL, GXF)\r\nLPV = (PGB, QFP)\r\nRMJ = (RSN, NML)\r\nMPL = (CQD, BRB)\r\nDNL = (RJP, SPC)\r\nLTM = (XGX, HTQ)\r\nHTF = (PPK, NTN)\r\nVQQ = (VDX, TCB)\r\nFJX = (PHN, LHV)\r\nSXP = (GBR, MLN)\r\nVJQ = (RSP, SVH)\r\nBTB = (XLL, SBK)\r\nKJH = (HTF, TSR)\r\nFRQ = (FQX, VTR)\r\nKHQ = (PTN, TNB)\r\nKPB = (VJH, NRX)\r\nHTQ = (JRL, TNT)\r\nTCG = (STS, PSG)\r\nQVH = (BLH, DPR)\r\nQDC = (SGK, QCS)\r\nBDM = (DXQ, TCF)\r\nCFQ = (QPB, MQH)\r\nSTP = (PVP, XHG)\r\nRGB = (SLH, TCT)\r\nBSJ = (JPS, QRL)\r\nRDX = (TDV, KDX)\r\nTBC = (BDB, VJQ)\r\nSRL = (TSX, VSG)\r\nKDP = (CJQ, JHP)\r\nKMG = (SGR, HNP)\r\nFNX = (LHV, PHN)\r\nQRL = (KQC, BFR)\r\nLHF = (LGX, GXB)\r\nFSG = (DNV, HCK)\r\nHML = (CFQ, QSN)\r\nHSA = (HHX, HLF)\r\nXVP = (SSQ, SDT)\r\nKDL = (TRX, NCX)\r\nRJP = (FQG, MJN)\r\nDLL = (HTH, JXN)\r\nXVF = (NCP, CXD)\r\nCQN = (MLX, JGL)\r\nQKJ = (FLF, XQF)\r\nBFS = (MGC, JSM)\r\nQFF = (PHC, QJD)\r\nHPC = (FNL, RDK)\r\nMGR = (CQN, DTK)\r\nTHX = (PTC, SHL)\r\nTPF = (XTF, SQH)\r\nFKX = (HFR, VRQ)\r\nCQD = (RDX, SSR)\r\nBCF = (VFK, LRJ)\r\nSTS = (NHK, VBC)\r\nCGG = (SLT, PXL)\r\nDXQ = (QVH, CPQ)\r\nXHH = (LSP, VMB)\r\nVBR = (JHR, VMV)\r\nGPH = (JRP, SPT)\r\nMBV = (MLS, JHV)\r\nNCP = (GSP, SMQ)\r\nNML = (BHV, FKX)\r\nKFF = (LKH, JLL)\r\nVTR = (LKV, CTL)\r\nVDV = (QMG, PDJ)\r\nQBP = (SGR, HNP)\r\nTRX = (VFL, MGF)\r\nHKG = (XHL, DBM)\r\nQGG = (QFD, LHP)\r\nTDH = (SSC, RHQ)\r\nCHH = (JGJ, LTN)\r\nQVV = (VFB, GRF)\r\nKGX = (XGP, LFQ)\r\nNQF = (QVV, GNK)\r\nXVV = (DMX, JDC)\r\nVRJ = (JSL, RVK)\r\nLKH = (JCG, RCD)\r\nRQL = (KHQ, MPQ)\r\nMLN = (HXG, GXS)\r\nSVH = (XVV, KVH)\r\nPVG = (LMM, LPT)\r\nHBF = (TXD, JFS)\r\nFXZ = (JBB, HPC)\r\nTRS = (XLP, HFM)\r\nRKQ = (KHV, KGN)\r\nSXG = (GVS, RBB)\r\nLTL = (VNM, CVM)\r\nKCR = (THX, VBG)";
            //InputData = "";   // Exemple donné pour debug
            #endregion

            InitInputData(InputData);

            InitialisationInstructions(Lines[0]);

            Lines.RemoveAt(0);
            Lines.RemoveAt(0);

            Dictionary<string, Tuple<string, string>> Noeuds = new Dictionary<string, Tuple<string, string>>();
            foreach (string ligne in Lines)
            {
                InitialisationLigne(ligne, Noeuds);
            }

            InitialisationReseau(Noeuds);

            if (this.Debug)
            {
                DebugInit();
            }
        }
        #endregion

        #region Initialisation
        /// <summary>
        /// Initialisation des données de travail pour une ligne.
        /// </summary>
        /// <param name="ligne">Données de la ligne d'entrée</param>
        private void InitialisationLigne(string ligne, Dictionary<string, Tuple<string, string>> Noeuds)
        {
            var Split = ligne.Split('=').Select(s=>s.Trim()).ToList();

            Noeuds.Add(Split[0], new Tuple<string, string>(Split[1].Substring(1,3), Split[1].Substring(6,3)));
        }

        /// <summary>
        /// Initialisation des données de travail pour une ligne.
        /// </summary>
        /// <param name="ligne">Données de la ligne d'entrée</param>
        private void InitialisationInstructions(string ligne)
        {
            foreach(char c in ligne)
            {
                Instructions.Add(c == 'L' ? Instruction.Gauche : Instruction.Droite);
            }
            if (Debug)
            {
                Console.WriteLine("Instructions : " + (string.Join("", Instructions.Select(i => i == Instruction.Gauche ? "L" : "R")).Equals(ligne) ? "OK" : "Erreur"));
                Console.WriteLine(Instructions.Count);
                Console.WriteLine();
            }
        }

        private void InitialisationReseau(Dictionary<string, Tuple<string, string>> Noeuds)
        {
            Reseau = new Network(Noeuds);
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

            Node StartNode = Reseau.NetworkByInstructions(Instructions).NoeudDepart;
            do
            {
                StartNode = StartNode.NextNodes[0];
                nb++;
            }
            while (!StartNode.isZZZ);

            return nb * this.Instructions.Count;
        }

        /// <summary>
        /// On évalue pour chaque noeud de départ les cycles(pattern) dans le déroulé des instructions.
        /// On fusionne ensuite les cycles entre eux deux à deux, jusqu'à ce que l'on obtienne un seul cycle.
        /// On renvoie alors le nombre total de jeux d'instructions complets joués, pondéré par le nombre de pas dans les instructions
        /// </summary>
        /// <returns>Le nombre de pas pour que tous les fantômes arrivent à destination</returns>
        private long ProcessPart2()
        {
            var cycles = Reseau.NetworkByInstructions(Instructions).NoeudsDepartGhost.Select(n => n.GetCycle()).ToList();

            if (Debug)
            {
                Console.WriteLine(string.Join("\r\n", cycles.Select(c => c.Raison + "x + " + c.Offset)));
                Console.WriteLine("");
            }

            while(cycles.Count > 1)
            {
                List<Cycle> cycles1 = cycles.ToList();
                cycles.Clear();
                for(int i = 0; i < cycles1.Count - 1; i+=2)
                {
                    Cycle c = cycles1[i];
                    Cycle d = cycles1[i+1];

                    Cycle merged = c.MergeWith(d);
                    
                    cycles.Add(merged);


                    if (Debug)
                    {
                        Console.WriteLine(c.Raison + "x + " + c.Offset);
                        Console.WriteLine(d.Raison + "x + " + d.Offset);
                        Console.WriteLine(merged.Raison + "x + " + merged.Offset);
                        Console.WriteLine("");
                    }
                }
                if(cycles1.Count % 2 == 1)
                {
                    cycles.Add(cycles1.Last());
                }
            }

            
            return cycles.Max(c => c.NombreTotal) * this.Instructions.Count;
        }
        #endregion

        #region Debug
        private void DebugInit()
        {
            foreach(var n in Reseau)
            {
                Console.WriteLine(n.ToString());
            }
            Console.WriteLine("");
        }
        #endregion

        #region Classes de travail
        private class Cycle
        {
            public long Offset { get; set; }
            public long Multiplicateur { get; set; } = 0;
            public long NombreTotal { get { return Offset + (Multiplicateur * Raison); } }
            public long Raison { get; set; }
            private Cycle(){}

            /// <summary>
            /// On part du principe que le noeud fourni en paramètre est déjà aggrégé par jeu d'instructions
            /// </summary>
            /// <param name="n">Noeud de départ de la suite</param>
            public Cycle(Node n)
            {
                Dictionary<Node, long> noeudsLus = new Dictionary<Node, long>();
                List<long> cyclesToZ = new List<long>();
                Node curr = n;
                long i = 0;
                bool boucle = true;
                do
                {
                    if (curr.endsWithZ)
                    {
                        cyclesToZ.Add(i);
                        if (noeudsLus.TryGetValue(curr, out long rang))
                        {
                            Offset = rang;
                            cyclesToZ.RemoveAll(c => c <= rang);
                            cyclesToZ.ForEach(c => c -= rang);
                            boucle = false;
                        }
                        else
                        {
                            noeudsLus.Add(curr, i);
                        }
                    }

                    curr = curr.NextNodes[0];
                    i++;
                } while (boucle);

                this.Raison = cyclesToZ.First();
            }

            /// <summary>
            /// On recherche le premier nombre entier commun aux deux suites, et on l'enregistre en tant que décalage de départ.
            /// On recherche ensuite le suivant, et on l'enregistre comme raison du cycle.
            /// </summary>
            /// <param name="other">Cycle à fusionner avec le cycle courant</param>
            /// <returns>Un nouveau cycle résultant de la fusion du cycle actuel et du cycle en paramètre</returns>
            public Cycle MergeWith(Cycle other)
            {
                List<Cycle> cycles = new List<Cycle>() { this, other };
                Cycle res = new Cycle();

                long max = cycles.Max(c => c.NombreTotal);
                long diviseur = cycles[1].NombreTotal;

                while (cycles[0].NombreTotal % diviseur != 0)
                    cycles[0].Multiplicateur++;

                res.Offset = cycles[0].NombreTotal;
                cycles[0].Multiplicateur++;
                while (cycles[0].NombreTotal % diviseur != 0)
                    cycles[0].Multiplicateur++;

                res.Raison = cycles[0].NombreTotal;

                res.Multiplicateur = 0;


                return res;
            }
        }
        private class Node
        {
            public string Name { get; set; }
            public bool isZZZ { get; set; } = false;
            public bool endsWithA { get; set; } = false;
            public bool endsWithZ { get; set; } = false;
            public Node[] NextNodes { get; set; } = new Node[2] {null, null};
            public Node FollowInstructions(List<Instruction> instructions, int index)
            {
                Node next = this.NextNodes[(int)instructions[index]];
                if (index == instructions.Count - 1)
                    return next;
                return next.FollowInstructions(instructions, index+1);
            }
            public Cycle GetCycle()
            {
                return new Cycle(this);
            }
            public override string ToString()
            {
                return $"{this.Name} = ({NextNodes[0].Name}, {NextNodes[1].Name})";
            }
        }
        private class Network : List<Node>
        {
            public Node NoeudDepart { get;}
            public List<Node> NoeudsDepartGhost { get;}
            public Network(Dictionary<string, Tuple<string, string>> data)
            {
                Dictionary<string, Node> Noeuds = new Dictionary<string, Node>();
                foreach (var item in data.Keys)
                {
                    Node noeud = new Node() 
                    {
                        Name = item, 
                        isZZZ = item.Equals("ZZZ"),
                        endsWithA = item.EndsWith("A"),
                        endsWithZ = item.EndsWith("Z")
                    };
                    this.Add(noeud);
                    Noeuds.Add(item, noeud);
                }
                foreach(var Noeud in this)
                {
                    Noeud.NextNodes[0] = Noeuds[data[Noeud.Name].Item1];
                    Noeud.NextNodes[1] = Noeuds[data[Noeud.Name].Item2];
                }
                NoeudsDepartGhost = this.Where(n=>n.endsWithA).ToList();
                this.NoeudDepart = Noeuds["AAA"];
            }
            public Network NetworkByInstructions(List<Instruction> instructions)
            {
                Dictionary < string, Tuple<string, string>> data = new Dictionary<string, Tuple<string, string>>();
                foreach (var Noeud in this)
                {
                    Node n = Noeud.FollowInstructions(instructions, 0);
                    data.Add(Noeud.Name, new Tuple<string, string>(n.Name, n.Name));
                }
                Network Res = new Network(data);
                return Res;
            }
        }
        #endregion
    }
}
