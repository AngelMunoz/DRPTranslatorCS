using DRPTranslator.Symbols;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DRPTranslatorCSTests
{
    public class MatchAACodTestCase
    {

        public static readonly List<object[]> MatchAACodCodonAATestCase = new List<object[]>
        {
            new object[]{new Codon(RNA.A, RNA.U, RNA.G), AA.MET},
            new object[]{new Codon(RNA.A, RNA.A, RNA.A), AA.LYS},
            new object[]{new Codon(RNA.U, RNA.G, RNA.U), AA.CYS},
            new object[]{new Codon(RNA.U, RNA.G, RNA.C), AA.CYS},
            new object[]{new Codon(RNA.G, RNA.C, RNA.U), AA.ALA},
            new object[]{new Codon(RNA.G, RNA.C, RNA.C), AA.ALA},
            new object[]{new Codon(RNA.U, RNA.G, RNA.A), AA.STOP},
            new object[]{new Codon(RNA.U, RNA.A, RNA.A), AA.STOP},
            new object[]{new Codon(RNA.U, RNA.A, RNA.G), AA.STOP},
        };

        public static IEnumerable<object[]> MatchAACodCodonAAIndex
        {
            get
            {
                List<object[]> tmp = new List<object[]>();
                for (int i = 0; i < MatchAACodCodonAATestCase.Count; i++)
                    tmp.Add(MatchAACodCodonAATestCase[i]);
                return tmp;
            }
        }

        public static readonly List<object[]> MatchAACodCodonAAListTestCase = new List<object[]>
        {
            new object[]
            {
                new List<Codon>()
                {
                    new Codon(RNA.A, RNA.G, RNA.G),
                    new Codon(RNA.A, RNA.C, RNA.G),
                    new Codon(RNA.A, RNA.A, RNA.C),
                    new Codon(RNA.U, RNA.G, RNA.G),
                    new Codon(RNA.A, RNA.G, RNA.U)
                },
                new List<AA>()
                {
                    AA.ARG,
                    AA.THR,
                    AA.ASN,
                    AA.TRP,
                    AA.SER
                }
            },
            new object[]
            {
                new List<Codon>()
                {
                    new Codon(RNA.G, RNA.U, RNA.U),
                    new Codon(RNA.U, RNA.C, RNA.A),
                    new Codon(RNA.U, RNA.G, RNA.U),
                    new Codon(RNA.C, RNA.A, RNA.C),
                    new Codon(RNA.C, RNA.C, RNA.U)
                },
                new List<AA>()
                {
                    AA.VAL,
                    AA.SER,
                    AA.CYS,
                    AA.HIS,
                    AA.PRO
                }
            },
        };

        public static IEnumerable<object[]> MatchAACodCodonAAListIndex
        {
            get
            {
                List<object[]> tmp = new List<object[]>();
                for (int i = 0; i < MatchAACodCodonAAListTestCase.Count; i++)
                    tmp.Add(MatchAACodCodonAAListTestCase[i]);
                return tmp;
            }
        }
    }

    public class GetCodonListTestCase
    {
        public static readonly List<object[]> GetCodonListTest = new List<object[]>
        {
            new object[]
            {
                "AUGCGCUGC", // AUG CGC UGC
                new List<Codon>()
                {
                    new Codon(RNA.A, RNA.U, RNA.G),
                    new Codon(RNA.C, RNA.G, RNA.C),
                    new Codon(RNA.U, RNA.G, RNA.C)
                }
            },
            new object[]
            {
                "GCGUAUCCC", // GCG UAU CCC
                new List<Codon>()
                {
                    new Codon(RNA.G, RNA.C, RNA.G),
                    new Codon(RNA.U, RNA.A, RNA.U),
                    new Codon(RNA.C, RNA.C, RNA.C)
                }
            },
            new object[]
            {
                "AUGGCAUGGCGC", // AUG GCA UGG CGC
                new List<Codon>()
                {
                    new Codon(RNA.A, RNA.U, RNA.G),
                    new Codon(RNA.G, RNA.C, RNA.A),
                    new Codon(RNA.U, RNA.G, RNA.G),
                    new Codon(RNA.C, RNA.G, RNA.C)
                }
            },
            new object[]
            {
                "GCGAGUUGGUAA", // GCG AGU UGG UAA
                new List<Codon>()
                {
                    new Codon(RNA.G, RNA.C, RNA.G),
                    new Codon(RNA.A, RNA.G, RNA.U),
                    new Codon(RNA.U, RNA.G, RNA.G),
                    new Codon(RNA.U, RNA.A, RNA.A)
                }
            }
        };

        public static IEnumerable<object[]> GetCodonListTestCaseIndex
        {
            get
            {
                List<object[]> tmp = new List<object[]>();
                for (int i = 0; i < GetCodonListTest.Count; i++)
                    tmp.Add(GetCodonListTest[i]);
                return tmp;
            }
        }

        public static readonly List<object[]> GetCodonSequenceTest = new List<object[]>
        {
            new object[]
            {
                new List<Codon>()
                {
                    new Codon(RNA.A, RNA.U, RNA.G),
                    new Codon(RNA.C, RNA.G, RNA.C),
                    new Codon(RNA.U, RNA.G, RNA.C)
                },
                "AUG-CGC-UGC" // AUG CGC UGC
            },
            new object[]
            {
                new List<Codon>()
                {
                    new Codon(RNA.G, RNA.C, RNA.G),
                    new Codon(RNA.U, RNA.A, RNA.U),
                    new Codon(RNA.C, RNA.C, RNA.C)
                },
                "GCG-UAU-CCC", // GCG UAU CCC
            },
            new object[]
            {
                new List<Codon>()
                {
                    new Codon(RNA.A, RNA.U, RNA.G),
                    new Codon(RNA.G, RNA.C, RNA.A),
                    new Codon(RNA.U, RNA.G, RNA.G),
                    new Codon(RNA.C, RNA.G, RNA.C)
                },
                "AUG-GCA-UGG-CGC", // AUG GCA UGG CGC
            },
            new object[]
            {
                new List<Codon>()
                {
                    new Codon(RNA.G, RNA.C, RNA.G),
                    new Codon(RNA.A, RNA.G, RNA.U),
                    new Codon(RNA.U, RNA.G, RNA.G),
                    new Codon(RNA.U, RNA.A, RNA.A)
                },
                "GCG-AGU-UGG-UAA", // GCG AGU UGG UAA
            }
        };

        public static IEnumerable<object[]> GetCodonSequenceTestCaseIndex
        {
            get
            {
                List<object[]> tmp = new List<object[]>();
                for (int i = 0; i < GetCodonSequenceTest.Count; i++)
                    tmp.Add(GetCodonSequenceTest[i]);
                return tmp;
            }
        }
    }
}
