using System;
using DRPTranslatorCS.Symbols;

namespace DRPTranslatorCS
{
    /// <summary>
    /// This class contains several matcher methods which convert characters into their matching DNA or RNA bases
    /// </summary>
    class GeneticMatcher
    {
        /// <summary>
        /// Given a Character representing a RNA Base, the function will return the matching RNA Base
        /// 'A' -> RNA.A
        /// </summary>
        /// <param name="b">Character representing a RNA Base</param>
        /// <returns>RNA Base</returns>
        public static RNA  matchRnaB(char b)
        {
            switch(b)
            {
                case 'A':
                    return RNA.A;
                case 'C':
                    return RNA.C;
                case 'U':
                    return RNA.U;
                case 'G':
                    return RNA.G;
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Given a RNA Base, the function will convert it to it's matching RNA character representation
        /// RNA.A -> 'A'
        /// </summary>
        /// <param name="b">RNA Base</param>
        /// <returns>Character Representing a RNA Base</returns>
        public static char matchRnaB(RNA b)
        {
            switch (b)
            {
                case RNA.A:
                    return 'A';
                case RNA.C:
                    return 'C';
                case RNA.U:
                    return 'U';
                case RNA.G:
                    return 'G';
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Given a character representing a RNA base, the function will return the oposite RNA base.
        /// 'A' -> RNA.U
        /// </summary>
        /// <param name="b">Character Representing a RNA Base</param>
        /// <returns>RNA Base</returns>
        public static RNA matchOpositeRnaB(char b)
        {
            switch (b)
            {
                case 'A':
                    return RNA.U;
                case 'C':
                    return RNA.G;
                case 'U':
                    return RNA.A;
                case 'G':
                    return RNA.C;
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Given a RNA Base, the function will convert it to it's oposite RNA character representation
        /// RNA.A -> 'U'
        /// </summary>
        /// <param name="b">RNA Base</param>
        /// <returns>Character Representing a RNA Base</returns>
        public static char matchOpositeRnaB(RNA b)
        {
            switch (b)
            {
                case RNA.A:
                    return 'U';
                case RNA.C:
                    return 'G';
                case RNA.U:
                    return 'A';
                case RNA.G:
                    return 'C';
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Given a Character representing a DNA Base, the function will return the matching DNA Base
        /// 'A' -> DNA.A
        /// </summary>
        /// <param name="b">Character representing a DNA Base</param>
        /// <returns>DNA Base</returns>
        public static DNA matchDnaB(char b)
        {
            switch (b)
            {
                case 'A':
                    return DNA.A;
                case 'C':  
                    return DNA.C;
                case 'T':  
                    return DNA.T;
                case 'G':  
                    return DNA.G;
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Given a DNA Base, the function will convert it to it's matching DNA character representation
        /// DNA.A -> 'A'
        /// </summary>
        /// <param name="b">DNA Base</param>
        /// <returns>Character Representing a DNA Base</returns>
        public static char matchDnaB(DNA b)
        {
            switch (b)
            {
                case DNA.A:
                    return 'A';
                case DNA.C:
                    return 'C';
                case DNA.T:
                    return 'T';
                case DNA.G:
                    return 'G';
                default:
                    throw new NotImplementedException();
            }
        }


        /// <summary>
        /// Given a character representing a DNA base, the function will return the oposite DNA base.
        /// 'A' -> DNA.T
        /// </summary>
        /// <param name="b">Character Representing a DNA Base</param>
        /// <returns>RNA Base</returns>
        public static DNA matchOpositeDnaB(char b)
        {
            switch (b)
            {
                case 'A':
                    return DNA.T;
                case 'C':
                    return DNA.G;
                case 'T':
                    return DNA.A;
                case 'G':
                    return DNA.C;
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Given a DNA Base, the function will convert it to it's matching DNA character representation
        /// DNA.A -> 'T'
        /// </summary>
        /// <param name="b">DNA Base</param>
        /// <returns>Character Representing a DNA Base</returns>
        public static char matchOpositeDnaB(DNA b)
        {
            switch (b)
            {
                case DNA.A:
                    return 'T';
                case DNA.C:
                    return 'G';
                case DNA.T:
                    return 'A';
                case DNA.G:
                    return 'C';
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
