using System;
using System.Collections.Generic;
using DRPTranslatorCS.Symbols;
namespace DRPTranslatorCS.Translators
{
    /// <summary>
    /// Translates and manages any method regarding DNA Sequences, transcribing them to RNA or Aminoacid sequences.
    /// This class can also (if needed) return the RNA or Aminoacid sequence representation of the Original DNA sequence without translating or transcribing
    /// </summary>
    public class DnaTranslator
    {
        /// <summary>
        /// DNA -> DNA Complementary: A -> T
        /// Given a string containing a DNA sequence, based on each character returns the oposite DNA base of the current character
        /// ACGTCG (original)
        /// TGCAGC (return)
        /// </summary>
        /// <param name="dna">
        /// String that represents a DNA sequence
        /// </param>
        /// <returns>
        /// Returns the complementary DNA Sequence
        /// </returns>
        public string CompDD(string dna)
        {
            List<char> dnaBases = new List<char>();
            string returnSeq = "";
            foreach (char dBase in dna)
            {
                dnaBases.Add(dBase);
            }
            dnaBases.Reverse();
            foreach (char dBase in dnaBases)
            {
                returnSeq += dBase;
            }
            return returnSeq;
        }

        /// <summary>
        /// Given a DNA string sequence, said sequence will be converted into
        /// it's matching RNA sequence without any transcription or translation
        /// DNA.A's become RNA.A's in that sense
        ///  DNA -> RNA Equivalent: T -> U
        ///  TAGATC (original)
        ///  UAGAUC (return)
        /// </summary>
        /// <param name="dna">
        /// String representing a DNA Sequence
        /// </param>
        /// <returns>
        /// String with the equivalent RNA sequence of the original DNA sequence
        /// without any translation or transcription
        /// </returns>
        public string EquivDR(string dna)
        {
            return dna.Replace('T', 'U');
        }

        /// <summary>
        /// DNA -> AA Equivalent No starts No stops (whole sequence): TAC -> TYR
        /// TACACT (original) (rna: UACUCU)
        /// TYR-SER (return)
        /// </summary>
        /// <param name="dna"></param>
        /// <returns></returns>
        public string EquivDA(string dna)
        {
            string rna = dna.Replace('T', 'U');
            List<Codon> codons = Codon.GetCodonList(rna, false);
            List<AA> aminos = GeneticMatcher.MatchAACod(codons);
            string seq = "";
            foreach (AA amino in aminos)
            {
                seq += amino.ToString();
            }
            return seq;
        }

        /// <summary>
        /// DNA -> AA Equivalent Starts Stops: AUG -> MET ... UAG -> STOP
        /// TACACT (original) (rna: UACUCU)
        /// TYR-SER (return)
        /// </summary>
        /// <param name="dna"></param>
        /// <param name="starts"></param>
        /// <param name="stops"></param>
        /// <returns></returns>
        public string EquivDA(string dna, bool start, bool stop)
        {
            string rna = dna.Replace('T', 'U');

            int startIndex = rna.IndexOf("AUG");
            int stopIndex = DetermineStop(rna);

            if (stopIndex < 0)
                stop = false;
            if (startIndex < 0)
                start = false;

            if (start && stop)
            {
                rna = rna.Substring(startIndex, stopIndex+3);
            }
            else if (start && !stop)
            {
                rna = rna.Substring(startIndex, rna.Length);
            }
            else if (!start && stop)
            {
                rna = rna.Substring(0, stopIndex+3);
            }

            bool bythree = rna.Length % 3 == 0 ? true : false;
            List<Codon> codList = Codon.GetCodonList(rna, bythree);
            return Codon.GetCodonSeqString(codList);

        }

        /// <summary>
        /// Given a RNA representing string, the method will look for the first occurence of any of the STOP codons.
        /// </summary>
        /// <param name="rna">String that represents a RNA sequence</param>
        /// <returns>The zero based index of the first STOP codon that is found</returns>
        private int DetermineStop(string rna)
        {
            int[] stopArr = { rna.IndexOf("UAA"), rna.IndexOf("UAG"), rna.IndexOf("UGA") };
            int stopIndex = 0;

            if (stopArr[0] > stopArr[1])
                stopIndex = stopArr[0];
            else if (stopArr[1] > stopArr[2])
                stopIndex = stopArr[1];
            else
                stopIndex = stopArr[2];

            return stopIndex;
        }

        /// <summary>
        /// DNA -> RNA Oposite:  T -> U
        /// ATGTGC (original)
        /// UACAGC (return)
        /// </summary>
        /// <param name="dna"></param>
        /// <returns></returns>
        public string TransDR(string dna)
        {
            List<char> dnaBases = new List<char>();
            string returnSeq = "";
            foreach (char dBase in dna)
            {
                dnaBases.Add(dBase == 'T' ? 'U' : dBase);
            }
            dnaBases.Reverse();
            foreach (char dBase in dnaBases)
            {
                returnSeq += dBase;
            }
            return returnSeq;
        }

        /// <summary>
        /// DNA -> AA Oposite No Starts No Stops:
        /// ...ATGGCA...TGA... ->
        /// [... ,UAC -> AUG, CGU -> GCA, ... , ACU -> UGA, ...] -> ...-MET-ALA-...-STOP-...
        /// </summary>
        /// <param name="dna"></param>
        /// <returns></returns>
        public string TransDA(string dna)
        {
            string equivRna = dna.Replace('T', 'U');
            string opRna = "";
            foreach (char eqRnaB in equivRna)
            {
                opRna += GeneticMatcher.MatchOpositeRnaB(eqRnaB);
            }
            List<Codon> codons = Codon.GetCodonList(opRna, false);
            List<AA> aminos = GeneticMatcher.MatchAACod(codons);
            string seq = "";
            foreach (AA amino in aminos)
            {
                seq += amino.ToString();
            }
            return seq;
        }

        /// <summary>
        /// DNA -> AA Oposite Starts Stops:
        /// [TAC -> ATG, CGT -> GCA, ... , ACT -> TGA] -> MET-ALA-...-STOP
        /// TACGCA...ACT
        /// ATGGCA...TGA
        /// </summary>
        /// <param name="dna"></param>
        /// <param name="starts"></param>
        /// <param name="stops"></param>
        /// <returns></returns>
        public string TransDA(string dna, bool start, bool stop)
        {
            string rna = "";

            foreach (char dnaB in dna)
            {
                rna += GeneticMatcher.MatchOpositeDnaB(dnaB);
            }
            rna.Replace('T', 'U');

            int startIndex = rna.IndexOf("AUG");
            int stopIndex = DetermineStop(rna);

            if (stopIndex < 0)
                stop = false;
            if (startIndex < 0)
                start = false;

            if (start && stop)
            {
                rna = rna.Substring(startIndex, stopIndex + 3);
            }
            else if (start && !stop)
            {
                rna = rna.Substring(startIndex, rna.Length);
            }
            else if (!start && stop)
            {
                rna = rna.Substring(0, stopIndex + 3);
            }
            
            bool bythree = rna.Length % 3 == 0 ? true : false;
            List<Codon> codList = Codon.GetCodonList(rna, bythree);
            return Codon.GetCodonSeqString(codList);
        }

    }
}
