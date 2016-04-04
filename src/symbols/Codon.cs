using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DRPTranslatorCS.Symbols
{
    public class Codon
    {
        private RNA fp;
        private RNA sp;
        private RNA tp;

        public Codon() { }
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

        public List<Codon> GetCodonList(string rnaSeq)
        {
            if (rnaSeq.Length % 3 != 0)
                throw new IndexOutOfRangeException("The sequence is not divisible by 3");

            List<string> strCodons = (from Match m in Regex.Matches(rnaSeq, @"\.{3}") select m.Value).ToList();
            List<Codon> codons = new List<Codon>();
            foreach (string rBase in strCodons)
            {
                codons.Add(new Codon(GeneticMatcher.MatchRnaB(rBase[0]),
                                     GeneticMatcher.MatchRnaB(rBase[1]),
                                     GeneticMatcher.MatchRnaB(rBase[2])));
            }
            return codons;
        }

        public string GetCodonSeqString(List<Codon> codons)
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