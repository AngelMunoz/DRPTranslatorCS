using Xunit;
using DRPTranslator;
using DRPTranslator.Symbols;
using System.Collections.Generic;
using System;

namespace DRPTranslatorCSTests
{
    public class CodonTest
    {
        [Theory]
        [MemberData(nameof(GetCodonListTestCase.GetCodonListTestCaseIndex), MemberType = typeof(GetCodonListTestCase))]
        public void GetCodonListTest(string seq,List<Codon> expected)
        {
            List<Codon> result = Codon.GetCodonList(seq);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetCodonListTestCase.GetCodonSequenceTestCaseIndex), MemberType = typeof(GetCodonListTestCase))]
        public void GetCodonSequenceTest(List<Codon> codons, string expected)
        {
            string result = Codon.GetCodonSeqString(codons);
            Assert.Equal(expected, result);
        }

    }
}
