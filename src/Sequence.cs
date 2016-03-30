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

        RnaCodon[] _rnaCodons;
        DnaCodon[] _dnaCodons;

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

        public string Seq
        {
            get
            {
                return _seq;
            }

            set
            {
                _seq = value;
            }
        }

        public bool DnaSeq
        {
            get
            {
                return _dnaSeq;
            }

            set
            {
                _dnaSeq = value;
            }
        }

        public string CompSeq
        {
            get
            {
                return _compSeq;
            }
        }

        public string AaSeq
        {
            get
            {
                return _aaSeq;
            }
        }

        public RnaCodon[] RnaCodons
        {
            get
            {
                return _rnaCodons;
            }

            set
            {
                _rnaCodons = value;
            }
        }

        public DnaCodon[] DnaCodons
        {
            get
            {
                return _dnaCodons;
            }

            set
            {
                _dnaCodons = value;
            }
        }

        public Dictionary<int, string> Starts
        {
            get
            {
                return _starts;
            }

        }

        public Dictionary<int, string> Stops
        {
            get
            {
                return _stops;
            }
        }

        internal DnaTranslator DnaTranslator
        {
            get
            {
                return _dnaTranslator;
            }
        }

        internal RnaTranslator RnaTranslator
        {
            get
            {
                return _rnaTranslator;
            }
        }

    }

}
