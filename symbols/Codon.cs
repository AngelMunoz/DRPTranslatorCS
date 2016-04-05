using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DRPTranslatorCS.Symbols
{
    /// <summary>
    /// Represents a Codon object, to use a codon it must have three genetic bases
    /// for the methods an empty codon is usefull
    /// </summary>
    public class Codon
    {
        private RNA fp;
        private RNA sp;
        private RNA tp;

        public Codon(RNA fp, RNA sp, RNA tp)
        {
            Fp = fp;
            Sp = sp;
            Tp = tp;
        }

        public RNA Fp
        {
            get
            {
                return fp;
            }

            set
            {
                fp = value;
            }
        }

        public RNA Sp
        {
            get
            {
                return sp;
            }

            set
            {
                sp = value;
            }
        }

        public RNA Tp
        {
            get
            {
                return tp;
            }

            set
            {
                tp = value;
            }
        }

        /// <summary>
        /// Given a rna string sequence, the method will chop the string in rna base triplets.
        /// </summary>
        /// <param name="rnaSeq">String representing a RNA sequence</param>
        /// <param name="bythree">This parameter tells the function whether to chop the string in strict triplets or take a last non strict tripplet</param>
        /// <returns>The codon List will only contain Full Codons (Three RNA Bases)</returns>
        public static List<Codon> GetCodonList(string rnaSeq, bool bythree)
        {
            List<string> strCodons = null;
            if (!bythree)
            {
                strCodons = (from Match m in Regex.Matches(rnaSeq, @"\.{1,3}") select m.Value).ToList();
            }
            else
            {
                if (rnaSeq.Length % 3 != 0)
                    throw new IndexOutOfRangeException("The sequence is not divisible by 3");
                strCodons = (from Match m in Regex.Matches(rnaSeq, @"\.{3}") select m.Value).ToList();
            }


            List<Codon> codons = new List<Codon>();
            foreach (string rBase in strCodons)
            {
                if (strCodons.LastIndexOf(rBase[0].ToString()) > 0 && strCodons.LastIndexOf(rBase[1].ToString()) > 0 && strCodons.LastIndexOf(rBase[2].ToString()) > 0)
                {
                    codons.Add(new Codon(GeneticMatcher.MatchRnaB(rBase[0]),
                                     GeneticMatcher.MatchRnaB(rBase[1]),
                                     GeneticMatcher.MatchRnaB(rBase[2])));
                }
            }
            return codons;
        }

        /// <summary>
        /// Given a List of Codons, the method will only return the string representation of each Codon in the Codon List
        /// </summary>
        /// <param name="codons">List that Contain Codons</param>
        /// <returns>String composed of the string representation of each codon in the supplied list</returns>
        public static string GetCodonSeqString(List<Codon> codons)
        {
            string seq = "";
            foreach (Codon codon in codons)
            {
                if (codons.Count == 1)
                {
                    seq += codon.ToString();
                }
                else if (codons.IndexOf(codon) == codons.Count - 1)
                {
                    seq += codon.ToString();
                }
                else
                {
                    seq += codon.ToString() + "-";
                }
            }
            return seq;
        }

        public override string ToString()
        {
            return @"" + Fp + Sp + Tp;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Codon cod = obj as Codon;
            if (Fp == cod.Fp && Sp == cod.Sp && Tp == cod.Tp)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

    }


}