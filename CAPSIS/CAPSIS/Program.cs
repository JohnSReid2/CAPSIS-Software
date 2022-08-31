using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Annotations;
using OxyPlot.Series;
using OxyPlot.Utilities;


class Software
{
    
    public static string cipherText = "start";

    //General Analysis Data
    public static int characterCount;
    public static int uniqueCharacters;



    public static bool isEnglishLetter(char c) => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
    public static int indexOfLetter(char c) => char.IsUpper(c) ? 65 : 97;

    static public void Main()
    {
        Console.WriteLine(System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription);
        Console.WriteLine("Main Method initiated. Enter Cipher Text:");
        //Recomended inputs: pi.txt, big.txt, bible.txt, enwik8.txt/enwik9.txt (likely to crash), random.txt, world192.txt
        //aaa.txt, alphabet.txt
        //string input = File.ReadAllText(@"C:\Users\johns\Documents\pi.txt"); //Take input from console
        string input = Console.ReadLine();

        if (input == null) 
        {cipherText = "null";}       
        else {cipherText = input;}
        //     ====== Reformatting ======
        Console.WriteLine("Reformatting cipher text...");
        cipherText = String.Concat(cipherText.Where(c => !Char.IsWhiteSpace(c))).ToUpper();
        //Console.WriteLine(cipherText);


        //     ====== GENERAL ANALYSIS ======
        GeneralAnalysis general = new GeneralAnalysis(cipherText);

        characterCount = general.CharacterCount();
        uniqueCharacters = general.UniqueCharacters();

        OutputAnalysis();

        //     ====== Frequency Analysis ======
        FrequencyAnalysis freqAnalysis = new FrequencyAnalysis(cipherText);
        int[,] freq = freqAnalysis.CharacterFreq();
        double[,] prob = freqAnalysis.LetterProbability();
        Console.WriteLine("=== Frequency Analysis ===");
        for (int i = 0; i < freq.GetLength(0); i++)
        {
            Console.WriteLine("Character: " + Convert.ToChar(freq[i , 0]) + "  Frequency: " + freq[i, 1]);
        }
        Console.WriteLine("=== Letter Distrubution ===");
        for (int i = 0; i < prob.GetLength(0); i++)
        {
            Console.WriteLine("Character: " + Convert.ToChar(Convert.ToInt32(prob[i, 0])) + "  Percentage: " + (prob[i, 1] * 100) + "%");
        }
        
        //     ====== Index of Coincidence ======
        IndexOfCoincedence indexOfCoincedence = new IndexOfCoincedence(cipherText);
        Console.WriteLine("Index of Coincedence " + indexOfCoincedence.Index());

        //     ====== Entropy Measure ======
        ShannonIndex shannonIndex = new ShannonIndex(cipherText);
        Console.WriteLine("Shannon index " + shannonIndex.Index());


        //     ====== Bigrams ======
        Bigrams.SlidingWindow slidingWindowBigram = new Bigrams.SlidingWindow(cipherText);
        Bigrams.Blocks blocksBigram = new Bigrams.Blocks(cipherText);


        

        int bigramTotalBlocks = blocksBigram.BigramTotal();
        int uniqBigramTotalBlocks = blocksBigram.UniqBigramTotal();
        int bigramTotalWindow = slidingWindowBigram.BigramTotal();
        int uniqBigramTotalWindow = slidingWindowBigram.UniqBigramTotal();

        Bigrams.BigramCount[] bigramCountsBlocks = blocksBigram.frequency();
        Bigrams.BigramCount[] bigramCountsWindow = slidingWindowBigram.frequency();

        Console.WriteLine("BLOCKS MODE");
        foreach (var block in bigramCountsBlocks)
        {
            Console.WriteLine(block.bigram + "      " + block.count);
        }

        Console.WriteLine("WINDOW MODE");
        foreach (var block in bigramCountsWindow)
        {
            Console.WriteLine(block.bigram + "      " + block.count);
        }

        Console.WriteLine("Identical?  " + blocksBigram.IdenticalBigram());


        //     ====== Trigrams ======
        Trigrams.SlidingWindow slidingWindowTrigram = new Trigrams.SlidingWindow(cipherText);
        Trigrams.Blocks blocksTrigram = new Trigrams.Blocks(cipherText);




        int trigramTotalBlocks = blocksBigram.BigramTotal();
        int uniqTrigramTotalBlocks = blocksBigram.UniqBigramTotal();
        int trigramTotalWindow = slidingWindowBigram.BigramTotal();
        int uniqTrigramTotalWindow = slidingWindowBigram.UniqBigramTotal();

        Trigrams.TrigramCount[] trigramCountsBlocks = blocksTrigram.frequency();
        Trigrams.TrigramCount[] trigramCountsWindow = slidingWindowTrigram.frequency();

        Console.WriteLine("BLOCKS MODE");
        foreach (var block in trigramCountsBlocks)
        {
            Console.WriteLine(block.trigram + "      " + block.count);
        }

        Console.WriteLine("WINDOW MODE");
        foreach (var block in trigramCountsWindow)
        {
            Console.WriteLine(block.trigram + "      " + block.count);
        }


        Console.WriteLine("Identical bigrams blocks?  " + blocksBigram.IdenticalBigram());
        Console.WriteLine("Identical bigrams window?  " + slidingWindowBigram.IdenticalBigram());
        Console.WriteLine("Identical trigrams blocks?  " + blocksTrigram.IdenticalTrigram());
        Console.WriteLine("Identical trigrams window?  " + slidingWindowTrigram.IdenticalTrigram());

        //     ===== Kasiski ======
        Console.WriteLine("Kasiski analysis");

        Kasiski kasiski = new Kasiski();
        
        List<int> kas = kasiski.KasiskiExamination(cipherText);
        foreach (int k in kas)
        {
            Console.WriteLine(k);
        }
    }

    static public void OutputAnalysis()
    {
        Console.WriteLine("--- General Analysis ---");
        Console.WriteLine("Character Count = " + characterCount);
        Console.WriteLine("Unique Character Count = " + uniqueCharacters);
        //Graph();
    }

    static public void Graph()
    {
        FrequencyAnalysis freqAnalysis = new FrequencyAnalysis(cipherText);
        int[,] freq = freqAnalysis.CharacterFreq();
        double[,] prob = freqAnalysis.LetterProbability();
        var model = new PlotModel { Title = "Letter Frequency" };
        model.Axes.Add(new CategoryAxis());
        var series = new BarSeries();
        model.Series.Add(series);

        double[] vals = new double[26];

        for (int i = 0; i < 26; i++)
        {
            vals[i] = prob[i,1];
        }

        foreach (double f in vals)
        {
            series.Items.Add(new BarItem { Value = f * 100 } );
        }

        using (var stream = File.Create(@"C:\graph.pdf"))
        {
            var pdfExporter = new PdfExporter { Width = 600, Height = 400 };
            pdfExporter.Export(model, stream);
        }

    }
    
}