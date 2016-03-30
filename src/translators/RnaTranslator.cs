using System;
namespace DRPTranslatorCS.Translators
{
    class RnaTranslator
    {

        /// <summary>
        /// Complementary RNA -> RNA: U -> A
        /// </summary>
        /// <param name="rna"></param>
        /// <returns></returns>
        public string compRR(string rna)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Equivalent RNA -> DNA: U -> T
        /// </summary>
        /// <param name="rna"></param>
        /// <returns></returns>
        public string equivRD(string rna)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Equivalent RNA -> AA No Starts No Stops: ...UAC -> TYR...
        /// </summary>
        /// <param name="rna"></param>
        /// <returns></returns>
        public string equivRA(string rna)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Equivalent RNA -> AA Starts? Stops?: AUG -> Met ... UAG -> STOP
        /// </summary>
        /// <param name="rna"></param>
        /// <param name="starts"></param>
        /// <param name="stops"></param>
        /// <returns></returns>
        public string equivRA(string rna, bool starts, bool stops)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Oposite RNA -> DNA: U -> T
        /// </summary>
        /// <param name="rna"></param>
        /// <returns></returns>
        public string transRD(string rna)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Oposite RNA -> AA No Starts No Stops: [... ,UAC -> AUG, CGU -> GCA, ... , ACU -> UGA, ...] -> ...-MET-ALA-...-STOP-...
        /// </summary>
        /// <param name="rna"></param>
        /// <returns></returns>
        public string transRA(string rna)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Oposite RNA -> AA Starts Stops [UAC -> AUG, CGU -> GCA, ... , ACU -> UGA] -> MET-ALA-...-STOP
        /// </summary>
        /// <param name="rna"></param>
        /// <param name="starts"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public string transRA(string rna, bool starts, bool stops)
        {
            throw new NotImplementedException();
        }

    }
}
