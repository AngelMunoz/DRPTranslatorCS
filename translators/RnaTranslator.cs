using DRPTranslatorCS.Symbols;
using System;
using System.Collections.Generic;

namespace DRPTranslatorCS.Translators
{
    public class RnaTranslator
    {

        /// <summary>
        /// RNA -> RNA Complementary: A -> U
        /// Given a string containing a RNA sequence, based on each character returns the oposite RNA base of the current character
        /// ACGTCG (original)
        /// UGCAGC (return)
        /// </summary>
        /// <param name="rna">
        /// String that represents a RNA sequence
        /// </param>
        /// <returns>
        /// Returns the complementary RNA Sequence
        /// </returns>
        public string CompRR(string rna)
        {
            List<char> rnaBases = new List<char>();
            string returnSeq = "";
            foreach (char rBase in rna)
            {
                rnaBases.Add(rBase);
            }
            rnaBases.Reverse();
            foreach (char dBase in rnaBases)
            {
                returnSeq += dBase;
            }
            return returnSeq;
        }

        /// <summary>
        /// Given a RNA string sequence, said sequence will be converted into
        /// it's matching RNA sequence without any transcription or translation
        /// RNA.A's become RNA.A's in that sense
        ///  RNA -> DNA Equivalent: U -> T
        ///  UAGAUC (original)
        ///  TAGATC (return)
        /// </summary>
        /// <param name="rna">
        /// String representing a RNA Sequence
        /// </param>
        /// <returns>
        /// String with the equivalent DNA sequence of the original RNA sequence
        /// without any translation or transcription
        /// </returns>
        public string EquivRD(string rna)
        {
            return rna.Replace('U', 'T');
        }

        /// <summary>
        /// RNA -> AA Equivalent No starts No stops (whole sequence): TAC -> TYR
        /// UACUCU
        /// TYR-SER (return)
        /// </summary>
        /// <param name="rna"></param>
        /// <returns></returns>
        public string EquivRA(string rna)
        {
            List<Codon> codons = Codon.GetCodonList(rna);
            List<AA> aminos = GeneticMatcher.MatchAACod(codons);
            string seq = "";
            foreach (AA amino in aminos)
            {
                seq += amino.ToString();
            }
            return seq;
        }

        /// <summary>
        /// RNA -> AA Equivalent Starts Stops: AUG -> MET ... UAG -> STOP
        /// UACUCU
        /// TYR-SER (return)
        /// </summary>
        /// <param name="rna"></param>
        /// <param name="starts"></param>
        /// <param name="stops"></param>
        /// <returns></returns>
        public string EquivRA(string rna, bool start, bool stop)
        {
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
            List<Codon> codList = Codon.GetCodonList(rna);
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
        /// RNA -> DNA Oposite:  U -> T
        /// UACAGC (original)
        /// ATGTGC (return)
        /// </summary>
        /// <param name="rna"></param>
        /// <returns></returns>
        public string TransRD(string rna)
        {
            List<char> rnaBases = new List<char>();
            string returnSeq = "";
            foreach (char rBase in rna)
            {
                rnaBases.Add(rBase);
            }
            rnaBases.Reverse();
            foreach (char dBase in rnaBases)
            {
                returnSeq += dBase;
            }
            returnSeq.Replace('U', 'T');
            return returnSeq;
        }

        /// <summary>
        /// RNA -> AA Oposite No Starts No Stops:
        /// AUGGCA...UGA... -> ...-MET-ALA-...-STOP-...
        /// </summary>
        /// <param name="rna"></param>
        /// <returns></returns>
        public string TransRA(string rna)
        {
            string opRna = "";
            foreach (char eqRnaB in rna)
            {
                opRna += GeneticMatcher.MatchOpositeRnaB(eqRnaB);
            }
            List<Codon> codons = Codon.GetCodonList(opRna);
            List<AA> aminos = GeneticMatcher.MatchAACod(codons);
            string seq = "";
            foreach (AA amino in aminos)
            {
                seq += amino.ToString();
            }
            return seq;
        }

        /// <summary>
        /// RNA -> AA Oposite Starts Stops:
        /// MET-ALA-...-STOP
        /// UACGCA...ACU
        /// AUGGCA...UGA
        /// </summary>
        /// <param name="rna"></param>
        /// <param name="starts"></param>
        /// <param name="stops"></param>
        /// <returns></returns>
        public string TransRA(string rna, bool start, bool stop)
        {

            foreach (char rBase in rna)
            {
                rna += GeneticMatcher.MatchOpositeRnaB(rBase);
            }

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
            List<Codon> codList = Codon.GetCodonList(rna);
            return Codon.GetCodonSeqString(codList);
        }


    }
}
