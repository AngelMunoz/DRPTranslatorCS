# Hello Everyone!

This is **DRPTRanslatorCS** a (rewritten from the ground up) port of [DRPTRanslator]() npm package. 

This library is useful for those that want to do some entry-level genetics. You can Translate, Transcript
DNA or RNA sequences, also you can get the Aminoacid sequences based on the provided sequence.

It is also helpful to get some information from the sequences themselves like Starts and Stop Codons, individual codons
so If you know someone who needs a little help with their Genetic sequence this might suit you.

However if you are an advanced geneticist looking for complex computations I'm afraid that this will not help you at all.
if you want to help me to get more features included in the library go ahead and raise an [Issue]() :)
I'm glad to help in any way possible, also if you find any bugs or unexpected behaviors please fill a new issue.

## Installation
In [Visual Studio]() nuget package manager type
```powershell
Install-Package DRPTranslatorCS
```
or
1. Right click in your solution
2. Select Manage NuGet Packages...
3. In the searchbox type `DRPTranslatorCS`
4. Select `DRPTranslatorCS` and click Install
 

There you go


## Usage
### Parsing individual characters
```csharp
using System;
using DRPTranslatorCS;
namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GeneticMatcher.ParseDna('C'));
            // Prints out a Symbols.DNA.C.ToString(); enum
        }
    }
}
```
    
    
### Translating or Transcribing DNA sequences
```csharp
using System;
using DRPTranslatorCS.Translators;
namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            DnaTranslator dnaTrans = new DnaTranslator();
            string transDna = dnaTrans.TransDnaRna("ATC");
            string transcriptedDna = dnaTrans.TransDnaAa("TAC");

            Console.WriteLine(transDna);
            // UAG
            Console.WriteLine(transcriptedDna);
            // MET
            Console.ReadKey();

        }
    }
}
```

If you need to do more stuff individually, check out `Codon` class
and `GeneticMatcher` class, both offer some useful methods like Parsing aminoacids or Codons
hat could help on more specialized tasks.

TODOS:

* [ ] Upload API Docs Website.
* [ ] Write Demos.


If you have suggestions or found a bug please let me know in the issues :)
