using System;

namespace DRPTranslatorCS.Translators
{
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
            throw new NotImplementedException();
        }

        /// <summary>
        ///  DNA -> RNA Equivalent: T -> U
        ///  TAGATC (original)
        ///  UAGAUC (return)
        /// </summary>
        /// <param name="dna"></param>
        /// <returns></returns>
        public string equivDR(string dna)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// DNA -> AA Oposite No Starts No Stops:
        /// [... ,UAC -> AUG, CGU -> GCA, ... , ACU -> UGA, ...] -> ...-MET-ALA-...-STOP-...
        /// TACACT
        /// Met-STOP
        /// </summary>
        /// <param name="dna"></param>
        /// <returns></returns>
        public string transDA(string dna)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

    }
}
