using System;
using Xunit;
using DRPTranslator;
using DRPTranslator.Symbols;
using System.Collections.Generic;

namespace DRPTranslatorCSTests
{
    
    public class GeneticMatcherTest
    {
        [Theory]
        [InlineData('A', RNA.A)]
        [InlineData('C', RNA.C)]
        [InlineData('U', RNA.U)]
        [InlineData('G', RNA.G)]
        public void MatchRnaBCharBaseTest(char b, RNA expected)
        {
            RNA result = GeneticMatcher.ParseRna(b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(RNA.A, 'A')]
        [InlineData(RNA.C, 'C')]
        [InlineData(RNA.U, 'U')]
        [InlineData(RNA.G, 'G')]
        public void MatchRnaBBaseCharTest(RNA b, char expected)
        {
            char result = GeneticMatcher.ParseRna(b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData('A', RNA.U)]
        [InlineData('C', RNA.G)]
        [InlineData('U', RNA.A)]
        [InlineData('G', RNA.C)]
        public void MatchOpositeRnaBCharBaseTest(char b, RNA expected)
        {
            RNA result = GeneticMatcher.ParseOpositeRna(b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(RNA.U, 'A')]
        [InlineData(RNA.G, 'C')]
        [InlineData(RNA.A, 'U')]
        [InlineData(RNA.C, 'G')]
        public void MatchOpositeRnaBBaseCharTest(RNA b, char expected)
        {
            char result = GeneticMatcher.ParseOpositeRna(b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData('A', DNA.A)]
        [InlineData('C', DNA.C)]
        [InlineData('T', DNA.T)]
        [InlineData('G', DNA.G)]
        public void MatchDnaBCharBaseTest(char b, DNA expected)
        {
            DNA result = GeneticMatcher.ParseDna(b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(DNA.A, 'A')]
        [InlineData(DNA.C, 'C')]
        [InlineData(DNA.T, 'T')]
        [InlineData(DNA.G, 'G')]
        public void MatchDnaBBaseCharTest(DNA b, char expected)
        {
            char result = GeneticMatcher.ParseDna(b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData('A', DNA.T)]
        [InlineData('C', DNA.G)]
        [InlineData('T', DNA.A)]
        [InlineData('G', DNA.C)]
        public void MatchOpositeDnaBCharBaseTest(char b, DNA expected)
        {
            DNA result = GeneticMatcher.ParseOpositeDna(b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(DNA.T, 'A')]
        [InlineData(DNA.G, 'C')]
        [InlineData(DNA.A, 'T')]
        [InlineData(DNA.C, 'G')]
        public void MatchOpositeDnaBBaseCharTest(DNA b, char expected)
        {
            char result = GeneticMatcher.ParseOpositeDna(b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(MatchAACodTestCase.MatchAACodCodonAAIndex), MemberType = typeof(MatchAACodTestCase))]
        public void MatchAACodCodonAATest(Codon codon, AA expected)
        {
            AA result = GeneticMatcher.ParseAA(codon);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(MatchAACodTestCase.MatchAACodCodonAAListIndex), MemberType = typeof(MatchAACodTestCase))]
        public void MatchAACodListCodonListAATest(List<Codon> codons, List<AA> expected)
        {
            List<AA> result = GeneticMatcher.ParseAA(codons);
            Assert.Equal(expected, result);
        }
    }
}
