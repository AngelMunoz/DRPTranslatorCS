using DRPTranslatorCS.Symbols;
using DRPTranslatorCS.Translators;
using System.Collections.Generic;

namespace DRPTranslatorCS
{
    public class Sequence
    {
        string _seq;
        bool _dnaSeq;
        string _compSeq;
        string _aaSeq;

        List<RnaCodon> _rnaCodons;
        List<DnaCodon> _dnaCodons;

        Dictionary<int, string> _starts;
        Dictionary<int, string> _stops;

        DnaTranslator _dnaTranslator;
        RnaTranslator _rnaTranslator;

        public Sequence(string _seq, bool _dnaSeq)
        {
            this._seq = _seq;
            this._dnaSeq = _dnaSeq;
            if(!_dnaSeq)
            {
                this._rnaTranslator = new RnaTranslator();
            }
            else
            {
                this._dnaTranslator = new DnaTranslator();
            }
        }

    }

}
