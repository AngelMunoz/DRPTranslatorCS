using Xunit;
using System;
using System.Collections.Generic;
using DRPTranslator;
using DRPTranslator.Symbols;
using DRPTranslator.Translators;

namespace DRPTranslatorCSTests
{
    public class DnaTranslatorTests
    {
        [Theory]
        [InlineData("TGCACTGCGATCGCGATG", "ACGTGACGCTAGCGCTAC")]
        [InlineData("TAGCGCTGATCAAAAACGGCA", "ATCGCGACTAGTTTTTGCCGT")]
        public void DnaToDnaTest(string rna, string expected)
        {
            DnaTranslator dnaTrans = new DnaTranslator();
            string result = dnaTrans.DnaToDna(rna);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("TGCACTGCGATCGCGATG", "UGCACUGCGAUCGCGAUG")]
        [InlineData("TAGCGCTGATCAAAAACGGCA", "UAGCGCUGAUCAAAAACGGCA")]
        public void EquivDnaRnaTest(string rna, string expected)
        {
            DnaTranslator dnaTrans = new DnaTranslator();
            string result = dnaTrans.EquivDnaRna(rna);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("TGCACTGCGATCGCGATG", "CYS-THR-ALA-ILE-ALA-MET")]
        [InlineData("TAGCGCTGATCAAAAACGGCA", "STOP-ARG-STOP-SER-LYS-THR-ALA")]
        public void EquivDnaAaTest(string rna, string expected)
        {
            DnaTranslator dnaTrans = new DnaTranslator();
            string result = dnaTrans.EquivDnaAa(rna);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("TGCACTGCGATCGCGATG", "ACGUGACGCUAGCGCUAC")]
        [InlineData("TAGCGCTGATCAAAAACGGCA", "AUCGCGACUAGUUUUUGCCGU")]
        public void TransDnaRnaTest(string rna, string expected)
        {
            DnaTranslator dnaTrans = new DnaTranslator();
            string result = dnaTrans.TransDnaRna(rna);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("TGCACTGCGATCGCGATG", "THR-STOP-ARG-STOP-ARG-TYR")] // ACG UGA CGC UAG CGC UAC
        [InlineData("TAGCGCTGATCAAAAACGGCA", "ILE-ALA-THR-SER-PHE-CYS-ARG")] // AUC GCG ACU AGU UUU UGC CGU
        public void TransDnaAaTest(string rna, string expected)
        {
            DnaTranslator dnaTrans = new DnaTranslator();
            string result = dnaTrans.TransDnaAa(rna);
            Assert.Equal(expected, result);
        }

    }
}
