using DRPTranslator.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DRPTranslator.Translators
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
        public string RnaToRna(string rna)
        {
            List<char> rnaBases = new List<char>();
            string returnSeq = "";
            foreach (char rBase in rna)
            {
                rnaBases.Add(rBase);
            }
            foreach (char dBase in rnaBases)
            {
                returnSeq += GeneticMatcher.ParseOpositeRna(dBase);
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
        public string EquivRnaDna(string rna)
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
        public string EquivRnaAa(string rna)
        {
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
        /// RNA -> DNA Oposite:  U -> T
        /// UACAGC (original)
        /// ATGTGC (return)
        /// </summary>
        /// <param name="rna"></param>
        /// <returns></returns>
        public string TransRnaToDna(string rna)
        {
            List<char> rnaBases = new List<char>();
            string returnSeq = "";
            foreach (char rBase in rna)
            {
                rnaBases.Add(rBase);
            }
            foreach (char dBase in rnaBases)
            {
                returnSeq += GeneticMatcher.ParseOpositeRna(dBase);
            }
            returnSeq = returnSeq.Replace('U', 'T');
            return returnSeq;
        }

        /// <summary>
        /// RNA -> AA Oposite
        /// AUGGCA...UGA... -> ...-MET-ALA-...-STOP-...
        /// </summary>
        /// <param name="rna"></param>
        /// <returns>The oposite aminoacid sequence from the original sequence</returns>
        public string TransRnaToAa(string rna)
        {
            string opRna = "";
            foreach (char eqRnaB in rna)
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
