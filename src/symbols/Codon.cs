using System.Collections.Generic;

namespace DRPTranslatorCS.Symbols
{
    public struct DnaCodon
    {
        DNA _fp;
        DNA _sp;
        DNA _tp;

        public DnaCodon(DNA _fp, DNA _sp, DNA _tp)
        {
            this._fp = _fp;
            this._sp = _sp;
            this._tp = _tp;
        }

        public DNA Fp
        {
            get
            {
                return _fp;
            }

            set
            {
                _fp = value;
            }
        }

        public DNA Sp
        {
            get
            {
                return _sp;
            }

            set
            {
                _sp = value;
            }
        }

        public DNA Tp
        {
            get
            {
                return _tp;
            }

            set
            {
                _tp = value;
            }
        }

        public static string getCodonSeqStr(List<DnaCodon> codons)
        {
            string codSeq = "";
            foreach (DnaCodon codon in codons)
            {
                if (codons.IndexOf(codon) == codons.Count - 1)
                {
                    codSeq += DnaCodon.getCodonStr(codon);
                }
                else
                {
                    codSeq += DnaCodon.getCodonStr(codon) + "-";
                }
            }
            return codSeq;
        }

        //TODO: Change all NotImplementedException
        public static string getCodonStr(DnaCodon codon)
        {
            string aa = "";
            switch (codon.Fp)
            {
                case DNA.A:
                    switch (codon.Sp)
                    {
                        case DNA.A:
                            switch (codon.Tp)
                            {
                                case DNA.A: // AAA
                                    aa = "Lys";
                                    break;
                                case DNA.T: // AAT
                                    aa = "Asn";
                                    break;
                                case DNA.G: // AAG
                                    aa = "Lys";
                                    break;
                                case DNA.C: // AAC
                                    aa = "Asn";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.T:
                            switch (codon.Tp)
                            {
                                case DNA.A: // ATA
                                    aa = "Ile";
                                    break;
                                case DNA.T: // ATT
                                    aa = "Ile";
                                    break;
                                case DNA.G: // ATG
                                    aa = "Met";
                                    break;
                                case DNA.C: // ATC
                                    aa = "Ile";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.G:
                            switch (codon.Tp)
                            {
                                case DNA.A: // AGA
                                    aa = "Arg";
                                    break;
                                case DNA.T: // AGT
                                    aa = "Ser";
                                    break;
                                case DNA.G: // AGG
                                    aa = "Arg";
                                    break;
                                case DNA.C: // AGC
                                    aa = "Ser";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.C:
                            switch (codon.Tp)
                            {
                                case DNA.A: // ACA
                                    aa = "Thr";
                                    break;
                                case DNA.T: // ACT
                                    aa = "Thr";
                                    break;
                                case DNA.G: // ACG
                                    aa = "Thr";
                                    break;
                                case DNA.C: // ACC
                                    aa = "Thr";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        default:
                            throw new System.NotImplementedException();
                    }//second level
                    break;
                case DNA.T:
                    switch (codon.Sp)
                    {
                        case DNA.A:
                            switch (codon.Tp)
                            {
                                case DNA.A: // TAA
                                    aa = "STOP";
                                    break;
                                case DNA.T: // TAT
                                    aa = "Tyr";
                                    break;
                                case DNA.G: // TAG
                                    aa = "STOP";
                                    break;
                                case DNA.C: // TAC
                                    aa = "Tyr";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.T:
                            switch (codon.Tp)
                            {
                                case DNA.A: // TTA
                                    aa = "Leu";
                                    break;
                                case DNA.T: // TTT
                                    aa = "Phe";
                                    break;
                                case DNA.G: // TTG
                                    aa = "Leu";
                                    break;
                                case DNA.C: // TTC
                                    aa = "Phe";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.G:
                            switch (codon.Tp)
                            {
                                case DNA.A: // TGA
                                    aa = "STOP";
                                    break;
                                case DNA.T: // TGT
                                    aa = "Cys";
                                    break;
                                case DNA.G: // TGG
                                    aa = "Trp";
                                    break;
                                case DNA.C: // TGC
                                    aa = "Cys";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.C:
                            switch (codon.Tp)
                            {
                                case DNA.A: // TCA
                                    aa = "Ser";
                                    break;
                                case DNA.T: // TCT
                                    aa = "Ser";
                                    break;
                                case DNA.G: // TCG
                                    aa = "Ser";
                                    break;
                                case DNA.C: // TCC
                                    aa = "Ser";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        default:
                            throw new System.NotImplementedException();
                    }//second level
                    break;
                case DNA.G:
                    switch (codon.Sp)
                    {
                        case DNA.A:
                            switch (codon.Tp)
                            {
                                case DNA.A: // GAA
                                    aa = "Glu";
                                    break;
                                case DNA.T: // GAT
                                    aa = "Asp";
                                    break;
                                case DNA.G: // GAG
                                    aa = "Glu";
                                    break;
                                case DNA.C: // GAC
                                    aa = "Asp";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.T:
                            switch (codon.Tp)
                            {
                                case DNA.A: // GTA
                                    aa = "Val";
                                    break;
                                case DNA.T: // GTT
                                    aa = "Val";
                                    break;
                                case DNA.G: // GTG
                                    aa = "Val";
                                    break;
                                case DNA.C: // GTC
                                    aa = "Val";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.G:
                            switch (codon.Tp)
                            {
                                case DNA.A: // GGA
                                    aa = "Gly";
                                    break;
                                case DNA.T: // GGT
                                    aa = "Gly";
                                    break;
                                case DNA.G: // GGG
                                    aa = "Gly";
                                    break;
                                case DNA.C: // GGC
                                    aa = "Gly";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.C:
                            switch (codon.Tp)
                            {
                                case DNA.A: // GCA
                                    aa = "Ala";
                                    break;
                                case DNA.T: // GCT
                                    aa = "Ala";
                                    break;
                                case DNA.G: // GCG
                                    aa = "Ala";
                                    break;
                                case DNA.C: // GCC
                                    aa = "Ala";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        default:
                            throw new System.NotImplementedException();
                    }//second level
                    break;
                case DNA.C:
                    switch (codon.Sp)
                    {
                        case DNA.A:
                            switch (codon.Tp)
                            {
                                case DNA.A: // CAA
                                    aa = "Gln";
                                    break;
                                case DNA.T: // CAT
                                    aa = "His";
                                    break;
                                case DNA.G: // CAG
                                    aa = "Gln";
                                    break;
                                case DNA.C: // CAC
                                    aa = "His";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.T:
                            switch (codon.Tp)
                            {
                                case DNA.A: // CTA
                                    aa = "Leu";
                                    break;
                                case DNA.T: // CTT
                                    aa = "Leu";
                                    break;
                                case DNA.G: // CTG
                                    aa = "Leu";
                                    break;
                                case DNA.C: // CTC
                                    aa = "Leu";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.G:
                            switch (codon.Tp)
                            {
                                case DNA.A: // CGA
                                    aa = "Arg";
                                    break;
                                case DNA.T: // CGT
                                    aa = "Arg";
                                    break;
                                case DNA.G: // CGG
                                    aa = "Arg";
                                    break;
                                case DNA.C: // CGC
                                    aa = "Arg";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case DNA.C:
                            switch (codon.Tp)
                            {
                                case DNA.A: // CCA
                                    aa = "Pro";
                                    break;
                                case DNA.T: // CCT
                                    aa = "Pro";
                                    break;
                                case DNA.G: // CCG
                                    aa = "Pro";
                                    break;
                                case DNA.C: // CCC
                                    aa = "Pro";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        default:
                            throw new System.NotImplementedException();
                    }//second level
                    break;
                default:
                    throw new System.NotImplementedException();
            }//first level
            return aa;
        }
    }

    public struct RnaCodon
    {
        RNA _fp;
        RNA _sp;
        RNA _tp;

        public RnaCodon(RNA _fp, RNA _sp, RNA _tp)
        {
            this._fp = _fp;
            this._sp = _sp;
            this._tp = _tp;
        }

        public RNA Fp
        {
            get
            {
                return _fp;
            }

            set
            {
                _fp = value;
            }
        }

        public RNA Sp
        {
            get
            {
                return _sp;
            }

            set
            {
                _sp = value;
            }
        }

        public RNA Tp
        {
            get
            {
                return _tp;
            }

            set
            {
                _tp = value;
            }
        }

        public static string getCodonSeqStr(List<RnaCodon> codons)
        {
            string codSeq = "";
            foreach (RnaCodon codon in codons)
            {
                if (codons.IndexOf(codon) == codons.Count - 1)
                {
                    codSeq += RnaCodon.getCodonStr(codon);
                }
                else
                {
                    codSeq += RnaCodon.getCodonStr(codon) + "-";
                }
            }
            return codSeq;
        }

        //TODO: Change all NotImplementedExceptions
        public static string getCodonStr(RnaCodon codon)
        {
            string aa = "";
            switch (codon.Fp)
            {
                case RNA.A:
                    switch (codon.Sp)
                    {
                        case RNA.A:
                            switch (codon.Tp)
                            {
                                case RNA.A: // AAA
                                    aa = "Lys";
                                    break;
                                case RNA.U: // AAU
                                    aa = "Asn";
                                    break;
                                case RNA.G: // AAG
                                    aa = "Lys";
                                    break;
                                case RNA.C: // AAC
                                    aa = "Asn";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.U:
                            switch (codon.Tp)
                            {
                                case RNA.A: // AUA
                                    aa = "Ile";
                                    break;
                                case RNA.U: // AUU
                                    aa = "Ile";
                                    break;
                                case RNA.G: // AUG
                                    aa = "Met";
                                    break;
                                case RNA.C: // AUC
                                    aa = "Ile";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.G:
                            switch (codon.Tp)
                            {
                                case RNA.A: // AGA
                                    aa = "Arg";
                                    break;
                                case RNA.U: // AGU
                                    aa = "Ser";
                                    break;
                                case RNA.G: // AGG
                                    aa = "Arg";
                                    break;
                                case RNA.C: // AGC
                                    aa = "Ser";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.C:
                            switch (codon.Tp)
                            {
                                case RNA.A: // ACA
                                    aa = "Thr";
                                    break;
                                case RNA.U: // ACU
                                    aa = "Thr";
                                    break;
                                case RNA.G: // ACG
                                    aa = "Thr";
                                    break;
                                case RNA.C: // ACC
                                    aa = "Thr";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        default:
                            throw new System.NotImplementedException();
                    }//second level
                    break;
                case RNA.U:
                    switch (codon.Sp)
                    {
                        case RNA.A:
                            switch (codon.Tp)
                            {
                                case RNA.A: // UAA
                                    aa = "STOP";
                                    break;
                                case RNA.U: // UAU
                                    aa = "Tyr";
                                    break;
                                case RNA.G: // UAG
                                    aa = "STOP";
                                    break;
                                case RNA.C: // UAC
                                    aa = "Tyr";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.U:
                            switch (codon.Tp)
                            {
                                case RNA.A: // UUA
                                    aa = "Leu";
                                    break;
                                case RNA.U: // UUU
                                    aa = "Phe";
                                    break;
                                case RNA.G: // UUG
                                    aa = "Leu";
                                    break;
                                case RNA.C: // UUC
                                    aa = "Phe";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.G:
                            switch (codon.Tp)
                            {
                                case RNA.A: // UGA
                                    aa = "STOP";
                                    break;
                                case RNA.U: // UGU
                                    aa = "Cys";
                                    break;
                                case RNA.G: // UGG
                                    aa = "Trp";
                                    break;
                                case RNA.C: // UGC
                                    aa = "Cys";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.C:
                            switch (codon.Tp)
                            {
                                case RNA.A: // UCA
                                    aa = "Ser";
                                    break;
                                case RNA.U: // UCU
                                    aa = "Ser";
                                    break;
                                case RNA.G: // UCG
                                    aa = "Ser";
                                    break;
                                case RNA.C: // UCC
                                    aa = "Ser";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        default:
                            throw new System.NotImplementedException();
                    }//second level
                    break;
                case RNA.G:
                    switch (codon.Sp)
                    {
                        case RNA.A:
                            switch (codon.Tp)
                            {
                                case RNA.A: // GAA
                                    aa = "Glu";
                                    break;
                                case RNA.U: // GAU
                                    aa = "Asp";
                                    break;
                                case RNA.G: // GAG
                                    aa = "Glu";
                                    break;
                                case RNA.C: // GAC
                                    aa = "Asp";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.U:
                            switch (codon.Tp)
                            {
                                case RNA.A: // GUA
                                    aa = "Val";
                                    break;
                                case RNA.U: // GUU
                                    aa = "Val";
                                    break;
                                case RNA.G: // GUG
                                    aa = "Val";
                                    break;
                                case RNA.C: // GUC
                                    aa = "Val";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.G:
                            switch (codon.Tp)
                            {
                                case RNA.A: // GGA
                                    aa = "Gly";
                                    break;
                                case RNA.U: // GGU
                                    aa = "Gly";
                                    break;
                                case RNA.G: // GGG
                                    aa = "Gly";
                                    break;
                                case RNA.C: // GGC
                                    aa = "Gly";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.C:
                            switch (codon.Tp)
                            {
                                case RNA.A: // GCA
                                    aa = "Ala";
                                    break;
                                case RNA.U: // GCU
                                    aa = "Ala";
                                    break;
                                case RNA.G: // GCG
                                    aa = "Ala";
                                    break;
                                case RNA.C: // GCC
                                    aa = "Ala";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        default:
                            throw new System.NotImplementedException();
                    }//second level
                    break;
                case RNA.C:
                    switch (codon.Sp)
                    {
                        case RNA.A:
                            switch (codon.Tp)
                            {
                                case RNA.A: // CAA
                                    aa = "Gln";
                                    break;
                                case RNA.U: // CAU
                                    aa = "His";
                                    break;
                                case RNA.G: // CAG
                                    aa = "Gln";
                                    break;
                                case RNA.C: // CAC
                                    aa = "His";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.U:
                            switch (codon.Tp)
                            {
                                case RNA.A: // CUA
                                    aa = "Leu";
                                    break;
                                case RNA.U: // CUU
                                    aa = "Leu";
                                    break;
                                case RNA.G: // CUG
                                    aa = "Leu";
                                    break;
                                case RNA.C: // CUC
                                    aa = "Leu";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.G:
                            switch (codon.Tp)
                            {
                                case RNA.A: // CGA
                                    aa = "Arg";
                                    break;
                                case RNA.U: // CGU
                                    aa = "Arg";
                                    break;
                                case RNA.G: // CGG
                                    aa = "Arg";
                                    break;
                                case RNA.C: // CGC
                                    aa = "Arg";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        case RNA.C:
                            switch (codon.Tp)
                            {
                                case RNA.A: // CCA
                                    aa = "Pro";
                                    break;
                                case RNA.U: // CCU
                                    aa = "Pro";
                                    break;
                                case RNA.G: // CCG
                                    aa = "Pro";
                                    break;
                                case RNA.C: // CCC
                                    aa = "Pro";
                                    break;
                                default:
                                    throw new System.NotImplementedException();
                            }//third level
                            break;
                        default:
                            throw new System.NotImplementedException();
                    }//second level
                    break;
                default:
                    throw new System.NotImplementedException();
            }//first level
            return aa;
        }
    }
}