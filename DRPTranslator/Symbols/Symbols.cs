namespace DRPTranslator.Symbols
{
    /// <summary>
    /// Representation of DNA Bases
    /// A: Adenine
    /// C: Citosine
    /// T: Thymine
    /// G: Guanine
    /// </summary>
    public enum DNA
    {
        A, C, T, G
    }

    /// <summary>
    /// Representation of RNA Bases
    /// A: Adenine
    /// C: Citosine
    /// U: Uracil
    /// G: Guanine
    /// </summary>
    public enum RNA
    {
        A, C, U, G
    }

    /// <summary>
    /// Representation of the Aminoacids that can be synthetized from DNA or RNA (often refered as AA)
    /// non-polar, aliphatic residues
    /// Name            Abbr. Symbol    Codons
    /// Glycine         Gly     G       GGU GGC GGA GGG
    /// Alanine         Ala     A       GCU GCC GCA GCG
    /// Valine          Val     V       GUU GUC GUA GUG
    /// Leucine         Leu     L       UUA UUG CUU CUC CUA CUG
    /// Isoleucine      Ile     I       AUU AUC AUA
    /// Proline         Pro     P       CCU CCC CCA CCG
    /// 
    /// aromatic residues
    /// Phenylalanine   Phe     F       UUU UUC
    /// Tyrosine        Tyr     Y       UAU UAC
    /// Tryptophan      Trp     W       UGG
    /// 
    /// polar, non-charged residues
    /// Serine          Ser     S       UCU UCC UCA UCG AGU AGC
    /// Threonine       Thr     T       ACU ACC ACA ACG
    /// Cysteine        Cys     C       UGU UGC
    /// Methionine      Met     M       AUG
    /// Asparagine      Asn     N       AAU AAC
    /// Glutamine       Gln     Q       CAA CAG
    /// 
    /// positively charged residues
    /// Lysine          Lys     K       AAA AAG
    /// Arginine        Arg     R       CGU CGC CGA CGG AGA AGG
    /// Histidine       His     H       CAU CAC
    /// 
    /// negatively charged residues
    /// Aspartate       Asp     D       GAU GAC
    /// Glutamate       Glu     E       GAA GAG
    ///
    /// </summary>
    public enum AA
    {
        ALA, ARG, ASN, ASP,
        CYS, GLN, GLU, GLY,
        HIS, LEU, LYS, MET,
        PHE, PRO, SER, THR,
        TRP, TYR, VAL, ILE,
        STOP
    }
}
