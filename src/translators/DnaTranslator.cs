using System;
using System.Collections.Generic;
using DRPTranslatorCS.Symbols;
namespace DRPTranslatorCS.Translators
{
    /// <summary>
    /// Translates and manages any method regarding DNA Sequences, transcribing them to RNA or Aminoacid sequences.
    /// This class can also (if needed) return the RNA or Aminoacid sequence representation of the Original DNA sequence without translating or transcribing
    /// </summary>
    class DnaTranslator
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
        public string compDD(string dna)
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
        public string equivDR(string dna)
        {
            List<DNA> dnaList = new List<DNA>();
            string returnSeq = "";
            foreach (char dnaBase in dna)
            {
                dnaList.Add(GeneticMatcher.matchDnaB(dnaBase));
            }
            foreach (char dnaBase in dnaList)
            {
                returnSeq += dnaBase;
            }
            return returnSeq;
        }

        /// <summary>
        /// DNA -> AA Equivalent No starts No stops (whole sequence): TAC -> TYR
        /// TACACT (original) (rna: UACUCU)
        /// TYR-SER (return)
        /// </summary>
        /// <param name="dna"></param>
        /// <returns></returns>
        public string equivDA(string dna)
        {
            List<DnaCodon> dnaCodList = new List<DnaCodon>(Codon.getDnaCodonList(dna));
            return Codon.getDnaCodonSeqStr(dnaCodList);
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
        public string equivDA(string dna, bool starts, bool stops)
        {
            //TODO: Design implementation with starts and stops
            throw new NotImplementedException();
        }

        /// <summary>
        /// DNA -> RNA Oposite:  T -> U
        /// ATGTGC (original)
        /// UACAGC (return)
        /// </summary>
        /// <param name="dna"></param>
        /// <returns></returns>
        public string transDR(string dna)
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
        public string transDA(string dna)
        {
            List<DnaCodon> dnaCodList = new List<DnaCodon>(Codon.getDnaCodonList(compDD(dna)));
            return Codon.getDnaCodonSeqStr(dnaCodList);
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
        public string transDA(string dna, bool starts, bool stops)
        {
            //TODO: Design implementation with starts and stops
            throw new NotImplementedException();
        }

    }
}
