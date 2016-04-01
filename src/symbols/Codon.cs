using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DRPTranslatorCS.Symbols
{
    /// <summary>
    /// Struct that Holds methods which transform strings into Codon Lists or Codon Lists into Strings
    /// </summary>
    public struct Codon
    {

        /// <summary>
        /// Given a DNA sequence that it's length must be divisible by 3,
        /// the function will return a List of DNA Codons
        /// </summary>
        /// <param name="dnaSeq">DNA sequence string, it's length must be divisible by 3</param>
        /// <returns>A List of DnaCodon Structs</returns>
        public static List<DnaCodon> getDnaCodonList(string dnaSeq)
        {
            if (dnaSeq.Length % 3 != 0)
                throw new IndexOutOfRangeException();

            List<string> strCodons = (from Match m in Regex.Matches(dnaSeq, @"\.{3}") select m.Value).ToList();
            List<DnaCodon> dnaCodons = new List<DnaCodon>();
            foreach (string strCodon in strCodons)
            {
                DNA fp = GeneticMatcher.matchDnaB(strCodon[0]);
                DNA sp = GeneticMatcher.matchDnaB(strCodon[1]);
                DNA tp = GeneticMatcher.matchDnaB(strCodon[2]);
                dnaCodons.Add(new DnaCodon(fp, sp, tp));
            }
            return dnaCodons;
        }

        /// <summary>
        /// Given a RNA sequence that it's length must be divisible by 3,
        /// the function will return a List of RNA Codons
        /// </summary>
        /// <param name="rnaSeq">RNA sequence string, it's length must be divisible by 3</param>
        /// <returns>A List of RnaCodon Structs</returns>
        public static List<RnaCodon> getRnaCodonList(string rnaSeq)
        {
            if (rnaSeq.Length % 3 != 0)
                throw new IndexOutOfRangeException();

            List<string> strCodons = (from Match m in Regex.Matches(rnaSeq, @"\.{3}") select m.Value).ToList();
            List<RnaCodon> rnaCodons = new List<RnaCodon>();
            foreach (string strCodon in strCodons)
            {
                RNA fp = GeneticMatcher.matchRnaB(strCodon[0]);
                RNA sp = GeneticMatcher.matchRnaB(strCodon[1]);
                RNA tp = GeneticMatcher.matchRnaB(strCodon[2]);
                rnaCodons.Add(new RnaCodon(fp, sp, tp));
            }
            return rnaCodons;
        }

        /// <summary>
        /// Given a DnaCodon List, the function will concatenate all codons
        /// into a single string sequence of aminoacids
        /// ATCACT -> "MET-STOP"
        /// </summary>
        /// <param name="codons">List of DnaCodons</param>
        /// <returns>String containing an Aminoacid sequence</returns>
        public static string getDnaCodonSeqStr(List<DnaCodon> codons)
        {
            string codSeq = "";
            foreach (DnaCodon codon in codons)
            {
                if (codons.IndexOf(codon) == codons.Count - 1)
                {
                    codSeq += getDnaCodonStr(codon);
                }
                else
                {
                    codSeq += getDnaCodonStr(codon) + "-";
                }
            }
            return codSeq;
        }
        //TODO:Implement the usage of AA Enum, say having a DnaCodon || RnaCodon list, return a list of aminoacids

        /// <summary>
        /// Given a DnaCodon, the function will match the codon's genetic bases
        /// to it's aminoacid counterpart
        /// ATC -> MET
        /// </summary>
        /// <param name="codon">DnaCodon</param>
        /// <returns>String that represents the DNA Codon</returns>
        //TODO: Change all NotImplementedException
        public static string getDnaCodonStr(DnaCodon codon)
        {
            string aa = "";
            switch (codon.Fp)
            {
                case DNA.A:
                    switch (codon.Sp)
                    {
                        case DNA.A:
                            switch (codon.Tp)
                            {
                                case DNA.A: // AAA
                                    aa = "LYS";
                                    break;
                                case DNA.T: // AAT
                                    aa = "ASN";
                                    break;
                                case DNA.G: // AAG
                                    aa = "LYS";
                                    break;
                                case DNA.C: // AAC
                                    aa = "ASN";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.T:
                            switch (codon.Tp)
                            {
                                case DNA.A: // ATA
                                    aa = "ILE";
                                    break;
                                case DNA.T: // ATT
                                    aa = "ILE";
                                    break;
                                case DNA.G: // ATG
                                    aa = "MET";
                                    break;
                                case DNA.C: // ATC
                                    aa = "ILE";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.G:
                            switch (codon.Tp)
                            {
                                case DNA.A: // AGA
                                    aa = "ARG";
                                    break;
                                case DNA.T: // AGT
                                    aa = "SER";
                                    break;
                                case DNA.G: // AGG
                                    aa = "ARG";
                                    break;
                                case DNA.C: // AGC
                                    aa = "SER";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.C:
                            switch (codon.Tp)
                            {
                                case DNA.A: // ACA
                                    aa = "THR";
                                    break;
                                case DNA.T: // ACT
                                    aa = "THR";
                                    break;
                                case DNA.G: // ACG
                                    aa = "THR";
                                    break;
                                case DNA.C: // ACC
                                    aa = "THR";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        default:
                            throw new System.NotImplementedException();
                    }//second level
                    break;
                case DNA.T:
                    switch (codon.Sp)
                    {
                        case DNA.A:
                            switch (codon.Tp)
                            {
                                case DNA.A: // TAA
                                    aa = "STOP";
                                    break;
                                case DNA.T: // TAT
                                    aa = "TYR";
                                    break;
                                case DNA.G: // TAG
                                    aa = "STOP";
                                    break;
                                case DNA.C: // TAC
                                    aa = "TYR";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.T:
                            switch (codon.Tp)
                            {
                                case DNA.A: // TTA
                                    aa = "LEU";
                                    break;
                                case DNA.T: // TTT
                                    aa = "PHE";
                                    break;
                                case DNA.G: // TTG
                                    aa = "LEU";
                                    break;
                                case DNA.C: // TTC
                                    aa = "PHE";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.G:
                            switch (codon.Tp)
                            {
                                case DNA.A: // TGA
                                    aa = "STOP";
                                    break;
                                case DNA.T: // TGT
                                    aa = "CYS";
                                    break;
                                case DNA.G: // TGG
                                    aa = "Trp";
                                    break;
                                case DNA.C: // TGC
                                    aa = "CYS";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.C:
                            switch (codon.Tp)
                            {
                                case DNA.A: // TCA
                                    aa = "SER";
                                    break;
                                case DNA.T: // TCT
                                    aa = "SER";
                                    break;
                                case DNA.G: // TCG
                                    aa = "SER";
                                    break;
                                case DNA.C: // TCC
                                    aa = "SER";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        default:
                            throw new System.NotImplementedException();
                    }//second level
                    break;
                case DNA.G:
                    switch (codon.Sp)
                    {
                        case DNA.A:
                            switch (codon.Tp)
                            {
                                case DNA.A: // GAA
                                    aa = "GLU";
                                    break;
                                case DNA.T: // GAT
                                    aa = "ASP";
                                    break;
                                case DNA.G: // GAG
                                    aa = "GLU";
                                    break;
                                case DNA.C: // GAC
                                    aa = "ASP";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.T:
                            switch (codon.Tp)
                            {
                                case DNA.A: // GTA
                                    aa = "VAL";
                                    break;
                                case DNA.T: // GTT
                                    aa = "VAL";
                                    break;
                                case DNA.G: // GTG
                                    aa = "VAL";
                                    break;
                                case DNA.C: // GTC
                                    aa = "VAL";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.G:
                            switch (codon.Tp)
                            {
                                case DNA.A: // GGA
                                    aa = "GLY";
                                    break;
                                case DNA.T: // GGT
                                    aa = "GLY";
                                    break;
                                case DNA.G: // GGG
                                    aa = "GLY";
                                    break;
                                case DNA.C: // GGC
                                    aa = "GLY";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.C:
                            switch (codon.Tp)
                            {
                                case DNA.A: // GCA
                                    aa = "ALA";
                                    break;
                                case DNA.T: // GCT
                                    aa = "ALA";
                                    break;
                                case DNA.G: // GCG
                                    aa = "ALA";
                                    break;
                                case DNA.C: // GCC
                                    aa = "ALA";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        default:
                            throw new System.NotImplementedException();
                    }//second level
                    break;
                case DNA.C:
                    switch (codon.Sp)
                    {
                        case DNA.A:
                            switch (codon.Tp)
                            {
                                case DNA.A: // CAA
                                    aa = "GLN";
                                    break;
                                case DNA.T: // CAT
                                    aa = "HIS";
                                    break;
                                case DNA.G: // CAG
                                    aa = "GLN";
                                    break;
                                case DNA.C: // CAC
                                    aa = "HIS";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.T:
                            switch (codon.Tp)
                            {
                                case DNA.A: // CTA
                                    aa = "LEU";
                                    break;
                                case DNA.T: // CTT
                                    aa = "LEU";
                                    break;
                                case DNA.G: // CTG
                                    aa = "LEU";
                                    break;
                                case DNA.C: // CTC
                                    aa = "LEU";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.G:
                            switch (codon.Tp)
                            {
                                case DNA.A: // CGA
                                    aa = "ARG";
                                    break;
                                case DNA.T: // CGT
                                    aa = "ARG";
                                    break;
                                case DNA.G: // CGG
                                    aa = "ARG";
                                    break;
                                case DNA.C: // CGC
                                    aa = "ARG";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.C:
                            switch (codon.Tp)
                            {
                                case DNA.A: // CCA
                                    aa = "PRO";
                                    break;
                                case DNA.T: // CCT
                                    aa = "PRO";
                                    break;
                                case DNA.G: // CCG
                                    aa = "PRO";
                                    break;
                                case DNA.C: // CCC
                                    aa = "PRO";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        default:
                            throw new System.NotImplementedException();
                    }//second level
                    break;
                default:
                    throw new System.NotImplementedException();
            }//first level
            return aa;
        }

        /// <summary>
        /// Given a DNA Codon string, the function will return a new DnaCodon
        /// "ATG" -> MET
        /// </summary>
        /// <param name="codon">String representing a DNA Codon</param>
        /// <returns>DNA Codon</returns>
        public static DnaCodon getDnaCodon(string codon)
        {
            char[] charArr = codon.ToCharArray();
            List<DNA> rnaList = new List<DNA>();
            foreach (char b in charArr)
            {
                rnaList.Add(GeneticMatcher.matchDnaB(b));
            }
            return new DnaCodon(rnaList[0], rnaList[1], rnaList[2]);
        }

        /// <summary>
        /// Given a RnaCodon List, the function will concatenate all codons
        /// into a single string sequence of aminoacids
        /// AUGUAG -> "MET-STOP"
        /// </summary>
        /// <param name="codons">List of RnaCodons</param>
        /// <returns>String containing an Aminoacid sequence</returns>
        public static string getRnaCodonSeqStr(List<RnaCodon> codons)
        {
            string codSeq = "";
            foreach (RnaCodon codon in codons)
            {
                if (codons.IndexOf(codon) == codons.Count - 1)
                {
                    codSeq += getRnaCodonStr(codon);
                }
                else
                {
                    codSeq += getRnaCodonStr(codon) + "-";
                }
            }
            return codSeq;
        }

        /// <summary>
        /// Given a RnaCodon, the function will match the codon's genetic bases
        /// to it's aminoacid counterpart
        /// AUG -> MET
        /// </summary>
        /// <param name="codon">RnaCodon</param>
        /// <returns>String that represents the DNA Codon</returns>
        //TODO: Change all NotImplementedExceptions
        public static string getRnaCodonStr(RnaCodon codon)
        {
            string aa = "";
            switch (codon.Fp)
            {
                case RNA.A:
                    switch (codon.Sp)
                    {
                        case RNA.A:
                            switch (codon.Tp)
                            {
                                case RNA.A: // AAA
                                    aa = "LYS";
                                    break;
                                case RNA.U: // AAU
                                    aa = "ASN";
                                    break;
                                case RNA.G: // AAG
                                    aa = "LYS";
                                    break;
                                case RNA.C: // AAC
                                    aa = "ASN";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.U:
                            switch (codon.Tp)
                            {
                                case RNA.A: // AUA
                                    aa = "ILE";
                                    break;
                                case RNA.U: // AUU
                                    aa = "ILE";
                                    break;
                                case RNA.G: // AUG
                                    aa = "MET";
                                    break;
                                case RNA.C: // AUC
                                    aa = "ILE";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.G:
                            switch (codon.Tp)
                            {
                                case RNA.A: // AGA
                                    aa = "ARG";
                                    break;
                                case RNA.U: // AGU
                                    aa = "SER";
                                    break;
                                case RNA.G: // AGG
                                    aa = "ARG";
                                    break;
                                case RNA.C: // AGC
                                    aa = "SER";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.C:
                            switch (codon.Tp)
                            {
                                case RNA.A: // ACA
                                    aa = "THR";
                                    break;
                                case RNA.U: // ACU
                                    aa = "THR";
                                    break;
                                case RNA.G: // ACG
                                    aa = "THR";
                                    break;
                                case RNA.C: // ACC
                                    aa = "THR";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        default:
                            throw new System.NotImplementedException();
                    }//second level
                    break;
                case RNA.U:
                    switch (codon.Sp)
                    {
                        case RNA.A:
                            switch (codon.Tp)
                            {
                                case RNA.A: // UAA
                                    aa = "STOP";
                                    break;
                                case RNA.U: // UAU
                                    aa = "TYR";
                                    break;
                                case RNA.G: // UAG
                                    aa = "STOP";
                                    break;
                                case RNA.C: // UAC
                                    aa = "TYR";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.U:
                            switch (codon.Tp)
                            {
                                case RNA.A: // UUA
                                    aa = "LEU";
                                    break;
                                case RNA.U: // UUU
                                    aa = "PHE";
                                    break;
                                case RNA.G: // UUG
                                    aa = "LEU";
                                    break;
                                case RNA.C: // UUC
                                    aa = "PHE";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.G:
                            switch (codon.Tp)
                            {
                                case RNA.A: // UGA
                                    aa = "STOP";
                                    break;
                                case RNA.U: // UGU
                                    aa = "CYS";
                                    break;
                                case RNA.G: // UGG
                                    aa = "Trp";
                                    break;
                                case RNA.C: // UGC
                                    aa = "CYS";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.C:
                            switch (codon.Tp)
                            {
                                case RNA.A: // UCA
                                    aa = "SER";
                                    break;
                                case RNA.U: // UCU
                                    aa = "SER";
                                    break;
                                case RNA.G: // UCG
                                    aa = "SER";
                                    break;
                                case RNA.C: // UCC
                                    aa = "SER";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        default:
                            throw new System.NotImplementedException();
                    }//second level
                    break;
                case RNA.G:
                    switch (codon.Sp)
                    {
                        case RNA.A:
                            switch (codon.Tp)
                            {
                                case RNA.A: // GAA
                                    aa = "GLU";
                                    break;
                                case RNA.U: // GAU
                                    aa = "ASP";
                                    break;
                                case RNA.G: // GAG
                                    aa = "GLU";
                                    break;
                                case RNA.C: // GAC
                                    aa = "ASP";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.U:
                            switch (codon.Tp)
                            {
                                case RNA.A: // GUA
                                    aa = "VAL";
                                    break;
                                case RNA.U: // GUU
                                    aa = "VAL";
                                    break;
                                case RNA.G: // GUG
                                    aa = "VAL";
                                    break;
                                case RNA.C: // GUC
                                    aa = "VAL";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.G:
                            switch (codon.Tp)
                            {
                                case RNA.A: // GGA
                                    aa = "GLY";
                                    break;
                                case RNA.U: // GGU
                                    aa = "GLY";
                                    break;
                                case RNA.G: // GGG
                                    aa = "GLY";
                                    break;
                                case RNA.C: // GGC
                                    aa = "GLY";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.C:
                            switch (codon.Tp)
                            {
                                case RNA.A: // GCA
                                    aa = "ALA";
                                    break;
                                case RNA.U: // GCU
                                    aa = "ALA";
                                    break;
                                case RNA.G: // GCG
                                    aa = "ALA";
                                    break;
                                case RNA.C: // GCC
                                    aa = "ALA";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        default:
                            throw new System.NotImplementedException();
                    }//second level
                    break;
                case RNA.C:
                    switch (codon.Sp)
                    {
                        case RNA.A:
                            switch (codon.Tp)
                            {
                                case RNA.A: // CAA
                                    aa = "GLN";
                                    break;
                                case RNA.U: // CAU
                                    aa = "HIS";
                                    break;
                                case RNA.G: // CAG
                                    aa = "GLN";
                                    break;
                                case RNA.C: // CAC
                                    aa = "HIS";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.U:
                            switch (codon.Tp)
                            {
                                case RNA.A: // CUA
                                    aa = "LEU";
                                    break;
                                case RNA.U: // CUU
                                    aa = "LEU";
                                    break;
                                case RNA.G: // CUG
                                    aa = "LEU";
                                    break;
                                case RNA.C: // CUC
                                    aa = "LEU";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.G:
                            switch (codon.Tp)
                            {
                                case RNA.A: // CGA
                                    aa = "ARG";
                                    break;
                                case RNA.U: // CGU
                                    aa = "ARG";
                                    break;
                                case RNA.G: // CGG
                                    aa = "ARG";
                                    break;
                                case RNA.C: // CGC
                                    aa = "ARG";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.C:
                            switch (codon.Tp)
                            {
                                case RNA.A: // CCA
                                    aa = "PRO";
                                    break;
                                case RNA.U: // CCU
                                    aa = "PRO";
                                    break;
                                case RNA.G: // CCG
                                    aa = "PRO";
                                    break;
                                case RNA.C: // CCC
                                    aa = "PRO";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        default:
                            throw new System.NotImplementedException();
                    }//second level
                    break;
                default:
                    throw new System.NotImplementedException();
            }//first level
            return aa;
        }

        /// <summary>
        /// Given a RNA Codon string, the function will return a new DnaCodon
        /// "AUG" -> MET
        /// </summary>
        /// <param name="codon">String representing a DNA Codon</param>
        /// <returns>DNA Codon</returns>
        public static RnaCodon getRnaCodon(string codon)
        {
            char[] charArr = codon.ToCharArray();
            List<RNA> rnaList = new List<RNA>();
            foreach (char b in charArr)
            {
                rnaList.Add(GeneticMatcher.matchRnaB(b));
            }
            var cod = new RnaCodon(rnaList[0], rnaList[1], rnaList[2]);
            return cod;
        }
    }

    //TODO: Codon -> AA methods

    /// <summary>
    /// Struct representing a DNA Codon
    /// </summary>
    public struct DnaCodon
    {
        DNA _fp;
        DNA _sp;
        DNA _tp;

        public DnaCodon(DNA _fp, DNA _sp, DNA _tp)
        {
            this._fp = _fp;
            this._sp = _sp;
            this._tp = _tp;
        }

        public DNA Fp
        {
            get
            {
                return _fp;
            }

            set
            {
                _fp = value;
            }
        }

        public DNA Sp
        {
            get
            {
                return _sp;
            }

            set
            {
                _sp = value;
            }
        }

        public DNA Tp
        {
            get
            {
                return _tp;
            }

            set
            {
                _tp = value;
            }
        }

        public AA toAmino()
        {
            throw new NotImplementedException();
        }

    }

    /// <summary>
    /// Struct Representing a RNA Codon
    /// </summary>
    public struct RnaCodon
    {
        RNA _fp;
        RNA _sp;
        RNA _tp;

        public RnaCodon(RNA _fp, RNA _sp, RNA _tp)
        {
            this._fp = _fp;
            this._sp = _sp;
            this._tp = _tp;
        }

        public RNA Fp
        {
            get
            {
                return _fp;
            }

            set
            {
                _fp = value;
            }
        }

        public RNA Sp
        {
            get
            {
                return _sp;
            }

            set
            {
                _sp = value;
            }
        }

        public RNA Tp
        {
            get
            {
                return _tp;
            }

            set
            {
                _tp = value;
            }
        }

        public AA toAmino()
        {
            throw new NotImplementedException();
        }
    }
}