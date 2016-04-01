using System;
using DRPTranslatorCS.Symbols;
using System.Collections.Generic;
namespace DRPTranslatorCS
{
    /// <summary>
    /// This class contains several matcher methods which convert characters into their matching DNA or RNA bases
    /// </summary>
    class GeneticMatcher
    {
        /// <summary>
        /// Given a Character representing a RNA Base, the function will return the matching RNA Base
        /// 'A' -> RNA.A
        /// </summary>
        /// <param name="b">Character representing a RNA Base</param>
        /// <returns>RNA Base</returns>
        public static RNA  matchRnaB(char b)
        {
            switch(b)
            {
                case 'A':
                    return RNA.A;
                case 'C':
                    return RNA.C;
                case 'U':
                    return RNA.U;
                case 'G':
                    return RNA.G;
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Given a RNA Base, the function will convert it to it's matching RNA character representation
        /// RNA.A -> 'A'
        /// </summary>
        /// <param name="b">RNA Base</param>
        /// <returns>Character Representing a RNA Base</returns>
        public static char matchRnaB(RNA b)
        {
            switch (b)
            {
                case RNA.A:
                    return 'A';
                case RNA.C:
                    return 'C';
                case RNA.U:
                    return 'U';
                case RNA.G:
                    return 'G';
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Given a character representing a RNA base, the function will return the oposite RNA base.
        /// 'A' -> RNA.U
        /// </summary>
        /// <param name="b">Character Representing a RNA Base</param>
        /// <returns>RNA Base</returns>
        public static RNA matchOpositeRnaB(char b)
        {
            switch (b)
            {
                case 'A':
                    return RNA.U;
                case 'C':
                    return RNA.G;
                case 'U':
                    return RNA.A;
                case 'G':
                    return RNA.C;
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Given a RNA Base, the function will convert it to it's oposite RNA character representation
        /// RNA.A -> 'U'
        /// </summary>
        /// <param name="b">RNA Base</param>
        /// <returns>Character Representing a RNA Base</returns>
        public static char matchOpositeRnaB(RNA b)
        {
            switch (b)
            {
                case RNA.A:
                    return 'U';
                case RNA.C:
                    return 'G';
                case RNA.U:
                    return 'A';
                case RNA.G:
                    return 'C';
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Given a Character representing a DNA Base, the function will return the matching DNA Base
        /// 'A' -> DNA.A
        /// </summary>
        /// <param name="b">Character representing a DNA Base</param>
        /// <returns>DNA Base</returns>
        public static DNA matchDnaB(char b)
        {
            switch (b)
            {
                case 'A':
                    return DNA.A;
                case 'C':  
                    return DNA.C;
                case 'T':  
                    return DNA.T;
                case 'G':  
                    return DNA.G;
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Given a DNA Base, the function will convert it to it's matching DNA character representation
        /// DNA.A -> 'A'
        /// </summary>
        /// <param name="b">DNA Base</param>
        /// <returns>Character Representing a DNA Base</returns>
        public static char matchDnaB(DNA b)
        {
            switch (b)
            {
                case DNA.A:
                    return 'A';
                case DNA.C:
                    return 'C';
                case DNA.T:
                    return 'T';
                case DNA.G:
                    return 'G';
                default:
                    throw new NotImplementedException();
            }
        }


        /// <summary>
        /// Given a character representing a DNA base, the function will return the oposite DNA base.
        /// 'A' -> DNA.T
        /// </summary>
        /// <param name="b">Character Representing a DNA Base</param>
        /// <returns>RNA Base</returns>
        public static DNA matchOpositeDnaB(char b)
        {
            switch (b)
            {
                case 'A':
                    return DNA.T;
                case 'C':
                    return DNA.G;
                case 'T':
                    return DNA.A;
                case 'G':
                    return DNA.C;
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Given a DNA Base, the function will convert it to it's matching DNA character representation
        /// DNA.A -> 'T'
        /// </summary>
        /// <param name="b">DNA Base</param>
        /// <returns>Character Representing a DNA Base</returns>
        public static char matchOpositeDnaB(DNA b)
        {
            switch (b)
            {
                case DNA.A:
                    return 'T';
                case DNA.C:
                    return 'G';
                case DNA.T:
                    return 'A';
                case DNA.G:
                    return 'C';
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Given an aminoacid, the function will return it's matching codon representing string
        /// AA.ALA -> "ALA"
        /// </summary>
        /// <param name="amino">Aminoacid to match</param>
        /// <returns>String representing an aminoacid</returns>
        public static string matchAAStr(AA amino)
        {
            string aa = "";
            switch (amino)
            {
                case AA.ALA:
                    aa = "ALA";
                    break;
                case AA.ARG:
                    aa = "ARG";
                    break;
                case AA.ASN:
                    aa = "ASN";
                    break;
                case AA.ASP:
                    aa = "ASP";
                    break;
                case AA.CYS:
                    aa = "CYS";
                    break;
                case AA.GLN:
                    aa = "GLN";
                    break;
                case AA.GLU:
                    aa = "GLU";
                    break;
                case AA.GLY:
                    aa = "GLY";
                    break;
                case AA.HIS:
                    aa = "HIS";
                    break;
                case AA.LEU:
                    aa = "LEU";
                    break;
                case AA.LYS:
                    aa = "LYS";
                    break;
                case AA.MET:
                    aa = "MET";
                    break;
                case AA.PHE:
                    aa = "PHE";
                    break;
                case AA.PRO:
                    aa = "PRO";
                    break;
                case AA.SER:
                    aa = "SER";
                    break;
                case AA.THR:
                    aa = "THR";
                    break;
                case AA.TRP:
                    aa = "TRP";
                    break;
                case AA.TYR:
                    aa = "TYR";
                    break;
                case AA.VAL:
                    aa = "VAL";
                    break;
                case AA.ILE:
                    aa = "ILE";
                    break;
                case AA.STOP:
                    aa = "STOP";
                    break;
                default:
                    throw new ArgumentException();
            }
            return aa;
        }

        /// <summary>
        /// Given a string representing an aminoacid, the function will return it's matching aminoacid enum
        /// "ALA" -> AA.ALA
        /// </summary>
        /// <param name="codon"></param>
        /// <returns></returns>
        public static AA matchStrAA(string amino)
        {
            AA aa;
            switch (amino)
            {
                case "ALA":
                    aa = AA.ALA;
                    break;
                case "ARG":
                    aa = AA.ARG;
                    break;
                case "ASN":
                    aa = AA.ASN;
                    break;
                case "ASP":
                    aa = AA.ASP;
                    break;
                case "CYS":
                    aa = AA.CYS;
                    break;
                case "GLN":
                    aa = AA.GLN;
                    break;
                case "GLU":
                    aa = AA.GLU;
                    break;
                case "GLY":
                    aa = AA.GLY;
                    break;
                case "HIS":
                    aa = AA.HIS;
                    break;
                case "LEU":
                    aa = AA.LEU;
                    break;
                case "LYS":
                    aa = AA.LYS;
                    break;
                case "MET":
                    aa = AA.MET;
                    break;
                case "PHE":
                    aa = AA.PHE;
                    break;
                case "PRO":
                    aa = AA.PRO;
                    break;
                case "SER":
                    aa = AA.SER;
                    break;
                case "THR":
                    aa = AA.THR;
                    break;
                case "TRP":
                    aa = AA.TRP;
                    break;
                case "TYR":
                    aa = AA.TYR;
                    break;
                case "VAL":
                    aa = AA.VAL;
                    break;
                case "ILE":
                    aa = AA.ILE;
                    break;
                case "STOP":
                    aa = AA.STOP;
                    break;
                default:
                    throw new ArgumentException();
            }
            return aa;
        }
        /// <summary>
        /// Given an aminoacid, the function will make a dictionary in which will include
        /// the Aminoacid and  a list containing all the possible dna codons that can form it.
        /// </summary>
        /// <param name="amino"></param>
        /// <returns></returns>
        public static Dictionary<AA, List<DnaCodon>> matchAminoDna(AA amino)
        {
            Dictionary<AA, List<DnaCodon>> aminoDic = new Dictionary<AA, List<DnaCodon>>();
            List<DnaCodon> codList = new List<DnaCodon>();
            switch (amino)
            {
                case AA.ALA: // 4 CODONS
                    codList.Add(new DnaCodon(DNA.G, DNA.C, DNA.T));
                    codList.Add(new DnaCodon(DNA.G, DNA.C, DNA.C));
                    codList.Add(new DnaCodon(DNA.G, DNA.C, DNA.A));
                    codList.Add(new DnaCodon(DNA.G, DNA.C, DNA.G));
                    aminoDic.Add(AA.ALA, codList);
                    break;
                case AA.ARG: // 6 CODONS
                    codList.Add(new DnaCodon(DNA.C, DNA.G, DNA.T));
                    codList.Add(new DnaCodon(DNA.C, DNA.G, DNA.C));
                    codList.Add(new DnaCodon(DNA.C, DNA.G, DNA.A));
                    codList.Add(new DnaCodon(DNA.C, DNA.G, DNA.G));
                    codList.Add(new DnaCodon(DNA.A, DNA.G, DNA.A));
                    codList.Add(new DnaCodon(DNA.A, DNA.G, DNA.G));
                    aminoDic.Add(AA.ARG, codList);
                    break;
                case AA.ASN: // 2 CODONS
                    codList.Add(new DnaCodon(DNA.A, DNA.A, DNA.T));
                    codList.Add(new DnaCodon(DNA.A, DNA.A, DNA.C));
                    aminoDic.Add(AA.ASN, codList);
                    break;
                case AA.ASP: // 2 CODONS
                    codList.Add(new DnaCodon(DNA.G, DNA.A, DNA.T));
                    codList.Add(new DnaCodon(DNA.G, DNA.A, DNA.C));
                    aminoDic.Add(AA.ASP, codList);
                    break;
                case AA.CYS: // 2 CODONS
                    codList.Add(new DnaCodon(DNA.T, DNA.G, DNA.T));
                    codList.Add(new DnaCodon(DNA.T, DNA.G, DNA.C));
                    aminoDic.Add(AA.ASP, codList);
                    break;
                case AA.GLN: // 2 CODONS
                    codList.Add(new DnaCodon(DNA.T, DNA.G, DNA.T));
                    codList.Add(new DnaCodon(DNA.T, DNA.G, DNA.C));
                    aminoDic.Add(AA.ASP, codList);
                    break;
                case AA.GLU: // 2 CODONS
                    codList.Add(new DnaCodon(DNA.G, DNA.A, DNA.A));
                    codList.Add(new DnaCodon(DNA.G, DNA.A, DNA.G));
                    aminoDic.Add(AA.GLU, codList);
                    break;
                case AA.GLY: // 4 CODONS
                    codList.Add(new DnaCodon(DNA.G, DNA.G, DNA.T));
                    codList.Add(new DnaCodon(DNA.G, DNA.G, DNA.C));
                    codList.Add(new DnaCodon(DNA.G, DNA.G, DNA.A));
                    codList.Add(new DnaCodon(DNA.G, DNA.G, DNA.G));
                    aminoDic.Add(AA.GLY, codList);
                    break;
                case AA.HIS: // 2 CODONS
                    codList.Add(new DnaCodon(DNA.C, DNA.A, DNA.T));
                    codList.Add(new DnaCodon(DNA.C, DNA.A, DNA.C));
                    aminoDic.Add(AA.HIS, codList);
                    break;
                case AA.LEU: // 6 CODONS
                    codList.Add(new DnaCodon(DNA.T, DNA.T, DNA.A));
                    codList.Add(new DnaCodon(DNA.T, DNA.T, DNA.G));
                    codList.Add(new DnaCodon(DNA.C, DNA.T, DNA.T));
                    codList.Add(new DnaCodon(DNA.C, DNA.T, DNA.C));
                    codList.Add(new DnaCodon(DNA.C, DNA.T, DNA.A));
                    codList.Add(new DnaCodon(DNA.C, DNA.T, DNA.G));
                    aminoDic.Add(AA.LEU, codList);
                    break;
                case AA.LYS: // 2 CODONS
                    codList.Add(new DnaCodon(DNA.A, DNA.A, DNA.A));
                    codList.Add(new DnaCodon(DNA.A, DNA.A, DNA.G));
                    aminoDic.Add(AA.LYS, codList);
                    break;
                case AA.MET: //  1 CODON
                    codList.Add(new DnaCodon(DNA.A, DNA.T, DNA.G));
                    aminoDic.Add(AA.MET, codList);
                    break;
                case AA.PHE: // 2 CODONS
                    codList.Add(new DnaCodon(DNA.T, DNA.T, DNA.T));
                    codList.Add(new DnaCodon(DNA.T, DNA.T, DNA.C));
                    aminoDic.Add(AA.PHE, codList);
                    break;
                case AA.PRO: // 4 CODONS
                    codList.Add(new DnaCodon(DNA.C, DNA.C, DNA.T));
                    codList.Add(new DnaCodon(DNA.C, DNA.C, DNA.C));
                    codList.Add(new DnaCodon(DNA.C, DNA.C, DNA.A));
                    codList.Add(new DnaCodon(DNA.C, DNA.C, DNA.G));
                    aminoDic.Add(AA.PRO, codList);
                    break;
                case AA.SER: // 6 CODONS
                    codList.Add(new DnaCodon(DNA.T, DNA.C, DNA.T));
                    codList.Add(new DnaCodon(DNA.T, DNA.C, DNA.C));
                    codList.Add(new DnaCodon(DNA.T, DNA.C, DNA.A));
                    codList.Add(new DnaCodon(DNA.T, DNA.C, DNA.G));
                    codList.Add(new DnaCodon(DNA.A, DNA.G, DNA.T));
                    codList.Add(new DnaCodon(DNA.A, DNA.G, DNA.C));
                    aminoDic.Add(AA.SER, codList);
                    break;
                case AA.THR: // 4 CODONS
                    codList.Add(new DnaCodon(DNA.C, DNA.C, DNA.T));
                    codList.Add(new DnaCodon(DNA.C, DNA.C, DNA.C));
                    codList.Add(new DnaCodon(DNA.C, DNA.C, DNA.A));
                    codList.Add(new DnaCodon(DNA.C, DNA.C, DNA.G));
                    aminoDic.Add(AA.PRO, codList);
                    break;
                case AA.TRP: // 1 CODON
                    codList.Add(new DnaCodon(DNA.T, DNA.G, DNA.G));
                    aminoDic.Add(AA.TRP, codList);
                    break;
                case AA.TYR: // 2 CODONS
                    codList.Add(new DnaCodon(DNA.T, DNA.A, DNA.T));
                    codList.Add(new DnaCodon(DNA.T, DNA.A, DNA.C));
                    aminoDic.Add(AA.TYR, codList);
                    break;
                case AA.VAL: // 4 CODONS
                    codList.Add(new DnaCodon(DNA.G, DNA.T, DNA.T));
                    codList.Add(new DnaCodon(DNA.G, DNA.T, DNA.C));
                    codList.Add(new DnaCodon(DNA.G, DNA.T, DNA.A));
                    codList.Add(new DnaCodon(DNA.G, DNA.T, DNA.G));
                    aminoDic.Add(AA.VAL, codList);
                    break;
                case AA.ILE: // 3 CODONS
                    codList.Add(new DnaCodon(DNA.A, DNA.T, DNA.T));
                    codList.Add(new DnaCodon(DNA.A, DNA.T, DNA.C));
                    codList.Add(new DnaCodon(DNA.A, DNA.T, DNA.A));
                    aminoDic.Add(AA.ILE, codList);
                    break;
                case AA.STOP: // 3 CODONS
                    codList.Add(new DnaCodon(DNA.T, DNA.A, DNA.A));
                    codList.Add(new DnaCodon(DNA.T, DNA.A, DNA.G));
                    codList.Add(new DnaCodon(DNA.T, DNA.G, DNA.A));
                    aminoDic.Add(AA.STOP, codList);
                    break;
                default:
                    throw new ArgumentException();
            }
            return aminoDic;
        }

        /// <summary>
        /// Given an aminoacid, the function will make a dictionary in which will include
        /// the Aminoacid and  a list containing all the possible RNA codons that can form it.
        /// </summary>
        /// <param name="amino"></param>
        /// <returns></returns>
        public static Dictionary<AA,List<RnaCodon>> matchAminoRna(AA amino)
        {
            Dictionary<AA, List<RnaCodon>> aminoDic = new Dictionary<AA, List<RnaCodon>>();
            List<RnaCodon> codList = new List<RnaCodon>();
            switch (amino)
            {
                case AA.ALA: // 4 CODONS
                    codList.Add(new RnaCodon(RNA.G, RNA.C, RNA.U));
                    codList.Add(new RnaCodon(RNA.G, RNA.C, RNA.C));
                    codList.Add(new RnaCodon(RNA.G, RNA.C, RNA.A));
                    codList.Add(new RnaCodon(RNA.G, RNA.C, RNA.G));
                    aminoDic.Add(AA.ALA, codList);
                    break;
                case AA.ARG: // 6 CODONS
                    codList.Add(new RnaCodon(RNA.C, RNA.G, RNA.U));
                    codList.Add(new RnaCodon(RNA.C, RNA.G, RNA.C));
                    codList.Add(new RnaCodon(RNA.C, RNA.G, RNA.A));
                    codList.Add(new RnaCodon(RNA.C, RNA.G, RNA.G));
                    codList.Add(new RnaCodon(RNA.A, RNA.G, RNA.A));
                    codList.Add(new RnaCodon(RNA.A, RNA.G, RNA.G));
                    aminoDic.Add(AA.ARG, codList);
                    break;
                case AA.ASN: // 2 CODONS
                    codList.Add(new RnaCodon(RNA.A, RNA.A, RNA.U));
                    codList.Add(new RnaCodon(RNA.A, RNA.A, RNA.C));
                    aminoDic.Add(AA.ASN, codList);
                    break;
                case AA.ASP: // 2 CODONS
                    codList.Add(new RnaCodon(RNA.G, RNA.A, RNA.U));
                    codList.Add(new RnaCodon(RNA.G, RNA.A, RNA.C));
                    aminoDic.Add(AA.ASP, codList);
                    break;
                case AA.CYS: // 2 CODONS
                    codList.Add(new RnaCodon(RNA.U, RNA.G, RNA.U));
                    codList.Add(new RnaCodon(RNA.U, RNA.G, RNA.C));
                    aminoDic.Add(AA.ASP, codList);
                    break;
                case AA.GLN: // 2 CODONS
                    codList.Add(new RnaCodon(RNA.U, RNA.G, RNA.U));
                    codList.Add(new RnaCodon(RNA.U, RNA.G, RNA.C));
                    aminoDic.Add(AA.ASP, codList);
                    break;
                case AA.GLU: // 2 CODONS
                    codList.Add(new RnaCodon(RNA.G, RNA.A, RNA.A));
                    codList.Add(new RnaCodon(RNA.G, RNA.A, RNA.G));
                    aminoDic.Add(AA.GLU, codList);
                    break;
                case AA.GLY: // 4 CODONS
                    codList.Add(new RnaCodon(RNA.G, RNA.G, RNA.U));
                    codList.Add(new RnaCodon(RNA.G, RNA.G, RNA.C));
                    codList.Add(new RnaCodon(RNA.G, RNA.G, RNA.A));
                    codList.Add(new RnaCodon(RNA.G, RNA.G, RNA.G));
                    aminoDic.Add(AA.GLY, codList);
                    break;
                case AA.HIS: // 2 CODONS
                    codList.Add(new RnaCodon(RNA.C, RNA.A, RNA.U));
                    codList.Add(new RnaCodon(RNA.C, RNA.A, RNA.C));
                    aminoDic.Add(AA.HIS, codList);
                    break;
                case AA.LEU: // 6 CODONS
                    codList.Add(new RnaCodon(RNA.U, RNA.U, RNA.A));
                    codList.Add(new RnaCodon(RNA.U, RNA.U, RNA.G));
                    codList.Add(new RnaCodon(RNA.C, RNA.U, RNA.U));
                    codList.Add(new RnaCodon(RNA.C, RNA.U, RNA.C));
                    codList.Add(new RnaCodon(RNA.C, RNA.U, RNA.A));
                    codList.Add(new RnaCodon(RNA.C, RNA.U, RNA.G));
                    aminoDic.Add(AA.LEU, codList);
                    break;
                case AA.LYS: // 2 CODONS
                    codList.Add(new RnaCodon(RNA.A, RNA.A, RNA.A));
                    codList.Add(new RnaCodon(RNA.A, RNA.A, RNA.G));
                    aminoDic.Add(AA.LYS, codList);
                    break;
                case AA.MET: //  1 CODON
                    codList.Add(new RnaCodon(RNA.A, RNA.U, RNA.G));
                    aminoDic.Add(AA.MET, codList);
                    break;
                case AA.PHE: // 2 CODONS
                    codList.Add(new RnaCodon(RNA.U, RNA.U, RNA.U));
                    codList.Add(new RnaCodon(RNA.U, RNA.U, RNA.C));
                    aminoDic.Add(AA.PHE, codList);
                    break;
                case AA.PRO: // 4 CODONS
                    codList.Add(new RnaCodon(RNA.C, RNA.C, RNA.U));
                    codList.Add(new RnaCodon(RNA.C, RNA.C, RNA.C));
                    codList.Add(new RnaCodon(RNA.C, RNA.C, RNA.A));
                    codList.Add(new RnaCodon(RNA.C, RNA.C, RNA.G));
                    aminoDic.Add(AA.PRO, codList);
                    break;
                case AA.SER: // 6 CODONS
                    codList.Add(new RnaCodon(RNA.U, RNA.C, RNA.U));
                    codList.Add(new RnaCodon(RNA.U, RNA.C, RNA.C));
                    codList.Add(new RnaCodon(RNA.U, RNA.C, RNA.A));
                    codList.Add(new RnaCodon(RNA.U, RNA.C, RNA.G));
                    codList.Add(new RnaCodon(RNA.A, RNA.G, RNA.U));
                    codList.Add(new RnaCodon(RNA.A, RNA.G, RNA.C));
                    aminoDic.Add(AA.SER, codList);
                    break;
                case AA.THR: // 4 CODONS
                    codList.Add(new RnaCodon(RNA.C, RNA.C, RNA.U));
                    codList.Add(new RnaCodon(RNA.C, RNA.C, RNA.C));
                    codList.Add(new RnaCodon(RNA.C, RNA.C, RNA.A));
                    codList.Add(new RnaCodon(RNA.C, RNA.C, RNA.G));
                    aminoDic.Add(AA.PRO, codList);
                    break;
                case AA.TRP: // 1 CODON
                    codList.Add(new RnaCodon(RNA.U, RNA.G, RNA.G));
                    aminoDic.Add(AA.TRP, codList);
                    break;
                case AA.TYR: // 2 CODONS
                    codList.Add(new RnaCodon(RNA.U, RNA.A, RNA.U));
                    codList.Add(new RnaCodon(RNA.U, RNA.A, RNA.C));
                    aminoDic.Add(AA.TYR, codList);
                    break;
                case AA.VAL: // 4 CODONS
                    codList.Add(new RnaCodon(RNA.G, RNA.U, RNA.U));
                    codList.Add(new RnaCodon(RNA.G, RNA.U, RNA.C));
                    codList.Add(new RnaCodon(RNA.G, RNA.U, RNA.A));
                    codList.Add(new RnaCodon(RNA.G, RNA.U, RNA.G));
                    aminoDic.Add(AA.VAL, codList);
                    break;
                case AA.ILE: // 3 CODONS
                    codList.Add(new RnaCodon(RNA.A, RNA.U, RNA.U));
                    codList.Add(new RnaCodon(RNA.A, RNA.U, RNA.C));
                    codList.Add(new RnaCodon(RNA.A, RNA.U, RNA.A));
                    aminoDic.Add(AA.ILE, codList);
                    break;
                case AA.STOP: // 3 CODONS
                    codList.Add(new RnaCodon(RNA.U, RNA.A, RNA.A));
                    codList.Add(new RnaCodon(RNA.U, RNA.A, RNA.G));
                    codList.Add(new RnaCodon(RNA.U, RNA.G, RNA.A));
                    aminoDic.Add(AA.STOP, codList);
                    break;
                default:
                    throw new ArgumentException();
            }
            return aminoDic;
        }


    }
}
