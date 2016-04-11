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
        public string DnaToDna(string dna)
        {
            List<char> dnaBases = new List<char>();
            string returnSeq = "";
            foreach (char dBase in dna)
            {
                dnaBases.Add(dBase);
            }
            foreach (char dBase in dnaBases)
            {
                returnSeq += GeneticMatcher.ParseOpositeDna(dBase);
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
        public string EquivDnaRna(string dna)
        {
            return dna.Replace('T', 'U');
        }

        /// <summary>
        /// DNA -> AA Equivalent TAC -> TYR
        /// TACACT (original) (rna: UACUCU)
        /// TYR-SER (return)
        /// </summary>
        /// <param name="dna"></param>
        /// <returns></returns>
        public string EquivDnaAa(string dna)
        {
            string rna = dna.Replace('T', 'U');
            List<Codon> codons = Codon.GetCodonList(rna);
            List<AA> aminos = GeneticMatcher.ParseAA(codons);
            string seq = "";
            foreach (AA amino in aminos)
            {
               seq += amino.ToString() + "-";
            }
            seq = seq.Remove(seq.LastIndexOf("-"));
            return seq;
        }

        /// <summary>
        /// DNA -> RNA Oposite:  T -> U
        /// ATGTGC (original)
        /// UACAGC (return)
        /// </summary>
        /// <param name="dna"></param>
        /// <returns></returns>
        public string TransDnaRna(string dna)
        {
            List<char> dnaBases = new List<char>();
            string returnSeq = "";
            foreach (char dBase in dna)
            {
                dnaBases.Add(dBase == 'T' ? 'U' : dBase);
            }
            foreach (char dBase in dnaBases)
            {
                returnSeq += GeneticMatcher.ParseOpositeRna(dBase);
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
        public string TransDnaAa(string dna)
        {
            string equivRna = dna.Replace('T', 'U');
            string opRna = "";
            foreach (char eqRnaB in equivRna)
            {
                opRna += GeneticMatcher.ParseOpositeRna(eqRnaB);
            }
            List<Codon> codons = Codon.GetCodonList(opRna);
            List<AA> aminos = GeneticMatcher.ParseAA(codons);
            string seq = "";
            foreach (AA amino in aminos)
            {
                seq += amino.ToString() + "-";
            }
            seq = seq.Remove(seq.LastIndexOf("-"));
            return seq;
        }

    }
}
