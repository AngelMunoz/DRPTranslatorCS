﻿using System;
using DRPTranslatorCS.Symbols;
using System.Collections.Generic;
namespace DRPTranslatorCS
{
    /// <summary>
    /// This class contains several matcher methods which convert characters into their matching DNA or RNA bases
    /// </summary>
    static class GeneticMatcher
    {
        static readonly Dictionary<AA, List<Codon>> _dic = new Dictionary<AA, List<Codon>>()
        {
            {
                AA.ALA, new List<Codon>()
                {
                    new Codon(RNA.G, RNA.C, RNA.U),
                    new Codon(RNA.G, RNA.C, RNA.C),
                    new Codon(RNA.G, RNA.C, RNA.A),
                    new Codon(RNA.G, RNA.C, RNA.G)
                }
            },
            {
                AA.ARG, new List<Codon>()
                {
                    new Codon(RNA.C, RNA.G, RNA.U),
                    new Codon(RNA.C, RNA.G, RNA.C),
                    new Codon(RNA.C, RNA.G, RNA.A),
                    new Codon(RNA.C, RNA.G, RNA.G),
                    new Codon(RNA.A, RNA.G, RNA.A),
                    new Codon(RNA.A, RNA.G, RNA.G)
                }
            },
            {
                AA.ASN, new List<Codon>()
                {
                    new Codon(RNA.A, RNA.A, RNA.U),
                    new Codon(RNA.A, RNA.A, RNA.C)
                }
            },
            {
                AA.ASP, new List<Codon>()
                {
                    new Codon(RNA.G, RNA.A, RNA.U),
                    new Codon(RNA.G, RNA.A, RNA.C)
                }
            },
            {
                AA.CYS, new List<Codon>()
                {
                    new Codon(RNA.U, RNA.G, RNA.U),
                    new Codon(RNA.U, RNA.G, RNA.C)
                }
            },
            {
                AA.GLN, new List<Codon>()
                {
                    new Codon(RNA.U, RNA.G, RNA.U),
                    new Codon(RNA.U, RNA.G, RNA.C)
                }
            },
            {
                AA.GLU, new List<Codon>()
                {
                    new Codon(RNA.G, RNA.A, RNA.A),
                    new Codon(RNA.G, RNA.A, RNA.G)
                }
            },
            {
                AA.GLY, new List<Codon>()
                {
                    new Codon(RNA.G, RNA.G, RNA.U),
                    new Codon(RNA.G, RNA.G, RNA.C),
                    new Codon(RNA.G, RNA.G, RNA.A),
                    new Codon(RNA.G, RNA.G, RNA.G)
                }
            },
            {
                AA.HIS, new List<Codon>()
                {
                    new Codon(RNA.C, RNA.A, RNA.U),
                    new Codon(RNA.C, RNA.A, RNA.C)
                }
            },
            {
                AA.LEU, new List<Codon>()
                {
                    new Codon(RNA.U, RNA.U, RNA.A),
                    new Codon(RNA.U, RNA.U, RNA.G),
                    new Codon(RNA.C, RNA.U, RNA.U),
                    new Codon(RNA.C, RNA.U, RNA.C),
                    new Codon(RNA.C, RNA.U, RNA.A),
                    new Codon(RNA.C, RNA.U, RNA.G)
                }
            },
            {
                AA.LYS, new List<Codon>()
                {
                    new Codon(RNA.A, RNA.A, RNA.A),
                    new Codon(RNA.A, RNA.A, RNA.G)
                }
            },
            {
                AA.MET, new List<Codon>()
                {
                    new Codon(RNA.A, RNA.U, RNA.G)
                }
            },
            {
                AA.PHE, new List<Codon>()
                {
                    new Codon(RNA.U, RNA.U, RNA.U),
                    new Codon(RNA.U, RNA.U, RNA.C)
                }
            },
            {
                AA.PRO, new List<Codon>()
                {
                    new Codon(RNA.C, RNA.C, RNA.U),
                    new Codon(RNA.C, RNA.C, RNA.C),
                    new Codon(RNA.C, RNA.C, RNA.A),
                    new Codon(RNA.C, RNA.C, RNA.G)
                }
            },
            {
                AA.SER, new List<Codon>()
                {
                    new Codon(RNA.U, RNA.C, RNA.U),
                    new Codon(RNA.U, RNA.C, RNA.C),
                    new Codon(RNA.U, RNA.C, RNA.A),
                    new Codon(RNA.U, RNA.C, RNA.G),
                    new Codon(RNA.A, RNA.G, RNA.U),
                    new Codon(RNA.A, RNA.G, RNA.C)
                }
            },
            {
                AA.THR, new List<Codon>()
                {
                    new Codon(RNA.C, RNA.C, RNA.U),
                    new Codon(RNA.C, RNA.C, RNA.C),
                    new Codon(RNA.C, RNA.C, RNA.A),
                    new Codon(RNA.C, RNA.C, RNA.G)
                }
            },
            {
                AA.TRP, new List<Codon>()
                {
                    new Codon(RNA.U, RNA.G, RNA.G)
                }
            },
            {
                AA.TYR, new List<Codon>()
                {
                    new Codon(RNA.U, RNA.A, RNA.U),
                    new Codon(RNA.U, RNA.A, RNA.C)
                }
            },
            {
                AA.VAL, new List<Codon>()
                {
                    new Codon(RNA.G, RNA.U, RNA.U),
                    new Codon(RNA.G, RNA.U, RNA.C),
                    new Codon(RNA.G, RNA.U, RNA.A),
                    new Codon(RNA.G, RNA.U, RNA.G)
                }
            },
            {
                AA.ILE, new List<Codon>()
                {
                    new Codon(RNA.A, RNA.U, RNA.U),
                    new Codon(RNA.A, RNA.U, RNA.C),
                    new Codon(RNA.A, RNA.U, RNA.A)
                }
            },
            {
                AA.STOP, new List<Codon>()
                {
                    new Codon(RNA.U, RNA.A, RNA.A),
                    new Codon(RNA.U, RNA.A, RNA.G),
                    new Codon(RNA.U, RNA.G, RNA.A)
                }
            }

        };

        public static Dictionary<AA, List<Codon>> Dic
        {
            get
            {
                return _dic;
            }
        }


        /// <summary>
        /// Given a Character representing a RNA Base, the function will return the matching RNA Base
        /// 'A' -> RNA.A
        /// </summary>
        /// <param name="b">Character representing a RNA Base</param>
        /// <returns>RNA Base</returns>
        public static RNA MatchRnaB(char b)
        {
            switch (b)
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
        public static char MatchRnaB(RNA b)
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
        public static RNA MatchOpositeRnaB(char b)
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
        public static char MatchOpositeRnaB(RNA b)
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
        public static DNA MatchDnaB(char b)
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
        public static char MatchDnaB(DNA b)
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
        public static DNA MatchOpositeDnaB(char b)
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
        public static char MatchOpositeDnaB(DNA b)
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

        /// <summary>
        /// Given a string representing an aminoacid, the function will return it's matching aminoacid enum
        /// "ALA" -> AA.ALA
        /// </summary>
        /// <param name="codon"></param>
        /// <returns></returns>
        public static AA MatchStrAA(string amino)
        {
            AA key = 0;
            foreach (var index in Dic)
            {
                if (index.Key.ToString() == amino)
                {
                    key = index.Key;
                }
            }
            if (key.ToString() != amino)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                return key;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codons"></param>
        /// <returns></returns>
        public static List<AA> MatchAACod(List<Codon> codons)
        {
            List<AA> aaList = new List<AA>();
            foreach (Codon codon in codons)
            {
                aaList.Add(MatchAACod(codon));
            }
            return aaList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codon"></param>
        /// <returns></returns>
        public static AA MatchAACod(Codon codon)
        {
            return MatchStrAA(codon.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amino"></param>
        /// <returns></returns>
        public static List<Codon> MatchCodonAA(AA amino)
        {
            return Dic[amino];
        }
    }
}
