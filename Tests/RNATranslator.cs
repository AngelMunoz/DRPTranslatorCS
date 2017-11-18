using Xunit;
using System;
using System.Collections.Generic;
using DRPTranslator;
using DRPTranslator.Symbols;
using DRPTranslator.Translators;

namespace DRPTranslatorCSTests
{
    public class RNATranslatorTests
    {
        [Theory]
        [InlineData("UGCACUGCGAUCGCGAUG","ACGUGACGCUAGCGCUAC")]
        [InlineData("UAGCGCUGAUCAAAAACGGCA", "AUCGCGACUAGUUUUUGCCGU")]
        public void RnaToRnaTest(string rna, string expected)
        {
            RnaTranslator rnaTrans = new RnaTranslator();
            string result = rnaTrans.RnaToRna(rna);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("UGCACUGCGAUCGCGAUG", "TGCACTGCGATCGCGATG")]
        [InlineData("UAGCGCUGAUCAAAAACGGCA", "TAGCGCTGATCAAAAACGGCA")]
        public void EquivRnaDnaTest(string rna, string expected)
        {
            RnaTranslator rnaTrans = new RnaTranslator();
            string result = rnaTrans.EquivRnaDna(rna);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("UGCACUGCGAUCGCGAUG", "CYS-THR-ALA-ILE-ALA-MET")]
        [InlineData("UAGCGCUGAUCAAAAACGGCA", "STOP-ARG-STOP-SER-LYS-THR-ALA")]
        public void EquivRnaAaTest(string rna, string expected)
        {
            RnaTranslator rnaTrans = new RnaTranslator();
            string result = rnaTrans.EquivRnaAa(rna);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("UGCACUGCGAUCGCGAUG", "ACGTGACGCTAGCGCTAC")]
        [InlineData("UAGCGCUGAUCAAAAACGGCA", "ATCGCGACTAGTTTTTGCCGT")]
        public void TransRnaToDnaTest(string rna, string expected)
        {
            RnaTranslator rnaTrans = new RnaTranslator();
            string result = rnaTrans.TransRnaToDna(rna);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("UGCACUGCGAUCGCGAUG", "THR-STOP-ARG-STOP-ARG-TYR")] // ACG UGA CGC UAG CGC UAC
        [InlineData("UAGCGCUGAUCAAAAACGGCA", "ILE-ALA-THR-SER-PHE-CYS-ARG")] // AUC GCG ACU AGU UUU UGC CGU
        public void TransRnaToAaTest(string rna, string expected)
        {
            RnaTranslator rnaTrans = new RnaTranslator();
            string result = rnaTrans.TransRnaToAa(rna);
            Assert.Equal(expected, result);
        }

    }
}
